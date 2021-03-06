﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowDialogCustom.Dialogs
{
    public class ViewCDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand _closeDialogCommand;

        public DelegateCommand CloseDialogCommand =>
        _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand(ExcuteDialogCommand));

        private void ExcuteDialogCommand()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public ViewCDialogViewModel()
        {

        }

        public string Title =>
            "ViewCDialog";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
