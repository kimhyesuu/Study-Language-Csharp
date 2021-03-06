﻿using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Prism4Demo.ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleBNavigator.xaml
    /// </summary>
    public partial class ModuleBNavigator : UserControl, IRegionMemberLifetime
    {
        #region Constructor

        public ModuleBNavigator()
        {
            InitializeComponent();
        }

        #endregion

        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion
    }
}
