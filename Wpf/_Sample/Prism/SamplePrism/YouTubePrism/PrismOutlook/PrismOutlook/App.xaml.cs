﻿using PrismOutlook.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismOutlook.Modules.Mail;
using PrismOutlook.Modules.Contact;

namespace PrismOutlook
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App
   {
      protected override Window CreateShell()
      {
         MainWindow mw = new MainWindow();
         if (mw is null) mw.Show();
         return Container.Resolve<MainWindow>();
      }

      protected override void InitializeShell(Window shell)
      {
         base.InitializeShell(shell);
      }

      protected override void RegisterTypes(IContainerRegistry containerRegistry)
      {
        
      }

      protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
      {
         //각 모듈을 만들고 user.core를 만든 후 실시          
         moduleCatalog.AddModule<MailModule>();        
      }
   }
}
