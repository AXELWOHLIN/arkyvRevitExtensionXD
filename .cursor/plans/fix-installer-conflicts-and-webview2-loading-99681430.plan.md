---
name: Fix Installer Conflicts and WebView2 Loading
overview: ""
todos:
  - id: c4239a96-7996-4d90-92fb-d280f5b28992
    content: Modify MsiBuilder/Installer.cs to include WebView2Loader.dll and implement stable GUID generation
    status: completed
isProject: false
---

# Fix Installer Conflicts and WebView2 Loading

I will modify the MSI builder to ensure unique identifiers for different versions and properly include the WebView2 runtime.

## User Action Required

- After I apply the fixes, you will need to **rebuild your installers** using the `MsiBuilder`.
- Ensure you provide unique project names for different versions if you aren't already (e.g., `ARKYV.Assistant-2024` vs `ARKYV.Assistant-2025`), though my changes will help automate unique IDs.

## Implementation Plan

1.  **Modify `MsiBuilder/Installer.cs`**:

    - **Fix WebView2**: Update `BuildMsi` to recursively search for `WebView2Loader.dll` (specifically x64) in the assembly directory (handling the `runtimes` folder) and place it in the root of the installation.
    - **Fix Installer Conflict**:
        - Replace the hardcoded `GetProjectGuid` method with a deterministic hashing function (MD5) that generates a GUID from the `projectName`. This ensures any unique project name gets a unique UpgradeCode.
        - Update the default `projectName` logic to append the Revit version(s) if the user didn't specify a name. This guarantees that a 2024 installer has a different ID than a 2025 installer even if you just use defaults.

2.  **Dependencies**:

    - Add `using System.Security.Cryptography;` to `Installer.cs`.