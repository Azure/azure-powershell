# Migration Guide for Az 1.0.0

This document describes the changes between the 6.x versions of AzureRM and Az version 1.0.0

## Table of Contents
- [General breaking changes](#general-breaking-changes)
  - [Cmdlet Noun Prefix Changes](#cmdlet-noun-prefix-changes)
  - [Module name changes](#module-name-changes)
  - [Removed modules](#removed-modules)
  - [Windows PowerShell 5.1 and .NET 4.7.2](#windows-powershell-51-and-net-framework-472)
  - [Temporary removal of User login using PSCredential](#temporary-removal-of-user-login-using-pscredential)
  - [Default Device Code login instead of Web Browser prompt](#default-device-code-login-instead-of-web-browser-prompt)
- [Module breaking changes](#module-breaking-changes)
  - [Az.ApiManagement (previously AzureRM.ApiManagement)](#azapimanagement-previously-azurermapimanagement)
  - [Az.Billing (previously AzureRM.Billing, AzureRM.Consumption, and AzureRM.UsageAggregates)](#azbilling-previously-azurermbilling-azurermconsumption-and-azurermusageaggregates)
  - [Az.CognitiveServices (previously AzureRM.CognitiveServices)](#azcognitiveservices-previously-azurermcognitiveservices)
  - [Az.Compute (previously AzureRM.Compute)](#azcompute-previously-azurermcompute)
  - [Az.DataFactory (previously AzureRM.DataFactories and AzureRM.DataFactoryV2)](#azdatafactory-previously-azurermdatafactories-and-azurermdatafactoryv2)
  - [Az.DataLakeAnalytics (previously AzureRM.DataLakeAnalytics)](#azdatalakeanalytics-previously-azurermdatalakeanalytics)
  - [Az.DataLakeStore (previously AzureRM.DataLakeStore)](#azdatalakestore-previously-azurermdatalakestore)
  - [Az.KeyVault (previously AzureRM.KeyVault)](#azkeyvault-previously-azurermkeyvault)
  - [Az.Media (previously AzureRM.Media)](#azmedia-previously-azurermmedia)
  - [Az.Monitor (previously AzureRM.Insights)](#azmonitor-previously-azurerminsights)
  - [Az.Network (previously AzureRM.Network)](#aznetwork-previously-azurermnetwork)
  - [Az.OperationalInsights (previously AzureRM.OperationalInsights)](#azoperationalinsights-previously-azurermoperationalinsights)
  - [Az.RecoveryServices (previously AzureRM.RecoveryServices, AzureRM.RecoveryServices.Backup, and AzureRM.RecoveryServices.SiteRecovery)](#azrecoveryservices-previously-azurermrecoveryservices-azurermrecoveryservicesbackup-and-azurermrecoveryservicessiterecovery)
  - [Az.Resources (previously AzureRM.Resources)](#azresources-previously-azurermresources)
  - [Az.ServiceFabric (previously AzureRM.ServiceFabric)](#azservicefabric-previously-azurermservicefabric)
  - [Az.Sql (previously AzureRM.Sql)](#azsql-previously-azurermsql)
  - [Az.Storage (previously Azure.Storage and AzureRM.Storage)](#azstorage-previously-azurestorage-and-azurermstorage)
  - [Az.Websites (previously AzureRM.Websites)](#azwebsites-previously-azurermwebsites)

## General breaking changes
### Cmdlet Noun Prefix Changes
In AzureRM, cmdlets used either 'AzureRM' or 'Azure' as a noun prefix.  Az simplifies and normalizes cmdlet names, so that all cmdlets use 'Az' as their cmdlet noun prefix. 
For example:
```powershell
Get-AzureRmVM
Get-AzureKeyVaultSecret
```

Have changed to
```powershell
Get-AzVM
Get-AzKeyVaultSecret
```

To make the transition to these new cmdlet names simpler, Az introduces two new cmdlets, ```Enable-AzureRmAlias``` and ```Disable-AzureRmAlias```.  ```Enable-AzureRmAlias``` creates aliases from the older cmdlet names in AzureRM to the newer Az cmdlet names.  The cmdlet allows creating aliases in the current session, or across all sessions by changing your user or machine profile. 

For example, the following script in AzureRM:
```powershell
#Requires -Modules AzureRM.Storage
Get-AzureRmStorageAccount | Get-AzureStorageContainer | Get-AzureStorageBlob
```

Could be run with minimal changes using ```Enable-AzureRmAlias```:
```powershell
#Requires -Modules Az.Storage
Enable-AzureRmAlias
Get-AzureRmStorageAccount | Get-AzureStorageContainer | Get-AzureStorageBlob
```

Running ```Enable-AzureRmAlias -Scope CurrentUser``` will enable the aliases for all PowerShell sessions you open, so that after executing this cmdlet, a script like this would not need to be changed at all:
```powershell
Get-AzureRmStorageAccount | Get-AzureStorageContainer | Get-AzureStorageBlob
```

For complete details on the usage of the alias cmdlets, execute ```Get-Help Enable-AzureRmAlias -Online``` from the PowerShell prompt.

```Disable-AzureRmAlias``` removes AzureRM cmdlet aliases created by ```Enable-AzureRmAlias```.  For complete details, execute ```Get-Help Disable-AzureRmAlias -Online``` from the PowerShell prompt.

### Module Name Changes
- The module names have changed from `AzureRM.*` to `Az.*`, except for the following modules:
```
AzureRM.Profile                       -> Az.Accounts
Azure.AnalysisServices                -> Az.AnalysisServices
AzureRM.Consumption                   -> Az.Billing
AzureRM.UsageAggregates               -> Az.Billing
AzureRM.DataFactories                 -> Az.DataFactory
AzureRM.DataFactoryV2                 -> Az.DataFactory
AzureRM.MachineLearningCompute        -> Az.MachineLearning
AzureRM.Insights                      -> Az.Monitor
AzureRM.RecoveryServices.Backup       -> Az.RecoveryServices
AzureRM.RecoveryServices.SiteRecovery -> Az.RecoveryServices
AzureRM.Tags                          -> Az.Resources
Azure.Storage                         -> Az.Storage
```

The changes in module names mean that any script that uses ```#Requires``` or ```Import-Module``` to load specific modules will need to be changed to use the new module instead.

#### Migrating #Requires Statements
Scripts that use #Requires to declare a dependency on AzureRM modules should be updated to use the new module names
```powershell
#Requires -Module AzureRM.Compute
```

Should be changed to
```powershell
#Requires -Module Az.Compute
```

#### Migrating Import-Module Statements
Scripts that use ```Import-Module``` to load AzureRM modules will need to be updated to reflect the new module names.
```powershell
Import-Module -Name AzureRM.Compute
```

Should be changed to
```powershell
Import-Module -Name Az.Compute
```

### Migrating Fully-Qualified Cmdlet Invocations
Scripts that use module-qualified cmdlet invocations, like
```powershell
AzureRM.Compute\Get-AzureRmVM
```

Should be changed to use the new module and cmdlet names
```powershell
Az.Compute\Get-AzVM
```

### Migrating Module Manifest Dependencies
Modules that express dependencies on AzureRM modules through a module manifest (.psd1) file will need to update the module names in their 'RequiredModules' section

```powershell
RequiredModules = @(@{ModuleName="AzureRM.Profile"; ModuleVersion="5.8.2"})
```

Should be changed to

```powershell
RequiredModules = @(@{ModuleName="Az.Accounts"; ModuleVersion="1.0.0"})
```

### Removed modules
- `AzureRM.Backup`
- `AzureRM.Compute.ManagedService`
- `AzureRM.Scheduler`

The tooling for these services are no longer actively supported.  Customers are encouraged to move to alternative services as soon as it is convenient.

### Windows PowerShell 5.1 and .NET Framework 4.7.2
- Using Az with Windows PowerShell 5.1 requires the installation of .NET Framework 4.7.2. However, using Az with PowerShell Core does not require .NET Framework 4.7.2. 

### Temporary removal of User login using PSCredential
- Due to changes in the authentication flow for .NET Standard, we are temporarily removing user login via PSCredential. This capability will be re-introduced in the 1/15/2019 release for Windows PowerShell 5.1. This is discussed in detail in [this issue.](https://github.com/Azure/azure-powershell/issues/7430)

### Default Device Code login instead of Web Browser prompt
- Due to changes in the authentication flow for .NET Standard, we are using device login as the default login flow during interactive login. Web browser based login will be re-introduced for Windows PowerShell 5.1 as the default in the 1/15/2019 release. At that time, users will be able to choose device login using a switch parameter.

## Module breaking changes

### Az.ApiManagement (previously AzureRM.ApiManagement)
- Removing the following cmdlets:
  - New-AzureRmApiManagementHostnameConfiguration
  - Set-AzureRmApiManagementHostnames
  - Update-AzureRmApiManagementDeployment
  - Import-AzureRmApiManagementHostnameCertificate
  - Use **Set-AzApiManagement** cmdlet to set these properties instead
- Following properties were removed
  - Removed property `PortalHostnameConfiguration`, `ProxyHostnameConfiguration`, `ManagementHostnameConfiguration` and `ScmHostnameConfiguration` of type `PsApiManagementHostnameConfiguration` from `PsApiManagementContext`. Instead use `PortalCustomHostnameConfiguration`, `ProxyCustomHostnameConfiguration`, `ManagementCustomHostnameConfiguration` and `ScmCustomHostnameConfiguration` of type `PsApiManagementCustomHostNameConfiguration`.
  - Removed property `StaticIPs` from PsApiManagementContext. The property has been split into `PublicIPAddresses` and `PrivateIPAddresses`.
  - Removed required property `Location` from New-AzureApiManagementVirtualNetwork cmdlet.

### Az.Billing (previously AzureRM.Billing, AzureRM.Consumption, and AzureRM.UsageAggregates)
- The `InvoiceName` parameter was removed from the `Get-AzConsumptionUsageDetail` cmdlet.  Scripts will need to use other identity parameters for the invoice.

### Az.CognitiveServices (previously AzureRM.CognitiveServices)
- Removed `GetSkusWithAccountParamSetName` parameter set from `Get-AzCognitiveServicesAccountSkus` cmdlet.  You must get Skus by Account Type and Location, instead of using ResourceGroupName and Account Name.

### Az.Compute (previously AzureRM.Compute)
- `IdentityIds` are removed from `Identity` property in `PSVirtualMachine` and `PSVirtualMachineScaleSet` objects.
  Scripts should no longer use the value of this field to make processing decisions.
- The type of `InstanceView` property of `PSVirtualMachineScaleSetVM` object is changed from `VirtualMachineInstanceView` to `VirtualMachineScaleSetVMInstanceView`
- `AutoOSUpgradePolicy` and `AutomaticOSUpgrade` properties are removed from `UpgradePolicy` property
- The type of `Sku` property in `PSSnapshotUpdate` object is changed from `DiskSku` to `SnapshotSku`
- `VmScaleSetVMParameterSet` is removed from `Add-AzVMDataDisk` cmdlet, you can no longer add a data disk individually to a ScaleSet VM.

### Az.DataFactory (previously AzureRM.DataFactories and AzureRM.DataFactoryV2)
- The `GatewayName` parameter has become mandatory in the `New-AzDataFactoryEncryptValue` cmdlet
- Removed `New-AzDataFactoryGatewayKey` cmdlet
- Removed `LinkedServiceName` parameter from `Get-AzDataFactoryV2ActivityRun` cmdlet.
  Scripts should no longer use the value of this field to make processing decisions.

### Az.DataLakeAnalytics (previously AzureRM.DataLakeAnalytics)
- Removed deprecated cmdlets: `New-AzDataLakeAnalyticsCatalogSecret`, `Remove-AzDataLakeAnalyticsCatalogSecret`, and `Set-AzDataLakeAnalyticsCatalogSecret`

### Az.DataLakeStore (previously AzureRM.DataLakeStore)
- The following cmdlets have had the `Encoding` parameter changed from the type `FileSystemCmdletProviderEncoding` to `System.Text.Encoding`. This change removes the encoding values `String` and `Oem`. All the other prior encoding values remain.
  - New-AzureRmDataLakeStoreItem
  - Add-AzureRmDataLakeStoreItemContent
  - Get-AzureRmDataLakeStoreItemContent
- Removed deprecated `Tags` property alias from `New-AzDataLakeStoreAccount` and `Set-AzDataLakeStoreAccount` cmdlets

  Scripts using
  ```powershell
  New-AzureRMDataLakeStoreAccount -Tags @{TagName="TagValue"}
  ```

  Should be changed to
  ```powershell
  New-AzDataLakeStoreAccount -Tag @{TagName="TagValue"}
  ```

- Removed deprecated properties ```Identity```, ```EncryptionState```, ```EncryptionProvisioningState```, ```EncryptionConfig```, ```FirewallState```, ```FirewallRules```, ```VirtualNetworkRules```, ```TrustedIdProviderState```, ```TrustedIdProviders```, ```DefaultGroup```, ```NewTier```, ```CurrentTier```, ```FirewallAllowAzureIps``` from ```PSDataLakeStoreAccountBasic``` object.  Any script that 
uses the ```PSDatalakeStoreAccount``` returned from ```Get-AzDataLakeStoreAccount``` should not reference these properties.

### Az.KeyVault (previously AzureRM.KeyVault)
- The `PurgeDisabled` property was removed from the `PSKeyVaultKeyAttributes`, `PSKeyVaultKeyIdentityItem`, and `PSKeyVaultSecretAttributes` objects.
  Scripts should no longer reference the ```PurgeDisabled``` property to make processing decisions.

### Az.Media (previously AzureRM.Media)
- Remove deprecated `Tags` property alias from `New-AzMediaService` cmdlet
  Scripts using
  ```powershell
  New-AzureRMMediaService -Tags @{TagName="TagValue"}
  ```

  Should be changed to
  ```powershell
  New-AzMMediaService -Tag @{TagName="TagValue"}
  ```
### Az.Monitor (previously AzureRM.Insights)
- Removed plural names `Categories` and `Timegrains` parameter in favor of singular parameter names from `Set-AzDiagnosticSetting` cmdlet.
  Scripts using
  ```powershell
  Set-AzureRmDiagnosticSetting -Timegrains PT1M -Categories Category1, Category2
  ```

  Should be changed to
  ```powershell
  Set-AzDiagnosticSetting -Timegrain PT1M -Category Category1, Category2
  ```
### Az.Network (previously AzureRM.Network)
- Removed deprecated `ResourceId` parameter from `Get-AzServiceEndpointPolicyDefinition` cmdlet
- Removed deprecated `EnableVmProtection` property from `PSVirtualNetwork` object
- Removed deprecated `Set-AzVirtualNetworkGatewayVpnClientConfig` cmdlet
  
Scripts should no longer make processing decisions based on the values for these fields.

### Az.OperationalInsights (previously AzureRM.OperationalInsights)
- Default parameter set for `Get-AzOperationalInsightsDataSource` is removed, and `ByWorkspaceNameByKind` has become the default parameter set

  Scripts that listed data sources using
  ```powershell
  Get-AzureRmOperationalInsightsDataSource
  ```

  Should be changed to specify a Kind
  ```powershell
  Get-AzOperationalInsightsDataSource -Kind AzureActivityLog
  ```

### Az.RecoveryServices (previously AzureRM.RecoveryServices, AzureRM.RecoveryServices.Backup, and AzureRM.RecoveryServices.SiteRecovery)
- Removed `Encryption` parameter from `New/Set-AzRecoveryServicesAsrPolicy` cmdlets
- `TargetStorageAccountName` parameter is now mandatory for managed disk restores in `Restore-AzRecoveryServicesBackupItem` cmdlet
- Removed `StorageAccountName` and `StorageAccountResourceGroupName` parameters in `Restore-AzRecoveryServicesBackupItem` cmdlet for Azure File Share restore
- Removed `Name`parameter in `Get-AzRecoveryServicesBackupContainer` cmdlet

### Az.Resources (previously AzureRM.Resources)
- Removed `Sku` parameter from `New/Set-AzPolicyAssignment` cmdlets
- Removed `Password` parameter from `New-AzADServicePrincipal` and `New-AzADSpCredential` cmdlets.
  Passwords are automatically generated, scripts that provided the password:
  ```powershell
  New-AzAdSpCredential -ObjectId 1f99cf81-0146-4f4e-beae-2007d0668476 -Password $secPassword
  ```

  Should be changed to retrieve the password from the output:
  ```powershell
  $credential = New-AzAdSpCredential -ObjectId 1f99cf81-0146-4f4e-beae-2007d0668476
  $secPassword = $credential.Secret
  ```

### Az.ServiceFabric (previously AzureRM.ServiceFabric)
- The following cmdlet return types have been changed:
  - The property `ServiceTypeHealthPolicies` of type `ApplicationHealthPolicy` has been removed.
  - The property `ApplicationHealthPolicies` of type `ClusterUpgradeDeltaHealthPolicy` has been removed.
  - The property `OverrideUserUpgradePolicy` of type `ClusterUpgradePolicy` has been removed.
  - These changes affect the following cmdlets:
    - Add-AzServiceFabricClientCertificate
    - Add-AzServiceFabricClusterCertificate
    - Add-AzServiceFabricNode
    - Add-AzServiceFabricNodeType
    - Get-AzServiceFabricCluster
    - Remove-AzServiceFabricClientCertificate
    - Remove-AzServiceFabricClusterCertificate
    - Remove-AzServiceFabricNode
    - Remove-AzServiceFabricNodeType
    - Remove-AzServiceFabricSetting
    - Set-AzServiceFabricSetting
    - Set-AzServiceFabricUpgradeType
    - Update-AzServiceFabricDurability
    - Update-AzServiceFabricReliability

### Az.Sql (previously AzureRM.Sql)
- Removed `State` and `ResourceId` parameters from `Set-AzSqlDatabaseBackupLongTermRetentionPolicy` cmdlet
- Removed deprecated cmdlets: `Get/Set-AzSqlServerBackupLongTermRetentionVault`, `Get/Start/Stop-AzSqlServerUpgrade`, `Get/Set-AzSqlDatabaseAuditingPolicy`, `Get/Set-AzSqlServerAuditingPolicy`, `Remove-AzSqlDatabaseAuditing`, `Remove-AzSqlServerAuditing`
- Removed deprecated parameter `Current` from `Get-AzSqlDatabaseBackupLongTermRetentionPolicy` cmdlet
- Removed deprecated parameter `DatabaseName` from `Get-AzSqlServerServiceObjective` cmdlet
- Removed deprecated parameter `PrivilegedLogin` from `Set-AzSqlDatabaseDataMaskingPolicy` cmdlet

### Az.Storage (previously Azure.Storage and AzureRM.Storage)
- To support creating an OAuth storage context with only the storage account name, the default parameter set has been changed to `OAuthParameterSet`
  - Example: `$ctx = New-AzStorageContext -StorageAccountName $accountName`
- The `Location` parameter has become mandatory in the `Get-AzStorageUsage` cmdlet
- The Storage API methods now use the Task-based Asynchronous Pattern (TAP), instead of synchronous API calls.
#### 1. Blob Snapshot
##### Before:
```powershell
$b = Get-AzureStorageBlob -Container $containerName -Blob $blobName -Context $ctx
$b.ICloudBlob.Snapshot()
```

##### After:
```powershell
$b = Get-AzStorageBlob -Container $containerName -Blob $blobName -Context $ctx
$task = $b.ICloudBlob.SnapshotAsync()
$task.Wait()
$snapshot = $task.Result
```

#### 2. Share Snapshot
##### Before:
```powershell
$Share = Get-AzureStorageShare -Name $containerName -Context $ctx
$snapshot = $Share.Snapshot()
```
#####  After:
```powershell

$Share = Get-AzStorageShare -Name $containerName -Context $ctx
$task = $Share.SnapshotAsync()
$task.Wait()
$snapshot = $task.Result
```

#### 3. Undelete a soft delete blob
##### Before:
```powershell
$b = Get-AzureStorageBlob -Container $containerName -Blob $blobName -IncludeDeleted -Context $ctx
$b.ICloudBlob.Undelete()
```
##### After:
```powershell
$b = Get-AzStorageBlob -Container $containerName -Blob $blobName -IncludeDeleted -Context $ctx
$task = $b.ICloudBlob.UndeleteAsync()
$task.Wait()
```

#### 4. Set Blob Tier
##### Before:
```powershell
$blockBlob = Get-AzureStorageBlob -Container $containerName -Blob $blockBlobName -Context $ctx
$blockBlob.ICloudBlob.SetStandardBlobTier("hot")

$pageBlob = Get-AzureStorageBlob -Container $containerName -Blob $pageBlobName -Context $ctx
$pageBlob.ICloudBlob.SetPremiumBlobTier("P4")
```

##### After:
```powershell
$blockBlob = Get-AzStorageBlob -Container $containerName -Blob $blockBlobName -Context $ctx
$task = $blockBlob.ICloudBlob.SetStandardBlobTierAsync("hot")
$task.Wait()

$pageBlob = Get-AzStorageBlob -Container $containerName -Blob $pageBlobName -Context $ctx
$task = $pageBlob.ICloudBlob.SetPremiumBlobTierAsync("P4")
$task.Wait()
```

### Az.Websites (previously AzureRM.Websites)
- Removed deprecated properties from the `PSAppServicePlan`, `PSCertificate`, `PSCloningInfo`, and `PSSite` objects
