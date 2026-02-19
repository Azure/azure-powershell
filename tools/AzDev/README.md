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
  - [GitHub Helpers](#github-helpers)
    - [Merge PRs](#merge-prs)
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
# Get first 10 modules
PS /> Get-DevModule | Select-Object -First 10

Name             Type          Path
----             ----          ----
Accounts         SdkBased      C:\azure-powershell\src\Accounts
ADDomainServices AutoRestBased C:\azure-powershell\src\ADDomainServices
Advisor          AutoRestBased C:\azure-powershell\src\Advisor
Aks              Hybrid        C:\azure-powershell\src\Aks
AksArc           AutoRestBased C:\azure-powershell\src\AksArc
Alb              AutoRestBased C:\azure-powershell\src\Alb
AlertsManagement Hybrid        C:\azure-powershell\src\AlertsManagement
AnalysisServices SdkBased      C:\azure-powershell\src\AnalysisServices
ApiManagement    SdkBased      C:\azure-powershell\src\ApiManagement
App              AutoRestBased C:\azure-powershell\src\App

# Group all projects by type
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

# Get statistics of autorest v3/v4
PS /> Get-DevProject -Type AutoRestBased | Group-Object -Property SubType

Count Name                      Group
----- ----                      -----
   50 v3                        {Advisor.Autorest, ApplicationInsights.Autorest, ArcResourceBridge.Autorest, Attestation.Autorest…}
  127 v4                        {ADDomainServices.Autorest, Aks.Autorest, AksArc.Autorest, Alb.Autorest…}
```

### Update Assemblies in `src/lib`

`Update-DevAssembly` is used to update the assemblies in the `src/lib` directory. This is useful because it saves you from having to manually download / extract / pick the correct one from the package.

```powershell
# Update the assembly manifest manually, then
Update-DevAssembly
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

### GitHub Helpers

Prerequisite: You need to install [GitHub CLI](https://cli.github.com/) and set up GitHub authentication first with `gh auth login`.

#### Merge PRs

`Merge-DevPullRequest` (alias: `Merge-DevPR`) helps you merge pull requests in the azure-powershell repo. It supports two parameter sets: merging a specific PR by number, and merging all archive PRs.

With the `-AllArchivePR` switch, the cmdlet lists all the matching PRs, ordered by CreatedAt ascending, and prompts you to confirm before merging. Use the `-Force` switch to skip the confirmation. For safety, this parameter set only supports merging PRs with the "[skip ci]" prefix in the title and created by the `azure-powershell-bot` user, which are the archive PRs for generated modules.

The cmdlet returns the list of merged PRs. If any PR fails to merge, an error is thrown and no results are returned.

```powershell
PS C:\> Merge-DevPullRequest -Approve -Number 28690

Do you want to approve and merge the following pull request?
- 28690  [skip ci] Archive e36b0a91ac13ad8c173760dab2d1c038495d41cc
Type Y to approve and merge, N to cancel: Y

No.   Title                                      CreatedBy        CreatedAt                  Url
---   -----                                      ---------        ---------                  ---
28690     [skip ci] Archive e36b0a91ac13ad8c173760dab2d1c038495d41cc        azure-powershell-bot           6/10/2024 2:15:30 PM

PS C:\> Merge-DevPullRequest -Approve -AllArchivePR -Force

No.   Title                                      CreatedBy        CreatedAt                  Url
---   -----                                      ---------        ---------                  ---
28690    [skip ci] Archive e36b0a91ac13ad8c173760dab2d1c038495d41cc        azure-powershell-bot           6/10/2024 2:15:30 PM
28689    [skip ci] Archive deed8db801365cc26557b46c7a8a01d134f0b524             azure-powershell-bot         6/29/2024 11:05:12 AM
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
