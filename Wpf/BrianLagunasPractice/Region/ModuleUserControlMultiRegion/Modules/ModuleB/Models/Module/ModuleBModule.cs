﻿using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB.Models.Module
{
    public class ModuleBModule : IModule
    {
        private IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("RightRegion", typeof(MessageList));
            _regionManager.RegisterViewWithRegion("TempRegion", typeof(ViewA));
            _regionManager.RegisterViewWithRegion("Temp2Region", typeof(ViewB));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
