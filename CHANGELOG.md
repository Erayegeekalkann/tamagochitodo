# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2025-01-XX

### Added
- Initial release of Tamagotchi Todo
- Core task management functionality
  - Create tasks with custom titles and descriptions
  - Mark tasks as complete or delete them
  - Restore completed tasks to active status
- Tamagotchi virtual pet system
  - Five default stats: Hunger, Happiness, Thirst, Energy, Health
  - Dynamic mood system based on stat levels
  - Visual pet display with ASCII art
- Stat impact system
  - Custom stat rewards for each task
  - Support for positive and negative stat impacts
  - Multiple stats can be affected by a single task
- Automatic stat decay
  - Stats decrease over time (every 30 minutes while running)
  - Time-based decay calculation when app is closed
  - Health-based secondary effects on other stats
- Theme system
  - Lofi-inspired aesthetic design
  - Dark theme with warm earth tones
  - Light theme with soft beige palette
  - Seamless theme switching with persistence
- Data persistence
  - JSON-based storage in AppData directory
  - Automatic save on task changes
  - Automatic save on application close
  - Time tracking for stat decay calculations
- User interface
  - Clean, minimalist design
  - Responsive layout
  - Tab-based task organization (Active/Completed)
  - Visual stat bars with color-coded levels
  - Modal dialog for task creation

### Technical Details
- Built with .NET 8.0 and WPF
- MVVM architecture pattern
- Newtonsoft.Json for serialization
- Custom theme resource dictionaries
- Settings persistence using application settings

[1.0.0]: https://github.com/yourusername/tamagotchi-todo/releases/tag/v1.0.0
