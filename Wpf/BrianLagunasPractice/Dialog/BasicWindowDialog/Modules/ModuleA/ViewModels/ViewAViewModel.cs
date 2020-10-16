﻿using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private DelegateCommand _showDialogCommand;
        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(ShowDialog));
        //버튼을 만들기 전에 동작되는 지 확인바람



        private void ShowDialog()
        {
            var p = new DialogParameters();
            p.Add("message", "Hello My name is Kim");


            _dialogService.ShowDialog("MessageDialog", p, r =>
            {
                //ex. 2
                if (IsNullOrParameter(r.Parameters))
                {
                    MessageReceived = r.Parameters.GetValue<string>("submessage");
                }
                else
                {
                    MessageReceived = "No";
                }    


                //ex. 1
                //if (r.Result == ButtonResult.OK)
                //{
                //    Message = "전달 받음 감사요";
                //}
                //else if (r.Result == ButtonResult.Cancel)
                //{
                //    Message = "취소 에바";
                //}
            });
        }

        private bool IsNullOrParameter(IDialogParameters parameters)
        {
            //ex.3
            return parameters.GetValue<string>("submessage") != string.Empty;
            //ex.2
           // return parameters.GetValue<string>("submessage") != null;
            #region ex.1
            //if (parameters.GetValue<string>("submessage") is null)
            //    return false;
            //return true;
            #endregion 
        }

        #region TitleName Property

        private string _messageReceived = "Hello";
        public string MessageReceived
        {
            get { return _messageReceived; }
            set { SetProperty(ref _messageReceived, value); }
        }
        public string ButtonTitle { get => "Show Dialog"; }

        #endregion

        #region IDialogService
        private IDialogService _dialogService;
        public ViewAViewModel(IDialogService dialogService)
        {
            this._dialogService = dialogService;
        }
        #endregion

    }
}
