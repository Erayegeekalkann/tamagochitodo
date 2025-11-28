using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TamagotchiTodo.Models
{
    public class TamagotchiStats : INotifyPropertyChanged
    {
        private Dictionary<string, int> _stats = new Dictionary<string, int>();
        private const int MaxStatValue = 100;
        private const int MinStatValue = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public TamagotchiStats()
        {
            // Initialize default stats
            InitializeStat("Hunger", 50);
            InitializeStat("Happiness", 50);
            InitializeStat("Thirst", 50);
            InitializeStat("Energy", 50);
            InitializeStat("Health", 100);
        }

        public void InitializeStat(string statName, int value)
        {
            _stats[statName] = Math.Clamp(value, MinStatValue, MaxStatValue);
            OnPropertyChanged(statName);
        }

        public int GetStat(string statName)
        {
            return _stats.ContainsKey(statName) ? _stats[statName] : 0;
        }

        public void SetStat(string statName, int value)
        {
            _stats[statName] = Math.Clamp(value, MinStatValue, MaxStatValue);
            OnPropertyChanged(statName);
            OnPropertyChanged("Stats");
        }

        public void ModifyStat(string statName, int delta)
        {
            if (_stats.ContainsKey(statName))
            {
                SetStat(statName, _stats[statName] + delta);
            }
        }

        public Dictionary<string, int> GetAllStats()
        {
            return new Dictionary<string, int>(_stats);
        }

        public void DecayStats(int decayAmount = 1)
        {
            // Hunger, Thirst, and Energy decrease over time
            ModifyStat("Hunger", -decayAmount);
            ModifyStat("Thirst", -decayAmount);
            ModifyStat("Energy", -decayAmount);

            // Health decreases if critical stats are too low
            if (GetStat("Hunger") < 20 || GetStat("Thirst") < 20)
            {
                ModifyStat("Health", -decayAmount);
            }

            // Happiness decreases if health is low
            if (GetStat("Health") < 30)
            {
                ModifyStat("Happiness", -decayAmount);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
