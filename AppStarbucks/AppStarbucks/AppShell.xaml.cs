using AppStarbucks.ViewModels;
using AppStarbucks.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppStarbucks
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DrinksPage), typeof(DrinksPage));
            Routing.RegisterRoute(nameof(BranchOfficePage), typeof(BranchOfficePage));

        }

        

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
