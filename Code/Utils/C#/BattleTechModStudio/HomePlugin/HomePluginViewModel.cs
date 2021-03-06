﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using HomePlugin.Annotations;

namespace HomePlugin
{
    public class HomePluginViewModel : INotifyPropertyChanged
    {
        public HomePluginViewModel(HomePluginModel homePluginModel)
        {
            HomePluginModel = homePluginModel;
            HomePluginModel.PropertyChanged += (sender, args) => this.OnPropertyChanged(args.PropertyName);
        }

        public HomePluginSettings HomePluginSettings
        {
            get => this.HomePluginModel.Settings; 
            set => this.HomePluginModel.Settings = value;
        }

        public HomePluginModel HomePluginModel { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}