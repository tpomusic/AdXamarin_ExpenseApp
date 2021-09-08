using ExpensesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        private ExpenseViewModel ViewModel;

        public ExpensesPage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpenseViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenses();
        }
    }
}