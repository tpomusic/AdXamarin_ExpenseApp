using ExpensesApplication.Models;
using ExpensesApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApplication.ViewModels
{
    public class ExpenseViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public Command AddExpenseCommand { get; set; }


        public ExpenseViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
            GetExpenses();
        }

        public void GetExpenses()
        {
            List<Expense> expenses = Expense.GetExpenses();
            Expenses.Clear();
            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());

        }


    }
}
