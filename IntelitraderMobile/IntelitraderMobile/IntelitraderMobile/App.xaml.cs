﻿using IntelitraderMobile.Services;
using IntelitraderMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntelitraderMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.ConfigureServices();
            //DependencyService.Register<APIUserService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}