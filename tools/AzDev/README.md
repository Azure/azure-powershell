# AzDev - developer module for Azure PowerShell

This module is designed to help developers of Azure PowerShell modules. It provides tools to assist development, troubleshooting issues, etc.

All the cmdlets in this module are prefixed with `Dev-` to avoid conflicts with other modules.

Like many other tools, this module targets `net8.0` so always run it in PowerShell 7.2 or later.

- [Quick start](#quick-start)
- [Features](#features)
  - [Repo inventory](#repo-inventory)
  - [Update Assemblies in `src/lib`](#update-assemblies-in-srclib)
  - [Connect azure-powershell and azure-powershell-common](#connect-azure-powershell-and-azure-powershell-common)
  - [Autorest helper](#autorest-helper)
    - [Open swagger online](#open-swagger-online)
- [Development](#development)
  - [Design](#design)
  - [Testing](#testing)

## Quick start

```powershell
# build the module
./tools/AzDev/build.ps1
# import the module
Import-Module ./artifacts/AzDev/AzDev.psd1
# set up the context (only once)
Set-DevContext -RepoRoot 'C:\repos\azure-powershell'
```

## Features

### Repo inventory

`Get-DevModule` and `Get-DevProject` are the main cmdlets to get the inventory of the repo.

```powershell
PS /> Get-DevModule | Select-Object -First 10

Name                 Type          Path
----                 ----          ----
Maps                 AutoRestBased /Users/azps/workspace/azure-powershell/src/Maps
Kusto                AutoRestBased /Users/azps/workspace/azure-powershell/src/Kusto
StorageMover         AutoRestBased /Users/azps/workspace/azure-powershell/src/StorageMover
ResourceGraph        Hybrid        /Users/azps/workspace/azure-powershell/src/ResourceGraph
Terraform            AutoRestBased /Users/azps/workspace/azure-powershell/src/Terraform
PostgreSql           AutoRestBased /Users/azps/workspace/azure-powershell/src/PostgreSql
SpringCloud          AutoRestBased /Users/azps/workspace/azure-powershell/src/SpringCloud
ManagedNetworkFabric AutoRestBased /Users/azps/workspace/azure-powershell/src/ManagedNetworkFabric
ServiceBus           Hybrid        /Users/azps/workspace/azure-powershell/src/ServiceBus
Mdp                  AutoRestBased /Users/azps/workspace/azure-powershell/src/Mdp

PS /> Get-DevProject | Group-Object -Property Type | Select-Object -Property Name,Count | Sort-Object -Property Count -Descending

Name          Count
----          -----
AutoRestBased   163
Wrapper         127
SdkBased         76
Test             70
Track1Sdk        48
Other             8
LegacyHelper      4
```

### Update Assemblies in `src/lib`

`Update-DevDependency` is used to update the assemblies in the `src/lib` directory. This is useful because it saves you from having to manually download / extract / pick the correct one from the package.

```powershell
# Update the assembly manifest manually, then
Update-DevDependency
# Check in all the changes
```

### Connect azure-powershell and azure-powershell-common

Help you connect the azure-powershell and azure-powershell-common repositories for developing or debugging.

```powershell
# Connect
Connect-DevCommonRepo

# Disconnect
Disconnect-DevCommonRepo
```

### Autorest helper

#### Open swagger online

`Open-DevSwagger` opens the online version of the specified swagger file. It's useful when you want to quickly check the structure of a swagger file.

```powershell
PS /> Open-DevSwagger workloads
Multiple projects matching [workloads]
  1: SapVirtualInstance.Autorest
  2: Monitors.Autorest
Enter the number corresponding to your selection
1
Multiple swagger references found in [SapVirtualInstance.Autorest]
  1: $(repo)/specification/workloads/resource-manager/Microsoft.Workloads/SAPVirtualInstance/readme.md
  2: $(repo)/specification/workloads/resource-manager/readme.powershell.md
Enter the number corresponding to your selection
1
Opening https://github.com/Azure/azure-rest-api-specs/blob/202321f386ea5b0c103b46902d43b3d3c50e029c/specification/workloads/resource-manager/Microsoft.Workloads/SAPVirtualInstance/readme.md in default browser...
```

## Development

### Design

`AzDev` supports both C# based and script based cmdlets.

The script based cmdlets are located in the `AzDev` folder. Take a look at `AzDev/CommonRepo.psm1` for example. Update `NestedModules` in `AzDev.psd1` when you add new scripts.

The C# based cmdlets are located in the `src` folder. It's quite similar to developing a SDK-based module in Azure PowerShell.

Either way, make sure

1. All cmdlets are prefixed with `Dev-`.
2. Add your new cmdlets to `FunctionsToExport` or `CmdletsToExport` in `AzDev.psd1`.

### Testing

Use `dotnet test` to run the unit tests. `Invoke-Pester` to run the E2E tests located in `Tests/PSTests`.
