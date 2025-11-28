using System;
using System.Windows;

namespace TamagotchiTodo.Services
{
    public enum ThemeType
    {
        Light,
        Dark
    }

    public class ThemeManager
    {
        private const string ThemeKey = "CurrentTheme";
        private static ThemeManager? _instance;
        private ThemeType _currentTheme;

        public static ThemeManager Instance => _instance ??= new ThemeManager();

        public ThemeType CurrentTheme
        {
            get => _currentTheme;
            private set => _currentTheme = value;
        }

        private ThemeManager()
        {
            _currentTheme = LoadThemePreference();
        }

        public void ApplyTheme(ThemeType theme)
        {
            CurrentTheme = theme;
            SaveThemePreference(theme);

            var themeDictionary = new ResourceDictionary();
            themeDictionary.Source = new Uri(
                $"Themes/{theme}Theme.xaml",
                UriKind.Relative
            );

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
        }

        public void ToggleTheme()
        {
            var newTheme = CurrentTheme == ThemeType.Light ? ThemeType.Dark : ThemeType.Light;
            ApplyTheme(newTheme);
        }

        private ThemeType LoadThemePreference()
        {
            var themeString = Properties.Settings.Default.Theme;
            return Enum.TryParse<ThemeType>(themeString, out var theme) ? theme : ThemeType.Dark;
        }

        private void SaveThemePreference(ThemeType theme)
        {
            Properties.Settings.Default.Theme = theme.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
