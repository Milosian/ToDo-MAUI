using System.Collections.ObjectModel;

namespace ToDo
{
    public class TaskViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem {Id = 1, TaskContent = "Zrobić zakupy na weekend", TaskDateToDo = new DateTime(2025, 5, 10), Status = "wykonane"},
                new TaskItem {Id = 2, TaskContent = "Napisać wypracowanie z polskiego", TaskDateToDo = new DateTime(2025, 5, 13), Status = "wykonane"},
                new TaskItem {Id = 3, TaskContent = "Przeczytać artykuł naukowy", TaskDateToDo = new DateTime(2025, 5, 8), Status = "niewykonane"},
            };
            TaskViewModel taskViewModel = new TaskViewModel();
            Preferences.Set("Id", Convert.ToInt32(taskViewModel.Tasks[0]));
        }
    }
}
