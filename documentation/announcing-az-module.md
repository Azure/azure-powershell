# Announcing new Module Az
On DATE we released a new module, 'Az' which combines the functionality of the AzureRM and AzureRM.Netcore modules.  Az runs on both PowerShell 5.1 and PowerShell Core.  Az ensure that the PowerShell and PowerShell core cmdlets for managing Azure resources will always be in sync and up to date.  In addition, Az also will also simplify and regularize the naming of Azure cmdlets, and the organization of Azure modules.

Az is a new module, and reorganizing and simplifying cmdlet names involves breaking changes, so we have added features to Az to make it easier to transition to the simplified, normalized names in your existing scripts.

## New Features
  - PowerShell and PowerShell Core support in the same module
  - PowerShell Core and PowerShell cmdlets always in sync and up to date with latest Azure capabilities
  - Shortened and Normalized cmdlet names - all cmdlets use the noun 'Az'
  - Normalized module Organization - data plane and management plane cmdlets in the same module
  - Enhanced authentication for Netcore

## Suppoted Platforms
  - PowerShell 5.1 with .Net Framework 4.7.2 or later [WIndows only]
  - PowerShell Core 6.0 - Windows, linux, MacOS
  - PowerShell Core 6.1 - Windows, linux, MacOS

## Timeline
  - Initial Release - DATE
  - AzureRM.Netcore deprecation - DATE
  - Az at functional parity with AzureRM
  - Last  version of AzureRM with new Azure features
  - Azure RM support

## AzureRM Obsolescence
Azure RM will continue to be supported, but new development and new Azure capabilities will be shipped only in Az starting DATE

## Migrating From AzureRM

### Migrating scripts

To make it easier for existing scripts to migraet to AzureRM, we have provided cmdlets to create aliases that map AzureRM cmdlet names to the appropriate

### Side by Side Execution

It is discouraged for AzureRM and Az to be installed on the same machine, but there may be limited circumstances where this is needed for certain older scripts.

If you need to have both module installed:
- Do not use the Enable-AzureRmAlias cmdlet with -Scope CurrentUser ot LocalMachine
- You cannot load Az and AzureRM modules in the same PowerShell session, but they can be used in seperate sessions as follows
  - 
  - 


