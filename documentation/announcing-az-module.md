# Announcing New Module 'Az'
In August 2018 we released a new module, 'Az' which combines the functionality of the AzureRM and AzureRM.Netcore modules.  Az runs on both PowerShell 5.1 and PowerShell Core.  'Az' ensures that the PowerShell and PowerShell Core cmdlets for managing Azure resources will always be in sync and up to date.  In addition, Az will simplify and regularize the naming of Azure cmdlets, and the organization of Azure modules.  Az is intended as a replacement for the AzureRM.Netcore and AzureRM modules.

Az currently ships in CloudShell, and can be found on the PowerShell Gallery [here](https://www.powershellgallery.com/packages/Az/)

Az is a new module, and reorganizing and simplifying cmdlet names involves breaking changes, so we have [added features to Az to make it easier to transition to the simplified, normalized names in your existing scripts](#migrating-from-azurerm). 

## New Features
  - PowerShell 5.1 and PowerShell Core support in the same module
  - PowerShell Core Edition and PowerShell Desktop Edition cmdlets always in sync and up to date with latest Azure capabilities
  - Shortened and Normalized cmdlet names - all cmdlets use the noun prefix 'Az'
  - Normalized module Organization - data plane and management plane cmdlets in the same module for each service
  - Enhanced authentication for Netcore
    * Self-renewing Service Princpal Authentication
    * Service Principal Certificate Authentication (in the future)
  - Enable/Disable-AzureRmAlias cmdlets to manage compatibility with scripts based on AzureRM

## Supported Platforms
  - PowerShell 5.1 with .Net Framework 4.7.2 or later [Windows only]
  - PowerShell Core 6.0 - Windows, Linux, MacOS
  - PowerShell Core 6.1 - Windows, Linux, MacOS

## Timeline
  - Initial Release - August 2018
  - Az at functional parity with AzureRM - November 2018
  - Last version of AzureRM with new Azure features - December 2018
  

## AzureRM Module Support
Azure RM will continue to be supported, and important bugs will be fixed, but new development and new Azure capabilities will be shipped only in Az starting December 2018

## Migrating From AzureRM

To make it easier for existing scripts to migrate from AzureRM to Az, we have provided cmdlets to create aliases that map the cmdlet names in AzureRM into the appropriate cmdlets in Az.  When the aliases are enabled, any script that uses AzureRM cmdlet names should run against Az without modification.

```powershell
PS C:\> Enable-AzureRmAlias
```

will enable Azure RM aliases in the Az module for the current PowerShell session.  For your convenience, we have added a ```Scope``` parameter that will automatically 
set up the AzureRm aliases in Az for every PowerShell session:

```powershell
PC C:\> Enable-AzureRmAlias -Scope CurrentUser
```

Sets up AzureRM cmdlet name aliases in the Az module for all sessions started by the current user, while

```powershell
PS C:\> Enable-AzureRmAlias -Scope LocalMachine
```

Sets up AzureRM Cmdlet aliases in the Az module for all sessions started on this machine for any user.  You can turn aliases off similarly using the ```Disable-AzureRmAlias``` cmdlet

```powershell
PS C:\> Disable-AzureRmAlias
```

Turns off aliases in the current session.  The ```Scope``` parameter allows you to remove the aliases for PowerShell sessions started by the current user

```powershell
PS C:\> Disable-AzureRmAlias -Scope CurrentUser
```

or for all PowerShell sessions:

```powershell
PS C:\> Disable-AzureRmAlias -Scope LocalMachine
```

### Module Name Changes
For scripts that import modules directly, or use ```#Requires``` statements to specify required modules, references to ```AzureRM.*``` will need to be changed to the appropriate ```Az``` module.  A current list of AzureRM modules and their Az equivalents are listed below.  Note that this list is subject to change as module names in Az are updated through November 2018.

| Azure RM Module Name | Az Module Name|
| -------------------------------------- | ------------------------------- |
| AzureRM | Az |
| Azure.AnalysisServices | Az.AnalysisServices |
| Azure.Storage | Az.Storage |
| AzureRM.Aks | Az.Aks |
| AzureRM.AnalysisServices | Az.AnalysisServices |
| AzureRM.ApiManagement | Az.ApiManagement |
| AzureRM.ApplicationInsights | Az.ApplicationInsights* |
| AzureRM.Automation | Az.Automation |
| AzureRM.Backup | Az.Backup***|
| AzureRM.Batch | Az.Batch |
| AzureRM.Billing | Az.Billing |
| AzureRM.Cdn | Az.Cdn |
| AzureRM.CognitiveServices | Az.CognitiveServices |
| AzureRM.Compute | Az.Compute |
| AzureRM.Compute.ManagedService | Az.Compute.ManagedService*** |
| AzureRM.Consumption | Az.Consumption* |
| AzureRM.ContainerInstance | Az.ContainerInstance* |
| AzureRM.ContainerRegistry | Az.ContainerRegistry* |
| AzureRM.DataFactories | Az.DataFactories*** |
| AzureRM.DataFactoryV2 | Az.FataFactoryV2* |
| AzureRM.DataLakeAnalytics | Az.DataLakeAnalytics |
| AzureRM.DataLakeStore | Az.DataLakeStore |
| AzureRM.DataMigration | Az.DataMigration |
| AzureRM.DeviceProvisioningServices | Az.DeviceProvisioningServices* |
| AzureRM.DevSpaces | Az.DevSpaces |
| AzureRM.DevTestLabs | Az.DevTestLabs |
| AzureRM.Dns | Az.Dns |
| AzureRM.EventGrid | Az.EventGrid |
| AzureRM.EventHub | Az.EventHub |
| AzureRM.HDInsight | Az.HDInsight** |
| AzureRM.Insights | Az.Insights* |
| AzureRM.IotHub | Az.IoTHub |
| AzureRM.KeyVault | Az.KeyVault|
| AzureRM.LogicApp | Az.LogicApp*** |
| AzureRM.MachineLearning | Az.MachineLearning |
| AzureRM.MachineLearningCompute | Az.MachineLearningCompute* |
| AzureRM.ManagedServiceIdentity | Az.ManagedServiceIdentity* |
| AzureRM.ManagementPartner | Az.ManagementPartner* |
| AzureRM.Maps | Az.Maps |
| AzureRM.MarketplaceOrdering | Az.MarketplaceOrdering* |
| AzureRM.Media | Az.Media |
| AzureRM.Network | Az.Network* |
| AzureRM.NotificationHubs | Az.NotificationHubs* |
| AzureRM.OperationalInsights | Az.OperationalIsights |
| AzureRM.PolicyInsights | Az.PolicyInsights *|
| AzureRM.PowerBIEmbedded | Az.PowerBIEmbedded* |
| AzureRM.Profile | Az.Profile* |
| AzureRM.RecoveryServices | Az.RecoveryServices**|
| AzureRM.RecoveryServices.Backup | Az.RecoveryServices**|
| AzureRM.RecoveryServices.SiteRecovery | Az.RecoveryServices**|
| AzureRM.RedisCache | Az.RedisCache** |
| AzureRM.Relay | Az.Relay* |
| AzureRM.Reservations | Az.Reservations* |
| AzureRM.Resources | Az. Resources |
| AzureRM.Scheduler | Az.Scheduler*** |
| AzureRM.Search | Az.Search |
| AzureRM.Security | Az.Security* |
| AzureRM.ServiceBus | Az.ServiceBus |
| AzureRM.ServiceFabric | Az.ServiceFabric** |
| AzureRM.SignalR | Az.SignalR |
| AzureRM.Sql | Az.Sql |
| AzureRM.Storage | Az.Storage |
| AzureRM.StorageSync | Az.StorageSync |
| AzureRM.StreamAnalytics | Az.StreamAnalytics |
| AzureRM.Subscription | Az.Subscription* |
| AzureRM.Tags | Az.Tags* |
| AzureRM.TrafficManager | Az.TrafficManager* |
| AzureRM.UsageAggregates | Az.UsageAggregates |
| AzureRM.Websites | Az.Websites |


  ```*``` Module Name may change for 1.0

  ```**``` Module not yet available

  ```***``` Module may not appear in 1.0


### Installing Az and AzureRM Side-by-Side - Discouraged

It is discouraged for AzureRM and Az to be installed on the same machine, but there may be limited circumstances where this is needed for certain older scripts.

If you need to have both modules installed:
- Do not use the Enable-AzureRmAlias cmdlet with -Scope CurrentUser or LocalMachine
- When installing Az on a machine with AzureRM previously installed, you must specify ```AllowClobber``` in the Install-Module cmdlet invocation.

  ```powershell
  PS C:\> Install-Module -Name Az -AllowClobber
  ```

- You cannot load Az and AzureRM modules in the same PowerShell session, but they can be used in seperate sessions as follows
  - In AzureRM session:  ```Import-Module AzureRM```
  - In Az session:  Use cmdlets with Az noun, do not use cmdlets with AzureRM noun


