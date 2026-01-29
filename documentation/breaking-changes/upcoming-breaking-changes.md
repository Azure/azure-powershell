# Upcoming breaking changes in Azure PowerShell

The breaking changes listed in this article are planned for the next major release of the Az
PowerShell module unless otherwise noted. Per our
[Support lifecycle](azureps-support-lifecycle.md), breaking changes in Azure PowerShell occur twice
a year with major versions of the Az PowerShell module.

Preview modules are not included in this list. Read more about [module version types](azureps-support-lifecycle.md#module-version-types).

## Az.Resources

### `Get-AzRoleDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type PSRoleDefinition is changing. The flattened properties 'Actions', 'NotActions', 'DataActions', 'NotDataActions', 'Condition', and 'ConditionVersion' are being removed. Use 'Permissions[n].Actions', 'Permissions[n].DataActions', etc. instead to access the full permission structure with per-permission conditions.
  - This change is expected to take effect from Az.Resources version: 10.0.0 and Az version: 16.0.0

### `Get-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Resources' from version : '9.0.0'

### `New-AzRoleDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The -InputFile JSON format and -Role parameter are changing. The flattened properties 'Actions', 'NotActions', 'DataActions', 'NotDataActions' at the root level are being replaced by a 'Permissions' array. Each permission object contains 'Actions', 'NotActions', 'DataActions', 'NotDataActions', 'Condition', and 'ConditionVersion' properties. The output type PSRoleDefinition is also changing accordingly.
  - This change is expected to take effect from Az.Resources version: 10.0.0 and Az version: 16.0.0

### `Remove-AzRoleDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The -InputObject parameter type PSRoleDefinition is changing. The flattened properties 'Actions', 'NotActions', 'DataActions', 'NotDataActions', 'Condition', 'ConditionVersion' are being replaced by a 'Permissions' array containing permission objects with these properties. The output when using -PassThru is also changing accordingly.
  - This change is expected to take effect from Az.Resources version: 10.0.0 and Az version: 16.0.0

### `Set-AzRoleDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The -InputFile JSON format and -Role parameter are changing. The flattened properties 'Actions', 'NotActions', 'DataActions', 'NotDataActions' at the root level are being replaced by a 'Permissions' array. Each permission object contains 'Actions', 'NotActions', 'DataActions', 'NotDataActions', 'Condition', and 'ConditionVersion' properties. The output type PSRoleDefinition is also changing accordingly.
  - This change is expected to take effect from Az.Resources version: 10.0.0 and Az version: 16.0.0

### `Update-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Resources' from version : '9.0.0'

- Parameter breaking-change will happen to parameter set `UpdateAzRoleManagementPolicy_UpdateExpanded`
  - `-Rule`
    - The parameter : 'Rule' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect in 'Az.Resources' from version : '9.0.0'

- Parameter breaking-change will happen to parameter set `UpdateAzRoleManagementPolicy_UpdateViaIdentityExpanded`
  - `-Rule`
    - The parameter : 'Rule' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect in 'Az.Resources' from version : '9.0.0'

## Az.StackHCI

### `Get-AzStackHciArcSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IArcSetting' is changing
  - The following properties in the output type are being deprecated : 'DefaultExtension' 'PerNodeDetail'
  - The following properties are being added to the output type : 'DefaultExtension' 'PerNodeDetail'
  - Change description : The types of the properties DefaultExtension and PerNodeDetail will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStackHciCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.ICluster' is changing
  - The following properties in the output type are being deprecated : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - The following properties are being added to the output type : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - Change description : The types of the properties ReportedPropertyNode, LogCollectionPropertyLogCollectionSessionDetail, RemoteSupportPropertyRemoteSupportSessionDetail, RemoteSupportPropertyRemoteSupportNodeSetting and ReportedPropertySupportedCapability will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStackHciDeploymentSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IDeploymentSetting' is changing
  - The following properties in the output type are being deprecated : 'DeploymentStatusStep' 'ValidationStatusStep' 'DeploymentConfigurationScaleUnit' 'ArcNodeResourceId'
  - The following properties are being added to the output type : 'DeploymentStatusStep' 'ValidationStatusStep' 'DeploymentConfigurationScaleUnit' 'ArcNodeResourceId'
  - Change description : The types of the properties DeploymentStatusStep, ValidationStatusStep, DeploymentConfigurationScaleUnit and ArcNodeResourceId will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStackHciExtension`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IExtension' is changing
  - The following properties in the output type are being deprecated : 'PerNodeExtensionDetail'
  - The following properties are being added to the output type : 'PerNodeExtensionDetail'
  - Change description : The type of the property PerNodeExtensionDetail will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStackHciUpdate`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdate' is changing
  - The following properties in the output type are being deprecated : 'ComponentVersion' 'HealthCheckResult' 'Prerequisite'
  - The following properties are being added to the output type : 'ComponentVersion' 'HealthCheckResult' 'Prerequisite'
  - Change description : The types of the properties ComponentVersion, HealthCheckResult and Prerequisite will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStackHciUpdateRun`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateRun' is changing
  - The following properties in the output type are being deprecated : 'ProgressStep'
  - The following properties are being added to the output type : 'ProgressStep'
  - Change description : The type of the property ProgressStep will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStackHciUpdateSummary`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateSummaries' is changing
  - The following properties in the output type are being deprecated : 'PackageVersion' 'HealthCheckResult'
  - The following properties are being added to the output type : 'PackageVersion' 'HealthCheckResult'
  - Change description : The types of the properties PackageVersion and HealthCheckResult will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Invoke-AzStackHciConsentAndInstallDefaultExtension`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IArcSetting' is changing
  - The following properties in the output type are being deprecated : 'DefaultExtension' 'PerNodeDetail'
  - The following properties are being added to the output type : 'DefaultExtension' 'PerNodeDetail'
  - Change description : The types of the properties DefaultExtension and PerNodeDetail will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.ICluster' is changing
  - The following properties in the output type are being deprecated : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - The following properties are being added to the output type : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - Change description : The types of the properties ReportedPropertyNode, LogCollectionPropertyLogCollectionSessionDetail, RemoteSupportPropertyRemoteSupportSessionDetail, RemoteSupportPropertyRemoteSupportNodeSetting and ReportedPropertySupportedCapability will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzStackHciArcSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IArcSetting' is changing
  - The following properties in the output type are being deprecated : 'DefaultExtension' 'PerNodeDetail'
  - The following properties are being added to the output type : 'DefaultExtension' 'PerNodeDetail'
  - Change description : The types of the properties DefaultExtension and PerNodeDetail will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzStackHciCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.ICluster' is changing
  - The following properties in the output type are being deprecated : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - The following properties are being added to the output type : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - Change description : The types of the properties ReportedPropertyNode, LogCollectionPropertyLogCollectionSessionDetail, RemoteSupportPropertyRemoteSupportSessionDetail, RemoteSupportPropertyRemoteSupportNodeSetting and ReportedPropertySupportedCapability will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    The type of the parameter is changing from 'string' to 'boolean'.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system-assigned identities. 
    - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

### `New-AzStackHciDeploymentSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IDeploymentSetting' is changing
  - The following properties in the output type are being deprecated : 'DeploymentStatusStep' 'ValidationStatusStep' 'DeploymentConfigurationScaleUnit' 'ArcNodeResourceId' 'DeploymentDataSecret' 'DeploymentDataInfrastructureNetwork' 'HostNetworkIntent' 'DeploymentDataPhysicalNode' 'SbePartnerInfoCredentialList' 'SbePartnerInfoPartnerProperty' 'HostNetworkStorageNetwork'
  - The following properties are being added to the output type : 'DeploymentStatusStep' 'ValidationStatusStep' 'DeploymentConfigurationScaleUnit' 'ArcNodeResourceId' 'DeploymentDataSecret' 'DeploymentDataInfrastructureNetwork' 'HostNetworkIntent' 'DeploymentDataPhysicalNode' 'SbePartnerInfoCredentialList' 'SbePartnerInfoPartnerProperty' 'HostNetworkStorageNetwork'
  - Change description : The types of the properties DeploymentStatusStep, ValidationStatusStep, DeploymentConfigurationScaleUnit and ArcNodeResourceId will be changed from single object or fixed array to 'List'. The type of property DeploymentDataSecret, DeploymentDataInfrastructureNetwork, HostNetworkIntent, DeploymentDataPhysicalNode, SbePartnerInfoCredentialList, SbePartnerInfoPartnerProperty and HostNetworkStorageNetwork of type ScaleUnits will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzStackHciExtension`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IExtension' is changing
  - The following properties in the output type are being deprecated : 'PerNodeExtensionDetail'
  - The following properties are being added to the output type : 'PerNodeExtensionDetail'
  - Change description : The type of the property PerNodeExtensionDetail will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Set-AzStackHciUpdate`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdate' is changing
  - The following properties in the output type are being deprecated : 'ComponentVersion' 'HealthCheckResult' 'Prerequisite'
  - The following properties are being added to the output type : 'ComponentVersion' 'HealthCheckResult' 'Prerequisite'
  - Change description : The types of the properties ComponentVersion, HealthCheckResult and Prerequisite will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Set-AzStackHciUpdateRun`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateRun' is changing
  - The following properties in the output type are being deprecated : 'ProgressStep'
  - The following properties are being added to the output type : 'ProgressStep'
  - Change description : The type of the property ProgressStep will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Set-AzStackHciUpdateSummary`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IUpdateSummaries' is changing
  - The following properties in the output type are being deprecated : 'PackageVersion' 'HealthCheckResult'
  - The following properties are being added to the output type : 'PackageVersion' 'HealthCheckResult'
  - Change description : The types of the properties PackageVersion and HealthCheckResult will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Test-AzStackHciEdgeDevice`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'
  - The output type 'string' is changing
  - The following properties in the output type are being deprecated : 'EdgeDeviceId'
  - The following properties are being added to the output type : 'EdgeDeviceId'
  - Change description : The type of the property EdgeDeviceId will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzStackHciCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.ICluster' is changing
  - The following properties in the output type are being deprecated : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - The following properties are being added to the output type : 'ReportedPropertyNode' 'LogCollectionPropertyLogCollectionSessionDetail' 'RemoteSupportPropertyRemoteSupportSessionDetail' 'RemoteSupportPropertyRemoteSupportNodeSetting' 'ReportedPropertySupportedCapability'
  - Change description : The types of the properties ReportedPropertyNode, LogCollectionPropertyLogCollectionSessionDetail, RemoteSupportPropertyRemoteSupportSessionDetail, RemoteSupportPropertyRemoteSupportNodeSetting and ReportedPropertySupportedCapability will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    The type of the parameter is changing from 'string' to 'boolean'.
    - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system-assigned identities. 
    - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

## Az.Storage

### `New-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-MinimumTlsVersion`
    - The MinimumTlsVersion parameter will no longer allow TLS 1.0 or TLS 1.1. TLS 1.2 or later will be required.
    - This change is expected to take effect from Az.Storage version: 9.7.0 and Az version: 15.4.0

### `Set-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-MinimumTlsVersion`
    - The MinimumTlsVersion parameter will no longer allow TLS 1.0 or TLS 1.1. TLS 1.2 or later will be required.
    - This change is expected to take effect from Az.Storage version: 9.7.0 and Az version: 15.4.0
