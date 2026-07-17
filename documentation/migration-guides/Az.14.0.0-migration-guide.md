# Migration Guide for Az 14.0.0

## Az.Accounts

### `Get-AzAccessToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The default output type is changed from `PSAccessToken` to `PSSecureAccessToken`.That is to change plaintext `PSAccessToken.Token` to `SecureString PSSecureAccessToken.Token`
  - This change is expected to take effect from Az.Accounts version: 5.0.0 and Az version: 14.0.0


#### Before
```powershell
$authHeader = @{
    'Content-Type'  = 'application/json'
    'Authorization' = 'Bearer ' + (Get-AccessToken).Token
}
$response = Invoke-RestMethod -Method Get -Headers $authHeader -Uri $uri
```

#### After
```powershell
$secureToken = (Get-AzAccessToken).Token
$ssPtr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($secureToken)
try {
     $plaintextToken = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR($ssPtr)
} 
finally {
     [System.Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ssPtr) 
}
$authHeader = @{
    'Content-Type'  = 'application/json'
    'Authorization' = 'Bearer ' + $plaintextToken
}
$response = Invoke-RestMethod -Method Get -Headers $authHeader -Uri $uri
```


## Az.Aks

### `Get-AzAksMaintenanceConfiguration`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMaintenanceConfiguration'
- The following properties in the output type are being deprecated : 'TimeInWeek Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek' 'NotAllowedTime Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan'
- The following properties are being added to the output type : 'TimeInWeek System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]' 'NotAllowedTime System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
- Change description : The type of property 'TimeInWeek' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek[]' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]',The type of property 'NotAllowedTime' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster
```

#### After
```powershell
Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster
```


### `Get-AzAksManagedClusterOSOption`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProfile'
- The following properties in the output type are being deprecated : 'OSOptionPropertyList Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty'
- The following properties are being added to the output type : 'OSOptionPropertyList System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]'
- Change description : The type of property 'OSOptionPropertyList' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]'.
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Get-AzAksManagedClusterOSOption -Location eastus
```

#### After
```powershell
Get-AzAksManagedClusterOSOption -Location eastus
```


### `Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOutboundEnvironmentEndpoint'
- The following properties in the output type are being deprecated : 'Endpoint Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency'
- The following properties are being added to the output type : 'Endpoint System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]'
- Change description : The type of property 'Endpoint' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]'.
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
$result = Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint -ResourceGroupName mygroup -ResourceName mycluster
$result | select Category,Endpoint
```

#### After
```powershell
$result = Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint -ResourceGroupName mygroup -ResourceName mycluster
$result | select Category,Endpoint
```


### `Get-AzAksNodePoolUpgradeProfile`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfile'
- The following properties in the output type are being deprecated : 'Upgrade Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem'
- The following properties are being added to the output type : 'Upgrade System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]'
- Change description : The type of property 'Upgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]'.
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default
```

#### After
```powershell
Get-AzAksNodePoolUpgradeProfile -ResourceGroupName group -ClusterName myCluster -AgentPoolName default
```


### `Get-AzAksUpgradeProfile`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterUpgradeProfile'
- The following properties in the output type are being deprecated : 'AgentPoolProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile' 'ControlPlaneProfileUpgrade Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem'
- The following properties are being added to the output type : 'AgentPoolProfile System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]' 'ControlPlaneProfileUpgrade System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]'
- Change description : The type of property 'AgentPoolProfile' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]'.,The type of property 'ControlPlaneProfileUpgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]'.
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Get-AzAksUpgradeProfile -ResourceGroupName group -Name myCluster
```

#### After
```powershell
Get-AzAksUpgradeProfile -ResourceGroupName group -Name myCluster
```


### `Get-AzAksVersion`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfileListResult'
- The following properties in the output type are being deprecated : 'Orchestrator Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile'
- The following properties are being added to the output type : 'Orchestrator System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile]'
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Get-AzAksVersion -location eastus
```

#### After
```powershell
Get-AzAksVersion -location eastus
```


### `New-AzAksCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of -NodeVmSize parameter in New-AzAksCluster and -VmSize parameter in New-AzAksNodePool from 'Standard_D2_V2'  being dynamically selected by the AKS resource provider based on quota and capacity.
  - This change is expected to take effect from Az.Aks version: 7.0.0 and Az version: 14.0.0


#### Before
```powershell
If '-NodeVmSize' is not provided, the default NodeVmSize is ‘Standard_D2_V2’。 
```

#### After
```powershell
If '-NodeVmSize' is not provided, the default NodeVmSize is dynamically selected by the AKS resource provider based on quota and capacity.
```


### `New-AzAksNodePool `

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of -NodeVmSize parameter in New-AzAksCluster and -VmSize parameter in New-AzAksNodePool from 'Standard_D2_V2'  being dynamically selected by the AKS resource provider based on quota and capacity.
  - This change is expected to take effect from Az.Aks version: 7.0.0 and Az version: 14.0.0


#### Before
```powershell
If '-VmSize' is not provided, the default VmSize is ‘Standard_D2_V2’。 
```

#### After
```powershell
If '-VmSize' is not provided, the default VmSize is dynamically selected by the AKS resource provider based on quota and capacity.
```


### `New-AzAksMaintenanceConfiguration`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMaintenanceConfiguration'
- The following properties in the output type are being deprecated : 'TimeInWeek Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek' 'NotAllowedTime Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan'
- The following properties are being added to the output type : 'TimeInWeek System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]' 'NotAllowedTime System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
- Change description : The type of property 'TimeInWeek' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek[]' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]',The type of property 'NotAllowedTime' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day 'Sunday' -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```

#### After
```powershell
$TimeSpan = New-AzAksTimeSpanObject -Start (Get-Date -Year 2023 -Month 3 -Day 1) -End (Get-Date -Year 2023 -Month 3 -Day 2)
$TimeInWeek = New-AzAksTimeInWeekObject -Day Sunday -HourSlot 1,2
$MaintenanceConfig = New-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config' -TimeInWeek $TimeInWeek -NotAllowedTime $TimeSpan
```


## Az.AppConfiguration

### `Get-AzAppConfigurationStore`
- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IConfigurationStore' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IConfigurationStore'
- The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference'
- The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference]'
- Change description : The type of property 'PrivateEndpointConnection' of type 'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IConfigurationStore' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference]'
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp
```

#### After
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp
```


### `New-AzAppConfigurationStore`
IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IConfigurationStore' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IConfigurationStore'
- The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference'
- The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference]'
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
$storeName = "azpstest-appstore-recover"
$resourceGroupName = "azpstest_gp"
$location = "eastus"
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard
Remove-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName
Get-AzAppConfigurationDeletedStore -Location $location -Name $storeName
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard -CreateMode 'Recover' -IdentityType SystemAssigned -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```

#### After
```powershell
$storeName = "azpstest-appstore-recover"
$resourceGroupName = "azpstest_gp"
$location = "eastus"
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard
Remove-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName
Get-AzAppConfigurationDeletedStore -Location $location -Name $storeName
New-AzAppConfigurationStore -Name $storeName -ResourceGroupName $resourceGroupName -Location $location -Sku Standard -CreateMode 'Recover' -EnableSystemAssignedIdentity:$true -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```


### `Update-AzAppConfigurationStore`
IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

- The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IConfigurationStore' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IConfigurationStore'
- The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference'
- The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference]'
- This change will take effect on '2025-05-19'- The change is expected to take effect from Az version : '14.0.0'
- The change is expected to take effect from version : '2.0.0'

#### Before
```powershell
Update-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -DisableLocalAuth -EnablePurgeProtection -PublicNetworkAccess 'Enabled' -IdentityType SystemAssigned -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```

#### After
```powershell
Update-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -DisableLocalAuth -EnablePurgeProtection -PublicNetworkAccess 'Enabled' -EnableSystemAssignedIdentity:$true -UserAssignedIdentity "/subscriptions/xxxx/resourceGroups/azpstest_gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uai"
```


## Az.Cdn

### `Clear-AzCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Clear-AzCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ContentPath <String[]>
```

#### After
```powershell
Clear-AzCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ContentPath <String[]>
```


### `Clear-AzFrontDoorCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Clear-AzFrontDoorCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ContentPath <String[]> [-Domain <String[]>]
```

#### After
```powershell
Clear-AzFrontDoorCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ContentPath <String[]> [-Domain <String[]>]
```


### `Get-AzCdnEdgeNode`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'IPAddressGroup' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEdgeNode' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzCdnEdgeNode
```

#### After
```powershell
Get-AzCdnEdgeNode
```


### `Get-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzCdnEndpoint -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
```

#### After
```powershell
Get-AzCdnEndpoint -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
```


### `Get-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzCdnOriginGroup -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>]
```

#### After
```powershell
Get-AzCdnOriginGroup -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>]
```


### `Get-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzFrontDoorCdnEndpoint -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
```

#### After
```powershell
Get-AzFrontDoorCdnEndpoint -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
```


### `Get-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzFrontDoorCdnOriginGroup -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
```

#### After
```powershell
Get-AzFrontDoorCdnOriginGroup -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
```


### `Get-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzFrontDoorCdnRoute -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>]
```

#### After
```powershell
Get-AzFrontDoorCdnRoute -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>]
```


### `Get-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Get-AzFrontDoorCdnRule -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String[]>]
```

#### After
```powershell
Get-AzFrontDoorCdnRule -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String[]>]
```


### `Import-AzCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Import-AzCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ContentPath <String[]>
```

#### After
```powershell
Import-AzCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ContentPath <String[]>
```


### `New-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-ContentTypesToCompress <String[]>] [-DefaultOriginGroupId <String>]
 [-DeliveryPolicyDescription <String>] [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>]
 [-IsCompressionEnabled] [-IsHttpAllowed] [-IsHttpsAllowed] [-OptimizationType <OptimizationType>]
 [-Origin <IDeepCreatedOrigin[]>] [-OriginGroup <IDeepCreatedOriginGroup[]>] [-OriginHostHeader <String>]
 [-OriginPath <String>] [-ProbePath <String>] [-QueryStringCachingBehavior <QueryStringCachingBehavior>]
 [-Tag <Hashtable>] [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
```

#### After
```powershell
New-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-ContentTypesToCompress <String[]>] [-DefaultOriginGroupId <String>]
 [-DeliveryPolicyDescription <String>] [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>]
 [-IsCompressionEnabled] [-IsHttpAllowed] [-IsHttpsAllowed] [-OptimizationType <String>]
 [-Origin <IDeepCreatedOrigin[]>] [-OriginGroup <IDeepCreatedOriginGroup[]>] [-OriginHostHeader <String>]
 [-OriginPath <String>] [-ProbePath <String>] [-QueryStringCachingBehavior <String>] [-Tag <Hashtable>]
 [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
```


### `New-AzCdnManagedHttpsParametersObject`

- Cmdlet breaking-change will happen to all parameter sets
  Add new mandatory parameter CertificateSourceParameterTypeName.
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType <CertificateType>
 -CertificateSource <CertificateSource> -ProtocolType <ProtocolType> [-MinimumTlsVersion <MinimumTlsVersion>]
```

#### After
```powershell
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType <String>
 -CertificateSourceParameterTypeName <String> -ProtocolType <String> -CertificateSource <String>
 [-MinimumTlsVersion <String>]
```


### `New-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>] [-Origin <IResourceReference[]>]
 [-ResponseBasedOriginErrorDetectionSetting <IResponseBasedOriginErrorDetectionParameters>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```

#### After
```powershell
New-AzCdnOriginGroup -Name <String> -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>] [-Origin <IResourceReference[]>]
 [-ResponseBasedOriginErrorDetectionSetting <IResponseBasedOriginErrorDetectionParameters>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```


### `New-AzCdnUserManagedHttpsParametersObject`

- Cmdlet breaking-change will happen to all parameter sets
  Add new mandatory parameter CertificateSourceParameterTypeName.
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzCdnUserManagedHttpsParametersObject -CertificateSourceParameterResourceGroupName <String>
 -CertificateSourceParameterSecretName <String> -CertificateSourceParameterSubscriptionId <String>
 -CertificateSourceParameterVaultName <String> -CertificateSource <CertificateSource>
 -ProtocolType <ProtocolType> [-CertificateSourceParameterSecretVersion <String>]
 [-MinimumTlsVersion <MinimumTlsVersion>]
```

#### After
```powershell
New-AzCdnUserManagedHttpsParametersObject -CertificateSourceParameterResourceGroupName <String>
 -CertificateSourceParameterSecretName <String> -CertificateSourceParameterSubscriptionId <String>
 -CertificateSourceParameterTypeName <String> -CertificateSourceParameterVaultName <String>
 -CertificateSource <String> -ProtocolType <String> [-CertificateSourceParameterSecretVersion <String>]
 [-MinimumTlsVersion <String>]
```


### `New-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzFrontDoorCdnEndpoint -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String>
 [-AutoGeneratedDomainNameLabelScope <AutoGeneratedDomainNameLabelScope>] [-EnabledState <EnabledState>]
 [-Tag <Hashtable>]
```

#### After
```powershell
New-AzFrontDoorCdnEndpoint -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-AutoGeneratedDomainNameLabelScope <String>]
 [-EnabledState <String>] [-Tag <Hashtable>]
```


### `New-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <EnabledState>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```

#### After
```powershell
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <String>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```


### `New-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzFrontDoorCdnRoute -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CacheConfigurationQueryParameter <String>]
 [-CacheConfigurationQueryStringCachingBehavior <AfdQueryStringCachingBehavior>]
 [-CompressionSettingContentTypesToCompress <String[]>] [-CompressionSettingIsCompressionEnabled]
 [-CustomDomain <IActivatedResourceReference[]>] [-EnabledState <EnabledState>]
 [-ForwardingProtocol <ForwardingProtocol>] [-HttpsRedirect <HttpsRedirect>]
 [-LinkToDefaultDomain <LinkToDefaultDomain>] [-OriginGroupId <String>] [-OriginPath <String>]
 [-PatternsToMatch <String[]>] [-RuleSet <IResourceReference[]>] [-SupportedProtocol <AfdEndpointProtocols[]>]
```

#### After
```powershell
New-AzFrontDoorCdnRoute -Name <String> -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CacheConfigurationQueryParameter <String>]
 [-CacheConfigurationQueryStringCachingBehavior <String>]
 [-CompressionSettingContentTypesToCompress <String[]>] [-CompressionSettingIsCompressionEnabled]
 [-CustomDomain <IActivatedResourceReference[]>] [-EnabledState <String>] [-ForwardingProtocol <String>]
 [-HttpsRedirect <String>] [-LinkToDefaultDomain <String>] [-OriginGroupId <String>] [-OriginPath <String>]
 [-PatternsToMatch <String[]>] [-RuleSet <IResourceReference[]>] [-SupportedProtocol <String[]>]
```


### `New-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
    - Change description : The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'. 
    - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
New-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] [-Action <IDeliveryRuleAction1[]>] [-Condition <IDeliveryRuleCondition[]>]
 [-MatchProcessingBehavior <MatchProcessingBehavior>] [-Order <Int32>]
```

#### After
```powershell
New-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] [-Action <IDeliveryRuleAction[]>] [-Condition <IDeliveryRuleCondition[]>]
 [-MatchProcessingBehavior <String>] [-Order <Int32>]
```


### `Remove-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Remove-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```

#### After
```powershell
Remove-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```


### `Remove-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Remove-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```

#### After
```powershell
Remove-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```


### `Remove-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Remove-AzFrontDoorCdnEndpoint -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```

#### After
```powershell
Remove-AzFrontDoorCdnEndpoint -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```


### `Remove-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Remove-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```

#### After
```powershell
Remove-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
```


### `Remove-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Remove-AzFrontDoorCdnRoute -EndpointName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
```

#### After
```powershell
Remove-AzFrontDoorCdnRoute -EndpointName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
```


### `Remove-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Remove-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>]
```

#### After
```powershell
Remove-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>]
```


### `Start-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Start-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
```

#### After
```powershell
Start-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
```


### `Stop-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Stop-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
```

#### After
```powershell
Stop-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
```


### `Update-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Update-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ContentTypesToCompress <String[]>] [-DefaultOriginGroupId <String>]
 [-DeliveryPolicyDescription <String>] [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>]
 [-IsCompressionEnabled] [-IsHttpAllowed] [-IsHttpsAllowed] [-OptimizationType <OptimizationType>]
 [-OriginHostHeader <String>] [-OriginPath <String>] [-ProbePath <String>]
 [-QueryStringCachingBehavior <QueryStringCachingBehavior>] [-Tag <Hashtable>]
 [-UrlSigningKey <IUrlSigningKey[]>] [-WebApplicationFirewallPolicyLinkId <String>]
```

#### After
```powershell
Update-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ContentTypesToCompress <String[]>] [-DefaultOriginGroupId <String>]
 [-DeliveryPolicyDescription <String>] [-DeliveryPolicyRule <IDeliveryRule[]>] [-GeoFilter <IGeoFilter[]>]
 [-IsCompressionEnabled] [-IsHttpAllowed] [-IsHttpsAllowed] [-OptimizationType <String>]
 [-OriginHostHeader <String>] [-OriginPath <String>] [-ProbePath <String>]
 [-QueryStringCachingBehavior <String>] [-Tag <Hashtable>] [-UrlSigningKey <IUrlSigningKey[]>]
 [-WebApplicationFirewallPolicyLinkId <String>]
```


### `Update-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Update-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>] [-Origin <IResourceReference[]>]
 [-ResponseBasedOriginErrorDetectionSetting <IResponseBasedOriginErrorDetectionParameters>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```

#### After
```powershell
Update-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>] [-Origin <IResourceReference[]>]
 [-ResponseBasedOriginErrorDetectionSetting <IResponseBasedOriginErrorDetectionParameters>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```


### `Update-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Update-AzFrontDoorCdnEndpoint -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnabledState <EnabledState>] [-Tag <Hashtable>]
```

#### After
```powershell
Update-AzFrontDoorCdnEndpoint -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnabledState <String>] [-Tag <Hashtable>]
```


### `Update-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Update-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <EnabledState>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```

#### After
```powershell
Update-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <String>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
```


### `Update-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Update-AzFrontDoorCdnRoute -EndpointName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-CacheConfigurationQueryParameter <String>]
 [-CacheConfigurationQueryStringCachingBehavior <AfdQueryStringCachingBehavior>]
 [-CompressionSettingContentTypesToCompress <String[]>] [-CompressionSettingIsCompressionEnabled]
 [-CustomDomain <IActivatedResourceReference[]>] [-EnabledState <EnabledState>]
 [-ForwardingProtocol <ForwardingProtocol>] [-HttpsRedirect <HttpsRedirect>]
 [-LinkToDefaultDomain <LinkToDefaultDomain>] [-OriginGroupId <String>] [-OriginPath <String>]
 [-PatternsToMatch <String[]>] [-RuleSet <IResourceReference[]>] [-SupportedProtocol <AfdEndpointProtocols[]>]

```

#### After
```powershell
Update-AzFrontDoorCdnRoute -EndpointName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-CacheConfigurationQueryParameter <String>]
 [-CacheConfigurationQueryStringCachingBehavior <String>]
 [-CompressionSettingContentTypesToCompress <String[]>] [-CompressionSettingIsCompressionEnabled]
 [-CustomDomain <IActivatedResourceReference[]>] [-EnabledState <String>] [-ForwardingProtocol <String>]
 [-HttpsRedirect <String>] [-LinkToDefaultDomain <String>] [-OriginGroupId <String>] [-OriginPath <String>]
 [-PatternsToMatch <String[]>] [-RuleSet <IResourceReference[]>] [-SupportedProtocol <String[]>]
```


### `Update-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
    - Change description : The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'. 
    - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'


#### Before
```powershell
Update-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] [-Action <IDeliveryRuleAction1[]>] [-Condition <IDeliveryRuleCondition[]>]
 [-MatchProcessingBehavior <MatchProcessingBehavior>] [-Order <Int32>]
```

#### After
```powershell
Update-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String>] [-Action <IDeliveryRuleAction[]>] [-Condition <IDeliveryRuleCondition[]>]
 [-MatchProcessingBehavior <String>] [-Order <Int32>]
```


## Az.Compute

### `Get-AzVMSize`

- Cmdlet breaking-change will happen to all parameter sets
  - The "ListVirtualMachineSize" parameter set will be deprecated as its API: "Virtual Machine Sizes - List" is deprecated. For listing available VM sizes by subscription or location, please use instead "Get-AzComputeResourceSku". Other parameter sets: "List Available Sizes for Availability Set" and "List Available Sizes for Virtual Machine" will continue to be supported.
  - This change is expected to take effect from Az.Compute version: 10.0.0 and Az version: 14.0.0


#### Before
```powershell
Get-AzVMSize -Location <string>
```

#### After
```powershell
 Get-AzComputeResourceSku -Location <string>
```


## Az.Resources

### `Get-AzResource`

- Cmdlet breaking-change will happen to all parameter sets
  - The API version for the resource type will be updated to use the default version instead of the latest.
  - This change is expected to take effect from Az.Resources version: 8.0.0 and Az version: 14.0.0


### `Invoke-AzResourceAction`

- Cmdlet breaking-change will happen to all parameter sets
  - The API version for the resource type will be updated to use the default version instead of the latest.
  - This change is expected to take effect from Az.Resources version: 8.0.0 and Az version: 14.0.0
  - In most of the situations, this change won't cause any break. If you see anything unexpected, you can manually specify the API version used.


#### Before
```powershell
Invoke-AzResourceAction -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -Action <action>
```

#### After
```powershell
Invoke-AzResourceAction -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -Action <action> -ApiVersion <api version>
```


### `New-AzResource`

- Cmdlet breaking-change will happen to all parameter sets
  - The API version for the resource type will be updated to use the default version instead of the latest.
  - This change is expected to take effect from Az.Resources version: 8.0.0 and Az version: 14.0.0
  - In most of the situations, this change won't cause any break. If you see anything unexpected, you can manually specify the API version used.


#### Before
```powershell
New-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
New-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```


### `Move-AzResource`

- Cmdlet breaking-change will happen to all parameter sets
  - The API version for the resource type will be updated to use the default version instead of the latest.
  - This change is expected to take effect from Az.Resources version: 8.0.0 and Az version: 14.0.0
  - In most of the situations, this change won't cause any break. If you see anything unexpected, you can manually specify the API version used.


#### Before
```powershell
Move-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
Move-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```


### `Remove-AzResource`

- Cmdlet breaking-change will happen to all parameter sets
  - The API version for the resource type will be updated to use the default version instead of the latest.
  - This change is expected to take effect from Az.Resources version: 8.0.0 and Az version: 14.0.0


#### Before
```powershell
Remove-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
Remove-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```


### `Set-AzResource`

- Cmdlet breaking-change will happen to all parameter sets
  - The API version for the resource type will be updated to use the default version instead of the latest.
  - This change is expected to take effect from Az.Resources version: 8.0.0 and Az version: 14.0.0
  - In most of the situations, this change won't cause any break. If you see anything unexpected, you can manually specify the API version used.


#### Before
```powershell
Set-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type>
```

#### After
```powershell
Set-AzResource -ResourceGroupName <resource group> -Name <resource> -ResourceType <resource type> -ApiVersion <api version>
```


## Az.Storage

### `Set-AzStorageFileContent`

- Cmdlet breaking-change will happen to all parameter sets
  - The ContentHash properties will be removed from the uploaded Azure file when file size > 1TB, or upload with Oauth credential, or with -DisAllowTrailingDot.
  - This change is expected to take effect from Az.Storage version: 9.0.0 and Az version: 14.0.0


#### Before
```powershell
Set-AzStorageFileContent -ShareName $shareName -Path $filename -Source $localSrcFile -Context $ctxoauth
```

#### After
```powershell
# If need contenthash in MD5, need set it after upload file
$file = Set-AzStorageFileContent -ShareName $shareName -Path $filename -Source $localSrcFile -Context $ctxoauth -PassThru
$md5 = New-Object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider
$filems5 = $md5.ComputeHash([System.IO.File]::ReadAllBytes($localSrcFile))
$file.ShareFileClient.SetHttpHeaders(@{"HttpHeaders" = @{"ContentHash" = $filems5}})
```


### `Start-AzStorageAccountMigration`

- Cmdlet breaking-change will happen to all parameter sets
  A prompt that needs users' confirmation will be added when converting the account's redundancy configuration. Suppress it with -Force.
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '9.0.0'


#### Before
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -AsJob
```

#### After
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -Force -AsJob
```


