# ARKYV Assistant for Revit

[![Revit 2024](https://img.shields.io/badge/Revit-2024+-blue.svg)](../..)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Description

ARKYV Assistant is a Revit add-in that integrates the ARKYV platform directly into Autodesk Revit. It provides seamless access to the ARKYV web application (https://app.arkyv.ai/) through an embedded WebView2 interface.

### Features

- **Integrated Web Interface**: Access ARKYV directly within Revit without switching applications
- **Dockable Panel Support**: Use ARKYV as a dockable panel in Revit 2024, 2025, and 2026
- **Simple Interface**: Single "ARKYV" button in the ribbon
- **Modern WebView2 Technology**: Built with Microsoft Edge WebView2 for optimal performance

## Supported Revit Versions

- Revit 2024 (.NET Framework 4.8)
- Revit 2025 (.NET 8.0)
- Revit 2026 (.NET 8.0)

## Installation

### ⚠️ Important: Choose the Correct Installer

Due to .NET framework differences, you need to install the correct version:

#### For Revit 2024 Users:
- Download and run: **`ARKYV.Assistant-2024-1.0.25.217.msi`**
- This contains .NET 4.8 compatible assemblies

#### For Revit 2025 and/or 2026 Users:
- Download and run: **`ARKYV.Assistant-2025-2026-1.0.25.217.msi`**
- This contains .NET 8.0 compatible assemblies

### Can I Install Both?

**Yes!** Both installers can be installed simultaneously on the same machine because they have unique identifiers. This allows you to:
- Use ARKYV Assistant in Revit 2024 AND 2025/2026 on the same computer
- Switch between different Revit versions without conflicts

### Manual Installation

If you prefer manual installation:

1. Download the appropriate ZIP file:
   - `ARKYV.Assistant-2024-1.0.25.217.zip` for Revit 2024
   - `ARKYV.Assistant-2025-2026-1.0.25.217.zip` for Revit 2025/2026

2. Extract contents to the appropriate Revit Addins folder:
   - For Revit 2024: `%AppData%\Autodesk\Revit\Addins\2024\`
   - For Revit 2025: `%AppData%\Autodesk\Revit\Addins\2025\`
   - For Revit 2026: `%AppData%\Autodesk\Revit\Addins\2026\`

## Usage

After installation, you'll find the ARKYV Assistant panel in the Revit ribbon with a single "ARKYV" button that opens the ARKYV platform as a dockable panel within Revit.

## Development

### Building from Source

1. Clone the repository
2. Open `RevitAddin.WebView2.Example.sln` in Visual Studio 2022
3. Build the solution for your target Revit version (2024, 2025, or 2026)

### Creating the Installers

The project includes separate MSI builders for different .NET frameworks:

```powershell
# For Revit 2024 (.NET 4.8)
dotnet run --project MsiBuilder\RevitAddinMsiBuilder.csproj -- --addin-path "Installer\2024\ARKYV.Assistant.addin" --revit-versions 2024 --output-dir "Output" --project-name "ARKYV.Assistant-2024"

# For Revit 2025/2026 (.NET 8.0)
dotnet run --project MsiBuilder\RevitAddinMsiBuilder.csproj -- --addin-path "Installer\2025\ARKYV.Assistant.addin" --revit-versions 2025 2026 --output-dir "Output" --project-name "ARKYV.Assistant-2025-2026"
```

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

© 2025 ARKYV - Building Information Management Platform