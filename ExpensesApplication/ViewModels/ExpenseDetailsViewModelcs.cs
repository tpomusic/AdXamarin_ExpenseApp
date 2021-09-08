using ExpensesApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpensesApplication.ViewModels
{
    public class ExpenseDetailsViewModel : INotifyPropertyChanged
    {
        private Expense expense;
        public Expense Expense 
        { get { return expense; } 
            set
            {
                expense = value;
                OnPropertyChanged("Expense");
            } 
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
