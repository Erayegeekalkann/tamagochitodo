using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TamagotchiTodo.Models;
using TamagotchiTodo.Services;
using TamagotchiTodo.ViewModels;
using TamagotchiTodo.Windows;

namespace TamagotchiTodo
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            // Apply saved theme
            ThemeManager.Instance.ApplyTheme(ThemeManager.Instance.CurrentTheme);

            // Initialize stats display
            InitializeStatsDisplay();

            // Subscribe to stats changes
            _viewModel.Pet.Stats.PropertyChanged += (s, e) => UpdateStatsDisplay();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateStatsDisplay();
        }

        private void InitializeStatsDisplay()
        {
            var stats = _viewModel.Pet.Stats.GetAllStats();
            foreach (var stat in stats)
            {
                AddStatBar(stat.Key, stat.Value);
            }
        }

        private void AddStatBar(string statName, int value)
        {
            var container = new StackPanel { Margin = new Thickness(0, 0, 0, 12) };

            var header = new Grid();
            header.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            header.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var nameText = new TextBlock
            {
                Text = statName,
                Foreground = (Brush)FindResource("PrimaryText"),
                FontSize = 13,
                FontWeight = FontWeights.Medium
            };

            var valueText = new TextBlock
            {
                Text = $"{value}/100",
                Foreground = (Brush)FindResource("SecondaryText"),
                FontSize = 12,
                Tag = statName
            };

            Grid.SetColumn(nameText, 0);
            Grid.SetColumn(valueText, 1);
            header.Children.Add(nameText);
            header.Children.Add(valueText);

            var progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = value,
                Height = 24,
                Margin = new Thickness(0, 5, 0, 0),
                BorderBrush = (Brush)FindResource("Border"),
                BorderThickness = new Thickness(1),
                Background = (Brush)FindResource("SecondaryBackground"),
                Tag = statName
            };

            // Color based on value
            progressBar.Foreground = GetStatColor(value);

            container.Children.Add(header);
            container.Children.Add(progressBar);
            StatsPanel.Children.Add(container);
        }

        private void UpdateStatsDisplay()
        {
            var stats = _viewModel.Pet.Stats.GetAllStats();

            foreach (var child in StatsPanel.Children)
            {
                if (child is StackPanel panel)
                {
                    foreach (var item in panel.Children)
                    {
                        if (item is ProgressBar bar && bar.Tag is string statName)
                        {
                            if (stats.ContainsKey(statName))
                            {
                                bar.Value = stats[statName];
                                bar.Foreground = GetStatColor(stats[statName]);
                            }
                        }
                        else if (item is Grid grid)
                        {
                            foreach (var gridChild in grid.Children)
                            {
                                if (gridChild is TextBlock text && text.Tag is string stat)
                                {
                                    if (stats.ContainsKey(stat))
                                    {
                                        text.Text = $"{stats[stat]}/100";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private Brush GetStatColor(int value)
        {
            if (value >= 70)
                return (Brush)FindResource("Success");
            else if (value >= 40)
                return (Brush)FindResource("Warning");
            else
                return (Brush)FindResource("Danger");
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Instance.ToggleTheme();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow(_viewModel.Pet.Stats.GetAllStats());
            if (addTaskWindow.ShowDialog() == true)
            {
                var task = addTaskWindow.CreatedTask;
                if (task != null)
                {
                    _viewModel.TaskService.AddTask(task);
                }
            }
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TodoTask task)
            {
                _viewModel.TaskService.CompleteTask(task);
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TodoTask task)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete '{task.Title}'?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.TaskService.DeleteTask(task);
                }
            }
        }

        private void RestoreTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TodoTask task)
            {
                _viewModel.TaskService.UncompleteTask(task);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _viewModel.SavePet();
            base.OnClosing(e);
        }
    }
}
