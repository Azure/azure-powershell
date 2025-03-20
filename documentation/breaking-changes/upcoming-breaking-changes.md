# Upcoming breaking changes in Azure PowerShell

## Az.Accounts

### `Get-AzAccessToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The Token property of the output type will be changed from String to SecureString. Add the [-AsSecureString] switch to avoid the impact of this upcoming breaking change.
  - This change is expected to take effect from Az.Accounts version: 5.0.0 and Az version: 14.0.0

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
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Clear-AzFrontDoorCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzCdnEdgeNode`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'IPAddressGroup' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IEdgeNode' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IIPAddressGroup]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Get-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Import-AzCdnEndpointContent`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'ContentPath, Domain' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IPurgeParameters' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnManagedHttpsParametersObject`

- Cmdlet breaking-change will happen to all parameter sets
  Add new mandatory parameter CertificateSourceParameterTypeName.
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzCdnUserManagedHttpsParametersObject`

- Cmdlet breaking-change will happen to all parameter sets
  Add new mandatory parameter CertificateSourceParameterTypeName.
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '4.0.0'

### `New-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `New-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
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

### `Remove-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Remove-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Condition' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRule' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IDeliveryRuleCondition]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Start-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Stop-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'Origin' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IDeepCreatedOriginGroup' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnOriginGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'HttpErrorRange' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IResponseBasedOriginErrorDetectionParameters' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHttpErrorRangeParameters]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnRoute`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The type of property 'PatternsToMatch, CompressionSettingContentTypesToCompress' of type 'Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IRoute' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '5.0.0'

### `Update-AzFrontDoorCdnRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
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

## Az.Compute

### `Get-AzVMSize`

- Cmdlet breaking-change will happen to all parameter sets
  - The "ListVirtualMachineSize" parameter set will be deprecated as its API: "Virtual Machine Sizes - List" is deprecated. For listing available VM sizes by subscription or location, please use instead "Get-AzComputeResourceSku". Other parameter sets: "List Available Sizes for Availability Set" and "List Available Sizes for Virtual Machine" will continue to be supported.
  - This change is expected to take effect from Az.Compute version: 10.0.0 and Az version: 14.0.0

## Az.ContainerInstance

### `New-AzContainerGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - This change will take effect on '5/21/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzContainerInstanceContainerGroupProfile`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - Change description : Removing the default value of OSType parameter. 
    - This change will take effect on '5/21/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupSchedulePolicyObject`

- Cmdlet breaking-change will happen to all parameter sets
  - May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload
  - This change is expected to take effect from Az.RecoveryServices version: 8.0.0 and Az version: 14.0.0

