using ExpensesApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApplication.ViewModels
{
    public class NewExpenseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Categories { get; set; }


        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }

        private string expenseName;
        public string ExpenseName
        {
            get { return expenseName; }
            set
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        private float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmmount");
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public Command SaveExpenseCommand { get; set; }


        public NewExpenseViewModel()
        {
            Categories = new ObservableCollection<string>();
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            ExpenseDate = DateTime.Now;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void InsertExpense()
        {
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            int success = Expense.InsertExpense(expense);
            if (success > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("ERROR", "Insert FAILED! Try Again.", "OK");
            }
        }

        public void GetExpenseStatuses()
        {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random2",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random3",
                Status = false
            });


        }
    }

    public class ExpenseStatus
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
