# Upcoming breaking changes in Azure PowerShell

The breaking changes listed in this article are planned for the next major release of the Az
PowerShell module unless otherwise noted. Per our
[Support lifecycle](azureps-support-lifecycle.md), breaking changes in Azure PowerShell occur twice
a year with major versions of the Az PowerShell module.

Preview modules are not included in this list. Read more about [module version types](azureps-support-lifecycle.md#module-version-types).

## Az.CloudService

### `Get-AzCloudService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudService' is changing
  - The following properties in the output type are being deprecated : 'Extension' 'LoadBalancerConfiguration' 'Secret' 'Role' 'Zone'
  - The following properties are being added to the output type : 'Extension' 'LoadBalancerConfiguration' 'Secret' 'Role' 'Zone'
  - Change description : The types of the properties 'Extension', 'LoadBalancerConfiguration', 'Secret', 'Role', and 'Zone' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzCloudServiceInstanceView`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudServiceInstanceView' is changing
  - The following properties in the output type are being deprecated : 'Statuses' 'RoleInstanceStatusesSummary' 'PrivateId'
  - The following properties are being added to the output type : 'Statuses' 'RoleInstanceStatusesSummary' 'PrivateId'
  - Change description : The types of the properties 'Statuses', 'RoleInstanceStatusesSummary', and 'PrivateId' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzCloudServiceNetworkInterface`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface' is changing
  - The following properties in the output type are being deprecated : 'ApplicationSecurityGroup' 'CustomDnsConfig' 'FlowLog' 'LoadBalancerFrontendIPConfiguration' 'NetworkSecurityGroupPropertiesNetworkInterface' 'PrivateEndpointPropertiesNetworkInterface' 'PrivateLinkServicePropertiesNetworkInterface' 'IPConfiguration' 'TapConfiguration' 'PrivateEndpointConnection' 'PrivateEndpointPropertiesIPConfiguration' 'PrivateLinkServiceConnection' 'ManualPrivateLinkServiceConnection' 'PrivateLinkServicePropertiesIPConfiguration' 'SecurityRule' 'DefaultSecurityRule' 'ApplicationGatewayIPConfiguration' 'Delegation' 'FlowLog' 'IPConfiguration' 'IPConfigurationProfile' 'NetworkInterface' 'PrivateEndpoint' 'ResourceNavigationLink' 'Route' 'DefaultSecurityRule' 'SecurityRule' 'ServiceAssociationLink' 'ServiceEndpointPolicy' 'ServiceEndpoint' 'NetworkSecurityGroupPropertiesSubnet' 'RouteTablePropertiesSubnet' 'IPAllocation' 'PropertiesAddressPrefixes' 'PropertiesNetworkSecurityGroupPropertiesSubnets' 'HostedWorkload' 'VisibilitySubscription' 'DnsSettingDnsServer' 'DnsSettingAppliedDnsServer' 'AutoApprovalSubscription' 'Fqdn'
  - The following properties are being added to the output type : 'ApplicationSecurityGroup' 'CustomDnsConfig' 'FlowLog' 'LoadBalancerFrontendIPConfiguration' 'NetworkSecurityGroupPropertiesNetworkInterface' 'PrivateEndpointPropertiesNetworkInterface' 'PrivateLinkServicePropertiesNetworkInterface' 'IPConfiguration' 'TapConfiguration' 'PrivateEndpointConnection' 'PrivateEndpointPropertiesIPConfiguration' 'PrivateLinkServiceConnection' 'ManualPrivateLinkServiceConnection' 'PrivateLinkServicePropertiesIPConfiguration' 'SecurityRule' 'DefaultSecurityRule' 'ApplicationGatewayIPConfiguration' 'Delegation' 'FlowLog' 'IPConfiguration' 'IPConfigurationProfile' 'NetworkInterface' 'PrivateEndpoint' 'ResourceNavigationLink' 'Route' 'DefaultSecurityRule' 'SecurityRule' 'ServiceAssociationLink' 'ServiceEndpointPolicy' 'ServiceEndpoint' 'NetworkSecurityGroupPropertiesSubnet' 'RouteTablePropertiesSubnet' 'IPAllocation' 'PropertiesAddressPrefixes' 'PropertiesNetworkSecurityGroupPropertiesSubnets' 'HostedWorkload' 'VisibilitySubscription' 'DnsSettingDnsServer' 'DnsSettingAppliedDnsServer' 'AutoApprovalSubscription' 'Fqdn'
  - Change description : The types of the properties 'ApplicationSecurityGroup', 'CustomDnsConfig', 'FlowLog', 'LoadBalancerFrontendIPConfiguration', 'NetworkSecurityGroupPropertiesNetworkInterface', 'PrivateEndpointPropertiesNetworkInterface', 'PrivateLinkServicePropertiesNetworkInterface', 'IPConfiguration', 'TapConfiguration', 'PrivateEndpointConnection', 'PrivateEndpointPropertiesIPConfiguration', 'PrivateLinkServiceConnection', 'ManualPrivateLinkServiceConnection', 'PrivateLinkServicePropertiesIPConfiguration', 'SecurityRule', 'DefaultSecurityRule', 'ApplicationGatewayIPConfiguration', 'Delegation', 'FlowLog', 'IPConfiguration', 'IPConfigurationProfile', 'NetworkInterface', 'PrivateEndpoint', 'ResourceNavigationLink', 'Route', 'DefaultSecurityRule', 'SecurityRule', 'ServiceAssociationLink', 'ServiceEndpointPolicy', 'ServiceEndpoint', 'NetworkSecurityGroupPropertiesSubnet', 'RouteTablePropertiesSubnet', 'IPAllocation', 'PropertiesAddressPrefixes', 'PropertiesNetworkSecurityGroupPropertiesSubnets', 'HostedWorkload', 'VisibilitySubscription', 'DnsSettingDnsServer', 'DnsSettingAppliedDnsServer', 'AutoApprovalSubscription', 'Fqdn' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzCloudServiceOSFamily`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.IOSFamily' is changing
  - The following properties in the output type are being deprecated : 'Version'
  - The following properties are being added to the output type : 'Version'
  - Change description : The types of the properties 'Version' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzCloudServicePublicIPAddress`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPublicIPAddress' is changing
  - The following properties in the output type are being deprecated : 'Zone' 'IPTag' 'PublicIPAddress' 'PublicIPPrefix' 'Subnet'
  - The following properties are being added to the output type : 'Zone' 'IPTag' 'PublicIPAddress' 'PublicIPPrefix' 'Subnet'
  - Change description : The types of the properties 'Zone', 'IPTag', 'PublicIPAddress', 'PublicIPPrefix', and 'Subnet' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzCloudServiceRoleInstance`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.IRoleInstance' is changing
  - The following properties in the output type are being deprecated : 'NetworkProfileNetworkInterface' 'InstanceViewStatuses'
  - The following properties are being added to the output type : 'NetworkProfileNetworkInterface' 'InstanceViewStatuses'
  - Change description : The types of the properties 'NetworkProfileNetworkInterface' and 'InstanceViewStatuses' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzCloudServiceRoleInstanceView`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.IRoleInstanceView' is changing
  - The following properties in the output type are being deprecated : 'Statuses'
  - The following properties are being added to the output type : 'Statuses'
  - Change description : The types of the properties 'Statuses' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzCloudService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudService' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudService'
  - The following properties in the output type are being deprecated : 'Zone, Extension, LoadBalancerConfiguration, Secret, Role'
  - The following properties are being added to the output type : 'Zone, Extension, LoadBalancerConfiguration, Secret, Role will be changed from object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzCloudServiceDiagnosticsExtension`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.Extension' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Extension'
  - The following properties in the output type are being deprecated : 'RolesAppliedTo System.String[]'
  - The following properties are being added to the output type : 'RolesAppliedTo System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzCloudServiceExtensionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.Extension' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Extension'
  - The following properties in the output type are being deprecated : 'RolesAppliedTo System.String[]'
  - The following properties are being added to the output type : 'RolesAppliedTo System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzCloudServiceLoadBalancerConfigurationObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.LoadBalancerConfiguration' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.LoadBalancerConfiguration'
  - The following properties in the output type are being deprecated : 'FrontendIPConfiguration Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ILoadBalancerFrontendIPConfiguration'
  - The following properties are being added to the output type : 'FrontendIPConfiguration System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ILoadBalancerFrontendIPConfiguration]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzCloudServiceRemoteDesktopExtensionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.Extension' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Extension'
  - The following properties in the output type are being deprecated : 'RolesAppliedTo System.String[]'
  - The following properties are being added to the output type : 'RolesAppliedTo System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzCloudServiceVaultSecretGroupObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudServiceVaultSecretGroup' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.CloudServiceVaultSecretGroup'
  - The following properties in the output type are being deprecated : 'VaultCertificate Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceVaultCertificate'
  - The following properties are being added to the output type : 'VaultCertificate System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceVaultCertificate]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzCloudService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.ICloudService' is changing
  - The following properties in the output type are being deprecated : 'Extension' 'LoadBalancerConfiguration' 'Secret' 'Role' 'Zone'
  - The following properties are being added to the output type : 'Extension' 'LoadBalancerConfiguration' 'Secret' 'Role' 'Zone'
  - Change description : The types of the properties 'Extension', 'LoadBalancerConfiguration', 'Secret', 'Role', and 'Zone' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Compute

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter sets
  - The default VM size will change from 'Standard_D2s_v3' to 'Standard_D2s_v5'.
  - This change is expected to take effect from Az.Compute version: 11.0.0 and Az version: 15.0.0

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - In the next breaking change period (Nov 2025), the default VM size will change from 'Standard_Ds1_v2' to 'Standard_D2s_v5'.
  - This change is expected to take effect from Az.Compute version: 11.0.0 and Az version: 15.0.0

## Az.ContainerInstance

### `New-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerGroup' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IContainerGroup'
  - The following properties in the output type are being deprecated : 'Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd'
  - The following properties are being added to the output type : 'Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'
  IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    

### `New-AzContainerInstanceContainerGroupProfile`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - Change description : Removing the default value of OSType parameter. 
    - This change will take effect on '5/21/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzContainerInstanceInitDefinitionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.InitContainerDefinition' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.InitContainerDefinition'
  - The following properties in the output type are being deprecated : 'EnvironmentVariable, InstanceViewEvent, VolumeMount, Command, CapabilityDrop, CapabilityAdd'
  - The following properties are being added to the output type : 'EnvironmentVariable, InstanceViewEvent, VolumeMount, Command, CapabilityDrop, CapabilityAdd. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerInstanceNoDefaultObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Container'
  - The following properties in the output type are being deprecated : 'Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, LimitsGpuSku, RequestsGpuSku, ReadinessProbeHttpGetScheme, LivenessProbeHttpGetScheme, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd, Protocol'
  - The following properties are being added to the output type : 'Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, LimitsGpuSku, RequestsGpuSku, ReadinessProbeHttpGetScheme, LivenessProbeHttpGetScheme, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd, Protocol. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerInstanceObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Container'
  - The following properties in the output type are being deprecated : 'Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, LimitsGpuSku, RequestsGpuSku, ReadinessProbeHttpGetScheme, LivenessProbeHttpGetScheme, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd, Protocol'
  - The following properties are being added to the output type : 'Port, EnvironmentVariable, InstanceViewEvent, LivenessProbeHttpGetHttpHeader, ReadinessProbeHttpGetHttpHeader, VolumeMount, LimitsGpuSku, RequestsGpuSku, ReadinessProbeHttpGetScheme, LivenessProbeHttpGetScheme, ReadinessProbeExecCommand, Command, CapabilityDrop, LivenessProbeExecCommand, CapabilityAdd, Protocol. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Databricks

### `Get-AzDatabricksAccessConnector`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IAccessConnector' is changing
  - The following properties in the output type are being deprecated : 'ReferedBy'
  - The following properties are being added to the output type : 'ReferedBy'
  - Change description : The types of the properties 'ReferedBy' will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]' 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDatabricksOutboundNetworkDependenciesEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IOutboundEnvironmentEndpoint' is changing
  - The following properties in the output type are being deprecated : 'Endpoint'
  - The following properties are being added to the output type : 'Endpoint'
  - Change description : The types of the properties 'Endpoint' will be changed from 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IEndpointDependency' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IEndpointDependency]' 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDatabricksVNetPeering`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IVirtualNetworkPeering' is changing
  - The following properties in the output type are being deprecated : 'DatabrickAddressSpaceAddressPrefix' 'RemoteAddressSpaceAddressPrefix'
  - The following properties are being added to the output type : 'DatabrickAddressSpaceAddressPrefix' 'RemoteAddressSpaceAddressPrefix'
  - Change description : The types of the properties 'DatabrickAddressSpaceAddressPrefix' and 'RemoteAddressSpaceAddressPrefix' will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]' 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzDatabricksWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IWorkspace' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Authorization' 'ComplianceSecurityProfileComplianceStandard'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Authorization' 'ComplianceSecurityProfileComplianceStandard'
  - Change description : The types of the properties 'PrivateEndpointConnection', 'Authorization' and 'ComplianceSecurityProfileComplianceStandard' will be changed from object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzDatabricksAccessConnector`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IAccessConnector' is changing
  - The following properties in the output type are being deprecated : 'ReferedBy' 'EnableSystemAssignedIdentity' 'UserAssignedIdentity'
  - The following properties are being added to the output type : 'ReferedBy' 'EnableSystemAssignedIdentity' 'UserAssignedIdentity'
  - Change description : (1) The types of the properties 'ReferedBy' will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]' (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzDatabricksVNetPeering`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IVirtualNetworkPeering' is changing
  - The following properties in the output type are being deprecated : 'DatabrickAddressSpaceAddressPrefix' 'RemoteAddressSpaceAddressPrefix'
  - The following properties are being added to the output type : 'DatabrickAddressSpaceAddressPrefix' 'RemoteAddressSpaceAddressPrefix'
  - Change description : The types of the properties 'DatabrickAddressSpaceAddressPrefix' and 'RemoteAddressSpaceAddressPrefix' will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]' 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzDatabricksWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IWorkspace' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IWorkspace'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection, ComplianceSecurityProfileComplianceStandard, Authorization'
  - The following properties are being added to the output type : 'PrivateEndpointConnection, ComplianceSecurityProfileComplianceStandard, Authorization The types of the properties will be changed from object to 'List''
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzDatabricksAccessConnector`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IAccessConnector' is changing
  - The following properties in the output type are being deprecated : 'ReferedBy' 'EnableSystemAssignedIdentity' 'UserAssignedIdentity'
  - The following properties are being added to the output type : 'ReferedBy' 'EnableSystemAssignedIdentity' 'UserAssignedIdentity'
  - Change description : (1) The types of the properties 'ReferedBy' will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]' (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzDatabricksVNetPeering`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IVirtualNetworkPeering' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IVirtualNetworkPeering'
  - The following properties in the output type are being deprecated : 'DatabrickAddressSpaceAddressPrefix, RemoteAddressSpaceAddressPrefix 'System.String[]''
  - The following properties are being added to the output type : 'DatabrickAddressSpaceAddressPrefix, RemoteAddressSpaceAddressPrefix 'System.Collections.Generic.List1[System.String]''
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzDatabricksWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.IWorkspace' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.IWorkspace'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection, ComplianceSecurityProfileComplianceStandard, Authorization'
  - The following properties are being added to the output type : 'PrivateEndpointConnection, ComplianceSecurityProfileComplianceStandard, Authorization The types of the properties will be changed from object to 'List''
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

## Az.ManagedServices

### `Get-AzManagedServicesAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationAssignment' is changing
  - The following properties in the output type are being deprecated : 'Authorization[]' 'EligibleAuthorization[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzManagedServicesDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationDefinition' is changing
  - The following properties in the output type are being deprecated : 'Authorization[]' 'EligibleAuthorization[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzManagedServicesAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationAssignment' is changing
  - The following properties in the output type are being deprecated : 'Authorization[]' 'EligibleAuthorization[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzManagedServicesAuthorizationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-DelegatedRoleDefinitionId`
    

### `New-AzManagedServicesDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationDefinition' is changing
  - The following properties in the output type are being deprecated : 'Authorization' 'EligibleAuthorization' 'DelegatedRoleDefinitionId[]' 'JustInTimeAccessPolicyManagedByTenantApprover[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]' 'List[DelegatedRoleDefinitionId]' 'List[JustInTimeAccessPolicyManagedByTenantApprover]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Authorization`
    - The parameter : 'Authorization' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '9.0.0'
  - `-EligibleAuthorization`
    - The parameter : 'EligibleAuthorization' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '9.0.0'

### `New-AzManagedServicesEligibleAuthorizationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-JustInTimeAccessPolicyManagedByTenantApprover`
    

## Az.Monitor

### `Get-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.IDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log' 'Metric'
  - The following properties are being added to the output type : 'Log' 'Metric'
  - Change description : The types of the properties Log and Metric will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

### `Get-AzDiagnosticSettingCategory`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.IDiagnosticSettingsCategoryResource' is changing
  - The following properties in the output type are being deprecated : 'CategoryGroup'
  - The following properties are being added to the output type : 'CategoryGroup'
  - Change description : The type of the property CategoryGroup will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

### `Get-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzSubscriptionDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.ISubscriptionDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log'
  - The following properties are being added to the output type : 'Log'
  - Change description : The type of the property Log will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

### `New-AzAutoscaleNotificationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-EmailCustomEmail`
    
  - `-Webhook`
    

### `New-AzAutoscaleProfileObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Rule`
    
  - `-ScheduleDay`
    
  - `-ScheduleHour`
    
  - `-ScheduleMinute`
    

### `New-AzAutoscaleScaleRuleMetricDimensionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Value`
    

### `New-AzAutoscaleScaleRuleObject`

- Parameter breaking-change will happen to all parameter sets
  - `-MetricTriggerDimension`
    

### `New-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.IDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log' 'Metric'
  - The following properties are being added to the output type : 'Log' 'Metric'
  - Change description : The types of the properties Log and Metric will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

- Parameter breaking-change will happen to parameter set `NewAzDiagnosticSetting_CreateExpanded`
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

### `New-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzSubscriptionDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.ISubscriptionDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log'
  - The following properties are being added to the output type : 'Log'
  - Change description : The type of the property Log will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

- Parameter breaking-change will happen to parameter set `NewAzSubscriptionDiagnosticSetting_CreateExpanded`
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

### `Update-AzDiagnosticSetting`

- Parameter breaking-change will happen to all parameter sets
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

### `Update-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Update-AzSubscriptionDiagnosticSetting`

- Parameter breaking-change will happen to all parameter sets
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect in 'Az.Monitor' from version : '7.0.0'

## Az.MySql

### `Get-AzMySqlConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzMySqlConnectionString`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzMySqlFirewallRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzMySqlReplica`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzMySqlServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzMySqlVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzMySqlFirewallRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzMySqlReplica`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzMySqlServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzMySqlVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Remove-AzMySqlFirewallRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Remove-AzMySqlServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Remove-AzMySqlVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Restart-AzMySqlServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Restore-AzMySqlServer_GeoRestore`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Restore-AzMySqlServer_PointInTimeRestore`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzMySqlConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzMySqlFirewallRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzMySqlServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzMySqlServerConfigurationsList`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzMySqlVirtualNetworkRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/1/2026'- The change is expected to take effect from Az version : '16.0.0'
  - The change is expected to take effect from version : '2.0.0'

## Az.Network

### `Invoke-AzFirewallPacketCapture`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.Network version: Az.Network: 8.0.0 and Az version: Az: 15.0.0

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupSchedulePolicyObject`

- Cmdlet breaking-change will happen to all parameter sets
  - May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload
  - This change is expected to take effect from Az.RecoveryServices version: 8.0.0 and Az version: 14.0.0

## Az.Relay

### `Get-AzRelayNamespace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayNamespace' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection'
  - The following properties are being added to the output type : 'List[PrivateEndpointConnection]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Relay' from version : '9.0.0'

### `Get-AzRelayNamespaceNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.INetworkRuleSet' is changing
  - The following properties in the output type are being deprecated : 'IPRule'
  - The following properties are being added to the output type : 'List[IPRule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Relay' from version : '9.0.0'

## Az.Resources

### `Get-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.Resources' from version : '9.0.0'

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

## Az.SecurityInsights

### `Get-AzSentinelEnrichment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelAutomationRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelBookmark`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelBookmarkRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelIncident`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelIncidentComment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelIncidentRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelIncidentTeam`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzSentinelOnboardingState`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/19/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '4.0.0'

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

## Az.StreamAnalytics

### `Get-AzStreamAnalyticsInput`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IInput' is changing
  - The following properties in the output type are being deprecated : 'Condition'
  - The following properties are being added to the output type : 'Condition'
  - Change description : The type of property Condition will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.StreamAnalytics' from version : '3.0.0'

### `Get-AzStreamAnalyticsJob`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamingJob' is changing
  - The following properties in the output type are being deprecated : 'Input' 'Output'
  - The following properties are being added to the output type : 'Input' 'Output'
  - Change description : The types of the properties Input and Output will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.StreamAnalytics' from version : '3.0.0'

### `Get-AzStreamAnalyticsOutput`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IOutput' is changing
  - The following properties in the output type are being deprecated : 'DiagnosticCondition'
  - The following properties are being added to the output type : 'DiagnosticCondition'
  - Change description : The type of property DiagnosticCondition will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.StreamAnalytics' from version : '3.0.0'

### `Get-AzStreamAnalyticsQuota`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ISubscriptionQuotasListResult' is changing
  - The following properties in the output type are being deprecated : 'ISubscriptionQuota'
  - The following properties are being added to the output type : 'ISubscriptionQuotasListResult'
  - Change description : The type of property Quota will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.StreamAnalytics' from version : '3.0.0'

### `New-AzStreamAnalyticsJob`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob' is changing
  - Change description : The types of the properties Function, Input and Output will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.StreamAnalytics' from version : '3.0.0'

### `Update-AzStreamAnalyticsJob`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob' is changing
  - Change description : The types of the properties Function, Input and Output will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect in 'Az.StreamAnalytics' from version : '3.0.0'
