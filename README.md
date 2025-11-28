# Tamagotchi Todo

A unique task management application that gamifies productivity by combining to-do lists with virtual pet care mechanics. Complete tasks to maintain your digital companion's wellbeing across multiple stat bars.

## Features

### Task Management
- Create, complete, and track tasks with custom descriptions
- Organize tasks into active and completed categories
- Set custom stat impacts for each task
- Flexible task rewards system allowing multiple stat modifications

### Tamagotchi Mechanics
- Multiple stat bars (Hunger, Happiness, Thirst, Energy, Health)
- Dynamic mood system that reflects your pet's overall wellbeing
- Automatic stat decay over time to encourage regular task completion
- Persistent state that continues even when the app is closed

### User Interface
- Lofi-inspired aesthetic with calming earth tones
- Dark and light theme support with seamless switching
- Clean, minimalist design focused on usability
- Responsive layout with clear visual feedback

### Data Persistence
- Automatic saving of tasks and pet state
- JSON-based storage in user's AppData directory
- Time-based stat decay calculation when reopening the app

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Windows operating system
- Visual Studio 2022 or JetBrains Rider (optional, for development)

### Installation

#### Option 1: Build from Source
```bash
# Clone the repository
git clone https://github.com/yourusername/tamagotchi-todo.git
cd tamagotchi-todo

# Build the project
dotnet build

# Run the application
dotnet run
```

#### Option 2: Visual Studio
1. Open `TamagotchiTodo.sln` in Visual Studio
2. Press F5 to build and run the application

## Usage

### Creating Tasks
1. Click the "Add New Task" button
2. Enter a task title and optional description
3. Adjust the stat impact sliders to set how completing this task will affect your pet
   - Positive values increase stats (e.g., +10 Happiness)
   - Negative values decrease stats (e.g., -5 Energy for rest tasks)
4. Click "Create Task" to add it to your active tasks

### Managing Your Pet
- Monitor stat bars on the left panel to track your pet's wellbeing
- Complete tasks regularly to maintain healthy stat levels
- Watch for critical stats (below 20) which can negatively impact health
- Your pet's mood changes based on happiness and health levels

### Theme Customization
Click the "Toggle Theme" button in the top-right corner to switch between light and dark modes. Your preference is automatically saved.

## Project Structure

```
TamagotchiTodo/
├── Models/              # Data models (TodoTask, TamagotchiPet, TamagotchiStats)
├── Services/            # Business logic (DataService, TaskService, TimerService, ThemeManager)
├── ViewModels/          # MVVM view models
├── Windows/             # Additional windows (AddTaskWindow)
├── Themes/              # Theme resource dictionaries
├── Properties/          # Application settings
├── App.xaml             # Application entry point
└── MainWindow.xaml      # Main application window
```

## Architecture

This application follows the Model-View-ViewModel (MVVM) pattern:

- **Models**: Represent the core data structures (tasks, pet stats, pet state)
- **Views**: XAML-based user interface components
- **ViewModels**: Mediate between models and views, handle UI logic
- **Services**: Provide data persistence, task management, and timer functionality

## Technical Details

### Technologies Used
- C# 12
- .NET 8.0
- WPF (Windows Presentation Foundation)
- Newtonsoft.Json for data serialization

### Data Storage
Application data is stored in:
```
%AppData%/TamagotchiTodo/
├── tasks.json          # Task data
└── pet.json            # Pet state and stats
```

### Stat Decay System
Stats automatically decay every 30 minutes while the app is running. When reopening the app, decay is calculated based on elapsed time since the last save (capped at 50 points to prevent excessive stat loss).

## Contributing

Contributions are welcome. Please follow these guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Setup
1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Restore NuGet packages (`dotnet restore`)
4. Build the solution (`dotnet build`)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Inspired by the classic Tamagotchi virtual pet toys
- Lofi aesthetic influenced by modern productivity applications
- Built with the WPF framework and .NET ecosystem

## Support

For issues, questions, or suggestions, please open an issue on the GitHub repository.

## Roadmap

Potential future enhancements:
- Custom stat creation
- Task categories and tags
- Statistics and productivity tracking
- Multiple pet types with unique characteristics
- Sound effects and notifications
- Cloud sync support
- Mobile companion app

## Version History

### 1.0.0 (Initial Release)
- Core task management functionality
- Tamagotchi stat system with five default stats
- Dark and light theme support
- Local data persistence
- Automatic stat decay system
