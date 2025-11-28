# Contributing to Tamagotchi Todo

Thank you for your interest in contributing to Tamagotchi Todo. This document provides guidelines and instructions for contributing to the project.

## Code of Conduct

This project adheres to a code of conduct that all contributors are expected to follow. Please be respectful and constructive in all interactions.

## How to Contribute

### Reporting Bugs

Before creating bug reports, please check existing issues to avoid duplicates. When creating a bug report, include:

- A clear and descriptive title
- Detailed steps to reproduce the issue
- Expected behavior vs. actual behavior
- Screenshots if applicable
- Your environment (Windows version, .NET version)

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, include:

- A clear and descriptive title
- Detailed description of the proposed functionality
- Explanation of why this enhancement would be useful
- Possible implementation approach if you have ideas

### Pull Requests

1. Fork the repository
2. Create a new branch from `main` for your feature or bugfix
3. Make your changes following the coding standards
4. Test your changes thoroughly
5. Commit your changes with clear, descriptive commit messages
6. Push your branch to your fork
7. Submit a pull request to the main repository

#### Pull Request Guidelines

- Follow the existing code style and conventions
- Include comments for complex logic
- Update documentation if you change functionality
- Keep pull requests focused on a single feature or fix
- Write clear commit messages describing what and why

## Development Setup

1. Clone your fork of the repository
2. Open the solution in Visual Studio 2022 or JetBrains Rider
3. Restore NuGet packages
4. Build the solution to ensure everything compiles
5. Run the application to verify it works

## Coding Standards

### C# Style Guidelines

- Use meaningful variable and method names
- Follow C# naming conventions (PascalCase for classes/methods, camelCase for variables)
- Keep methods focused and concise
- Add XML documentation comments for public APIs
- Use LINQ where appropriate for cleaner code

### XAML Guidelines

- Maintain consistent indentation (4 spaces)
- Use meaningful names for UI elements that are referenced in code
- Group related properties together
- Use resources for repeated values (colors, styles, etc.)

### File Organization

- Place new models in the `Models` folder
- Place services in the `Services` folder
- Place view models in the `ViewModels` folder
- Place additional windows in the `Windows` folder

## Testing

While the project doesn't currently have automated tests, please manually test your changes:

- Test all affected features thoroughly
- Test both light and dark themes
- Test data persistence (closing and reopening the app)
- Test edge cases and error conditions

## Documentation

- Update the README.md if you add new features
- Update inline code comments for complex logic
- Update XML documentation for public APIs

## Questions?

If you have questions about contributing, feel free to open an issue with the "question" label.

## License

By contributing to Tamagotchi Todo, you agree that your contributions will be licensed under the MIT License.
