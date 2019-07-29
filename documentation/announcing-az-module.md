# Announcing New Module 'Az'
In August 2018 we released a new module, 'Az' which combines the functionality of the AzureRM and AzureRM.Netcore modules.  Az will go to version 1.0 on 12/18/2018. Az runs on both Windows PowerShell 5.1 and PowerShell Core.  'Az' ensures that the Windows PowerShell and PowerShell Core cmdlets for managing Azure resources will always be in sync and up to date.  In addition, Az will simplify and regularize the naming of Azure cmdlets, and the organization of Azure modules.  Az is intended as a replacement for the AzureRM.Netcore and AzureRM modules.

Az currently ships in Cloud Shell, and can be found on the PowerShell Gallery [here](https://www.powershellgallery.com/packages/Az/)

Az is a new module, and reorganizing and simplifying cmdlet names involves breaking changes, so we have [added features to Az to make it easier to transition to the simplified, normalized names in your existing scripts](#migrating-from-azurerm). 

## New Features
  - Windows PowerShell 5.1 and PowerShell Core support in the same module
  - PowerShell Core and Windows PowerShell cmdlets are always in sync and up to date with latest Azure capabilities
  - Shortened and normalized cmdlet names - all cmdlets use the noun prefix 'Az'
  - Simplified and normalized module organization - data plane and management plane cmdlets in the same module for each service
  - Enhanced authentication for Netcore
    * Self-renewing Service Principal Authentication
    * Service Principal Certificate Authentication (in the future)
  - Enable/Disable-AzureRmAlias cmdlets to manage compatibility with scripts based on AzureRM

## Supported Platforms
  - PowerShell 5.1 with .Net Framework 4.7.2 or later [Windows only]
  - PowerShell Core 6.0 - Windows, Linux, macOS
  - PowerShell Core 6.1 - Windows, Linux, macOS

## Timeline

| Date | Feature |
-------|----------
| **August 2018** | Initial Release |
| **November 2018** | Functional parity with AzureRM |
| **December 2018** | Az 1.0 Release |
| **January 2019** | New Authentication mechanisms for Windows PowerShell
|  | - Username + password authentication
|  | - Web browser control authentication |

 

## AzureRM Module Support
AzureRM will continue to be supported, and important bugs will be fixed, but new development and new Azure capabilities will be shipped only in Az starting December 2018.

## Authentication Changes
   - ADAL has limited support for the "not recommended" user credential non-interactive auth flow.
     - Connect-AzAccount in Az 1.0 will not accept PSCredential, but will support this for Windows PowerShell only in Az 1.1.0 (January 15, 2019)
     - Here are a couple issues that describe why ADAL has limited this support   
        - [Azure ActiveDirectory UserPasswordCredential doesn't support .NET core](https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/issues/482#issuecomment-262256236)
        - [Connect-AzureRmAccount with user credential login does not work in Az](https://github.com/Azure/azure-powershell/issues/7430#issuecomment-426480499)

  - Service Principal improvements
    - Self-renewing Service Principal Authentication
    - Service Principal Certificate Authentication (in the future)
  - Device Auth Flow
  - Future Improvements
    - [Interactive user credential login in az](https://github.com/Azure/azure-powershell/issues/7358)


## Migrating From AzureRM

To make it easier for existing scripts to migrate from AzureRM to Az, we have provided cmdlets to create aliases that map the cmdlet names in AzureRM into the appropriate cmdlets in Az.  When the aliases are enabled, any script that uses AzureRM cmdlet names should run against Az without modification.

Note: Connect-AzAccount aka Connect-AzureRmAccount no does not ```PSCredential``` in version 1.0, but will in version 1.1. See [Authentication Changes](#authentication-changes) for more details

```powershell
PS C:\> Enable-AzureRmAlias
```

will enable AzureRM aliases in the Az module for the current PowerShell session.  For your convenience, we have added a ```Scope``` parameter that will automatically set up the AzureRM aliases in Az for every PowerShell session:

```powershell
PC C:\> Enable-AzureRmAlias -Scope CurrentUser
```

Sets up AzureRM cmdlet name aliases in the Az module for all sessions started by the current user, while

```powershell
PS C:\> Enable-AzureRmAlias -Scope LocalMachine
```

sets up AzureRM cmdlet aliases in the Az module for all sessions started on this machine for any user. You can turn aliases off similarly using the ```Disable-AzureRmAlias``` cmdlet

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
For scripts that import modules directly, or use ```#Requires``` statements to specify required modules, references to ```AzureRM.*``` will need to be changed to the appropriate ```Az``` module.  A current list of AzureRM modules and their Az equivalents are listed below.

| AzureRM Module Name | Az Module Name|
| -------------------------------------- | ------------------------------- |
| AzureRM | Az |
| Azure.AnalysisServices | Az.AnalysisServices |
| **Azure.Storage** | **Az.Storage** |
| AzureRM.Aks | Az.Aks |
| AzureRM.AnalysisServices | Az.AnalysisServices |
| AzureRM.ApiManagement | Az.ApiManagement |
| AzureRM.ApplicationInsights | Az.ApplicationInsights |
| AzureRM.Automation | Az.Automation |
| ~~AzureRM.Backup~~ | **REMOVED** |
| AzureRM.Batch | Az.Batch |
| AzureRM.Billing | Az.Billing |
| AzureRM.Cdn | Az.Cdn |
| AzureRM.CognitiveServices | Az.CognitiveServices |
| AzureRM.Compute | Az.Compute |
| ~~AzureRM.Compute.ManagedService~~ | **REMOVED** |
| **AzureRM.Consumption** | **Az.Billing** |
| AzureRM.ContainerInstance | Az.ContainerInstance |
| AzureRM.ContainerRegistry | Az.ContainerRegistry |
| **AzureRM.DataFactories** | **Az.DataFactory** |
| **AzureRM.DataFactoryV2** | **Az.DataFactory** |
| AzureRM.DataLakeAnalytics | Az.DataLakeAnalytics |
| AzureRM.DataLakeStore | Az.DataLakeStore |
| AzureRM.DataMigration | Az.DataMigration |
| AzureRM.DeviceProvisioningServices | Az.DeviceProvisioningServices |
| AzureRM.DevSpaces | Az.DevSpaces |
| AzureRM.DevTestLabs | Az.DevTestLabs |
| AzureRM.Dns | Az.Dns |
| AzureRM.EventGrid | Az.EventGrid |
| AzureRM.EventHub | Az.EventHub |
| AzureRM.HDInsight | Az.HDInsight |
| **AzureRM.Insights** | **Az.Monitor** |
| AzureRM.IotHub | Az.IoTHub |
| AzureRM.KeyVault | Az.KeyVault |
| AzureRM.LogicApp | Az.LogicApp |
| AzureRM.MachineLearning | Az.MachineLearning |
| **AzureRM.MachineLearningCompute** | **Az.MachineLearning** |
| AzureRM.ManagedServiceIdentity | Az.ManagedServiceIdentity |
| AzureRM.ManagementPartner | Az.ManagementPartner |
| AzureRM.Maps | Az.Maps |
| AzureRM.MarketplaceOrdering | Az.MarketplaceOrdering |
| AzureRM.Media | Az.Media |
| AzureRM.Network | Az.Network |
| AzureRM.NotificationHubs | Az.NotificationHubs |
| AzureRM.OperationalInsights | Az.OperationalInsights |
| AzureRM.PolicyInsights | Az.PolicyInsights |
| AzureRM.PowerBIEmbedded | Az.PowerBIEmbedded* |
| **AzureRM.Profile** | **Az.Accounts** |
| AzureRM.RecoveryServices | Az.RecoveryServices |
| **AzureRM.RecoveryServices.Backup** | **Az.RecoveryServices** |
| **AzureRM.RecoveryServices.SiteRecovery**| **Az.RecoveryServices** |
| AzureRM.RedisCache | Az.RedisCache |
| AzureRM.Relay | Az.Relay |
| AzureRM.Reservations | Az.Reservations |
| AzureRM.Resources | Az. Resources |
| ~~AzureRM.Scheduler~~ | **REMOVED** |
| AzureRM.Search | Az.Search |
| AzureRM.Security | Az.Security |
| AzureRM.ServiceBus | Az.ServiceBus |
| AzureRM.ServiceFabric | Az.ServiceFabric |
| AzureRM.SignalR | Az.SignalR |
| AzureRM.Sql | Az.Sql |
| AzureRM.Storage | Az.Storage |
| AzureRM.StorageSync | Az.StorageSync |
| AzureRM.StreamAnalytics | Az.StreamAnalytics |
| AzureRM.Subscription | Az.Subscription |
| **AzureRM.Tags** | **Az.Resources** |
| AzureRM.TrafficManager | Az.TrafficManager |
| AzureRM.UsageAggregates | Az.UsageAggregates |
| AzureRM.Websites | Az.Websites |


### Installing Az and AzureRM Side-by-Side

Az and AzureRM cannot be imported side-by-side into the same PowerShell session.  If you do not want to migrate your scripts from AzureRM to Az right away, there are two main options:
- Install Az in PowerShell Core, and leave AzureRM in Windows PowerShell
- Install Az and AzureRM side-by-side in Windows PowerShell and ensure scripts do not mix the modules

#### Install Az in PowerShell Core
You can follow the instructions in [Installing PowerShell Core on Windows](https://docs.microsoft.com/powershell/scripting/install/installing-powershell-core-on-windows?view=powershell-6
) to install PowerShell Core, then use ```Install-Module Az``` in PowerShell Core to acquire the Az module.  Since Windows PowerShell and PowerShell Core can exist side-by-side and do not share module directories, this will effectively isolate the two modules.

#### Install Az and AzureRM Side-by-Side
If you need to have both modules installed:
- Do not use the Enable-AzureRmAlias cmdlet with -Scope CurrentUser or LocalMachine
- When installing Az on a machine with AzureRM previously installed, you must specify ```AllowClobber``` in the Install-Module cmdlet invocation.

  ```powershell
  PS C:\> Install-Module -Name Az -AllowClobber
  ```

##### Interactive Usage
You cannot load Az and AzureRM modules in the same PowerShell session, but they can be used in separate sessions as follows
  - In AzureRM session:  ```Import-Module AzureRM```
  - In Az session:  Begin the session with ```Enable-AzureRmAlias```, which will prevent inadvertently loading AzureRM modules.  Alternately, you can use cmdlets with Az noun prefix, and avoid using cmdlets with Azure or AzureRm noun

##### Usage in Scripts

Declare the modules used in your script at the beginning of your script.
- For Az:
  ```powershell
  #Requires -Modules Az.Accounts, Az.Storage, Az.Compute
  ```

- For AzureRM:
  ```powershell
  #Requires -Modules AzureRM.Profile, AzureRM.Storage, Azure.Storage, AzureRM.Compute
  ```


