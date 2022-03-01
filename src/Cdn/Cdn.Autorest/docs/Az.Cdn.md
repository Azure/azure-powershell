---
Module Name: Az.Cdn
Module Guid: f9fae843-9c26-4513-9442-17f4379802bf
Download Help Link: https://docs.microsoft.com/powershell/module/az.cdn
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Cdn Module
## Description
Microsoft Azure PowerShell: Cdn cmdlets

## Az.Cdn Cmdlets
### [Clear-AzCdnAfdEndpointContent](Clear-AzCdnAfdEndpointContent.md)
Removes a content from AzureFrontDoor.

### [Clear-AzCdnEndpointContent](Clear-AzCdnEndpointContent.md)
Removes a content from CDN.

### [Disable-AzCdnCustomDomainCustomHttps](Disable-AzCdnCustomDomainCustomHttps.md)
Disable https delivery of the custom domain.

### [Enable-AzCdnCustomDomainCustomHttps](Enable-AzCdnCustomDomainCustomHttps.md)
Enable https delivery of the custom domain.

### [Get-AzCdnAfdCustomDomain](Get-AzCdnAfdCustomDomain.md)
Gets an existing AzureFrontDoor domain with the specified domain name under the specified subscription, resource group and profile.

### [Get-AzCdnAfdEndpoint](Get-AzCdnAfdEndpoint.md)
Gets an existing AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Get-AzCdnAfdEndpointResourceUsage](Get-AzCdnAfdEndpointResourceUsage.md)
Checks the quota and actual usage of endpoints under the given CDN profile.

### [Get-AzCdnAfdOrigin](Get-AzCdnAfdOrigin.md)
Gets an existing origin within an origin group.

### [Get-AzCdnAfdOriginGroup](Get-AzCdnAfdOriginGroup.md)
Gets an existing origin group within a profile.

### [Get-AzCdnAfdOriginGroupResourceUsage](Get-AzCdnAfdOriginGroupResourceUsage.md)
Checks the quota and actual usage of endpoints under the given CDN profile.

### [Get-AzCdnAfdProfileResourceUsage](Get-AzCdnAfdProfileResourceUsage.md)
Checks the quota and actual usage of endpoints under the given CDN profile.

### [Get-AzCdnCustomDomain](Get-AzCdnCustomDomain.md)
Gets an existing custom domain within an endpoint.

### [Get-AzCdnEdgeNode](Get-AzCdnEdgeNode.md)
Edgenodes are the global Point of Presence (POP) locations used to deliver CDN content to end users.

### [Get-AzCdnEndpoint](Get-AzCdnEndpoint.md)
Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Get-AzCdnEndpointResourceUsage](Get-AzCdnEndpointResourceUsage.md)
Checks the quota and usage of geo filters and custom domains under the given endpoint.

### [Get-AzCdnLogAnalyticLocation](Get-AzCdnLogAnalyticLocation.md)
Get all available location names for AFD log analytics report.

### [Get-AzCdnLogAnalyticMetric](Get-AzCdnLogAnalyticMetric.md)
Get log report for AFD profile

### [Get-AzCdnLogAnalyticRanking](Get-AzCdnLogAnalyticRanking.md)
Get log analytics ranking report for AFD profile

### [Get-AzCdnLogAnalyticResource](Get-AzCdnLogAnalyticResource.md)
Get all endpoints and custom domains available for AFD log report

### [Get-AzCdnLogAnalyticWafLogAnalyticMetric](Get-AzCdnLogAnalyticWafLogAnalyticMetric.md)
Get Waf related log analytics report for AFD profile.

### [Get-AzCdnLogAnalyticWafLogAnalyticRanking](Get-AzCdnLogAnalyticWafLogAnalyticRanking.md)
Get WAF log analytics charts for AFD profile

### [Get-AzCdnManagedRuleSet](Get-AzCdnManagedRuleSet.md)
Lists all available managed rule sets.

### [Get-AzCdnOrigin](Get-AzCdnOrigin.md)
Gets an existing origin within an endpoint.

### [Get-AzCdnOriginGroup](Get-AzCdnOriginGroup.md)
Gets an existing origin group within an endpoint.

### [Get-AzCdnPolicy](Get-AzCdnPolicy.md)
Retrieve protection policy with specified name within a resource group.

### [Get-AzCdnProfile](Get-AzCdnProfile.md)


### [Get-AzCdnProfileResourceUsage](Get-AzCdnProfileResourceUsage.md)
Checks the quota and actual usage of endpoints under the given Azure Front Door Standard or Azure Front Door Premium or CDN profile.

### [Get-AzCdnProfileSupportedOptimizationType](Get-AzCdnProfileSupportedOptimizationType.md)
Gets the supported optimization types for the current profile.
A user can create an endpoint with an optimization type from the listed values.

### [Get-AzCdnResourceUsage](Get-AzCdnResourceUsage.md)
Check the quota and actual usage of the CDN profiles under the given subscription.

### [Get-AzCdnRoute](Get-AzCdnRoute.md)
Gets an existing route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [Get-AzCdnRule](Get-AzCdnRule.md)
Gets an existing delivery rule within a rule set.

### [Get-AzCdnRuleSet](Get-AzCdnRuleSet.md)
Gets an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.

### [Get-AzCdnRuleSetResourceUsage](Get-AzCdnRuleSetResourceUsage.md)
Checks the quota and actual usage of endpoints under the given CDN profile.

### [Get-AzCdnSecret](Get-AzCdnSecret.md)
Gets an existing Secret within a profile.

### [Get-AzCdnSecurityPolicy](Get-AzCdnSecurityPolicy.md)
Gets an existing security policy within a profile.

### [Get-AzFrontDoorCdnProfile](Get-AzFrontDoorCdnProfile.md)


### [Import-AzCdnEndpointContent](Import-AzCdnEndpointContent.md)
Pre-loads a content to CDN.
Available for Verizon Profiles.

### [Invoke-AzCdnSecretValidate](Invoke-AzCdnSecretValidate.md)
Validate a Secret in the profile.

### [New-AzCdnAfdCustomDomain](New-AzCdnAfdCustomDomain.md)
Creates a new domain within the specified profile.

### [New-AzCdnAfdEndpoint](New-AzCdnAfdEndpoint.md)
Creates a new AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [New-AzCdnAfdOrigin](New-AzCdnAfdOrigin.md)
Creates a new origin within the specified origin group.

### [New-AzCdnAfdOriginGroup](New-AzCdnAfdOriginGroup.md)
Creates a new origin group within the specified profile.

### [New-AzCdnCustomDomain](New-AzCdnCustomDomain.md)
Creates a new custom domain within an endpoint.

### [New-AzCdnEndpoint](New-AzCdnEndpoint.md)
Creates a new CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [New-AzCdnOrigin](New-AzCdnOrigin.md)
Creates a new origin within the specified endpoint.

### [New-AzCdnOriginGroup](New-AzCdnOriginGroup.md)
Creates a new origin group within the specified endpoint.

### [New-AzCdnPolicy](New-AzCdnPolicy.md)
Create or update policy with specified rule set name within a resource group.

### [New-AzCdnProfileSsoUri](New-AzCdnProfileSsoUri.md)
Generates a dynamic SSO URI used to sign in to the CDN supplemental portal.
Supplemental portal is used to configure advanced feature capabilities that are not yet available in the Azure portal, such as core reports in a standard profile; rules engine, advanced HTTP reports, and real-time stats and alerts in a premium profile.
The SSO URI changes approximately every 10 minutes.

### [New-AzCdnRoute](New-AzCdnRoute.md)
Creates a new route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [New-AzCdnRule](New-AzCdnRule.md)
Creates a new delivery rule within the specified rule set.

### [New-AzCdnSecret](New-AzCdnSecret.md)
Creates a new Secret within the specified profile.

### [New-AzCdnSecurityPolicy](New-AzCdnSecurityPolicy.md)
Creates a new security policy within the specified profile.

### [New-AzFrontDoorCdnProfile](New-AzFrontDoorCdnProfile.md)
Creates a new Azure Front Door Standard or Azure Front Door Premium or CDN profile with a profile name under the specified subscription and resource group.

### [Remove-AzCdnAfdCustomDomain](Remove-AzCdnAfdCustomDomain.md)
Deletes an existing AzureFrontDoor domain with the specified domain name under the specified subscription, resource group and profile.

### [Remove-AzCdnAfdEndpoint](Remove-AzCdnAfdEndpoint.md)
Deletes an existing AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Remove-AzCdnAfdOrigin](Remove-AzCdnAfdOrigin.md)
Deletes an existing origin within an origin group.

### [Remove-AzCdnAfdOriginGroup](Remove-AzCdnAfdOriginGroup.md)
Deletes an existing origin group within a profile.

### [Remove-AzCdnCustomDomain](Remove-AzCdnCustomDomain.md)
Deletes an existing custom domain within an endpoint.

### [Remove-AzCdnEndpoint](Remove-AzCdnEndpoint.md)
Deletes an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

### [Remove-AzCdnOrigin](Remove-AzCdnOrigin.md)
Deletes an existing origin within an endpoint.

### [Remove-AzCdnOriginGroup](Remove-AzCdnOriginGroup.md)
Deletes an existing origin group within an endpoint.

### [Remove-AzCdnPolicy](Remove-AzCdnPolicy.md)
Deletes Policy

### [Remove-AzCdnRoute](Remove-AzCdnRoute.md)
Deletes an existing route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [Remove-AzCdnRule](Remove-AzCdnRule.md)
Deletes an existing delivery rule within a rule set.

### [Remove-AzCdnRuleSet](Remove-AzCdnRuleSet.md)
Deletes an existing AzureFrontDoor rule set with the specified rule set name under the specified subscription, resource group and profile.

### [Remove-AzCdnSecret](Remove-AzCdnSecret.md)
Deletes an existing Secret within profile.

### [Remove-AzCdnSecurityPolicy](Remove-AzCdnSecurityPolicy.md)
Deletes an existing security policy within profile.

### [Start-AzCdnEndpoint](Start-AzCdnEndpoint.md)
Starts an existing CDN endpoint that is on a stopped state.

### [Stop-AzCdnEndpoint](Stop-AzCdnEndpoint.md)
Stops an existing running CDN endpoint.

### [Test-AzCdnAfdEndpointCustomDomain](Test-AzCdnAfdEndpointCustomDomain.md)
Validates the custom domain mapping to ensure it maps to the correct CDN endpoint in DNS.

### [Test-AzCdnAfdProfileHostNameAvailability](Test-AzCdnAfdProfileHostNameAvailability.md)
Validates the custom domain mapping to ensure it maps to the correct CDN endpoint in DNS.

### [Test-AzCdnEndpointCustomDomain](Test-AzCdnEndpointCustomDomain.md)
Validates the custom domain mapping to ensure it maps to the correct CDN endpoint in DNS.

### [Test-AzCdnEndpointNameAvailability](Test-AzCdnEndpointNameAvailability.md)
Check the availability of a resource name.
This is needed for resources where name is globally unique, such as a afdx endpoint.

### [Test-AzCdnNameAvailability](Test-AzCdnNameAvailability.md)
Check the availability of a resource name.
This is needed for resources where name is globally unique, such as a CDN endpoint.

### [Test-AzCdnProbe](Test-AzCdnProbe.md)
Check if the probe path is a valid path and the file can be accessed.
Probe path is the path to a file hosted on the origin server to help accelerate the delivery of dynamic content via the CDN endpoint.
This path is relative to the origin path specified in the endpoint configuration.

### [Update-AzCdnAfdCustomDomain](Update-AzCdnAfdCustomDomain.md)
Updates an existing domain within a profile.

### [Update-AzCdnAfdCustomDomainValidationToken](Update-AzCdnAfdCustomDomainValidationToken.md)
Updates the domain validation token.

### [Update-AzCdnAfdEndpoint](Update-AzCdnAfdEndpoint.md)
Updates an existing AzureFrontDoor endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the Update Origin operation.
To update origin groups, use the Update Origin group operation.
To update domains, use the Update Custom Domain operation.

### [Update-AzCdnAfdOrigin](Update-AzCdnAfdOrigin.md)
Updates an existing origin within an origin group.

### [Update-AzCdnAfdOriginGroup](Update-AzCdnAfdOriginGroup.md)
Updates an existing origin group within a profile.

### [Update-AzCdnEndpoint](Update-AzCdnEndpoint.md)
Updates an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
Only tags can be updated after creating an endpoint.
To update origins, use the Update Origin operation.
To update origin groups, use the Update Origin group operation.
To update custom domains, use the Update Custom Domain operation.

### [Update-AzCdnOrigin](Update-AzCdnOrigin.md)
Updates an existing origin within an endpoint.

### [Update-AzCdnOriginGroup](Update-AzCdnOriginGroup.md)
Updates an existing origin group within an endpoint.

### [Update-AzCdnPolicy](Update-AzCdnPolicy.md)
Update an existing CdnWebApplicationFirewallPolicy with the specified policy name under the specified subscription and resource group

### [Update-AzCdnRoute](Update-AzCdnRoute.md)
Updates an existing route with the specified route name under the specified subscription, resource group, profile, and AzureFrontDoor endpoint.

### [Update-AzCdnRule](Update-AzCdnRule.md)
Updates an existing delivery rule within a rule set.

### [Update-AzCdnSecurityPolicy](Update-AzCdnSecurityPolicy.md)
Updates an existing security policy within a profile.

