# Migration Guide for Az 7.0.0

## Az.Accounts

### `Affect output of the cmdlets:
- Get-AzContext
- Remove-AzContext
- Rename-AzContext
- Select-AzContext
- Connect-AzAccount
- Disconnect-AzAccount
- Import-AzContext
- Save-AzContext`
Removed `ServicePrincipalSecret` and `CertificatePassword` in `PSAzureRmAccount`

#### Before
```powershell
PS C:\> $cred = Get-Credential
PS C:\> Connect-AzAccount -ServicePrincipal -Tenant 54826b22-xxxx-xxxx-xxxx-xxxxxxxxxxxxx -Credential $cred
PS C:\> (Get-AzContext).Account.ExtendedProperties

Key                    Value
---                    -----
CertificatePath        C:\certficate.pfx
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
CertificatePath C:\certficate.pfx
Tenants         54826b22-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Subscriptions   0b1f6471-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
```


## Az.Aks

### `Get-AzAksVersion`
Property `Upgrades` in output changed to `Upgrade`.

#### Before
(Get-AzAksVersion -location eastus).Upgrades

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
#### After
(Get-AzAksVersion -location eastus).Upgrade

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


## Az.ContainerInstance

### `All`
Upgraded API version from 2021-03-01 to 2021-09-01, no change in usage

#### Before
API version 2021-03-01
#### After
API version 2021-09-01


### `New-AzContainerInstanceObject`
Removed parameter `ReadinessProbeHttpGetHttpHeadersName` and `ReadinessProbeHttpGetHttpHeadersValue`, added `ReadinessProbeHttpGetHttpHeader` as their alternative

#### Before
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -ReadinessProbeHttpGetHttpHeadersName "foo" -ReadinessProbeHttpGetHttpHeadersValue "bar" -ReadinessProbeHttpGetPort 8000

not deserialize the current JSON object (e.g. {"name":"value"}) into type 'Microsoft.Azure.CloudConsole.Providers.Data.Definition.HttpHeaderDefinition[]' because the type requires a JSON array (e.g. [1,2,3]) to deserialize correctly.
To fix this error either change the JSON to a JSON array (e.g. [1,2,3]) or change the deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object.

The usage is broken
#### After
PS C:\> $header= New-AzContainerInstanceHttpHeaderObject -Name foo  -Value bar
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -ReadinessProbeHttpGetHttpHeader $header-ReadinessProbeHttpGetPort 8000
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName bez-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public
PS C:\> $containerGroup.Container.ReadinessProbeHttpGetHttpHeader 

Name Value
---- -----
foo  bar


### `New-AzContainerInstanceObject`
Removed parameter `LivenessProbeHttpGetHttpHeadersName` and `LivenessProbeHttpGetHttpHeadersValue`, added `LivenessProbeHttpGetHttpHeader` as their alternative

#### Before
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -LivenesssProbeHttpGetHttpHeadersName "foo" -LivenessProbeHttpGetHttpHeadersValue "bar" -LivenessProbeHttpGetPort 8000

not deserialize the current JSON object (e.g. {"name":"value"}) into type 'Microsoft.Azure.CloudConsole.Providers.Data.Definition.HttpHeaderDefinition[]' because the type requires a JSON array (e.g. [1,2,3]) to deserialize correctly.
To fix this error either change the JSON to a JSON array (e.g. [1,2,3]) or change the deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object.

The usage is broken
#### After
PS C:\> $header= New-AzContainerInstanceHttpHeaderObject -Name foo  -Value bar
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -LivenessProbeHttpGetHttpHeader $header-LivenessProbeHttpGetPort 8000
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName bez-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName bez-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public
PS C:\> $containerGroup.Container.LivenessProbeHttpGetHttpHeader 

Name Value
---- -----
foo  bar


### `New-AzContainerGroup`
Removed parameter NetworkProfileId, added SubnetId as its alternative

#### Before
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -NetworkProfileId "/subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}"
PS C:\> $containerGroup.NetworkProfileId 

/subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
#### After
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType 'Private' -SubnetId @{"Id"="/subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}"; "Name"="subnet"}
PS C:\> $containerGroup.SubnetId | fl

Id :  /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}
Name : subnet


### `New-AzContainerGroup`
Changed the type of parameter LogAnalyticWorkspaceResourceId from Hashtable to String

#### Before
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public -LogAnalyticWorkspaceId /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/rg/providers/microsoft.operationalinsights/workspaces/workspace/{workspacename} -LogAnalyticWorkspaceKey {key} -LogAnalyticWorkspaceResourceId @{"Id"="/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/rg/providers/microsoft.operationalinsights/workspaces/workspace"} 

Az.ContainerInstance.internal\New-AzContainerGroup : The request content was invalid and could not be deserialized: 'Unexpected character encountered while parsing value: {. Path 'properties.diagnostics.logAnalytics.workspaceResourceId'

The usage is broken
#### After
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx  
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public -LogAnalyticWorkspaceId /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/rg/providers/microsoft.operationalinsights/workspaces/workspace/{workspacename} -LogAnalyticWorkspaceKey {key} -LogAnalyticWorkspaceResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/rg/providers/microsoft.operationalinsights/workspaces/workspace"

PS C:\> $containerGroup.LogAnalyticWorkspaceResourceId

"/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/rg/providers/microsoft.operationalinsights/workspaces/workspace"


### `Invoke-AzContainerInstanceCommand`
Displayed command execution result as the cmdlet output by connecting websocket in backend

#### Before
PS C:\> $websocket = Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello" -TerminalSizeCol 12 -TerminalSizeRow 12
PS C:\> $websocket

Password                                           WebSocketUri
--------                                           ------------
****************** wss://bridge-linux-xx.eastus.management.azurecontainer.io/exec/caas-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/bridge-xxxxxxxxxxxxxxx?rows=12&cols=12api-version=2018-02-01-preview

User needs connect websocket using password to fetch command execution result
#### After
PS C:\> Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello"

hello


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

#### Before
There is no change to the usage.
#### After



### `Remove-AzFunctionApp`
If this is the last app in the app service plan, then the plan will not be deleted. Before this release, the app plan will also be deleted.

#### Before
There is no change to the usage.
#### After



## Az.HDInsight

### `New-AzHDInsightCluster`
Changed  the type of parameter "OSType" from `Microsoft.Azure.Management.HDInsight.Models.OSType` to `System.string`

#### Before
There is no change to the usage.
#### After



### `New-AzHDInsightCluster, New-AzHDInsightClusterConfig`
Changed  the type of parameter "ClusterTier" from `Microsoft.Azure.Management.HDInsight.Models.ClusterTier` to `System.string`

#### Before
There is no change to the usage.
#### After



### `Set-AzHDInsightClusterDiskEncryptionKey, Set- AzHDInsightClusterSize`
The output type has changed from 'Microsoft.Azure.Management.HDInsight.Models.Cluster' to 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster'.

#### Before
All properties remain the same, so there is no change to the usage.
#### After



### `All cmdlets that returns type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster'`
The type of property 'AssignedIdentity' has changed from 'Microsoft.Azure.Management.HDInsight.Models.ClusterIdentity' to 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightClusterIdentity'.

#### Before
All properties remain the same, so there is no change to the usage.
#### After



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
New-AzManagedServicesDefinition -DisplayName "MyTestDefinition" -ManagedByTenantId 72f9acbf-86f1-41af-91ab-2d7ef011db47 -RoleDefinitionId acdd72a7-3385-48ef-bd42-f606fba81ae7 -PrincipalId 714160ec-87d5-42bb-8b17-287c0dd7417d
```
#### After
```powershell
$permantAuth = New-AzManagedServicesAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -DelegatedRoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx","xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"

New-AzManagedServicesDefinition -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -RegistrationDefinitionName "Test definition" -ManagedByTenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Authorization $permantAuth -Description "Test definition desc" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" 
```


## Az.Monitor

### `Get-AzLog`
	
The type of the properties 'EventName', 'Category', 'ResourceProviderName', 'OperationName', 'Status', 'SubStatus has changed from 'Microsoft.Azure.Management.Monitor.Models.LocalizableString' to 'System.String'

#### Before
$log = Get-AzLog -MaxRecord 1

$eventName = $log.EventName.LocalizedValue

$category = $log.Category.LocalizedValue

$resourceProviderName = $log.ResourceProviderName.LocalizedValue

$operationName = $log.OperationName.LocalizedValue

$status = $log.Status.LocalizedValue

$subStatus = $log.SubStatus.LocalizedValue
#### After
$log = Get-AzLog -MaxRecord 1

$eventName = $log.EventName

$category = $log.Category

$resourceProviderName = $log.ResourceProviderName

$operationName = $log.OperationName

$status = $log.Status

$subStatus = $log.SubStatus


### `Get-AzMetric,Get-AzMetricDefinition`
The type of property 'Unit' has changed to 'System.String'

#### Before
There is no change to the usage.
#### After



### `New-AzMetricAlertRuleV2Criteria`
The type of property 'TimeAggregation' has changed to System.String'

#### Before
There is no change to the usage.
#### After



## Az.OperationalInsights

### `Get-AzOperationalInsightsCluster`
Made "list" the default parameter set.

#### Before
There is no default parameter set.
#### After
Default parameter set is now "list", when providing resource group name - return all clusters for the given resource group.


### `Update-AzOperationalInsightsCluster`
Made "UpdateByNameParameterSet" the default parameter set.

#### Before
There is no default parameter set.
#### After
Default parameter set is now "UpdateByNameParameterSet".


## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupContainer`
Changed the BackupManagementType from MARS to MAB. Functionality remains same, this is to bring consistency across cmdlets.

#### Before
$containers = Get-AzRecoveryServicesBackupContainer -ContainerType Windows -BackupManagementType MARS -VaultId $vault.ID
#### After
$cont = Get-AzRecoveryServicesBackupContainer -ContainerType Windows -BackupManagementType MAB -VaultId $vault.ID


### `Get-AzRecoveryServicesBackupItem`
	Changed the BackupManagementType from MARS to MAB. Functionality remains same, this is to bring consistency across cmdlets

#### Before
Get-AzRecoveryServicesBackupItem -BackupManagementType MARS -VaultId $vault.ID -WorkloadType FileFolder
#### After
Get-AzRecoveryServicesBackupItem -BackupManagementType MAB -VaultId $vault.ID -WorkloadType FileFolder


### `Get-AzRecoveryServicesBackupJob`
Changed the BackupManagementType from MARS to MAB. Functionality remains same, this is to bring consistency across cmdlets

#### Before
Get-AzRecoveryServicesBackupJob -BackupManagementType MARS -VaultId $vault.ID
#### After
Get-AzRecoveryServicesBackupJob -BackupManagementType MAB -VaultId $vault.ID


## Az.Resources

### `MSGraph (don't forget to add link)`


### `PolicyAssignment cmdlets`
The type of property 'Identity' of type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' has changed from 'System.Management.Automation.PSObject' to 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyIdentity'.

#### Before
PS C:\> $v = Get-AzPolicyAssignment -Id $someId
PS C:\> Write-Host $v.type, $v.principalId, $v.tenantId
#### After
PS C:\> $v = Get-AzPolicyAssignment -Id $someId
PS C:\> Write-Host $v.IdentityType, $v.PrincipalId, $v.TenantId, $v.UserAssignedIdentities


## Az.Storage

### `Get-AzRmStorageShare`
Parameter "Name" has been removed from parameter set "ShareResourceId", since name can be inferred from the resource ID.

#### Before
$StorageShare = Get-AzRmStorageShare -ResourceId "/subscriptions/..." -Name "MyStorageShare"
#### After
$StorageShare = Get-AzRmStorageShare -ResourceId "/subscriptions/..."


