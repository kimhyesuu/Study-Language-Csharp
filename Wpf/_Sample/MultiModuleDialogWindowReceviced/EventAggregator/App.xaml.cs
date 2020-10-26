﻿using System.Windows;
using EventAggregator.Core;
using EventAggregator.Dialog;
using EventAggregator.Views;
using ModuleA.Models.Module;
using ModuleB.Models.Module;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

namespace EventAggregator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IHsManager<string>, HsManager<string>>();
            containerRegistry.RegisterDialog<MyDialog, MyDialogViewModel>();
            containerRegistry.RegisterDialogWindow<MyDialogWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ModuleAModule>();
            moduleCatalog.AddModule<ModuleBModule>();
        }
    }
}
