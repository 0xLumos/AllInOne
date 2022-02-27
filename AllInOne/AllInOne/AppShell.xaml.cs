﻿using AllInOne.ViewModels;
using AllInOne.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AllInOne
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            CurrentItem.CurrentItem = login_page;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
           
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
