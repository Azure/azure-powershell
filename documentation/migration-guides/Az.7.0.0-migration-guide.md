# Migration Guide for Az 7.0.0

## Az.Accounts

### Context and account cmdlets

Output of the following cmdlets have been changed:
- Get-AzContext
- Remove-AzContext
- Rename-AzContext
- Select-AzContext
- Connect-AzAccount
- Disconnect-AzAccount
- Import-AzContext
- Save-AzContext

Removed `ServicePrincipalSecret` and `CertificatePassword` in `PSAzureRmAccount`

#### Before
```powershell
PS C:\> $cred = Get-Credential
PS C:\> Connect-AzAccount -ServicePrincipal -Tenant 54826b22-xxxx-xxxx-xxxx-xxxxxxxxxxxxx -Credential $cred
PS C:\> (Get-AzContext).Account.ExtendedProperties

Key                    Value
---                    -----
CertificatePath        C:\certificate.pfx
CertificatePassword    password****
Tenants                54826b22-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
ServicePrincipalSecret 7QK7Q********************************
Subscriptions          0b1f6471-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
```
#### After
```powershell
PS C:\> $cred = Get-Credential
PS C:\> Connect-AzAccount -ServicePrincipal -Tenant 54826b22-xxxx-xxxx-xxxx-xxxxxxxxxxxxx -Credential $cred
PS C:\> (Get-AzContext).Account.ExtendedProperties

Key             Value
---             -----
CertificatePath C:\certificate.pfx
Tenants         54826b22-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Subscriptions   0b1f6471-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
```


## Az.Aks

### `Get-AzAksVersion`
Property `Upgrades` in output changed to `Upgrade`.

#### Before
```powershell
PS C:\> (Get-AzAksVersion -location eastus).Upgrades

OrchestratorType OrchestratorVersion IsPreview
---------------- ------------------- ---------
Kubernetes       1.19.13
Kubernetes       1.20.7
Kubernetes       1.20.9
Kubernetes       1.20.7
Kubernetes       1.20.9
Kubernetes       1.20.9
Kubernetes       1.21.1
Kubernetes       1.21.2
Kubernetes       1.21.1
Kubernetes       1.21.2
Kubernetes       1.21.2
Kubernetes       1.22.1              True
Kubernetes       1.22.2              True
Kubernetes       1.22.1              True
Kubernetes       1.22.2              True
Kubernetes       1.22.2              True
```
#### After
```powershell
PS C:\> (Get-AzAksVersion -location eastus).Upgrade

OrchestratorType OrchestratorVersion IsPreview
---------------- ------------------- ---------
Kubernetes       1.19.13
Kubernetes       1.20.7
Kubernetes       1.20.9
Kubernetes       1.20.7
Kubernetes       1.20.9
Kubernetes       1.20.9
Kubernetes       1.21.1
Kubernetes       1.21.2
Kubernetes       1.21.1
Kubernetes       1.21.2
Kubernetes       1.21.2
Kubernetes       1.22.1              True
Kubernetes       1.22.2              True
Kubernetes       1.22.1              True
Kubernetes       1.22.2              True
Kubernetes       1.22.2              True
```


## Az.ContainerInstance

### `New-AzContainerGroup`
Removed parameter NetworkProfileId, added SubnetId as its alternative

#### Before
```powershell
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -NetworkProfileId "/subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}"
PS C:\> $containerGroup.NetworkProfileId

/subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
```
#### After
```powershell
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType 'Private' -SubnetId @{"Id"="/subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}"; "Name"="subnet"}
PS C:\> $containerGroup.SubnetId | fl

Id :  /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
Name : subnet
```


### `Invoke-AzContainerInstanceCommand`
Displayed command execution result as the cmdlet output by connecting websocket in backend

#### Before
```powershell
PS C:\> $websocket = Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello" -TerminalSizeCol 12 -TerminalSizeRow 12
PS C:\> $websocket

Password                                           WebSocketUri
--------                                           ------------
****************** wss://bridge-linux-xx.eastus.management.azurecontainer.io/exec/caas-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/bridge-xxxxxxxxxxxxxxx?rows=12&cols=12api-version=2018-02-01-preview

User needs connect websocket using password to fetch command execution result
```
#### After
```powershell
PS C:\> Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello"

hello
```


## Az.Functions

### `Update-AzFunctionApp, Update-AzFunctionAppPlan`
`Update-AzFunctionApp` will prompt for confirmation. This behavior can be bypassed by specifying `-Force`.

#### Before
```powershell
Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -PlanName NewPlanName
```
#### After
```powershell
Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -PlanName NewPlanName -Force
```


### `New-AzFunctionApp`
If `FunctionsVersion` parameter is not specified when executing the `New-AzFunctionApp` cmdlet, then the default Functions version will be set to `4`.

```
There is no change to the usage.
```

### `Remove-AzFunctionApp`
If this is the last app in the app service plan, then the plan will not be deleted. Before this release, the app plan will also be deleted.

```
There is no change to the usage.
```

## Az.HDInsight

### `New-AzHDInsightCluster`
Changed  the type of parameter "OSType" from `Microsoft.Azure.Management.HDInsight.Models.OSType` to `System.string`

```
There is no change to the usage.
```


### `New-AzHDInsightCluster, New-AzHDInsightClusterConfig`
Changed  the type of parameter "ClusterTier" from `Microsoft.Azure.Management.HDInsight.Models.ClusterTier` to `System.string`

```
There is no change to the usage.
```


### `Set-AzHDInsightClusterDiskEncryptionKey, Set- AzHDInsightClusterSize`
The output type has changed from 'Microsoft.Azure.Management.HDInsight.Models.Cluster' to 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster'.

```
All properties remain the same, so there is no change to the usage.
```



### `Cluster cmdlets`
The type of property 'AssignedIdentity' has changed from 'Microsoft.Azure.Management.HDInsight.Models.ClusterIdentity' to 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightClusterIdentity'.


```
All properties remain the same, so there is no change to the usage.
```


### `Get-AzHDInsightProperties`
The generic type for output 'property VmSizes' has been changed from 'System.Collections.Generic.IDictionary2[System.String,Microsoft.Azure.Commands.HDInsight.Models.Management.AzureHDInsightVmSizesCapability]' to 'System.Collections.Generic.IList1[System.String]'.

#### Before
```powershell
PS C:\> $result = Get-AzHDInsightProperty -Location "South Central us"
PS C:\> $availableVmSizes = $result.VmSizes['iaas'].AvailableVmSizes
```
#### After
```powershell
PS C:\> $result = Get-AzHDInsightProperty -Location "South Central us"
PS C:\> $availableVmSizes = $result.VmSizes
```


## Az.KeyVault

### `New-AzKeyVaultRoleDefinition, Get-AzKeyVaultRoleDefinition`
The following properties in `PSKeyVaultPermission` model are renamed:
- `AllowedActions` -> `Actions`
- `DeniedActions` -> `NotActions`
- `AllowedDataActions` -> `DataActions`
- `DeniedDataActions` -> `NotDataActions`

#### Before
```powershell
PS C:\> $backupRole = Get-AzKeyVaultRoleDefinition -HsmName myHsm -RoleDefinitionName "Managed HSM Backup User"

PS C:\> $backupRole.Permissions

AllowedActions DeniedActions AllowedDataActions DeniedDataActions
-------------- ------------- ------------------ -----------------
0 action(s)    0 action(s)   3 action(s)        0 action(s)

PS C:\> $backupRole.Permissions.AllowedDataActions

Microsoft.KeyVault/managedHsm/backup/start/action
Microsoft.KeyVault/managedHsm/backup/status/action
Microsoft.KeyVault/managedHsm/keys/backup/action
```
#### After
```powershell
PS C:\> $backupRole = Get-AzKeyVaultRoleDefinition -HsmName myHsm -RoleDefinitionName "Managed HSM Backup User"

PS C:\> $backupRole.Permissions

Actions     NotActions  DataActions NotDataActions
-------     ----------  ----------- --------------
0 action(s) 0 action(s) 3 action(s) 0 action(s)

PS C:\> $backupRole.Permissions.DataActions

Microsoft.KeyVault/managedHsm/backup/start/action
Microsoft.KeyVault/managedHsm/backup/status/action
Microsoft.KeyVault/managedHsm/keys/backup/action
```


## Az.ManagedServices

### `New-AzManagedServicesDefinition`
The `-DisplayName` parameter was removed.

#### Before
```powershell
PS C:\> New-AzManagedServicesDefinition -DisplayName "MyTestDefinition" -ManagedByTenantId 00001111-aaaa-2222-bbbb-3333cccc4444 -RoleDefinitionId acdd72a7-3385-48ef-bd42-f606fba81ae7 -PrincipalId 714160ec-87d5-42bb-8b17-287c0dd7417d
```
#### After
```powershell
PS C:\> $permantAuth = New-AzManagedServicesAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -DelegatedRoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx","xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
PS C:\> New-AzManagedServicesDefinition -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -RegistrationDefinitionName "Test definition" -ManagedByTenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Authorization $permantAuth -Description "Test definition desc" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```


## Az.Monitor

### `Get-AzLog`

The type of the properties 'EventName', 'Category', 'ResourceProviderName', 'OperationName', 'Status', 'SubStatus has changed from 'Microsoft.Azure.Management.Monitor.Models.LocalizableString' to 'System.String'

#### Before
```powershell
PS C:\> $log = Get-AzLog -MaxRecord 1
PS C:\> $eventName = $log.EventName.LocalizedValue
PS C:\> $category = $log.Category.LocalizedValue
PS C:\> $resourceProviderName = $log.ResourceProviderName.LocalizedValue
PS C:\> $operationName = $log.OperationName.LocalizedValue
PS C:\> $status = $log.Status.LocalizedValue
PS C:\> $subStatus = $log.SubStatus.LocalizedValue
```
#### After
```powershell
PS C:\> $log = Get-AzLog -MaxRecord 1
PS C:\> $eventName = $log.EventName
PS C:\> $category = $log.Category
PS C:\> $resourceProviderName = $log.ResourceProviderName
PS C:\> $operationName = $log.OperationName
PS C:\> $status = $log.Status
PS C:\> $subStatus = $log.SubStatus
```


### `Get-AzMetric,Get-AzMetricDefinition`
The type of property 'Unit' has changed to 'System.String'

```
There is no change to the usage.
```



### `New-AzMetricAlertRuleV2Criteria`
The type of property 'TimeAggregation' has changed to System.String'

```
There is no change to the usage.
```



## Az.OperationalInsights

### `Get-AzOperationalInsightsCluster`
Made "list" the default parameter set.

#### Before
```powershell
There is no default parameter set.
```
#### After
```powershell
Default parameter set is now "list", when providing resource group name - return all clusters for the given resource group.
```


### `Update-AzOperationalInsightsCluster`
Made "UpdateByNameParameterSet" the default parameter set.

#### Before
```powershell
There is no default parameter set.
```
#### After
```powershell
Default parameter set is now "UpdateByNameParameterSet".
```


## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupContainer`
Changed the BackupManagementType from MARS to MAB. Functionality remains same, this is to bring consistency across cmdlets.

#### Before
```powershell
$containers = Get-AzRecoveryServicesBackupContainer -ContainerType Windows -BackupManagementType MARS -VaultId $vault.ID
```
#### After
```powershell
$cont = Get-AzRecoveryServicesBackupContainer -ContainerType Windows -BackupManagementType MAB -VaultId $vault.ID
```


### `Get-AzRecoveryServicesBackupItem`
Changed the BackupManagementType from MARS to MAB. Functionality remains same, this is to bring consistency across cmdlets

#### Before
```powershell
Get-AzRecoveryServicesBackupItem -BackupManagementType MARS -VaultId $vault.ID -WorkloadType FileFolder
```
#### After
```powershell
Get-AzRecoveryServicesBackupItem -BackupManagementType MAB -VaultId $vault.ID -WorkloadType FileFolder
```


### `Get-AzRecoveryServicesBackupJob`
Changed the BackupManagementType from MARS to MAB. Functionality remains same, this is to bring consistency across cmdlets

#### Before
```powershell
Get-AzRecoveryServicesBackupJob -BackupManagementType MARS -VaultId $vault.ID
```
#### After
```powershell
Get-AzRecoveryServicesBackupJob -BackupManagementType MAB -VaultId $vault.ID
```


## Az.Resources

### `AzAD cmdlets`
Please refer to (placeholder) for the migration guide of Active Directory cmdlets.

### `PolicyAssignment cmdlets`
The type of property 'Identity' of type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' has changed from 'System.Management.Automation.PSObject' to 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyIdentity'.

#### Before
```powershell
PS C:\> $v = Get-AzPolicyAssignment -Id $someId
PS C:\> Write-Host $v.type, $v.principalId, $v.tenantId
```
#### After
```powershell
PS C:\> $v = Get-AzPolicyAssignment -Id $someId
PS C:\> Write-Host $v.IdentityType, $v.PrincipalId, $v.TenantId, $v.UserAssignedIdentities
```


## Az.Storage

### `Get-AzRmStorageShare`
Parameter "Name" has been removed from parameter set "ShareResourceId", since name can be inferred from the resource ID.

#### Before
```powershell
$StorageShare = Get-AzRmStorageShare -ResourceId "/subscriptions/..." -Name "MyStorageShare"
```
#### After
```powershell
$StorageShare = Get-AzRmStorageShare -ResourceId "/subscriptions/..."
```


