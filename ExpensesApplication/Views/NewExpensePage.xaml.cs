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
    public partial class NewExpensePage : ContentPage
    {
        NewExpenseViewModel ViewModel;
        public NewExpensePage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as NewExpenseViewModel;
        }
        /// <summary>
        /// THIS SHOWS HOW TO create a seperate section in the table view defined in the XAML
        /// This is how to build XAML elements through C# code
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenseStatuses();
            int count = 0;
            var section = new TableSection("Statuses");
            foreach (var expenseStatus in ViewModel.ExpenseStatuses)
            {
                var cell = new SwitchCell { Text = expenseStatus.Name };
                Binding binding = new Binding();
                binding.Source = ViewModel.ExpenseStatuses[count];
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;
                cell.SetBinding(SwitchCell.OnProperty, binding);

                section.Add(cell);
                count++;
            }
            expenseTableView.Root.Add(section);
        }
    }
}