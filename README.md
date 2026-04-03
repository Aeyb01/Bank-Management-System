# Bank Management System

A console-based bank management system built in C# as part of a structured learning roadmap toward mastering C# with a **1400 lines of structured code.**

This project is intentionally offline and single-user. Its purpose is not to simulate a production banking system, but to practice clean architecture, separation of concerns, generic programming, delegates, and JSON persistence in a real-world context.

---

## Features

- Account creation with a multi-field validated form (name, date of birth, email, phone, address, account type, initial deposit)
- Persistent storage via JSON serialization using `System.Text.Json`
- Deposit and withdrawal operations with balance tracking
- Dynamic console UI with in-place field updates and cursor management
- Generic input handling system powered by enums and delegates
- Multi-language name validation with Unicode support and profanity filtering

---

## Project Structure

```
BankManagementSystem/
├── Program.cs
├── Models/
│   ├── BankAccount.cs          # Core account data model
│   └── Enums.cs                # Menu and option enums
├── Data/
│   ├── Dictionaries.cs         # Action routing dictionaries
│   ├── JsonUtility.cs          # Load/save entry point
│   └── SaveData.cs             # JSON file creation logic
├── Services/
│   ├── CommandExecutor.cs      # Executes enum-mapped actions
│   ├── FieldInputService.cs    # Validated input + UI update pipeline
│   ├── InputValidator.cs       # Generic enum-based input parser
│   ├── UserInputService.cs     # Orchestrates menu input flow
│   ├── ResetLine.cs            # Console line clearing utility
│   ├── Deposit.cs              # Deposit operation orchestrator
│   ├── MakeDeposit.cs          # Deposit amount handler
│   ├── Withdraw.cs             # Withdrawal operation orchestrator
│   ├── MakeWithdraw.cs         # Withdrawal amount handler
│   ├── WithdrawValidator.cs    # Withdrawal input validator
│   └── Account Creation/
│       ├── CreateAccount.cs
│       ├── Name/               # Name handler + validator
│       ├── DateOfBirth/        # DOB handler + validator
│       ├── EmailAddress/       # Email handler + validator
│       ├── PhoneNumber/        # Phone handler + validator
│       ├── Address/            # Address handler + validator
│       ├── AccountType/        # Account type handler + validator
│       └── InitialDeposit/     # Initial deposit handler + validator
├── UI/
│   ├── MenuManager.cs          # Top-level navigation controller
│   ├── MainMenu.cs             # Main account menu display
│   ├── NoAccountMenu.cs        # First-launch menu display
│   ├── AccountCreationUI.cs    # Account creation form display
│   ├── DepositMenu.cs          # Deposit menu display
│   ├── WithdrawMenu.cs         # Withdrawal menu display
│   ├── Display.cs              # Shared menu renderer with variable injection
│   ├── ReplaceVariable.cs      # Template variable replacement utility
│   ├── UIFieldCoordinates.cs   # Console coordinate calculator
│   └── ConsoleNotifier.cs      # Colored console message utility
└── UserData/
    └── account.json            # Persisted account data (auto-generated)
```

---

## Architecture Highlights

### Generic Input System

The menu navigation system is built around generics and enums. Any menu can be driven by the same `HandleInput<T>` method, where `T` is an enum representing that menu's options. The corresponding `Dictionary<T, Action>` maps each option to its handler.

```csharp
// Works for any enum — zero code duplication between menus
public static void HandleInput<T>(Dictionary<T, Action> dictionary) where T : Enum
```

### Validated Field Input

The `PromptUntilValid` method accepts any validation function as a `Func<string, bool>` delegate, eliminating repeated loop patterns across every form field.

```csharp
public static string PromptUntilValid(string prompt, Func<string, bool> validator)
```

### Logic / Display Separation

All business logic classes (validators, handlers, executors) are free of any UI code. Display classes handle rendering only. This mirrors the architecture required for a strong achritechtural project.

---

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- A terminal that supports ANSI escape sequences (Windows Terminal, macOS Terminal, any Linux terminal)

### Run

```bash
git clone https://github.com/your-username/BankManagementSystem.git
cd BankManagementSystem
dotnet run
```

On first launch, no account exists and the system will prompt you to create one. Account data is saved to `UserData/account.json` in the project root.

---

## Dependencies

- [ProfanityFilter](https://www.nuget.org/packages/ProfanityFilter/) — used for name validation during account creation

---

## Known Limitations (MVP)

This is a learning MVP with the following known limitations that will be addressed in a future refactoring pass.

**Recursive navigation** — deposit and withdrawal operations call `MenuManager.DisplayMenu()` recursively instead of using a loop. This will cause a `StackOverflowException` after a high number of operations.

**Balance stored as string** — the `Deposit` property in `BankAccount` is typed as `string` rather than `decimal`. This requires repeated `Parse` and `ToString` calls throughout the codebase.

**Age calculation uses year only** — `AgeVerification()` computes age from birth year alone, which produces off-by-one errors near birthday boundaries.

**Validators print errors directly** — validation classes call `ConsoleNotifiers` internally, which couples them to the console and prevents reuse in non-console contexts.

**Single account, no authentication** — the system supports exactly one user account with no login screen. Multi-account support requires a login system which is planned for a future version.

---

## Roadmap

- [ ] Fix recursive navigation (replace with loop in MenuManager)
- [ ] Fix `Balance` type to `decimal` throughout
- [ ] Fix age calculation to use full date comparison
- [ ] Separate error display from validators
- [ ] Add `Transaction` model and history screen
- [ ] Add account confirmation screen before saving
- [ ] Add login system (username + password)
- [ ] Add multi-account support
- [ ] Add monthly fee logic for savings accounts
- [ ] Add account information update screen
- [ ] Add statement export to `.txt`
- [ ] Integrate [Spectre.Console](https://spectreconsole.net/) for improved UI

---

## Learning Context

This project is Bloc 2 of a personal four-bloc roadmap toward learning C#:

- **Bloc 1** — C# fundamentals (completed)
- **Bloc 2** — Business logic and persistence via mini-projects (this project)
- **Bloc 3** — Core engine architecture in console C#
- **Bloc 4** — Unity/GUI integration with UI layer on top of the pure logic engine

The architecture philosophy throughout: if you can delete the display layer and the logic still compiles and runs correctly, the separation is correct.

---

## License

This project is for personal educational use. No license is applied.
