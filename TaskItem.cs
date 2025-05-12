using System.ComponentModel;

namespace ToDo
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string _taskContent;
        private DateTime _taskDateToDo;
        private string _status;

        public int Id { get; set; }

        public string TaskContent
        {
            get => _taskContent;
            set
            {
                _taskContent = value;
                OnPropertyChanged(nameof(TaskContent));
            }
        }

        public DateTime TaskDateToDo
        {
            get => _taskDateToDo;
            set
            {
                _taskDateToDo = value;
                OnPropertyChanged(nameof(TaskDateToDo));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
