namespace ToDo
{
    public partial class MainPage : ContentPage
    {
        private TaskViewModel _taskViewModel;
        private TaskItem _taskToEdit;
        bool taskStatus = false;
        string statusName = "";
        public MainPage()
        {
            InitializeComponent();
            _taskViewModel = new TaskViewModel();
            BindingContext = _taskViewModel;
        }
        private void AddTaskBtn_Clicked(object sender, EventArgs e)
        {
            _taskViewModel.Tasks.Add(new TaskItem { Id = _taskViewModel.Tasks.Count + 1, TaskContent = TaskEntry.Text, TaskDateToDo = TaskDatePicker.Date, Status = statusName });

            Preferences.Set("Id", _taskViewModel.Tasks.Count + 1);
            Preferences.Set("Task content", TaskEntry.Text);
            Preferences.Set("Task Date", TaskDatePicker.Date);
            Preferences.Set("Status", statusName);

            TaskEntry.Text = string.Empty;
            TaskDatePicker.Date = DateTime.Now;
        }

        private void EditTask_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var taskToEdit = button.CommandParameter as TaskItem;

            if (taskToEdit != null)
            {
                TaskEntry.Text = taskToEdit.TaskContent;
                TaskDatePicker.Date = taskToEdit.TaskDateToDo;
                if (taskToEdit.Status == "wykonane") { DoneCheck.IsChecked = true; statusName = "wykonane"; }
                else { DoneCheck.IsChecked = false; statusName = "niewykonane"; }
                _taskToEdit = taskToEdit;
                SaveChangesBtn.IsVisible = true;
                AddTaskBtn.IsEnabled = false;
            }

        }

        private void DoneCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            taskStatus = !taskStatus;
            if (taskStatus == true)
            {
                statusName = "wykonane";
            }
            else
            {
                statusName = "niewykonane";
            }
        }

        private void RemoveTask_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var taskToRemove = button.CommandParameter as TaskItem;

            if (taskToRemove != null)
            {
                _taskViewModel.Tasks.Remove(taskToRemove);
            }
        }

        private void SaveChangesBtn_Clicked(object sender, EventArgs e)
        {
            if (_taskToEdit != null)
            {
                _taskToEdit.TaskContent = TaskEntry.Text;
                _taskToEdit.TaskDateToDo = TaskDatePicker.Date;
                _taskToEdit.Status = statusName;

                TaskEntry.Text = string.Empty;
                TaskDatePicker.Date = DateTime.Now;
                SaveChangesBtn.IsVisible = false;
                AddTaskBtn.IsEnabled = true;
            }
        }
    }
}
