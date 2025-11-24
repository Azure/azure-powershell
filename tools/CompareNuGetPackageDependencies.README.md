# Compare NuGet Package Dependencies

## Overview

The `CompareNuGetPackageDependencies.ps1` script allows you to compare the dependencies of two versions of a NuGet package recursively. This is useful for understanding what changed between package versions, particularly when upgrading dependencies in the Azure PowerShell repository.

## Prerequisites

- PowerShell 7.0 or later
- .NET SDK 8.0 or later
- Internet connectivity to download NuGet packages

## Usage

### Basic Usage

```powershell
.\CompareNuGetPackageDependencies.ps1 -PackageName "Azure.Core" -Version1 "1.47.3" -Version2 "1.50.0"
```

### Save Results to File

```powershell
.\CompareNuGetPackageDependencies.ps1 -PackageName "Azure.Core" -Version1 "1.47.3" -Version2 "1.50.0" -OutputFile "comparison.txt"
```

## Parameters

| Parameter | Required | Description |
|-----------|----------|-------------|
| `PackageName` | Yes | The name of the NuGet package to compare (e.g., "Azure.Core") |
| `Version1` | Yes | The first version to compare (e.g., "1.47.3") |
| `Version2` | Yes | The second version to compare (e.g., "1.50.0") |
| `OutputFile` | No | Optional path to save the comparison results to a text file |
| `TargetFramework` | No | Target framework to use for package restore (default: "net6.0" for broader compatibility) |

## Output

The script displays and optionally saves a comparison report showing:

- **Added Dependencies**: New dependencies in Version2 that weren't in Version1
- **Removed Dependencies**: Dependencies in Version1 that are no longer in Version2
- **Changed Dependency Versions**: Dependencies that exist in both versions but with different version numbers
- **Unchanged Dependencies**: Dependencies that remain the same across both versions
- **Summary**: Count of changes in each category

### Example Output

```
========================================
NuGet Package Dependency Comparison
========================================
Package: Azure.Core
Version 1: 1.47.3
Version 2: 1.50.0
========================================

CHANGED DEPENDENCY VERSIONS (1):
  ~ System.ClientModel : 1.6.1 -> 1.8.0

UNCHANGED DEPENDENCIES (4):
  = Microsoft.Bcl.AsyncInterfaces : 8.0.0
  = Microsoft.Extensions.DependencyInjection.Abstractions : 8.0.2
  = Microsoft.Extensions.Logging.Abstractions : 8.0.3
  = System.Memory.Data : 8.0.1

========================================
SUMMARY:
  Added: 0
  Removed: 0
  Changed: 1
  Unchanged: 4
========================================
```

## How It Works

1. Creates temporary .NET projects for each package version
2. Uses `dotnet restore` to download packages and resolve dependencies
3. Uses `dotnet list package --include-transitive` to get the full dependency tree
4. Compares the dependency trees to identify differences
5. Displays results with color-coded output (green for added, red for removed, yellow for changed)

## Use Cases

- **Upgrading Packages**: Understand what transitive dependencies will change when upgrading a package
- **Security Audits**: Identify if a package upgrade introduces or removes specific dependencies
- **Breaking Changes**: Determine if dependency version changes might introduce breaking changes
- **Documentation**: Document dependency changes for release notes

## Notes

- The script analyzes transitive dependencies (dependencies of dependencies) recursively
- Temporary projects are created in the system temp directory and cleaned up after execution
- The script uses `--no-cache` to ensure fresh package data is retrieved
- Results are sorted alphabetically by package name for easier reading
