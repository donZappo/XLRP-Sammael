﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UI.Core.Interfaces.Data;

namespace UI.Core.Services
{
    public class PluginService
    {
        public List<IPlugin> GetPlugins(string path)
        {
            var pluginList = new List<IPlugin>();
            var pluginType = typeof(IPlugin);
            var di = new DirectoryInfo(path);
            di.GetFiles("*.dll").ToList().ForEach(
                fi =>
                {
                    try
                    {
                        var assembly = Assembly.LoadFile(fi.FullName);
                        var pluginTypes = assembly.GetTypes().Where(
                            type => !type.IsInterface && !type.IsAbstract && pluginType.IsAssignableFrom(type));
                        pluginList.AddRange(pluginTypes.Select(type => (IPlugin) Activator.CreateInstance(type)));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Failed to load assembly {fi.FullName}, error = [{ex}]");
                    }
                });
            return pluginList;
        }
    }
}