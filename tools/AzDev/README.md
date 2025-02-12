# AzDev - developer module for Azure PowerShell

This module is designed to help developers of Azure PowerShell modules. It provides tools to assist development, troubleshooting issues, etc.

All the cmdlets in this module are prefixed with `Dev-` to avoid conflicts with other modules.

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

### Connect azure-powershell and azure-powershell-common

Help you connect the azure-powershell and azure-powershell-common repositories for developing or debugging.

```powershell
# Connect
Connect-CommonRepo

# Disconnect
Disconnect-CommonRepo
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