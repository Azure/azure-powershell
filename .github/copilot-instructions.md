# Copilot Instructions for Azure PowerShell

## Architecture Overview

Azure PowerShell consists of **two main development approaches for projects**:

1. **SDK-based projects** - Hand-written C# cmdlets with custom business logic
2. **AutoRest-based projects** - Auto-generated from OpenAPI specs via AutoRest PowerShell (mostly newer Azure services)

Always check module type before making changes - SDK vs AutoRest projects have different development patterns.

### Modules vs Projects
- **Module**: A complete PowerShell module (e.g., `Az.Compute`) that can consist of multiple projects
- **Project**: Individual C# project within a module, developed with one approach (SDK-based OR AutoRest)
- **Hybrid Module**: Contains both SDK-based and AutoRest projects (e.g., `Az.Resources` with both approaches)

### Key Directories
- `src/` - All the modules, source code of SDK-based projects and non-generated part of AutoRest-based projects.
- `generated/` - Pure generated part of AutoRest-based modules
- `tools/` - Build scripts, static analysis tools
- `documentation/` - Developer guides, breaking change tracking

## SDK-Based Development

### Project Structure
```
ModuleName/
├── ModuleName/           # Main cmdlet project
├── ModuleName.Test/      # Unit and scenario tests
└── ModuleName.sln        # Visual Studio solution
```

### Building SDK Projects
```powershell
# Build specific modules
./tools/BuildScripts/BuildModules.ps1 -ModuleName Accounts,KeyVault

# Full build from root
./tools/BuildScripts/BuildModules.ps1

# Build only changed modules
./tools/BuildScripts/BuildModules.ps1 -ModifiedModule

# Run build artifacts
Import-Module ./artifacts/Debug/Az.Accounts/Az.Accounts.psd1
```

### Testing SDK Projects

- **Scenario tests**: `ModuleName.Test` projects with `*Tests.cs` files and PowerShell scripts `*Tests.ps1` using Azure TestFramework
- **Test recordings**: Stored in `SessionRecords/` directories

### Key Files for SDK Development
- `src/ModuleName/ModuleName/ModuleName.psd1` - Module manifest
- `src/ModuleName/ModuleName/Cmdlets/*Cmdlet.cs` - Cmdlet implementations
- `src/ModuleName/ModuleName.Test/*Tests.(cs|ps1)` - Scenario tests

## AutoRest-Based Development

### Project Structure
```
ModuleName/
└── ModuleName.Autorest/
    ├── custom/                # Hand-written customizations
    ├── docs/                  # Reference documentation
    ├── examples/              # Example scripts and output
    ├── generated/             # AutoRest generated code
    ├── test/                  # Test files
    ├── README.md              # Project overview and setup instructions
    ├── Az.ModuleName.psd1     # Module manifest
    └── Az.ModuleName.psm1     # Main module file
```

### AutoRest Workflows
TODO

## Hybrid Modules
Some modules contain both SDK-based and AutoRest-based projects, requiring understanding of both approaches.

## Wrapper Project
TODO

## Common Conventions (All Development Approaches)

### Version Handling
Always use `[System.Version]` for version comparisons, never string comparison:
```powershell
# CORRECT
if ([System.Version]$ModuleVersion -ge [System.Version]"1.0.0")

# WRONG - fails for versions like "10.0.0" vs "1.0.0"
if ($ModuleVersion -ge "1.0.0")
```

### Compatibility

As PowerShell 7 is cross-platform, ensure all scripts and modules are compatible with Windows, macOS, and Linux by:

1. Do not assume Windows-specific paths (use `Join-Path` or `Resolve-Path`).
2. Do not assume case insensitivity.

Since Azure PowerShell support both PowerShell 5.1 and PowerShell 7+, ensure all scripts and modules are compatible with both versions.

### Breaking Changes
TODO: summary
- Tracked in `documentation/breaking-changes/upcoming-breaking-changes.md`
- StaticAnalysis enforces breaking change detection
- Suppressions go in `tools/StaticAnalysis/Exceptions/Az.ModuleName/`
- Use semantic versioning: breaking changes only in major versions

## Integration Points

### Cross-Module Dependencies

`Az.Accounts` provides core authentication. It's required by all modules.

Other hard dependencies between modules are disallowed to avoid dependency hell.
Instead, use `Invoke-AzRestMethod` if you need cross resource-provider calls.
