using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TamagotchiTodo.Models
{
    public class TamagotchiPet : INotifyPropertyChanged
    {
        private string _name = "Tasker";
        private string _mood = "Happy";
        private DateTime _lastUpdated;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Mood
        {
            get => _mood;
            private set
            {
                _mood = value;
                OnPropertyChanged();
            }
        }

        public TamagotchiStats Stats { get; set; }
        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public TamagotchiPet()
        {
            Stats = new TamagotchiStats();
            LastUpdated = DateTime.Now;
            UpdateMood();
        }

        public void UpdateMood()
        {
            var happiness = Stats.GetStat("Happiness");
            var health = Stats.GetStat("Health");

            if (health < 20)
            {
                Mood = "Critical";
            }
            else if (happiness > 80 && health > 70)
            {
                Mood = "Ecstatic";
            }
            else if (happiness > 60)
            {
                Mood = "Happy";
            }
            else if (happiness > 40)
            {
                Mood = "Neutral";
            }
            else if (happiness > 20)
            {
                Mood = "Sad";
            }
            else
            {
                Mood = "Depressed";
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
