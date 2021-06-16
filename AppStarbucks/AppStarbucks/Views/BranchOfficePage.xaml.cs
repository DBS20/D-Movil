using AppStarbucks.Models;
using AppStarbucks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarbucks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BranchOfficePage : ContentPage
    {
        public BranchOfficePage()
        {
            InitializeComponent();

            BindingContext = new BranchOfficeViewModel();
        }

        /*public BranchOfficePage(BranchOfficeModel boSelected)
        {
            InitializeComponent();

            BindingContext = new BranchOfficeViewModel(boSelected);
        }*/
    }
}