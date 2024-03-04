using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {

                con.CreateTable<Task>();
                var listOfTasks = con.Table<Task>().ToList();             
                taskListView.ItemsSource = listOfTasks;


            }
        }

    }
}