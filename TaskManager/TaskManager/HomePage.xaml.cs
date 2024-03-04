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
    public partial class HomePage : ContentPage
    {

        string priority = string.Empty;

        public HomePage()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task task = new Task();

            

            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                if (taskEntry.Text != null && selectedPriority.Text != null)
                {
                    priority = selectedPriority.Text.ToLower();

                    if (priority != "high" && priority != "medium" && priority != "low")
                    {
                        DisplayAlert("Priority does not match", "Priority should be high, medium or low only", "OK");
                    }
                    else
                    {

                        task.Description = taskEntry.Text;

                        task.Priority = selectedPriority.Text.ToLower();


                        con.CreateTable<Task>();

                        int row = con.Insert(task);

                        con.Close();

                        if (row > 0)
                        {
                            taskEntry.Text = string.Empty;
                            selectedPriority.Text = string.Empty;
                            DisplayAlert("Success", "Task Inserted", "OK");
                            Navigation.PushAsync(new TaskListPage());
                        }
                        else
                        {
                            DisplayAlert("Failed", "Cannot Save Task ", "OK");
                        }

                    }
                }
                else
                {
                    DisplayAlert("Empty Field", "Descritpion or priority caanot be empty", "OK");
                }
                }
        }
    }
}