# Security Policy

## Supported Versions

The following versions of Tamagotchi Todo are currently supported with security updates:

| Version | Supported          |
| ------- | ------------------ |
| 1.0.x   | :white_check_mark: |

## Reporting a Vulnerability

We take the security of Tamagotchi Todo seriously. If you have discovered a security vulnerability, we appreciate your help in disclosing it to us in a responsible manner.

### How to Report

Please report security vulnerabilities by emailing the project maintainers. Do not open public issues for security vulnerabilities.

Include the following information in your report:

- Type of vulnerability
- Full paths of source file(s) related to the vulnerability
- Location of the affected source code (tag/branch/commit or direct URL)
- Step-by-step instructions to reproduce the issue
- Proof-of-concept or exploit code (if possible)
- Impact of the vulnerability, including how an attacker might exploit it

### What to Expect

- You will receive an acknowledgment of your report within 48 hours
- We will investigate and validate the vulnerability
- We will work on a fix and keep you informed of our progress
- Once the vulnerability is fixed, we will publicly disclose it (with credit to you, if desired)

## Security Considerations

### Data Storage

Tamagotchi Todo stores data locally in JSON format:
- Task data is stored in `%AppData%/TamagotchiTodo/tasks.json`
- Pet state is stored in `%AppData%/TamagotchiTodo/pet.json`

This data is stored in plain text and is accessible to any process running under your user account. Do not store sensitive information in task titles or descriptions.

### Theme Preferences

User theme preferences are stored in application settings. This data is not sensitive but is persistent across sessions.

### No Network Communication

The application does not communicate over the network and does not collect or transmit any user data.

## Best Practices

When using Tamagotchi Todo:
- Do not store passwords or sensitive information in task descriptions
- Keep your Windows user account secure
- Regularly update to the latest version to receive security fixes

## Scope

This security policy applies to:
- The Tamagotchi Todo application
- The source code in this repository
- Official releases and binaries

## Attribution

Thank you to all security researchers who help keep Tamagotchi Todo safe for everyone.
