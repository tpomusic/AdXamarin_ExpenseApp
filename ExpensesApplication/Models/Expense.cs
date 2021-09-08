﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpensesApplication.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Amount { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Expense()
        {

        }

        public static int InsertExpense(Expense expense)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                CreateTableResult createResult = conn.CreateTable<Expense>();
                return conn.Insert(expense);
            }
        }

        public static List<Expense> GetExpenses()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                CreateTableResult createResult = conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList();
            }
        }

        public static List<Expense> GetExpenses(string category)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                CreateTableResult createResult = conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Category == category).ToList();
            }
        }

        public static float GetTotalExpensesAmount()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                CreateTableResult createResult = conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList().Sum(e => e.Amount);
            }
        }
    }
}
