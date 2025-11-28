using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TamagotchiTodo.Models;

namespace TamagotchiTodo.Windows
{
    public partial class AddTaskWindow : Window
    {
        private readonly Dictionary<string, Slider> _statSliders;
        public TodoTask? CreatedTask { get; private set; }

        public AddTaskWindow(Dictionary<string, int> availableStats)
        {
            InitializeComponent();
            _statSliders = new Dictionary<string, Slider>();

            InitializeStatSliders(availableStats);
        }

        private void InitializeStatSliders(Dictionary<string, int> availableStats)
        {
            foreach (var stat in availableStats.Keys)
            {
                var container = new StackPanel { Margin = new Thickness(0, 0, 0, 15) };

                var header = new Grid();
                header.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                header.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var nameText = new TextBlock
                {
                    Text = stat,
                    Foreground = (Brush)FindResource("PrimaryText"),
                    FontWeight = FontWeights.Medium,
                    FontSize = 13
                };

                var valueText = new TextBlock
                {
                    Text = "0",
                    Foreground = (Brush)FindResource("SecondaryText"),
                    FontSize = 12
                };

                Grid.SetColumn(nameText, 0);
                Grid.SetColumn(valueText, 1);
                header.Children.Add(nameText);
                header.Children.Add(valueText);

                var slider = new Slider
                {
                    Minimum = -30,
                    Maximum = 30,
                    Value = 0,
                    TickFrequency = 5,
                    IsSnapToTickEnabled = true,
                    Margin = new Thickness(0, 5, 0, 0),
                    Tag = valueText
                };

                slider.ValueChanged += (s, e) =>
                {
                    if (slider.Tag is TextBlock text)
                    {
                        var value = (int)slider.Value;
                        text.Text = value > 0 ? $"+{value}" : value.ToString();
                    }
                };

                _statSliders[stat] = slider;

                container.Children.Add(header);
                container.Children.Add(slider);
                StatImpactsPanel.Children.Add(container);
            }
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CreatedTask = new TodoTask
            {
                Title = TitleTextBox.Text.Trim(),
                Description = DescriptionTextBox.Text.Trim()
            };

            foreach (var kvp in _statSliders)
            {
                var value = (int)kvp.Value.Value;
                if (value != 0)
                {
                    CreatedTask.StatImpacts[kvp.Key] = value;
                }
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
