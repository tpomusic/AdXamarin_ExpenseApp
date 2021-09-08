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
    public partial class ExpenseDetailsPage : ContentPage
    {
        ExpenseDetailsViewModel ViewModel;
        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }
        public ExpenseDetailsPage(Models.Expense selectedExpense)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpenseDetailsViewModel;
            ViewModel.Expense = selectedExpense;

        }
    }
}