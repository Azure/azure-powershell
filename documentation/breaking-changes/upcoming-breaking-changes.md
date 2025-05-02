# Upcoming breaking changes in Azure PowerShell

## Az.Accounts

### `Get-AzAccessToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The Token property of the output type will be changed from String to SecureString. Add the [-AsSecureString] switch to avoid the impact of this upcoming breaking change.
  - This change is expected to take effect from Az.Accounts version: 5.0.0 and Az version: 14.0.0

## Az.Aks

### `Get-AzAksMaintenanceConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMaintenanceConfiguration'
  - The following properties in the output type are being deprecated : 'TimeInWeek Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek' 'NotAllowedTime Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan'
  - The following properties are being added to the output type : 'TimeInWeek System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]' 'NotAllowedTime System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
  - Change description : The type of property 'TimeInWeek' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek[]' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]',The type of property 'NotAllowedTime' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]' 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAksManagedClusterOSOption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProfile'
  - The following properties in the output type are being deprecated : 'OSOptionPropertyList Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty'
  - The following properties are being added to the output type : 'OSOptionPropertyList System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]'
  - Change description : The type of property 'OSOptionPropertyList' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOSOptionProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOSOptionProperty]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOutboundEnvironmentEndpoint'
  - The following properties in the output type are being deprecated : 'Endpoint Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency'
  - The following properties are being added to the output type : 'Endpoint System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]'
  - Change description : The type of property 'Endpoint' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IOutboundEnvironmentEndpoint' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IEndpointDependency]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAksNodePoolUpgradeProfile`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfile'
  - The following properties in the output type are being deprecated : 'Upgrade Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem'
  - The following properties are being added to the output type : 'Upgrade System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]'
  - Change description : The type of property 'Upgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IAgentPoolUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAgentPoolUpgradeProfilePropertiesUpgradesItem]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAksUpgradeProfile`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterUpgradeProfile'
  - The following properties in the output type are being deprecated : 'AgentPoolProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile' 'ControlPlaneProfileUpgrade Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem'
  - The following properties are being added to the output type : 'AgentPoolProfile System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]' 'ControlPlaneProfileUpgrade System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]'
  - Change description : The type of property 'AgentPoolProfile' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfile]'.,The type of property 'ControlPlaneProfileUpgrade' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IManagedClusterUpgradeProfile' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IManagedClusterPoolUpgradeProfileUpgradesItem]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAksVersion`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfileListResult'
  - The following properties in the output type are being deprecated : 'Orchestrator Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile'
  - The following properties are being added to the output type : 'Orchestrator System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IOrchestratorVersionProfile]'
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzAksMaintenanceConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IMaintenanceConfiguration'
  - The following properties in the output type are being deprecated : 'TimeInWeek Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek' 'NotAllowedTime Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan'
  - The following properties are being added to the output type : 'TimeInWeek System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]' 'NotAllowedTime System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]'
  - Change description : The type of property 'TimeInWeek' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek[]' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeInWeek]',The type of property 'NotAllowedTime' of type 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20230201.IMaintenanceConfiguration' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITimeSpan]' 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '7.0.0'

## Az.AppConfiguration

### `Get-AzAppConfigurationStore`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IConfigurationStore' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IConfigurationStore'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference'
  - The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference]'
  - Change description : The type of property 'PrivateEndpointConnection' of type 'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20220501.IConfigurationStore' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.IPrivateEndpointConnectionReference]' 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzAppConfigurationStore`

- Cmdlet breaking-change will happen to all parameter sets
  IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzAppConfigurationStore`

- Cmdlet breaking-change will happen to all parameter sets
  IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

## Az.Blueprint

### `Export-AzBlueprintWithArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Get-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Get-AzBlueprintArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Get-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Import-AzBlueprintWithArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `New-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `New-AzBlueprintArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `New-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Publish-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Remove-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Set-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Set-AzBlueprintArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Set-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

## Az.Cdn

### `Clear-AzCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Clear-AzFrontDoorCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzCdnEdgeNode`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'IPAddressGroup' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEdgeNode' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Import-AzCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnManagedHttpsParametersObject`

- Cmdlet breaking-change will happen to all parameter sets
  Add new mandatory parameter CertificateSourceParameterTypeName.
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnUserManagedHttpsParametersObject`

- Cmdlet breaking-change will happen to all parameter sets
  Add new mandatory parameter CertificateSourceParameterTypeName.
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
    - Change description : The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'. 
    - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `Remove-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Start-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Stop-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'.
    - Change description : The element type for parameter 'Action' has been changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeliveryRuleAction1' to 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleAction'. 
    - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

## Az.ContainerInstance

### `New-AzContainerGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - This change will take effect on '21/05/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzContainerInstanceContainerGroupProfile`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - Change description : Removing the default value of OSType parameter. 
    - This change will take effect on '21/05/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

## Az.ManagedServiceIdentity

### `Get-AzFederatedIdentityCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential' is changing
  - The following properties in the output type are being deprecated : 'Audience <System.String[]>'
  - The following properties are being added to the output type : 'Audience <System.Collections.Generic.List`1[System.String]>'
  - Change description : The type of property 'Audience' of type 'FederatedIdentityCredential' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzFederatedIdentityCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential' is changing
  - The following properties in the output type are being deprecated : 'Audience <System.String[]>'
  - The following properties are being added to the output type : 'Audience <System.Collections.Generic.List`1[System.String]>'
  - Change description : The type of property 'Audience' of type 'FederatedIdentityCredential' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Audience`
    - The parameter : 'Audience' is changing.
    The type of the parameter is changing from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
    - Change description : The type of property 'Audience' of type 'FederatedIdentityCredential' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
    - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `Remove-AzFederatedIdentityCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'bool' is changing
  - The following properties in the output type are being deprecated : 'Audience <System.String[]>'
  - The following properties are being added to the output type : 'Audience <System.Collections.Generic.List`1[System.String]>'
  - Change description : The type of property 'Audience' of type 'FederatedIdentityCredential' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzFederatedIdentityCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential' is changing
  - The following properties in the output type are being deprecated : 'Audience <System.String[]>'
  - The following properties are being added to the output type : 'Audience <System.Collections.Generic.List`1[System.String]>'
  - Change description : The type of property 'Audience' of type 'FederatedIdentityCredential' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Audience`
    - The parameter : 'Audience' is changing.
    The type of the parameter is changing from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'.
    - Change description : The type of property 'Audience' of type 'FederatedIdentityCredential' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
    - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '2.0.0'

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupSchedulePolicyObject`

- Cmdlet breaking-change will happen to all parameter sets
  - May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload
  - This change is expected to take effect from Az.RecoveryServices version: 8.0.0 and Az version: 14.0.0

## Az.Storage

### `Start-AzStorageAccountMigration`

- Cmdlet breaking-change will happen to all parameter sets
  A prompt that needs users' confirmation will be added when converting the account's redundancy configuration. Suppress it with -Force.
  - This change will take effect on '19/05/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '9.0.0'

