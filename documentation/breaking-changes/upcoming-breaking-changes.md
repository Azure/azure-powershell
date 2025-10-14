# Upcoming breaking changes in Azure PowerShell

The breaking changes listed in this article are planned for the next major release of the Az
PowerShell module unless otherwise noted. Per our
[Support lifecycle](azureps-support-lifecycle.md), breaking changes in Azure PowerShell occur twice
a year with major versions of the Az PowerShell module.

Preview modules are not included in this list. Read more about [module version types](azureps-support-lifecycle.md#module-version-types).

## Az.Advisor

### `Disable-AzAdvisorRecommendation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IResourceRecommendationBase' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IResourceRecommendationBase'
  - The following properties in the output type are being deprecated : 'Action Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IRecommendationPropertiesActionsItem[]' 'SuppressionId System.String[]'
  - The following properties are being added to the output type : 'Action System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IRecommendationPropertiesActionsItem].' 'SuppressionId System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Enable-AzAdvisorRecommendation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IResourceRecommendationBase' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IResourceRecommendationBase'
  - The following properties in the output type are being deprecated : 'Action Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IRecommendationPropertiesActionsItem[]' 'SuppressionId System.String[]'
  - The following properties are being added to the output type : 'Action System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IRecommendationPropertiesActionsItem].' 'SuppressionId System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzAdvisorConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData' is changing
  - The following properties in the output type are being deprecated : 'Digest'
  - The following properties are being added to the output type : 'Digest'
  - Change description : The type of property 'Digest' of type 'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IDigestConfig' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IDigestConfig]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzAdvisorRecommendation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IResourceRecommendationBase' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IResourceRecommendationBase'
  - The following properties in the output type are being deprecated : 'Action Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IRecommendationPropertiesActionsItem[]' 'SuppressionId System.String[]'
  - The following properties are being added to the output type : 'Action System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IRecommendationPropertiesActionsItem].' 'SuppressionId System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Set-AzAdvisorConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IConfigData'
  - The following properties in the output type are being deprecated : 'Digest Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IDigestConfig'
  - The following properties are being added to the output type : 'Digest System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IDigestConfig]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.ApplicationInsights

### `Get-AzApplicationInsights`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IApplicationInsightsComponent' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsComponent'
  - The following properties in the output type are being deprecated : 'PrivateLinkScopedResource Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IPrivateLinkScopedResource'
  - The following properties are being added to the output type : 'PrivateLinkScopedResource System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IPrivateLinkScopedResource]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzApplicationInsightsApiKey`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentApiKey' is changing
  - The following properties in the output type are being deprecated : 'LinkedReadProperty' 'LinkedWriteProperty'
  - The following properties are being added to the output type : 'LinkedReadProperty' 'LinkedWriteProperty'
  - Change description : The types of the properties LinkedReadProperty, LinkedWriteProperty will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzApplicationInsightsMyWorkbook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook' is changing
  - The following properties in the output type are being deprecated : 'PropertiesTag'
  - The following properties are being added to the output type : 'PropertiesTag'
  - Change description : The types of the properties PropertiesTag will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzApplicationInsightsWebTest`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220615.IWebTest' is changing
  - The following properties in the output type are being deprecated : 'RequestHeader' 'PropertiesLocations'
  - The following properties are being added to the output type : 'RequestHeader' 'PropertiesLocations'
  - Change description : The type of property 'RequestHeader' will be changed from 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IHeaderField' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IHeaderField]'. And the property 'PropertiesLocations' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220615.IWebTest' will be removed. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzApplicationInsightsWorkbook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' is changing
  - The following properties in the output type are being deprecated : 'PropertiesTag'
  - The following properties are being added to the output type : 'PropertiesTag'
  - Change description : The type of property 'PropertiesTag' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzApplicationInsightsWorkbookRevision`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' is changing
  - The following properties in the output type are being deprecated : 'PropertiesTag'
  - The following properties are being added to the output type : 'PropertiesTag'
  - Change description : The type of property 'PropertiesTag' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzApplicationInsightsWorkbookTemplate`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate' is changing
  - The following properties in the output type are being deprecated : 'Gallery'
  - The following properties are being added to the output type : 'Gallery'
  - Change description : The type of property 'Gallery' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWorkbookTemplateGallery' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWorkbookTemplateGallery]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzApplicationInsights`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IApplicationInsightsComponent' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsComponent'
  - The following properties in the output type are being deprecated : 'PrivateLinkScopedResource Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IPrivateLinkScopedResource'
  - The following properties are being added to the output type : 'PrivateLinkScopedResource System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IPrivateLinkScopedResource]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzApplicationInsightsApiKey`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentApiKey' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsComponentApiKey'
  - The following properties in the output type are being deprecated : 'LinkedReadProperty and LinkedWriteProperty System.String[]'
  - The following properties are being added to the output type : 'LinkedReadProperty and LinkedWriteProperty System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzApplicationInsightsMyWorkbook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook' is changing
  - The following properties in the output type are being deprecated : 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'EnableSystemAssignedIdentity' 'UserAssignedIdentity'
  - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzApplicationInsightsWebTest`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220615.IWebTest' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWebTest'
  - The following properties in the output type are being deprecated : 'RequestHeader System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IHeaderField]'
  - The following properties are being added to the output type : 'RequestHeader System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IHeaderField]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzApplicationInsightsWorkbook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' is changing
  - The following properties in the output type are being deprecated : 'PropertiesTag'
  - The following properties are being added to the output type : 'PropertiesTag'
  - Change description : The type of property 'PropertiesTag' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzApplicationInsightsWorkbookTemplate`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate' is changing
  - The following properties in the output type are being deprecated : 'Gallery'
  - The following properties are being added to the output type : 'Gallery'
  - Change description : The type of property 'Gallery' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWorkbookTemplateGallery' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWorkbookTemplateGallery]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Remove-AzApplicationInsightsApiKey`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentApiKey' is changing
  - The following properties in the output type are being deprecated : 'LinkedReadProperty' 'LinkedWriteProperty'
  - The following properties are being added to the output type : 'LinkedReadProperty' 'LinkedWriteProperty'
  - Change description : The types of the properties LinkedReadProperty, LinkedWriteProperty will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Set-AzApplicationInsightsDailyCap`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentBillingFeatures' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsComponentBillingFeatures'
  - The following properties in the output type are being deprecated : 'CurrentBillingFeature System.String[]'
  - The following properties are being added to the output type : 'CurrentBillingFeature System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Set-AzApplicationInsightsPricingPlan`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentBillingFeatures' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsComponentBillingFeatures'
  - The following properties in the output type are being deprecated : 'CurrentBillingFeature System.String[]'
  - The following properties are being added to the output type : 'CurrentBillingFeature System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzApplicationInsights`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IApplicationInsightsComponent' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsComponent'
  - The following properties in the output type are being deprecated : 'PrivateLinkScopedResource Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IPrivateLinkScopedResource'
  - The following properties are being added to the output type : 'PrivateLinkScopedResource System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IPrivateLinkScopedResource]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzApplicationInsightsMyWorkbook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook' is changing
  - The following properties in the output type are being deprecated : 'PropertiesTag'
  - The following properties are being added to the output type : 'PropertiesTag'
  - Change description : The types of the properties PropertiesTag will be changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzApplicationInsightsWorkbook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' is changing
  - The following properties in the output type are being deprecated : 'PropertiesTag'
  - The following properties are being added to the output type : 'PropertiesTag'
  - Change description : The type of property 'PropertiesTag' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook' has changed from 'System.String[]' to 'System.Collections.Generic.List`1[System.String]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzApplicationInsightsWorkbookTemplate`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate' is changing
  - The following properties in the output type are being deprecated : 'Gallery'
  - The following properties are being added to the output type : 'Gallery'
  - Change description : The type of property 'Gallery' of type 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate' has changed from 'Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWorkbookTemplateGallery' to 'System.Collections.Generic.List`1[Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IWorkbookTemplateGallery]'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.ArcResourceBridge

### `Get-AzArcResourceBridgeApplianceCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IApplianceListCredentialResults' is changing
  - The following properties in the output type are being deprecated : 'Kubeconfig' 'SupportedVersion'
  - The following properties are being added to the output type : 'Kubeconfig' 'SupportedVersion'
  - Change description : The types of the properties 'Kubeconfig' and 'SupportedVersion' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzArcResourceBridgeCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IApplianceListKeysResults' is changing
  - The following properties in the output type are being deprecated : 'Kubeconfig' 'SupportedVersion'
  - The following properties are being added to the output type : 'Kubeconfig' 'SupportedVersion'
  - Change description : The types of the properties 'Kubeconfig' and 'SupportedVersion' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzArcResourceBridgeTelemetryConfig`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzArcResourceBridgeUpgradeGraph`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IUpgradeGraph' is changing
  - The following properties in the output type are being deprecated : 'Kubeconfig' 'SupportedVersion'
  - The following properties are being added to the output type : 'Kubeconfig' 'SupportedVersion'
  - Change description : The types of the properties 'Kubeconfig' and 'SupportedVersion' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzArcResourceBridge`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.Api20221027.IAppliance' is changing
  - The following properties in the output type are being deprecated : 'IdentityType'
  - The following properties are being added to the output type : 'EnableSystemAssignedIdentity'
  - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Attestation

### `Get-AzAttestationDefaultProvider`

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationDefaultProvider_Get`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationDefaultProvider_GetViaIdentity`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationDefaultProvider_List`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProviderListResult' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzAttestationProvider`

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationProvider_Get`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationProvider_GetViaIdentity`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationProvider_List`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProviderListResult' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Cmdlet breaking-change will happen to parameter set `GetAzAttestationProvider_List1`
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProviderListResult' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzAttestationProvider`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.IAttestationProvider'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.IPrivateEndpointConnection'
  - The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.IPrivateEndpointConnection]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzAttestationProvider`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'Value'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'Value'
  - Change description : The types of the properties 'PrivateEndpointConnection' and 'Value' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Automanage

### `Get-AzAutomanageHciReport`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IReport' is changing
  - The following properties in the output type are being deprecated : 'AdditionalInfo' 'Detail' 'Resource'
  - The following properties are being added to the output type : 'AdditionalInfo' 'Detail' 'Resource'
  - Change description : The types of the properties 'AdditionalInfo', 'Detail' and 'Resource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzAutomanageHcrpReport`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IReport' is changing
  - The following properties in the output type are being deprecated : 'AdditionalInfo' 'Detail' 'Resource'
  - The following properties are being added to the output type : 'AdditionalInfo' 'Detail' 'Resource'
  - Change description : The types of the properties 'AdditionalInfo', 'Detail' and 'Resource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzAutomanageReport`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IReport' is changing
  - The following properties in the output type are being deprecated : 'AdditionalInfo' 'Detail' 'Resource'
  - The following properties are being added to the output type : 'AdditionalInfo' 'Detail' 'Resource'
  - Change description : The types of the properties 'AdditionalInfo', 'Detail' and 'Resource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Batch

### `Get-AzBatchCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0

### `Get-AzBatchRemoteDesktopProtocolFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet 'Get-AzBatchRemoteLoginSettings' is replacing this cmdlet.
  - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0

### `New-AzBatchCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0

### `New-AzBatchPool`

- Parameter breaking-change will happen to all parameter sets
  - `-ApplicationLicenses`
    - The parameter : 'ApplicationLicense' is changing.
    - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0
  - `-CertificateReferences`
    - The parameter : 'CertificateReference' is changing.
    - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0
  - `-CloudServiceConfiguration`
    - The parameter : 'CloudServiceConfiguration' is changing.
    - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0
  - `-ResourceTag`
    - The parameter : 'ResourceTag' is changing.
    - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0
  - `-TargetNodeCommunicationMode`
    - The parameter : 'TargetNodeCommunicationMode' is changing.
    - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0

### `Remove-AzBatchCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0

### `Stop-AzBatchCertificateDeletion`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.Batch version: 4.0.0 and Az version: 15.0.0

## Az.Compute

### `Get-AzGalleryApplicationVersion`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20220103.IGalleryApplicationVersion' is changing
  - The following properties in the output type are being deprecated : 'PublishingProfileTargetExtendedLocation' 'ReplicationStatusSummary' 'TargetRegion'
  - The following properties are being added to the output type : 'PublishingProfileTargetExtendedLocation' 'ReplicationStatusSummary' 'TargetRegion'
  - Change description : The types of the properties 'PublishingProfileTargetExtendedLocation', 'ReplicationStatusSummary' and 'TargetRegion' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Invoke-AzSpotPlacementScore`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20250605.ISpotPlacementScoresResponse' is changing
  - The following properties in the output type are being deprecated : 'PlacementScore' 'DesiredSize' 'DesiredLocation'
  - The following properties are being added to the output type : 'PlacementScore' 'DesiredSize' 'DesiredLocation'
  - Change description : The types of the properties 'PlacementScore', 'DesiredSize' and 'DesiredLocation' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzGalleryApplicationVersion`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20220103.IGalleryApplicationVersion' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IGalleryApplicationVersion'
  - The following properties in the output type are being deprecated : 'PublishingProfileTargetExtendedLocation Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IGalleryTargetExtendedLocation' 'ReplicationStatusSummary Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IRegionalReplicationStatus' 'TargetRegion Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.ITargetRegion' 'EncryptionDataDiskImage Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IDataDiskImageEncryption'
  - The following properties are being added to the output type : 'PublishingProfileTargetExtendedLocation System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IGalleryTargetExtendedLocation]' 'ReplicationStatusSummary System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IRegionalReplicationStatus]' 'TargetRegion System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.ITargetRegion]' 'EncryptionDataDiskImage System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IDataDiskImageEncryption]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter sets
  - The default VM size will change from 'Standard_D2s_v3' to 'Standard_D2s_v5'.
  - This change is expected to take effect from Az.Compute version: 11.0.0 and Az version: 15.0.0

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - In the next breaking change period (Nov 2025), the default VM size will change from 'Standard_Ds1_v2' to 'Standard_D2s_v5'.
  - This change is expected to take effect from Az.Compute version: 11.0.0 and Az version: 15.0.0

### `Set-AzVMRunCommand`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20230701.IVirtualMachineRunCommand' is changing
  - The following properties in the output type are being deprecated : 'InstanceViewStatuses' 'ProtectedParameter' 'Parameter'
  - The following properties are being added to the output type : 'InstanceViewStatuses' 'ProtectedParameter' 'Parameter'
  - Change description : The types of the properties 'InstanceViewStatuses', 'ProtectedParameter' and 'Parameter' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Set-AzVmssVMRunCommand`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20230701.IVirtualMachineRunCommand' is changing
  - The following properties in the output type are being deprecated : 'InstanceViewStatuses' 'ProtectedParameter' 'Parameter'
  - The following properties are being added to the output type : 'InstanceViewStatuses' 'ProtectedParameter' 'Parameter'
  - Change description : The types of the properties 'InstanceViewStatuses', 'ProtectedParameter' and 'Parameter' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzGalleryApplicationVersion`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20220103.IGalleryApplicationVersion' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IGalleryApplicationVersion'
  - The following properties in the output type are being deprecated : 'PublishingProfileTargetExtendedLocation Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IGalleryTargetExtendedLocation' 'ReplicationStatusSummary Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IRegionalReplicationStatus' 'TargetRegion Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.ITargetRegion'
  - The following properties are being added to the output type : 'PublishingProfileTargetExtendedLocation System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IGalleryTargetExtendedLocation]' 'ReplicationStatusSummary System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IRegionalReplicationStatus]' 'TargetRegion System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.ITargetRegion]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.ConfidentialLedger

### `Get-AzConfidentialLedger`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.IConfidentialLedger' is changing
  - The following properties in the output type are being deprecated : 'AadBasedSecurityPrincipal' 'CertBasedSecurityPrincipal'
  - The following properties are being added to the output type : 'AadBasedSecurityPrincipal' 'CertBasedSecurityPrincipal'
  - Change description : The type of property 'AadBasedSecurityPrincipal', 'CertBasedSecurityPrincipal' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzConfidentialLedger`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.IConfidentialLedger' is changing
  - The following properties in the output type are being deprecated : 'AadBasedSecurityPrincipal' 'CertBasedSecurityPrincipal'
  - The following properties are being added to the output type : 'AadBasedSecurityPrincipal' 'CertBasedSecurityPrincipal'
  - Change description : The type of property 'AadBasedSecurityPrincipal', 'CertBasedSecurityPrincipal' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzConfidentialLedger`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.IConfidentialLedger' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.IConfidentialLedger'
  - The following properties in the output type are being deprecated : 'AadBasedSecurityPrincipal Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.IAadBasedSecurityPrincipal' 'CertBasedSecurityPrincipal Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.ICertBasedSecurityPrincipal'
  - The following properties are being added to the output type : 'AadBasedSecurityPrincipal System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.IAadBasedSecurityPrincipal]' 'CertBasedSecurityPrincipal System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.ICertBasedSecurityPrincipal]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

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

## Az.ContainerRegistry

### `Get-AzContainerRegistry`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistry' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IRegistry'
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.PSContainerRegistryCredential' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.PSContainerRegistryCredential'
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryExportPipeline`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IExportPipeline' is changing
  - The following properties in the output type are being deprecated : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1) The types of the properties 'NetworkRuleSetIPRule', 'PrivateEndpointConnection' and 'DataEndpointHostName' will be changed from single object to 'List'. (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryImportPipeline`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IImportPipeline' is changing
  - The following properties in the output type are being deprecated : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1) The types of the properties 'NetworkRuleSetIPRule', 'PrivateEndpointConnection' and 'DataEndpointHostName' will be changed from single object to 'List'. (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryReplication`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IReplication' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IReplication'
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryScopeMap`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IScopeMap' is changing
  - The following properties in the output type are being deprecated : 'Action'
  - The following properties are being added to the output type : 'Action'
  - Change description : The types of the properties 'Action' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IToken' is changing
  - The following properties in the output type are being deprecated : 'CredentialsCertificate' 'CredentialsPassword'
  - The following properties are being added to the output type : 'CredentialsCertificate' 'CredentialsPassword'
  - Change description : The types of the properties 'CredentialsCertificate' and 'CredentialsPassword' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryWebhook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IWebhook'
  - The following properties in the output type are being deprecated : 'Action, NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'Action, NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryWebhookCallbackConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.ICallbackConfig' is changing
  - The following properties in the output type are being deprecated : 'Action'
  - The following properties are being added to the output type : 'Action'
  - Change description : The types of the properties 'Action' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzContainerRegistryWebhookEvent`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IEvent' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IEvent'
  - The following properties in the output type are being deprecated : 'ContentTimestamp, TargetSize, TargetLength, TargetTag, TargetRepository, TargetName, TargetMediaType, TargetDigest, SourceInstanceId, SourceAddr, ActorName, RequestUseragent, RequestMethod, RequestId, RequestHost, RequestAddr, ContentId, ContentAction, TargetUrl, TargetVersion, Action'
  - The following properties are being added to the output type : 'ContentTimestamp, TargetSize, TargetLength, TargetTag, TargetRepository, TargetName, TargetMediaType, TargetDigest, SourceInstanceId, SourceAddr, ActorName, RequestUseragent, RequestMethod, RequestId, RequestHost, RequestAddr, ContentId, ContentAction, TargetUrl, TargetVersion, Action. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Import-AzContainerRegistryImage`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistry`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistry' is changing
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule' 'PrivateEndpointConnection' 'DataEndpointHostName' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule' 'PrivateEndpointConnection' 'DataEndpointHostName' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1) The types of the properties 'NetworkRuleSetIPRule', 'PrivateEndpointConnection' and 'DataEndpointHostName' will be changed from single object to 'List'. (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryCredentials`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.PSContainerRegistryCredential' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.PSContainerRegistryCredential'
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryExportPipeline`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IExportPipeline' is changing
  - The following properties in the output type are being deprecated : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1) The types of the properties 'NetworkRuleSetIPRule', 'PrivateEndpointConnection' and 'DataEndpointHostName' will be changed from single object to 'List'. (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryImportPipeline`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IImportPipeline' is changing
  - The following properties in the output type are being deprecated : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'Option' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1) The types of the properties 'NetworkRuleSetIPRule', 'PrivateEndpointConnection' and 'DataEndpointHostName' will be changed from single object to 'List'. (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryReplication`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IReplication' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IReplication'
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryScopeMap`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IScopeMap' is changing
  - The following properties in the output type are being deprecated : 'Action'
  - The following properties are being added to the output type : 'Action'
  - Change description : The types of the properties 'Action' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IToken' is changing
  - The following properties in the output type are being deprecated : 'CredentialsCertificate' 'CredentialsPassword'
  - The following properties are being added to the output type : 'CredentialsCertificate' 'CredentialsPassword'
  - Change description : The types of the properties 'CredentialsCertificate' and 'CredentialsPassword' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzContainerRegistryWebhook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IWebhook'
  - The following properties in the output type are being deprecated : 'Action, NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'Action, NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Test-AzContainerRegistryWebhook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'System.String' to the new type :'System.String'
  - The following properties in the output type are being deprecated : 'Action'
  - The following properties are being added to the output type : 'Action. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzContainerRegistry`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistry' is changing
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule' 'PrivateEndpointConnection' 'DataEndpointHostName' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule' 'PrivateEndpointConnection' 'DataEndpointHostName' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1) The types of the properties 'NetworkRuleSetIPRule', 'PrivateEndpointConnection' and 'DataEndpointHostName' will be changed from single object to 'List'. (2) IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzContainerRegistryCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.PSContainerRegistryCredential' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.PSContainerRegistryCredential'
  - The following properties in the output type are being deprecated : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName'
  - The following properties are being added to the output type : 'NetworkRuleSetIPRule, PrivateEndpointConnection, DataEndpointHostName. This parameter will be changed from single object to 'List'.'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzContainerRegistryScopeMap`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IScopeMap' is changing
  - The following properties in the output type are being deprecated : 'Action'
  - The following properties are being added to the output type : 'Action'
  - Change description : The types of the properties 'Action' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzContainerRegistryToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IToken' is changing
  - The following properties in the output type are being deprecated : 'CredentialsCertificate' 'CredentialsPassword'
  - The following properties are being added to the output type : 'CredentialsCertificate' 'CredentialsPassword'
  - Change description : The types of the properties 'CredentialsCertificate' and 'CredentialsPassword' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzContainerRegistryWebhook`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook' is changing
  - The following properties in the output type are being deprecated : 'Action'
  - The following properties are being added to the output type : 'Action'
  - Change description : The types of the properties 'Action' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.DevCenter

### `Connect-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Connect-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Connect-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Connect-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminAttachedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminAttachedNetwork' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCatalogSyncErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCatalogSyncErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCustomizationTask`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCustomizationTask' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCustomizationTaskErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCustomizationTaskErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminDevBoxDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminEnvironmentDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminEnvironmentDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminGallery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminGallery' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminImage`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminImage' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminImageVersion`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminImageVersion' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The default parameter set will change from list dev center image versions to list project image versions. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminNetworkConnection' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminNetworkConnectionHealthDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminNetworkConnectionHealthDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminOperationStatus`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminOperationStatus' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminPool' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProject' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectAllowedEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectAllowedEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectCatalogSyncErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectCatalogSyncErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectEnvironmentDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectEnvironmentDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectEnvironmentDefinitionErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectEnvironmentDefinitionErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectInheritedSetting`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectInheritedSetting' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Invoke-AzDevCenterAdminExecuteCheckNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Invoke-AzDevCenterAdminExecuteCheckNameAvailability' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminAttachedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'New-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-PlanId`
    - The parameter : 'PlanId' is changing.
    - Change description : PlanId parameter will be removed. 
    - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'New-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminGallery`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The Plan resource will be deprecated
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The PlanMember resource will be deprecated
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterUserDevBox`

- Parameter breaking-change will happen to all parameter sets
  - `-LocalAdministrator`
    

### `Remove-AzDevCenterAdminAttachedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminAttachedNetwork' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminDevBoxDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminGallery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminGallery' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminNetworkConnection' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminPool' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminProject' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminProjectEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterUserEnvironment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Repair-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Restart-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Start-AzDevCenterAdminNetworkConnectionHealthCheck`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Start-AzDevCenterAdminNetworkConnectionHealthCheck' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Start-AzDevCenterAdminPoolHealthCheck`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Start-AzDevCenterAdminPoolHealthCheck' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Start-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Stop-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Sync-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Sync-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Sync-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Sync-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminDevBoxDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-PlanId`
    - The parameter : 'PlanId' is changing.
    - Change description : PlanId parameter will be removed. 
    - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminNetworkConnection' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminPool' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminProject' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminProjectEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

## Az.Dns

### `Get-AzDnsDnssecConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20230701Preview.IDnssecConfig' is changing
  - The following properties in the output type are being deprecated : 'SigningKey'
  - The following properties are being added to the output type : 'SigningKey'
  - Change description : The types of the properties 'SigningKey' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzDnsDnssecConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20230701Preview.IDnssecConfig' is changing
  - The following properties in the output type are being deprecated : 'SigningKey'
  - The following properties are being added to the output type : 'SigningKey'
  - Change description : The types of the properties 'SigningKey' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.HealthcareApis

### `Get-AzHealthcareApisService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServicesDescription' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader'
  - Change description : The types of the properties 'PrivateEndpointConnection', 'AccessPolicy', 'AcrConfigurationOciArtifact', 'CorConfigurationOrigin', 'CorConfigurationMethod', 'AcrConfigurationLoginServer', and 'CorConfigurationHeader' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzHealthcareApisWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IWorkspace' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection'
  - The following properties are being added to the output type : 'PrivateEndpointConnection'
  - Change description : The types of the properties 'PrivateEndpointConnection' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzHealthcareDicomService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomService' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'AuthenticationConfigurationAudience' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'AuthenticationConfigurationAudience' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1)The types of the properties 'PrivateEndpointConnection' and 'AuthenticationConfigurationAudience' will be changed from single object to 'List'. (2)IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzHealthcareFhirService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IFhirService' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1)The types of the properties 'PrivateEndpointConnection' and 'AuthenticationConfigurationAudience' will be changed from single object to 'List'. (2)IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzHealthcareApisService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServicesDescription' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServicesDescription'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection' 'AccessPolicy Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceAccessPolicyEntry' 'AcrConfigurationOciArtifact Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceOciArtifactEntry' 'CorConfigurationOrigin System.String[]' 'CorConfigurationMethod System.String[]' 'AcrConfigurationLoginServer System.String[]' 'CorConfigurationHeader System.String[]'
  - The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection]' 'AccessPolicy System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceAccessPolicyEntry]' 'AcrConfigurationOciArtifact System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceOciArtifactEntry]' 'CorConfigurationOrigin System.Collections.Generic.List1[System.String]' 'CorConfigurationMethod System.Collections.Generic.List1[System.String]' 'AcrConfigurationLoginServer System.Collections.Generic.List1[System.String]' 'CorConfigurationHeader System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzHealthcareApisWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IWorkspace' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IWorkspace'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection'
  - The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzHealthcareDicomService`

- Cmdlet breaking-change will happen to all parameter sets
  IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomService' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IDicomService'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection' 'AuthenticationConfigurationAudience System.String[]'
  - The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection]' 'AuthenticationConfigurationAudience System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzHealthcareFhirService`

- Cmdlet breaking-change will happen to all parameter sets
  IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'
  - The output type is changing from the existing type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IFhirService' to the new type :'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IFhirService'
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection' 'AccessPolicy Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceAccessPolicyEntry' 'AcrConfigurationOciArtifact Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceOciArtifactEntry' 'CorConfigurationOrigin System.String[]' 'CorConfigurationMethod System.String[]' 'AcrConfigurationLoginServer System.String[]' 'CorConfigurationHeader System.String[]'
  - The following properties are being added to the output type : 'PrivateEndpointConnection System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IPrivateEndpointConnection]' 'AccessPolicy System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceAccessPolicyEntry]' 'AcrConfigurationOciArtifact System.Collections.Generic.List1[Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceOciArtifactEntry]' 'CorConfigurationOrigin System.Collections.Generic.List1[System.String]' 'CorConfigurationMethod System.Collections.Generic.List1[System.String]' 'AcrConfigurationLoginServer System.Collections.Generic.List1[System.String]' 'CorConfigurationHeader System.Collections.Generic.List1[System.String]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzHealthcareIotConnector`

- Cmdlet breaking-change will happen to all parameter sets
  IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Test-AzHealthcareServiceNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzHealthcareApisService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServicesDescription' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader'
  - Change description : The types of the properties 'PrivateEndpointConnection', 'AccessPolicy', 'AcrConfigurationOciArtifact', 'CorConfigurationOrigin', 'CorConfigurationMethod', 'AcrConfigurationLoginServer', and 'CorConfigurationHeader' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzHealthcareApisWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IWorkspace' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection'
  - The following properties are being added to the output type : 'PrivateEndpointConnection'
  - Change description : The types of the properties 'PrivateEndpointConnection' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzHealthcareDicomService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomService' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'AuthenticationConfigurationAudience' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'AuthenticationConfigurationAudience' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1)The types of the properties 'PrivateEndpointConnection' and 'AuthenticationConfigurationAudience' will be changed from single object to 'List'. (2)IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzHealthcareFhirService`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IFhirService' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader' 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'AccessPolicy' 'AcrConfigurationOciArtifact' 'CorConfigurationOrigin' 'CorConfigurationMethod' 'AcrConfigurationLoginServer' 'CorConfigurationHeader' 'IdentityType' 'IdentityUserAssignedIdentity'
  - Change description : (1)The types of the properties 'PrivateEndpointConnection' and 'AuthenticationConfigurationAudience' will be changed from single object to 'List'. (2)IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzHealthcareIotConnector`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IIotConnector' is changing
  - The following properties in the output type are being deprecated : 'IdentityType' 'IdentityUserAssignedIdentity'
  - The following properties are being added to the output type : 'EnableSystemAssignedIdentity' 'UserAssignedIdentity'
  - Change description : IdentityType will be removed. EnableSystemAssignedIdentity will be used to enable/disable system assigned identity and UserAssignedIdentity will be used to specify user assigned identities. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

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

### `Get-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IActivityLogAlertResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'ConditionAllOf' 'Scope'
  - The following properties are being added to the output type : 'ActionGroup' 'ConditionAllOf' 'Scope'
  - Change description : The types of the properties ActionGroup, ConditionAllOf and Scope will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAutoscalePredictiveMetric`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IPredictiveResponse' is changing
  - The following properties in the output type are being deprecated : 'Data'
  - The following properties are being added to the output type : 'Data'
  - Change description : The type of the property 'Data' of type 'IPredictiveResponse' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource' is changing
  - The following properties in the output type are being deprecated : 'Notification' 'Profile'
  - The following properties are being added to the output type : 'Notification' 'Profile'
  - Change description : The types of the properties 'Notification' and 'Profile' of type 'IAutoscaleSettingResource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log' 'Metric'
  - The following properties are being added to the output type : 'Log' 'Metric'
  - Change description : The types of the properties Log and Metric will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzDiagnosticSettingCategory`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsCategoryResource' is changing
  - The following properties in the output type are being deprecated : 'CategoryGroup'
  - The following properties are being added to the output type : 'CategoryGroup'
  - Change description : The type of the property CategoryGroup will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - The following properties are being added to the output type : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - Change description : The types of the properties ActionGroup, CriterionAllOf, Scope and TargetResourceType will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzSubscriptionDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.ISubscriptionDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log'
  - The following properties are being added to the output type : 'Log'
  - Change description : The type of the property Log will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.AlertRuleAnyOfOrLeafCondition' is changing
  - The following properties in the output type are being deprecated : '"ContainsAny","AnyOf[]"'
  - The following properties are being added to the output type : '"List[ContainsAny]","List[AnyOf]"'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-AnyOf`
    
  - `-ContainsAny`
    

### `New-AzActivityLogAlertAlertRuleLeafConditionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.AlertRuleLeafCondition' is changing
  - The following properties in the output type are being deprecated : 'ContainsAny'
  - The following properties are being added to the output type : 'List[ContainsAny]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-ContainsAny`
    

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
    

### `New-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource' is changing
  - The following properties in the output type are being deprecated : 'Notification' 'Profile'
  - The following properties are being added to the output type : 'Notification' 'Profile'
  - Change description : The types of the properties 'Notification' and 'Profile' of type 'IAutoscaleSettingResource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Profile`
    - The parameter : 'Profile' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '7.0.0'

### `New-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log' 'Metric'
  - The following properties are being added to the output type : 'Log' 'Metric'
  - Change description : The types of the properties Log and Metric will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '7.0.0'

### `New-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - The following properties are being added to the output type : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - Change description : The types of the properties ActionGroup, CriterionAllOf, Scope and TargetResourceType will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzScheduledQueryRuleConditionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Dimension`
    

### `New-AzScheduledQueryRuleDimensionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Value`
    

### `New-AzSubscriptionDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.ISubscriptionDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log'
  - The following properties are being added to the output type : 'Log'
  - Change description : The type of the property Log will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '7.0.0'

### `Update-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Update-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - The following properties are being added to the output type : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - Change description : The types of the properties ActionGroup, CriterionAllOf, Scope and TargetResourceType will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

## Az.NetworkCloud

### `Get-AzNetworkCloudAgentPool`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IAgentPool' is changing
  - The following properties in the output type are being deprecated : 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AvailabilityZone' 'Label' 'Taint'
  - The following properties are being added to the output type : 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AvailabilityZone' 'Label' 'Taint'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudBareMetalMachine`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBareMetalMachine' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HardwareInventoryInterface' 'HardwareInventoryNic' 'HybridAksClustersAssociatedId' 'MachineRole' 'SecretRotationStatus' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HardwareInventoryInterface' 'HardwareInventoryNic' 'HybridAksClustersAssociatedId' 'MachineRole' 'SecretRotationStatus' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudBareMetalMachineKeySet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBareMetalMachineKeySet' is changing
  - The following properties in the output type are being deprecated : 'JumpHostsAllowed' 'UserList' 'UserListStatus'
  - The following properties are being added to the output type : 'JumpHostsAllowed' 'UserList' 'UserListStatus'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudBmcKeySet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBmcKeySet' is changing
  - The following properties in the output type are being deprecated : 'UserList' 'UserListStatus'
  - The following properties are being added to the output type : 'UserList' 'UserListStatus'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.ICluster' is changing
  - The following properties in the output type are being deprecated : 'AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData' 'AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData' 'AvailableUpgradeVersion' 'ComputeRackDefinition' 'WorkloadResourceId'
  - The following properties are being added to the output type : 'AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData' 'AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData' 'AvailableUpgradeVersion' 'ComputeRackDefinition' 'WorkloadResourceId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudClusterManager`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IClusterManager' is changing
  - The following properties in the output type are being deprecated : 'AvailabilityZone' 'ClusterVersion'
  - The following properties are being added to the output type : 'AvailabilityZone' 'ClusterVersion'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudKubernetesCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesCluster' is changing
  - The following properties in the output type are being deprecated : 'AadConfigurationAdminGroupObjectId' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AttachedNetworkId' 'AvailableUpgrade' 'BgpServiceLoadBalancerConfigurationBgpAdvertisement' 'BgpServiceLoadBalancerConfigurationBgpPeer' 'BgpServiceLoadBalancerConfigurationIPAddressPool' 'ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey' 'ControlPlaneNodeConfigurationAvailabilityZone' 'FeatureStatuses' 'InitialAgentPoolConfiguration' 'L2ServiceLoadBalancerConfigurationIPAddressPool' 'NetworkConfigurationPodCidr' 'NetworkConfigurationServiceCidr' 'Node' 'SshPublicKey'
  - The following properties are being added to the output type : 'AadConfigurationAdminGroupObjectId' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AttachedNetworkId' 'AvailableUpgrade' 'BgpServiceLoadBalancerConfigurationBgpAdvertisement' 'BgpServiceLoadBalancerConfigurationBgpPeer' 'BgpServiceLoadBalancerConfigurationIPAddressPool' 'ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey' 'ControlPlaneNodeConfigurationAvailabilityZone' 'FeatureStatuses' 'InitialAgentPoolConfiguration' 'L2ServiceLoadBalancerConfigurationIPAddressPool' 'NetworkConfigurationPodCidr' 'NetworkConfigurationServiceCidr' 'Node' 'SshPublicKey'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudKubernetesClusterFeature`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeature' is changing
  - The following properties in the output type are being deprecated : 'Option'
  - The following properties are being added to the output type : 'Option'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudL2Network`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IL2Network' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudL3Network`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IL3Network' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudMetricsConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IClusterMetricsConfiguration' is changing
  - The following properties in the output type are being deprecated : 'DisabledMetric' 'EnabledMetric'
  - The following properties are being added to the output type : 'DisabledMetric' 'EnabledMetric'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudRackSku`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IRackSku' is changing
  - The following properties in the output type are being deprecated : 'ComputeMachine' 'ControllerMachine' 'StorageAppliance' 'SupportedRackSkuId'
  - The following properties are being added to the output type : 'ComputeMachine' 'ControllerMachine' 'StorageAppliance' 'SupportedRackSkuId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudStorageAppliance`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStorageAppliance' is changing
  - The following properties in the output type are being deprecated : 'SecretRotationStatus'
  - The following properties are being added to the output type : 'SecretRotationStatus'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudTrunkedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.ITrunkedNetwork' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'IsolationDomainId' 'VirtualMachinesAssociatedId' 'Vlan'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'IsolationDomainId' 'VirtualMachinesAssociatedId' 'Vlan'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudVirtualMachine`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IVirtualMachine' is changing
  - The following properties in the output type are being deprecated : 'NetworkAttachment' 'PlacementHint' 'SshPublicKey' 'StorageProfileVolumeAttachment' 'Volume'
  - The following properties are being added to the output type : 'NetworkAttachment' 'PlacementHint' 'SshPublicKey' 'StorageProfileVolumeAttachment' 'Volume'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNetworkCloudVolume`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IVolume' is changing
  - The following properties in the output type are being deprecated : 'AttachedTo'
  - The following properties are being added to the output type : 'AttachedTo'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Invoke-AzNetworkCloudBareMetalMachineDataExtract`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'bool' is changing
  - The following properties in the output type are being deprecated : 'Argument'
  - The following properties are being added to the output type : 'Argument'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudAgentPool`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IAgentPool' is changing
  - The following properties in the output type are being deprecated : 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AvailabilityZone' 'Label' 'Taint'
  - The following properties are being added to the output type : 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AvailabilityZone' 'Label' 'Taint'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudBareMetalMachineKeySet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBareMetalMachineKeySet' is changing
  - The following properties in the output type are being deprecated : 'JumpHostsAllowed' 'UserList' 'UserListStatus'
  - The following properties are being added to the output type : 'JumpHostsAllowed' 'UserList' 'UserListStatus'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudBgpAdvertisementObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Community`
    
  - `-IPAddressPool`
    
  - `-Peer`
    

### `New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-BgpAdvertisement`
    
  - `-BgpPeer`
    
  - `-IPAddressPool`
    

### `New-AzNetworkCloudBmcKeySet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBmcKeySet' is changing
  - The following properties in the output type are being deprecated : 'UserList' 'UserListStatus'
  - The following properties are being added to the output type : 'UserList' 'UserListStatus'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.ICluster' is changing
  - The following properties in the output type are being deprecated : 'AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData' 'AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData' 'AvailableUpgradeVersion' 'BareMetalMachineConfigurationData' 'ComputeRackDefinition' 'StorageApplianceConfigurationData' 'WorkloadResourceId'
  - The following properties are being added to the output type : 'AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData' 'AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData' 'AvailableUpgradeVersion' 'BareMetalMachineConfigurationData' 'ComputeRackDefinition' 'StorageApplianceConfigurationData' 'WorkloadResourceId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudClusterManager`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IClusterManager' is changing
  - The following properties in the output type are being deprecated : 'AvailabilityZone'
  - The following properties are being added to the output type : 'AvailabilityZone'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudControlPlaneNodeConfigurationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-AdministratorConfigurationSshPublicKey`
    
  - `-AvailabilityZone`
    

### `New-AzNetworkCloudEgressEndpointObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Endpoint`
    

### `New-AzNetworkCloudInitialAgentPoolConfigurationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-AdministratorConfigurationSshPublicKey`
    
  - `-AttachedNetworkConfigurationL2Network`
    
  - `-AttachedNetworkConfigurationL3Network`
    
  - `-AttachedNetworkConfigurationTrunkedNetwork`
    
  - `-AvailabilityZone`
    
  - `-Label`
    
  - `-Taint`
    

### `New-AzNetworkCloudIpAddressPoolObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Address`
    

### `New-AzNetworkCloudKubernetesCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesCluster' is changing
  - The following properties in the output type are being deprecated : 'AadConfigurationAdminGroupObjectId' 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AttachedNetworkId' 'AvailabilityZone' 'AvailableUpgrade' 'BgpServiceLoadBalancerConfigurationBgpAdvertisement' 'BgpServiceLoadBalancerConfigurationBgpPeer' 'BgpServiceLoadBalancerConfigurationIPAddressPool' 'ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey' 'ControlPlaneNodeConfigurationAvailabilityZone' 'FeatureStatuses' 'InitialAgentPoolConfiguration' 'L2ServiceLoadBalancerConfigurationIPAddressPool' 'Label' 'NetworkConfigurationPodCidr' 'NetworkConfigurationServiceCidr' 'Node' 'SshPublicKey' 'Taint'
  - The following properties are being added to the output type : 'AadConfigurationAdminGroupObjectId' 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AttachedNetworkId' 'AvailabilityZone' 'AvailableUpgrade' 'BgpServiceLoadBalancerConfigurationBgpAdvertisement' 'BgpServiceLoadBalancerConfigurationBgpPeer' 'BgpServiceLoadBalancerConfigurationIPAddressPool' 'ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey' 'ControlPlaneNodeConfigurationAvailabilityZone' 'FeatureStatuses' 'InitialAgentPoolConfiguration' 'L2ServiceLoadBalancerConfigurationIPAddressPool' 'Label' 'NetworkConfigurationPodCidr' 'NetworkConfigurationServiceCidr' 'Node' 'SshPublicKey' 'Taint'
  - Change description : The type of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudKubernetesClusterFeature`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeature' is changing
  - The following properties in the output type are being deprecated : 'Option'
  - The following properties are being added to the output type : 'Option'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudL2Network`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IL2Network' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudL3Network`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IL3Network' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudMetricsConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IClusterMetricsConfiguration' is changing
  - The following properties in the output type are being deprecated : 'DisabledMetric' 'EnabledMetric'
  - The following properties are being added to the output type : 'DisabledMetric' 'EnabledMetric'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudRackDefinitionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-BareMetalMachineConfigurationData`
    
  - `-StorageApplianceConfigurationData`
    

### `New-AzNetworkCloudTrunkedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.ITrunkedNetwork' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'IsolationDomainId' 'VirtualMachinesAssociatedId' 'Vlan'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'IsolationDomainId' 'VirtualMachinesAssociatedId' 'Vlan'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudVirtualMachine`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IVirtualMachine' is changing
  - The following properties in the output type are being deprecated : 'NetworkAttachment' 'PlacementHint' 'SshPublicKey' 'StorageProfileVolumeAttachment' 'Volume'
  - The following properties are being added to the output type : 'NetworkAttachment' 'PlacementHint' 'SshPublicKey' 'StorageProfileVolumeAttachment' 'Volume'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNetworkCloudVolume`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IVolume' is changing
  - The following properties in the output type are being deprecated : 'AttachedTo'
  - The following properties are being added to the output type : 'AttachedTo'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudAgentPool`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IAgentPool' is changing
  - The following properties in the output type are being deprecated : 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AvailabilityZone' 'Label' 'Taint'
  - The following properties are being added to the output type : 'AdministratorConfigurationSshPublicKey' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AvailabilityZone' 'Label' 'Taint'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudBareMetalMachine`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBareMetalMachine' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HardwareInventoryInterface' 'HardwareInventoryNic' 'HybridAksClustersAssociatedId' 'MachineRole' 'SecretRotationStatus' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HardwareInventoryInterface' 'HardwareInventoryNic' 'HybridAksClustersAssociatedId' 'MachineRole' 'SecretRotationStatus' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudBareMetalMachineKeySet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBareMetalMachineKeySet' is changing
  - The following properties in the output type are being deprecated : 'JumpHostsAllowed' 'UserList' 'UserListStatus'
  - The following properties are being added to the output type : 'JumpHostsAllowed' 'UserList' 'UserListStatus'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudBmcKeySet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IBmcKeySet' is changing
  - The following properties in the output type are being deprecated : 'UserList' 'UserListStatus'
  - The following properties are being added to the output type : 'UserList' 'UserListStatus'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.ICluster' is changing
  - The following properties in the output type are being deprecated : 'AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData' 'AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData' 'AvailableUpgradeVersion' 'ComputeRackDefinition' 'WorkloadResourceId'
  - The following properties are being added to the output type : 'AggregatorOrSingleRackDefinitionBareMetalMachineConfigurationData' 'AggregatorOrSingleRackDefinitionStorageApplianceConfigurationData' 'AvailableUpgradeVersion' 'ComputeRackDefinition' 'WorkloadResourceId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudClusterManager`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IClusterManager' is changing
  - The following properties in the output type are being deprecated : 'AvailabilityZone' 'ClusterVersion'
  - The following properties are being added to the output type : 'AvailabilityZone' 'ClusterVersion'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudKubernetesCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesCluster' is changing
  - The following properties in the output type are being deprecated : 'AadConfigurationAdminGroupObjectId' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AttachedNetworkId' 'AvailableUpgrade' 'BgpServiceLoadBalancerConfigurationBgpAdvertisement' 'BgpServiceLoadBalancerConfigurationBgpPeer' 'BgpServiceLoadBalancerConfigurationIPAddressPool' 'ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey' 'ControlPlaneNodeConfigurationAvailabilityZone' 'FeatureStatuses' 'InitialAgentPoolConfiguration' 'L2ServiceLoadBalancerConfigurationIPAddressPool' 'NetworkConfigurationPodCidr' 'NetworkConfigurationServiceCidr' 'Node' 'SshPublicKey'
  - The following properties are being added to the output type : 'AadConfigurationAdminGroupObjectId' 'AttachedNetworkConfigurationL2Network' 'AttachedNetworkConfigurationL3Network' 'AttachedNetworkConfigurationTrunkedNetwork' 'AttachedNetworkId' 'AvailableUpgrade' 'BgpServiceLoadBalancerConfigurationBgpAdvertisement' 'BgpServiceLoadBalancerConfigurationBgpPeer' 'BgpServiceLoadBalancerConfigurationIPAddressPool' 'ControlPlaneNodeConfigurationAdministratorConfigurationSshPublicKey' 'ControlPlaneNodeConfigurationAvailabilityZone' 'FeatureStatuses' 'InitialAgentPoolConfiguration' 'L2ServiceLoadBalancerConfigurationIPAddressPool' 'NetworkConfigurationPodCidr' 'NetworkConfigurationServiceCidr' 'Node' 'SshPublicKey'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudKubernetesClusterFeature`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeature' is changing
  - The following properties in the output type are being deprecated : 'Option'
  - The following properties are being added to the output type : 'Option'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudL2Network`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IL2Network' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudL3Network`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IL3Network' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'VirtualMachinesAssociatedId'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudMetricsConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IClusterMetricsConfiguration' is changing
  - The following properties in the output type are being deprecated : 'DisabledMetric' 'EnabledMetric'
  - The following properties are being added to the output type : 'DisabledMetric' 'EnabledMetric'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudStorageAppliance`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStorageAppliance' is changing
  - The following properties in the output type are being deprecated : 'SecretRotationStatus'
  - The following properties are being added to the output type : 'SecretRotationStatus'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudTrunkedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.ITrunkedNetwork' is changing
  - The following properties in the output type are being deprecated : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'IsolationDomainId' 'VirtualMachinesAssociatedId' 'Vlan'
  - The following properties are being added to the output type : 'AssociatedResourceId' 'HybridAksClustersAssociatedId' 'IsolationDomainId' 'VirtualMachinesAssociatedId' 'Vlan'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudVirtualMachine`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IVirtualMachine' is changing
  - The following properties in the output type are being deprecated : 'NetworkAttachment' 'PlacementHint' 'SshPublicKey' 'StorageProfileVolumeAttachment' 'Volume'
  - The following properties are being added to the output type : 'NetworkAttachment' 'PlacementHint' 'SshPublicKey' 'StorageProfileVolumeAttachment' 'Volume'
  - Change description : The types of properties will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNetworkCloudVolume`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IVolume' is changing
  - The following properties in the output type are being deprecated : 'AttachedTo'
  - The following properties are being added to the output type : 'AttachedTo'
  - Change description : The type of property will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

## Az.Nginx

### `Get-AzNginxConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxConfiguration' is changing
  - The following properties in the output type are being deprecated : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - The following properties are being added to the output type : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - Change description : The types of the properties File, ProtectedFile and PackageProtectedFile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNginxDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxDeployment' is changing
  - The following properties in the output type are being deprecated : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - The following properties are being added to the output type : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - Change description : The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Invoke-AzNginxAnalysisConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.IAnalysisResult' is changing
  - The following properties in the output type are being deprecated : 'DataError'
  - The following properties are being added to the output type : 'DataError'
  - Change description : The type of the property DataError will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set 'Analysis' and 'AnalysisViaIdentity' will be removed. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzNginxConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxConfiguration' is changing
  - The following properties in the output type are being deprecated : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - The following properties are being added to the output type : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - Change description : The types of the properties File, ProtectedFile and PackageProtectedFile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNginxDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxDeployment' is changing
  - The following properties in the output type are being deprecated : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - The following properties are being added to the output type : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - Change description : The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `New-AzNginxNetworkProfileObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.NginxNetworkProfile' is changing
  - Change description : The types of the properties PrivateIPAddress and PublicIPAddress of Property FrontendIPConfiguration will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNginxDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxDeployment' is changing
  - The following properties in the output type are being deprecated : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - The following properties are being added to the output type : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - Change description : The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupSchedulePolicyObject`

- Cmdlet breaking-change will happen to all parameter sets
  - May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload
  - This change is expected to take effect from Az.RecoveryServices version: 8.0.0 and Az version: 14.0.0

## Az.Relay

### `Get-AzRelayNamespace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IRelayNamespace' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection'
  - The following properties are being added to the output type : 'List[PrivateEndpointConnection]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzRelayNamespaceNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.INetworkRuleSet' is changing
  - The following properties in the output type are being deprecated : 'IPRule'
  - The following properties are being added to the output type : 'List[IPRule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Resources

### `Get-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Rule`
    - The parameter : 'Rule' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '9.0.0'

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

## Az.StorageMover

### `Get-AzStorageMoverAgent`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IAgent' is changing
  - The following properties in the output type are being deprecated : 'UploadLimitScheduleWeeklyRecurrence'
  - The following properties are being added to the output type : 'UploadLimitScheduleWeeklyRecurrence'
  - Change description : The type of the property UploadLimitScheduleWeeklyRecurrence will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzStorageMoverJobDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Create will be removed. Suggest to use CreateExpanded and CreateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzStorageMoverProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Create will be removed. Suggest to use CreateExpanded and CreateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzStorageMover`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Update and UpdateViaIdentity will be removed. Suggest to use UpdateExpanded, UpdateViaIdentityExpanded and UpdateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzStorageMoverAgent`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IAgent' is changing
  - The following properties in the output type are being deprecated : 'UploadLimitScheduleWeeklyRecurrence'
  - The following properties are being added to the output type : 'UploadLimitScheduleWeeklyRecurrence'
  - Change description : The type of the property UploadLimitScheduleWeeklyRecurrence will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Cmdlet breaking-change will happen to parameter set `UpdateAzStorageMoverAgent_Update`
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Update and UpdateViaIdentity will be removed. Suggest to use UpdateExpanded, UpdateViaIdentityExpanded and UpdateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Cmdlet breaking-change will happen to parameter set `UpdateAzStorageMoverAgent_UpdateViaIdentity`
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Update and UpdateViaIdentity will be removed. Suggest to use UpdateExpanded, UpdateViaIdentityExpanded and UpdateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzStorageMoverJobDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Update and UpdateViaIdentity will be removed. Suggest to use UpdateExpanded, UpdateViaIdentityExpanded and UpdateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzStorageMoverProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set Update and UpdateViaIdentity will be removed. Suggest to use UpdateExpanded, UpdateViaIdentityExpanded and UpdateViaJsonString instead. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

## Az.StreamAnalytics

### `Get-AzStreamAnalyticsInput`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput' is changing
  - The following properties in the output type are being deprecated : 'Condition'
  - The following properties are being added to the output type : 'Condition'
  - Change description : The type of property Condition will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStreamAnalyticsJob`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob' is changing
  - The following properties in the output type are being deprecated : 'Input' 'Output'
  - The following properties are being added to the output type : 'Input' 'Output'
  - Change description : The types of the properties Input and Output will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStreamAnalyticsOutput`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput' is changing
  - The following properties in the output type are being deprecated : 'DiagnosticCondition'
  - The following properties are being added to the output type : 'DiagnosticCondition'
  - Change description : The type of property DiagnosticCondition will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzStreamAnalyticsQuota`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota' is changing
  - The following properties in the output type are being deprecated : 'ISubscriptionQuota'
  - The following properties are being added to the output type : 'ISubscriptionQuotasListResult'
  - Change description : The type of property Quota will be changed from fixed array to 'List'. 
  - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzStreamAnalyticsJob`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob' is changing
  - Change description : The types of the properties Function, Input and Output will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzStreamAnalyticsCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-Location`
    - The parameter : 'Location' is changing.
    - Change description : The parameter Location will be removed. 
    - This change will take effect on '11/1/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

### `Update-AzStreamAnalyticsJob`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob' is changing
  - Change description : The types of the properties Function, Input and Output will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'
