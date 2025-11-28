using System;
using System.Windows.Threading;

namespace TamagotchiTodo.Services
{
    public class TimerService
    {
        private readonly DispatcherTimer _decayTimer;
        public event EventHandler? DecayTick;

        public TimerService()
        {
            _decayTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(30) // Decay every 30 minutes
            };
            _decayTimer.Tick += OnDecayTick;
        }

        public void Start()
        {
            _decayTimer.Start();
        }

        public void Stop()
        {
            _decayTimer.Stop();
        }

        private void OnDecayTick(object? sender, EventArgs e)
        {
            DecayTick?.Invoke(this, EventArgs.Empty);
        }
    }
}
