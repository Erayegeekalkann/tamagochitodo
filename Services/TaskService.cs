using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TamagotchiTodo.Models;

namespace TamagotchiTodo.Services
{
    public class TaskService
    {
        private readonly DataService _dataService;
        private List<TodoTask> _tasks;

        public ObservableCollection<TodoTask> ActiveTasks { get; private set; }
        public ObservableCollection<TodoTask> CompletedTasks { get; private set; }

        public event EventHandler<TodoTask>? TaskCompleted;

        public TaskService(DataService dataService)
        {
            _dataService = dataService;
            _tasks = new List<TodoTask>();
            ActiveTasks = new ObservableCollection<TodoTask>();
            CompletedTasks = new ObservableCollection<TodoTask>();
        }

        public void LoadTasks()
        {
            _tasks = _dataService.LoadTasks();
            RefreshCollections();
        }

        public void SaveTasks()
        {
            _dataService.SaveTasks(_tasks);
        }

        public void AddTask(TodoTask task)
        {
            _tasks.Add(task);
            ActiveTasks.Add(task);
            SaveTasks();
        }

        public void CompleteTask(TodoTask task)
        {
            task.IsCompleted = true;
            task.CompletedAt = DateTime.Now;

            ActiveTasks.Remove(task);
            CompletedTasks.Insert(0, task);

            TaskCompleted?.Invoke(this, task);
            SaveTasks();
        }

        public void DeleteTask(TodoTask task)
        {
            _tasks.Remove(task);
            ActiveTasks.Remove(task);
            CompletedTasks.Remove(task);
            SaveTasks();
        }

        public void UncompleteTask(TodoTask task)
        {
            task.IsCompleted = false;
            task.CompletedAt = null;

            CompletedTasks.Remove(task);
            ActiveTasks.Add(task);
            SaveTasks();
        }

        private void RefreshCollections()
        {
            ActiveTasks.Clear();
            CompletedTasks.Clear();

            var activeTasks = _tasks.Where(t => !t.IsCompleted).OrderByDescending(t => t.CreatedAt);
            var completedTasks = _tasks.Where(t => t.IsCompleted).OrderByDescending(t => t.CompletedAt);

            foreach (var task in activeTasks)
            {
                ActiveTasks.Add(task);
            }

            foreach (var task in completedTasks)
            {
                CompletedTasks.Add(task);
            }
        }
    }
}
