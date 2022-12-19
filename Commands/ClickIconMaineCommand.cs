﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Aspose;
using Aspose.Imaging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace Crypto
{
    public class ClickIconMaineCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private MainViewModel viewModel { get; set; }
        public ClickIconMaineCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            viewModel.Exchange = AdapterDataAPi.Get_all_exchangerate(viewModel.SetIconsCurrencies.name);
            var tmp = viewModel.MainItem.setCurrencyAndIcons.Find(i => i.name == viewModel.SetIconsCurrencies.name).iconUrl;
            using (Image im = Image.Load(Resources.ResourceManager.GetObject(tmp));
            {
                
                im.Resize(200,200);
                viewModel.Image = im;
            }
            //viewModel.Url = viewModel.MainItem.setCurrencyAndIcons.Find(i => i.name == viewModel.SetIconsCurrencies.name).iconUrl;

        }
    }
}
