# Migration Guide for Az 5.0.0

This document describes the changes between the 4.0.0 and 5.0.0 versions of Az.

- [Migration Guide for Az 5.0.0](#migration-guide-for-az-500)
  - [Az.Aks](#azaks)
    - [New-AzAksCluster](#new-azakscluster)
    - [Set-AzAksCluster](#set-azakscluster)
  - [Az.ContainerRegistry](#azcontainerregistry)
    - [New-AzContainerRegistry](#new-azcontainerregistry)
  - [Az.Functions](#azfunctions)
    - [Get-AzFunctionApp](#get-azfunctionapp)
    - [New-AzFunctionApp](#new-azfunctionapp)
  - [Az.KeyVault](#azkeyvault)
    - [New-AzKeyVault](#new-azkeyvault)
    - [Update-AzKeyVault](#update-azkeyvault)
    - [Get-AzKeyVaultSecret](#get-azkeyvaultsecret)
  - [Az.ManagedServices](#azmanagedservices)
    - [Get-AzManagedServicesDefinition](#get-azmanagedservicesdefinition)
    - [New-AzManagedServicesAssignment](#new-azmanagedservicesassignment)
    - [Remove-AzManagedServicesAssignment](#remove-azmanagedservicesassignment)
    - [Remove-AzManagedServicesDefinition](#remove-azmanagedservicesdefinition)
  - [Az.ResourceManager](#azresourcemanager)
    - [Get-AzManagementGroupDeployment](#get-azmanagementgroupdeployment)
    - [Get-AzManagementGroupDeploymentOperation](#get-azmanagementgroupdeploymentoperation)
    - [Get-AzDeployment](#get-azdeployment)
    - [Get-AzDeploymentOperation](#get-azdeploymentoperation)
    - [Get-AzDeploymentWhatIfResult](#get-azdeploymentwhatifresult)
    - [Get-AzTenantDeployment](#get-aztenantdeployment)
    - [Get-AzTenantDeploymentOperation](#get-aztenantdeploymentoperation)
    - [New-AzManagementGroupDeployment](#new-azmanagementgroupdeployment)
    - [New-AzDeployment](#new-azdeployment)
    - [New-AzTenantDeployment](#new-aztenantdeployment)
    - [Remove-AzManagementGroupDeployment](#remove-azmanagementgroupdeployment)
    - [Remove-AzDeployment](#remove-azdeployment)
    - [Remove-AzTenantDeployment](#remove-aztenantdeployment)
    - [Save-AzManagementGroupDeploymentTemplate](#save-azmanagementgroupdeploymenttemplate)
    - [Save-AzDeploymentTemplate](#save-azdeploymenttemplate)
    - [Save-AzTenantDeploymentTemplate](#save-aztenantdeploymenttemplate)
    - [Stop-AzManagementGroupDeployment](#stop-azmanagementgroupdeployment)
    - [Stop-AzDeployment](#stop-azdeployment)
    - [Stop-AzTenantDeployment](#stop-aztenantdeployment)
    - [Test-AzManagementGroupDeployment](#test-azmanagementgroupdeployment)
    - [Test-AzDeployment](#test-azdeployment)
    - [Test-AzTenantDeployment](#test-aztenantdeployment)
    - [Get-AzResourceGroupDeployment](#get-azresourcegroupdeployment)
    - [Get-AzResourceGroupDeploymentOperation](#get-azresourcegroupdeploymentoperation)
    - [Get-AzResourceGroupDeploymentWhatIfResult](#get-azresourcegroupdeploymentwhatifresult)
    - [New-AzResourceGroupDeployment](#new-azresourcegroupdeployment)
    - [Remove-AzResourceGroupDeployment](#remove-azresourcegroupdeployment)
    - [Save-AzResourceGroupDeploymentTemplate](#save-azresourcegroupdeploymenttemplate)
    - [Stop-AzResourceGroupDeployment](#stop-azresourcegroupdeployment)
    - [Test-AzResourceGroupDeployment](#test-azresourcegroupdeployment)
    - [Get-AzManagementGroupDeploymentWhatIfResult](#get-azmanagementgroupdeploymentwhatifresult)
    - [Get-AzTenantDeploymentWhatIfResult](#get-aztenantdeploymentwhatifresult)
  - [Az.Sql](#azsql)
    - [Set-AzSqlServerActiveDirectoryAdministrator](#set-azsqlserveractivedirectoryadministrator)
  - [Az.Synapse](#azsynapse)
    - [New-AzSynapseSqlPool](#new-azsynapsesqlpool)
    - [Update-AzSynapseSqlPool](#update-azsynapsesqlpool)
  - [Az.Network](#aznetwork)
    - [Approve-AzPrivateEndpointConnection](#approve-azprivateendpointconnection)
    - [Deny-AzPrivateEndpointConnection](#deny-azprivateendpointconnection)
    - [Get-AzPrivateEndpointConnection](#get-azprivateendpointconnection)
    - [Remove-AzPrivateEndpointConnection](#remove-azprivateendpointconnection)
    - [Set-AzPrivateEndpointConnection](#set-azprivateendpointconnection)
    - [New-AzNetworkWatcherConnectionMonitorEndpointObject](#new-aznetworkwatcherconnectionmonitorendpointobject)

## Az.Aks

### New-AzAksCluster

- No longer supports the parameter `NodeOsType` and no alias was found for the original parameter
  name, it will always be `Linux`.
- No longer supports the alias `ClientIdAndSecret` for parameter `ServicePrincipalIdAndSecret`.
- The default value of `NodeVmSetType` is changed from `AvailabilitySet` to `VirtualMachineScaleSets`.
- The default value of `NetworkPlugin` is changed from `none` to `azure`.

#### Before

```powershell
New-AzAksCluster -ResourceGroupName myResourceGroup -Name myCluster -WindowsProfileAdminUserName azureuser -WindowsProfileAdminUserPassword $cred -NetworkPlugin azure -NodeOsType Linux -ClientIdAndSecret xxx
```

#### After

```powershell
New-AzAksCluster -ResourceGroupName myResourceGroup -Name myCluster -WindowsProfileAdminUserName azureuser -WindowsProfileAdminUserPassword $cred -NodeVmSetType AvailabilitySet  -ServicePrincipalIdAndSecret xxx
```

### Set-AzAksCluster

No longer supports the alias `ClientIdAndSecret` for parameter `ServicePrincipalIdAndSecret`.

#### Before

```powershell
Get-AzAksCluster -ResourceGroupName xxx -Name xxx | Set-AzAksCluster -ClientIdAndSecret xxx
```

#### After

```powershell
Get-AzAksCluster -ResourceGroupName xxx -Name xxx | Set-AzAksCluster -ServicePrincipalIdAndSecret xxx
```

## Az.ContainerRegistry

### New-AzContainerRegistry

No longer supports the parameter `StorageAccountName` and no alias was found for the original parameter name.

#### Before

```powershell
New-AzContainerRegistry -Name $name -ResourceGroupName $rg -Location $location -SKU Classic -StorageAccountName $storage
```

#### After

`Classic` was deprecated and `StorageAccountName` was removed since it only works with Classic
Container Registry.

## Az.Functions

### Get-AzFunctionApp

Removed `IncludeSlot` switch parameter from all but one parameter set of `Get-AzFunctionApp`. The
cmdlet now supports retrieving deployment slots in the results when `-IncludeSlot` is specified.
This functionality was broken in the previous cmdlet version. However, this is now fixed.

### New-AzFunctionApp

- Fixed `-DisableApplicationInsights` in `New-AzFunctionApp` so that no application insights project
  is created when this option is specified.
- Removed support to create PowerShell 6.2 function apps since PowerShell 6.2 is EOL. The current
  guidance for customers is to create PowerShell 7.0 function apps instead.
- Changed the default runtime version in Functions version 3 on Windows for PowerShell function apps
  from 6.2 to 7.0 when the `RuntimeVersion` parameter is not specified.
- Changed the default runtime version in Functions version 3 on Windows and Linux for Node function
  apps from 10 to 12 when the `RuntimeVersion` parameter is not specified. However, users can still
  create Node 10 function apps by specifying `-Runtime Node` and `-RuntimeVersion 10`. Changed the
  default runtime version in Functions version 3 on Linux for Python function apps from 3.7 to 3.8
  when the `RuntimeVersion` parameter is not specified. However, users can still create Python 3.7
  function apps by specifying `-Runtime Python` and `-RuntimeVersion 3.7`.

#### Before

```powershell
# Create a Node 10 function app on Linux
New-AzFunctionApp -ResourceGroupName $rd `
                  -Name $functionAppName `
                  -StorageAccountName $storageAccountName `
                  -Location $location `
                  -OSType Linux `
                  -Runtime Node

# Create a Node 10 function app on Windows
New-AzFunctionApp -ResourceGroupName $rd `
                  -Name $functionAppName `
                  -StorageAccountName $storageAccountName `
                  -Location $location `
                  -OSType Windows `
                  -Runtime Node

# Create a Python 3.7 function app on Linux
New-AzFunctionApp -ResourceGroupName $rd `
                  -Name $functionAppName `
                  -StorageAccountName $storageAccountName `
                  -Location $location `
                  -OSType Linux `
                  -Runtime Python
```

#### After

```powershell
# Create a Node 10 function app on Linux
New-AzFunctionApp -ResourceGroupName $rd `
                  -Name $functionAppName `
                  -StorageAccountName $storageAccountName `
                  -Location $location `
                  -OSType Linux `
                  -Runtime Node `
                  -RuntimeVersion 10

# Create a Node 10 function app on Windows
New-AzFunctionApp -ResourceGroupName $rd `
                  -Name $functionAppName `
                  -StorageAccountName $storageAccountName `
                  -Location $location `
                  -OSType Windows `
                  -Runtime Node

# Create a Python 3.7 function app on Linux
New-AzFunctionApp -ResourceGroupName $rd `
                  -Name $functionAppName `
                  -StorageAccountName $storageAccountName `
                  -Location $location `
                  -OSType Linux `
                  -Runtime Python `
                  -RuntimeVersion 3.7
```

## Az.KeyVault

### New-AzKeyVault

No longer supports the parameter `DisableSoftDelete` and no alias was found for the original parameter name.

#### Before

```powershell
# Opt out soft delete while creating a key vault
New-AzKeyVault -VaultName 'Contoso03Vault' -ResourceGroupName 'Group14' -Location 'East US' -DisableSoftDelete
```

#### After

The ability to update soft-delete setting is deprecated in Az.KeyVault 3.0.0. Read more: https://docs.microsoft.com/azure/key-vault/general/soft-delete-change

### Update-AzKeyVault

No longer supports the parameter `EnableSoftDelete`, `SoftDeleteRetentionInDays`, and no alias was
found for the original parameter name.

#### Before

```powershell
Update-AzKeyVault -VaultName 'Contoso03Vault' -ResourceGroupName 'Group14' -EnableSoftDelete -SoftDeleteRetentionInDays 15
```

#### After

The ability to update soft-delete setting is deprecated in Az.KeyVault 3.0.0. Read more: https://docs.microsoft.com/azure/key-vault/general/soft-delete-change

### Get-AzKeyVaultSecret

The property `SecretValueText` of type `Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSecret`
has been removed. The `SecretValueText` property has been replaced with `SecretValue`.

#### Before

```powershell
$secret = Get-AzKeyVaultSecret -VaultName myVault -Name mySecret
$secretInPlainText = $secret.SecretValueText
```

#### After

```powershell
# PowerShell 7 or newer
$secret = Get-AzKeyVaultSecret -VaultName myVault -Name mySecret
$secretInPlainText = ConvertFrom-SecureString -SecureString $secret.SecretValue -AsPlainText

# Prior to PowerShell 7, or Windows PowerShell
$secret = Get-AzKeyVaultSecret -VaultName myVault -Name mySecret
$secretInPlainText = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($secret.SecretValue))
```

## Az.ManagedServices

### Get-AzManagedServicesDefinition

No longer supports the parameter `ResourceId` and no alias was found for the original parameter name.

#### Before

```powershell
Get-AzManagedServicesDefinition -ResourceId xxx
```

#### After

```powershell
Get-AzManagedServicesDefinition -Id xxx
```

### New-AzManagedServicesAssignment

No longer supports the parameter `RegistrationDefinitionName`, `RegistrationDefinitionResourceId`,
and no alias was found for the original parameter name.

#### Before

```powershell
New-AzManagedServicesAssignment -RegistrationDefinitionName xxx -Scope xxx
```

#### After

```powershell
New-AzManagedServicesAssignment -Scope xxx -RegistrationDefinition xxx
```

### Remove-AzManagedServicesAssignment

No longer supports the parameter `Id`, `ResourceId`, and no alias was found for the original
parameter name.

#### Before

```powershell
Remove-AzManagedServicesAssignment -ResourceId xxx
```

#### After

```powershell
Get-AzManagedServicesAssignment -Scope xxx | Remove-AzManagedServicesAssignment
```

### Remove-AzManagedServicesDefinition

No longer supports the parameter `Id`, `ResourceId`, and no alias was found for the original
parameter name.

#### Before

```powershell
Remove-AzManagedServicesDefinition -ResourceId xxx
```

#### After

```powershell
Get-AzManagedServicesDefinition -Scope xxx | Remove-AzManagedServicesDefinition
```

## Az.ResourceManager

### Get-AzManagementGroupDeployment

No longer supports the parameter `ApiVersion` and no alias was found for the original parameter name.

#### Before

```powershell
Get-AzManagementGroupDeployment -ManagementGroupId xxx -Name xxx -ApiVersion xxx
```

#### After

```powershell
Get-AzManagementGroupDeployment -ManagementGroupId xxx -Name xxx
```

### Get-AzManagementGroupDeploymentOperation

Same with `Get-AzManagementGroupDeployment`.

### Get-AzDeployment

Same with `Get-AzManagementGroupDeployment`.

### Get-AzDeploymentOperation

Same with `Get-AzManagementGroupDeployment`.

### Get-AzDeploymentWhatIfResult

Same with `Get-AzManagementGroupDeployment`.

### Get-AzTenantDeployment

Same with `Get-AzManagementGroupDeployment`.

### Get-AzTenantDeploymentOperation

Same with `Get-AzManagementGroupDeployment`.

### New-AzManagementGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### New-AzDeployment

Same with `Get-AzManagementGroupDeployment`.

### New-AzTenantDeployment

Same with `Get-AzManagementGroupDeployment`.

### Remove-AzManagementGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Remove-AzDeployment

Same with `Get-AzManagementGroupDeployment`.

### Remove-AzTenantDeployment

Same with `Get-AzManagementGroupDeployment`.

### Save-AzManagementGroupDeploymentTemplate

Same with `Get-AzManagementGroupDeployment`.

### Save-AzDeploymentTemplate

Same with `Get-AzManagementGroupDeployment`.

### Save-AzTenantDeploymentTemplate

Same with `Get-AzManagementGroupDeployment`.

### Stop-AzManagementGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Stop-AzDeployment

Same with `Get-AzManagementGroupDeployment`.

### Stop-AzTenantDeployment

Same with `Get-AzManagementGroupDeployment`.

### Test-AzManagementGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Test-AzDeployment

Same with `Get-AzManagementGroupDeployment`.

### Test-AzTenantDeployment

Same with `Get-AzManagementGroupDeployment`.

### Get-AzResourceGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Get-AzResourceGroupDeploymentOperation

Same with `Get-AzManagementGroupDeployment`.

### Get-AzResourceGroupDeploymentWhatIfResult

Same with `Get-AzManagementGroupDeployment`.

### New-AzResourceGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Remove-AzResourceGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Save-AzResourceGroupDeploymentTemplate

Same with `Get-AzManagementGroupDeployment`.

### Stop-AzResourceGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Test-AzResourceGroupDeployment

Same with `Get-AzManagementGroupDeployment`.

### Get-AzManagementGroupDeploymentWhatIfResult

Same with `Get-AzManagementGroupDeployment`.

### Get-AzTenantDeploymentWhatIfResult

Same with `Get-AzManagementGroupDeployment`.

## Az.Sql

### Set-AzSqlServerActiveDirectoryAdministrator

No longer supports the parameter `IsAzureADOnlyAuthentication` and no alias was found for the
original parameter name.

#### Before

```powershell
Set-AzSqlServerActiveDirectoryAdministrator -ResourceGroupName 'ResourceGroup01' -ServerName 'Server01' -DisplayName 'DBAs' -IsAzureADOnlyAuthentication
```

#### After

```powershell
Set-AzSqlServerActiveDirectoryAdministrator -ResourceGroupName 'ResourceGroup01' -ServerName 'Server01' -DisplayName 'DBAs'
```

## Az.Synapse

### New-AzSynapseSqlPool

No longer supports the parameter `FromBackup`, `FromRestorePoint`, `BackupResourceGroupName`,
`BackupWorkspaceName`, `BackupSqlPoolName`, `BackupSqlPoolObject`, `BackupResourceId`,
`SourceResourceGroupName`, `SourceWorkspaceName`, `SourceSqlPoolName`, `SourceSqlPoolObject`,
`SourceResourceId`, `RestorePoint`, and no alias was found for the original parameter name.

#### Before

```powershell
New-AzSynapseSqlPool -FromBackup -WorkspaceName ContosoWorkspace -Name ContosoSqlPool -BackupWorkspaceName ContosoWorkspace -BackupSqlPoolName ExistingContosoSqlPool
```

#### After

```powershell
PS C:\> New-AzSynapseSqlPool -WorkspaceName ContosoWorkspace -Name ContosoSqlPool -PerformanceLevel DW200c
```

### Update-AzSynapseSqlPool

No longer supports the parameter `Suspend`, `Resume`, and no alias was found for the original
parameter name.

## Az.Network

### Approve-AzPrivateEndpointConnection

No longer supports the parameter `PrivateLinkResourceType` and no alias was found for the original
parameter name.

#### Before

```powershell
Approve-AzPrivateEndpointConnection -ResourceGroupName xxx -ServiceName xxx -Name xxx -PrivateLinkResourceType 'Microsoft.Network/privateLinkServices' -Description xxx
```

#### After

```powershell
Approve-AzPrivateEndpointConnection -ResourceGroupName xxx -ServiceName xxx -Name xxx -Description xxx
```

### Deny-AzPrivateEndpointConnection

Same with `Approve-AzPrivateEndpointConnection`.

### Get-AzPrivateEndpointConnection

Same with `Approve-AzPrivateEndpointConnection`.

### Remove-AzPrivateEndpointConnection

Same with `Approve-AzPrivateEndpointConnection`.

### Set-AzPrivateEndpointConnection

Same with `Approve-AzPrivateEndpointConnection`.

### New-AzNetworkWatcherConnectionMonitorEndpointObject

No longer supports the parameter `FilterType`, `FilterItem`, and no alias was found for the original
parameter name.

#### Before

```powershell
$MySrcResourceId1 = '/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourceGroup/providers/Microsoft.OperationalInsights/workspaces/myworkspace'
$SrcEndpointFilterItem1 =New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject -Type 'AgentAddress' -Address 'WIN-P0HGNDO2S1B'
$SourceEndpointObject1 = New-AzNetworkWatcherConnectionMonitorEndPointObject -Name 'workspaceEndpoint' -ResourceId $MySrcResourceId1 -FilterType Include -FilterItem $SrcEndpointFilterItem1
```

#### After

```powershell
MySrcResourceId1 = '/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myresourceGroup/providers/Microsoft.OperationalInsights/workspaces/myworkspace'
$SourceEndpointObject1 = New-AzNetworkWatcherConnectionMonitorEndPointObject -Name 'workspaceEndpoint' -ResourceId $MySrcResourceId1
```
