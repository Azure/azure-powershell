---
applyTo: "**/*.ps1"
---

# PowerShell Scripts (*.ps1)

When writing PowerShell script files in the Azure PowerShell repository, follow these compatibility and portability guidelines:

## PowerShell Version Compatibility

### Default Requirement: PowerShell 5.1 Compatibility
- **All PowerShell scripts must be compatible with PowerShell 5.1** unless they are specifically for repository tooling
- Use syntax and cmdlets that work in both Windows PowerShell 5.1 and PowerShell 7+
- Avoid PowerShell 7+ exclusive features in user-facing scripts

### Repository Tooling Exception
- Scripts in `/tools/`, `.azure-pipelines/`, and build/test automation may target PowerShell 7+
- CI/CD scripts, build scripts, and development tools can use modern PowerShell features
- Clearly document if a tool script requires PowerShell 7+

## Cross-Platform Compatibility

### Unix-like OS Support
- **All scripts must be compatible with Unix-like operating systems** (Linux, macOS)
- Avoid Windows-specific paths, registry operations, and Windows-only cmdlets
- Use cross-platform PowerShell features and patterns

### Path Handling
```powershell
# Good - Cross-platform path handling
$configPath = Join-Path -Path $PSScriptRoot -ChildPath "config.json"
$modulePath = [System.IO.Path]::Combine($PSScriptRoot, "modules", "Az.Example")

# Avoid - Windows-specific paths
$configPath = "$PSScriptRoot\config.json"
$modulePath = "$env:USERPROFILE\Documents\PowerShell\Modules"
```

### File System Operations
```powershell
# Good - Cross-platform file operations
if (Test-Path $filePath) {
    $content = Get-Content -Path $filePath -Raw
}

# Acceptable - Platform-specific logic with graceful fallback
if ($env:OS -eq "Windows_NT") { 
    # Windows-specific logic when required by business needs
    $result = Get-WindowsFeature
} else {
    # Graceful fallback for other platforms
    Write-Warning "This feature is only available on Windows"
    $result = $null
}
```

## Best Practices

### Error Handling
```powershell
# Use proper error handling for cross-platform scenarios
try {
    $result = Invoke-SomeCommand
} catch {
    Write-Error "Operation failed: $($_.Exception.Message)"
    exit 1
}
```

### Environment Variables
```powershell
# Good - Check for variables that exist on all platforms
$homeDir = $env:HOME ?? $env:USERPROFILE
$tempDir = $env:TMPDIR ?? $env:TEMP ?? "/tmp"

# Avoid - Platform-specific environment variables without fallbacks
$userName = $env:USERNAME  # Windows only
```

### Execution Policy Considerations
- Scripts should handle execution policy restrictions gracefully
- Include appropriate documentation for users on different platforms
- Use `-ExecutionPolicy Bypass` only when necessary and document why

## Examples

### Cross-Platform Script Template
```powershell
#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Cross-platform Azure PowerShell utility script
.DESCRIPTION
    This script works on Windows, Linux, and macOS with PowerShell 5.1+
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$ResourceGroupName
)

# Set strict mode for better error catching
Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

# Cross-platform path handling
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$configFile = Join-Path -Path $scriptDir -ChildPath "config.json"

try {
    # Your script logic here
    Write-Host "Processing resource group: $ResourceGroupName"
} catch {
    Write-Error "Script failed: $($_.Exception.Message)"
    exit 1
}
```

### Repository Tooling Script (PowerShell 7+ allowed)
```powershell
#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Build automation script (requires PowerShell 7+)
.NOTES
    This is a repository tooling script and may use PowerShell 7+ features
#>

#Requires -Version 7.0

# Can use PowerShell 7+ features like null coalescing
$buildPath = $env:BUILD_PATH ?? (Join-Path $PSScriptRoot "build")

# Modern PowerShell features allowed in tooling
$modules = Get-ChildItem -Path "src" -Directory | 
    Where-Object { Test-Path (Join-Path $_.FullName "*.psd1") }
```

## Testing Compatibility
- Test scripts on both Windows PowerShell 5.1 and PowerShell 7+
- Verify functionality on Linux/macOS when possible
- Use `$PSVersionTable` to check PowerShell version in scripts when needed
- Consider using `#Requires` directive to specify minimum PowerShell version