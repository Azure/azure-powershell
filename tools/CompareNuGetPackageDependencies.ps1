#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Compare dependencies of two NuGet package versions recursively
.DESCRIPTION
    This script downloads two versions of a NuGet package and compares their dependencies recursively
.PARAMETER PackageName
    The name of the NuGet package to compare
.PARAMETER Version1
    The first version to compare
.PARAMETER Version2
    The second version to compare
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$PackageName,
    
    [Parameter(Mandatory = $true)]
    [string]$Version1,
    
    [Parameter(Mandatory = $true)]
    [string]$Version2
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"

# Function to get package dependencies recursively
function Get-PackageDependencies {
    param(
        [string]$PackageName,
        [string]$Version,
        [string]$TempDir,
        [hashtable]$VisitedPackages = @{}
    )
    
    $key = "$PackageName@$Version"
    
    # Prevent circular dependencies
    if ($VisitedPackages.ContainsKey($key)) {
        return $VisitedPackages[$key]
    }
    
    Write-Host "Processing: $PackageName $Version" -ForegroundColor Cyan
    
    # Create a temporary project to restore the package
    $projectDir = Join-Path $TempDir "project_$([guid]::NewGuid().ToString('N'))"
    New-Item -ItemType Directory -Path $projectDir -Force | Out-Null
    
    $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="$PackageName" Version="$Version" />
  </ItemGroup>
</Project>
"@
    
    $csprojPath = Join-Path $projectDir "temp.csproj"
    Set-Content -Path $csprojPath -Value $csprojContent -Encoding UTF8
    
    # Restore packages
    $restoreOutput = dotnet restore $csprojPath --no-cache 2>&1 | Out-String
    
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "Failed to restore $PackageName $Version"
        Remove-Item -Recurse -Force $projectDir -ErrorAction SilentlyContinue
        return @{}
    }
    
    # Get project dependencies
    $depsOutput = dotnet list $csprojPath package --include-transitive 2>&1 | Out-String
    
    # Parse dependencies
    $dependencies = @{}
    $lines = $depsOutput -split "`n"
    $inTransitive = $false
    
    foreach ($line in $lines) {
        $line = $line.Trim()
        
        if ($line -match "Top-level Package") {
            $inTransitive = $false
            continue
        }
        
        if ($line -match "Transitive Package") {
            $inTransitive = $true
            continue
        }
        
        # Match package lines like: "> Azure.Core    1.47.3"
        if ($line -match "^>\s+([^\s]+)\s+([^\s]+)") {
            $depName = $Matches[1]
            $depVersion = $Matches[2]
            
            # Skip the package itself
            if ($depName -eq $PackageName) {
                continue
            }
            
            $dependencies[$depName] = @{
                Version = $depVersion
                IsTransitive = $inTransitive
            }
        }
    }
    
    # Clean up
    Remove-Item -Recurse -Force $projectDir -ErrorAction SilentlyContinue
    
    # Store in visited packages
    $VisitedPackages[$key] = $dependencies
    
    return $dependencies
}

# Function to compare dependency trees
function Compare-DependencyTrees {
    param(
        [hashtable]$Tree1,
        [hashtable]$Tree2
    )
    
    $comparison = @{
        AddedPackages = @{}
        RemovedPackages = @{}
        ChangedVersions = @{}
        UnchangedPackages = @{}
    }
    
    # Find added and changed packages
    foreach ($pkg in $Tree2.Keys) {
        if (-not $Tree1.ContainsKey($pkg)) {
            $comparison.AddedPackages[$pkg] = $Tree2[$pkg]
        }
        elseif ($Tree1[$pkg].Version -ne $Tree2[$pkg].Version) {
            $comparison.ChangedVersions[$pkg] = @{
                OldVersion = $Tree1[$pkg].Version
                NewVersion = $Tree2[$pkg].Version
            }
        }
        else {
            $comparison.UnchangedPackages[$pkg] = $Tree2[$pkg]
        }
    }
    
    # Find removed packages
    foreach ($pkg in $Tree1.Keys) {
        if (-not $Tree2.ContainsKey($pkg)) {
            $comparison.RemovedPackages[$pkg] = $Tree1[$pkg]
        }
    }
    
    return $comparison
}

# Function to display results
function Show-ComparisonResults {
    param(
        [string]$PackageName,
        [string]$Version1,
        [string]$Version2,
        [hashtable]$Comparison
    )
    
    Write-Host "`n========================================" -ForegroundColor White
    Write-Host "NuGet Package Dependency Comparison" -ForegroundColor White
    Write-Host "========================================" -ForegroundColor White
    Write-Host "Package: $PackageName" -ForegroundColor Yellow
    Write-Host "Version 1: $Version1" -ForegroundColor Yellow
    Write-Host "Version 2: $Version2" -ForegroundColor Yellow
    Write-Host "========================================`n" -ForegroundColor White
    
    if ($Comparison.AddedPackages.Count -gt 0) {
        Write-Host "ADDED DEPENDENCIES ($($Comparison.AddedPackages.Count)):" -ForegroundColor Green
        foreach ($pkg in ($Comparison.AddedPackages.Keys | Sort-Object)) {
            $version = $Comparison.AddedPackages[$pkg].Version
            Write-Host "  + $pkg : $version" -ForegroundColor Green
        }
        Write-Host ""
    }
    
    if ($Comparison.RemovedPackages.Count -gt 0) {
        Write-Host "REMOVED DEPENDENCIES ($($Comparison.RemovedPackages.Count)):" -ForegroundColor Red
        foreach ($pkg in ($Comparison.RemovedPackages.Keys | Sort-Object)) {
            $version = $Comparison.RemovedPackages[$pkg].Version
            Write-Host "  - $pkg : $version" -ForegroundColor Red
        }
        Write-Host ""
    }
    
    if ($Comparison.ChangedVersions.Count -gt 0) {
        Write-Host "CHANGED DEPENDENCY VERSIONS ($($Comparison.ChangedVersions.Count)):" -ForegroundColor Yellow
        foreach ($pkg in ($Comparison.ChangedVersions.Keys | Sort-Object)) {
            $oldVer = $Comparison.ChangedVersions[$pkg].OldVersion
            $newVer = $Comparison.ChangedVersions[$pkg].NewVersion
            Write-Host "  ~ $pkg : $oldVer -> $newVer" -ForegroundColor Yellow
        }
        Write-Host ""
    }
    
    if ($Comparison.UnchangedPackages.Count -gt 0) {
        Write-Host "UNCHANGED DEPENDENCIES ($($Comparison.UnchangedPackages.Count)):" -ForegroundColor Gray
        foreach ($pkg in ($Comparison.UnchangedPackages.Keys | Sort-Object)) {
            $version = $Comparison.UnchangedPackages[$pkg].Version
            Write-Host "  = $pkg : $version" -ForegroundColor Gray
        }
        Write-Host ""
    }
    
    # Summary
    Write-Host "========================================" -ForegroundColor White
    Write-Host "SUMMARY:" -ForegroundColor White
    Write-Host "  Added: $($Comparison.AddedPackages.Count)" -ForegroundColor Green
    Write-Host "  Removed: $($Comparison.RemovedPackages.Count)" -ForegroundColor Red
    Write-Host "  Changed: $($Comparison.ChangedVersions.Count)" -ForegroundColor Yellow
    Write-Host "  Unchanged: $($Comparison.UnchangedPackages.Count)" -ForegroundColor Gray
    Write-Host "========================================`n" -ForegroundColor White
}

# Main execution
try {
    Write-Host "`nComparing NuGet package dependencies..." -ForegroundColor Cyan
    Write-Host "Package: $PackageName" -ForegroundColor Cyan
    Write-Host "Version 1: $Version1" -ForegroundColor Cyan
    Write-Host "Version 2: $Version2`n" -ForegroundColor Cyan
    
    # Create temporary directory
    $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) "nuget_compare_$([guid]::NewGuid().ToString('N'))"
    New-Item -ItemType Directory -Path $tempDir -Force | Out-Null
    
    Write-Host "Analyzing version $Version1..." -ForegroundColor Cyan
    $deps1 = Get-PackageDependencies -PackageName $PackageName -Version $Version1 -TempDir $tempDir
    
    Write-Host "`nAnalyzing version $Version2..." -ForegroundColor Cyan
    $deps2 = Get-PackageDependencies -PackageName $PackageName -Version $Version2 -TempDir $tempDir
    
    Write-Host "`nComparing dependency trees..." -ForegroundColor Cyan
    $comparison = Compare-DependencyTrees -Tree1 $deps1 -Tree2 $deps2
    
    Show-ComparisonResults -PackageName $PackageName -Version1 $Version1 -Version2 $Version2 -Comparison $comparison
    
    # Clean up
    Remove-Item -Recurse -Force $tempDir -ErrorAction SilentlyContinue
    
    Write-Host "Comparison completed successfully!" -ForegroundColor Green
}
catch {
    Write-Error "An error occurred: $_"
    exit 1
}
