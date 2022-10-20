﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Rg.Plugins.Popup.Services;

//https://github.com/rotorgames/Rg.Plugins.Popup/wiki/Getting-started

namespace PopupApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ShowPopupDemo());
        }
    }
}
