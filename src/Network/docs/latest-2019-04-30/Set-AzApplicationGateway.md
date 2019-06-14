---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azapplicationgateway
schema: 2.0.0
---

# Set-AzApplicationGateway

## SYNOPSIS
Creates or updates the specified application gateway.

## SYNTAX

### Update (Default)
```
Set-AzApplicationGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IApplicationGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzApplicationGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -AutoscaleConfigurationMinCapacity <Int32> -WebApplicationFirewallConfigurationEnabled
 -WebApplicationFirewallConfigurationFirewallMode <ApplicationGatewayFirewallMode>
 -WebApplicationFirewallConfigurationRuleSetType <String>
 -WebApplicationFirewallConfigurationRuleSetVersion <String>
 [-AuthenticationCertificate <IApplicationGatewayAuthenticationCertificate[]>]
 [-AutoscaleConfigurationMaxCapacity <Int32>] [-BackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-BackendHttpSettingsCollection <IApplicationGatewayBackendHttpSettings[]>]
 [-CustomErrorConfiguration <IApplicationGatewayCustomError[]>] [-EnableFIP] [-EnableHttp2] [-Etag <String>]
 [-FirewallPolicyId <String>] [-FrontendIPConfiguration <IApplicationGatewayFrontendIPConfiguration[]>]
 [-FrontendPort <IApplicationGatewayFrontendPort[]>]
 [-GatewayIPConfiguration <IApplicationGatewayIPConfiguration[]>]
 [-HttpListener <IApplicationGatewayHttpListener[]>] [-Id <String>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>] [-Location <String>]
 [-Probe <IApplicationGatewayProbe[]>] [-ProvisioningState <String>]
 [-RedirectConfiguration <IApplicationGatewayRedirectConfiguration[]>]
 [-RequestRoutingRule <IApplicationGatewayRequestRoutingRule[]>] [-ResourceGuid <String>]
 [-RewriteRuleSet <IApplicationGatewayRewriteRuleSet[]>] [-SkuCapacity <Int32>]
 [-SkuName <ApplicationGatewaySkuName>] [-SkuTier <ApplicationGatewayTier>]
 [-SslCertificate <IApplicationGatewaySslCertificate[]>]
 [-SslPolicyCIPherSuite <ApplicationGatewaySslCipherSuite[]>]
 [-SslPolicyDisabledSslProtocol <ApplicationGatewaySslProtocol[]>]
 [-SslPolicyMinProtocolVersion <ApplicationGatewaySslProtocol>]
 [-SslPolicyName <ApplicationGatewaySslPolicyName>] [-SslPolicyType <ApplicationGatewaySslPolicyType>]
 [-Tag <IResourceTags>] [-TrustedRootCertificate <IApplicationGatewayTrustedRootCertificate[]>]
 [-UrlPathMap <IApplicationGatewayUrlPathMap[]>]
 [-WebApplicationFirewallConfigurationDisabledRuleGroup <IApplicationGatewayFirewallDisabledRuleGroup[]>]
 [-WebApplicationFirewallConfigurationExclusion <IApplicationGatewayFirewallExclusion[]>]
 [-WebApplicationFirewallConfigurationFileUploadLimitInMb <Int32>]
 [-WebApplicationFirewallConfigurationMaxRequestBodySize <Int32>]
 [-WebApplicationFirewallConfigurationMaxRequestBodySizeInKb <Int32>]
 [-WebApplicationFirewallConfigurationRequestBodyCheck] [-Zone <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the specified application gateway.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AuthenticationCertificate
Authentication certificates of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoscaleConfigurationMaxCapacity
Upper bound on number of Application Gateway capacity

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoscaleConfigurationMinCapacity
Lower bound on number of Application Gateway capacity

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendAddressPool
Backend address pool of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendHttpSettingsCollection
Backend http settings of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomErrorConfiguration
Custom error configurations of the application gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableFIP
Whether FIPS is enabled on the application gateway resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableHttp2
Whether HTTP2 is enabled on the application gateway resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FirewallPolicyId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FrontendIPConfiguration
Frontend IP addresses of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FrontendPort
Frontend ports of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GatewayIPConfiguration
Subnets of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpListener
Http listeners of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHttpListener[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
The type of identity used for the resource.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.
The type 'None' will remove any identities from the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ResourceIdentityType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with resource.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IManagedServiceIdentityUserAssignedIdentities
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the application gateway.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Application gateway resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway
Parameter Sets: Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Probe
Probes of the application gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Provisioning state of the application gateway resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RedirectConfiguration
Redirect configurations of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfiguration[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RequestRoutingRule
Request routing rules of the application gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRequestRoutingRule[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGuid
Resource GUID property of the application gateway resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RewriteRuleSet
Rewrite rules for the application gateway resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSet[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
Capacity (instance count) of an application gateway.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
Name of an application gateway SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
Tier of an application gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslCertificate
SSL certificates of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificate[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslPolicyCIPherSuite
Ssl cipher suites to be enabled in the specified order to application gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuite[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslPolicyDisabledSslProtocol
Ssl protocols to be disabled on application gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslPolicyMinProtocolVersion
Minimum version of Ssl protocol to be supported on application gateway.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslProtocol
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslPolicyName
Name of Ssl predefined policy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyName
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslPolicyType
Type of Ssl Policy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TrustedRootCertificate
Trusted Root certificates of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificate[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UrlPathMap
URL path map of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationDisabledRuleGroup
The disabled rule groups.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationEnabled
Whether the web application firewall is enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationExclusion
The exclusion list.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationFileUploadLimitInMb
Maximum file upload size in Mb for WAF.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationFirewallMode
Web application firewall mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationMaxRequestBodySize
Maximum request body size for WAF.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationMaxRequestBodySizeInKb
Maximum request body size in Kb for WAF.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationRequestBodyCheck
Whether allow WAF to check request Body.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationRuleSetType
The type of the web application firewall rule set.
Possible values are: 'OWASP'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebApplicationFirewallConfigurationRuleSetVersion
The version of the rule set type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Zone
A list of availability zones denoting where the resource needs to come from.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway

## ALIASES

## RELATED LINKS

