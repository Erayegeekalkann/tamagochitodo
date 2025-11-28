using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TamagotchiTodo.Models;
using TamagotchiTodo.Services;

namespace TamagotchiTodo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly TaskService _taskService;
        private readonly TimerService _timerService;
        private TamagotchiPet _pet;

        public TamagotchiPet Pet
        {
            get => _pet;
            set
            {
                _pet = value;
                OnPropertyChanged();
            }
        }

        public TaskService TaskService => _taskService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            _dataService = new DataService();
            _taskService = new TaskService(_dataService);
            _timerService = new TimerService();

            _pet = _dataService.LoadPet();
            _taskService.LoadTasks();

            _taskService.TaskCompleted += OnTaskCompleted;
            _timerService.DecayTick += OnDecayTick;
            _timerService.Start();
        }

        private void OnTaskCompleted(object? sender, TodoTask task)
        {
            // Apply stat impacts from the completed task
            foreach (var impact in task.StatImpacts)
            {
                Pet.Stats.ModifyStat(impact.Key, impact.Value);
            }

            Pet.UpdateMood();
            SavePet();
        }

        private void OnDecayTick(object? sender, EventArgs e)
        {
            Pet.Stats.DecayStats(1);
            Pet.UpdateMood();
            SavePet();
        }

        public void SavePet()
        {
            _dataService.SavePet(Pet);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
