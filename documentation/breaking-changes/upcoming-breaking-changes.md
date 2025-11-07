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
