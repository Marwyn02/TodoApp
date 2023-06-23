using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Formats.Tar;
using Microsoft.Maui.Controls;

namespace TodoApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

        public MainPage()
        {
            InitializeComponent();
            TaskListView.ItemsSource = tasks;
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            string taskName = TaskEntry.Text;
            if (!string.IsNullOrWhiteSpace(taskName))
            {
                tasks.Add(new TaskItem { TaskName = taskName });
                TaskEntry.Text = string.Empty;
            }
        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var taskItem = (TaskItem)button.CommandParameter;
            tasks.Remove(taskItem);
        }
    }

    public class TaskItem
    {
        public string TaskName { get; set; }
    }
}


