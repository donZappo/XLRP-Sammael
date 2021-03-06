﻿using System;
using System.Collections.Generic;

namespace UI.Core.Interfaces.Data
{
    public interface IPlugin
    {
        string Description { get; }

        List<IPluginControl> Modules { get; }

        string Name { get; }

        Type PageType { get; }
    }
}