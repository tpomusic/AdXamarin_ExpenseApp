﻿using ExpensesApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApplication
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath)
        {
            DatabasePath = databasePath;
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

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
