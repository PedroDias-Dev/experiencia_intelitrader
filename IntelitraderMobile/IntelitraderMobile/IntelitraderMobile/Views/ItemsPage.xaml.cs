using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using IntelitraderMobile.ViewModels;
using IntelitraderMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntelitraderMobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();

            //_userViewModel = Startup.Resolve<ItemsViewModel>();
            //BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel?.ExecuteLoadItemsCommand();
            _viewModel.OnAppearing();       
        }
    }
}