---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azapplicationgateway
schema: 2.0.0
---

# New-AzApplicationGateway

## SYNOPSIS
Creates or updates the specified application gateway.

## SYNTAX

### Create (Default)
```
New-AzApplicationGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IApplicationGateway>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzApplicationGateway -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
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
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-Probe <IApplicationGatewayProbe[]>]
 [-ProvisioningState <String>] [-RedirectConfiguration <IApplicationGatewayRedirectConfiguration[]>]
 [-RequestRoutingRule <IApplicationGatewayRequestRoutingRule[]>] [-ResourceGuid <String>]
 [-RewriteRuleSet <IApplicationGatewayRewriteRuleSet[]>] [-SkuCapacity <Int32>]
 [-SkuName <ApplicationGatewaySkuName>] [-SkuTier <ApplicationGatewayTier>]
 [-SslCertificate <IApplicationGatewaySslCertificate[]>]
 [-SslPolicyCIPherSuite <ApplicationGatewaySslCipherSuite[]>]
 [-SslPolicyDisabledSslProtocol <ApplicationGatewaySslProtocol[]>]
 [-SslPolicyMinProtocolVersion <ApplicationGatewaySslProtocol>]
 [-SslPolicyName <ApplicationGatewaySslPolicyName>] [-SslPolicyType <ApplicationGatewaySslPolicyType>]
 [-Tag <Hashtable>] [-TrustedRootCertificate <IApplicationGatewayTrustedRootCertificate[]>]
 [-UrlPathMap <IApplicationGatewayUrlPathMap[]>]
 [-WebApplicationFirewallConfigurationDisabledRuleGroup <IApplicationGatewayFirewallDisabledRuleGroup[]>]
 [-WebApplicationFirewallConfigurationExclusion <IApplicationGatewayFirewallExclusion[]>]
 [-WebApplicationFirewallConfigurationFileUploadLimitInMb <Int32>]
 [-WebApplicationFirewallConfigurationMaxRequestBodySize <Int32>]
 [-WebApplicationFirewallConfigurationMaxRequestBodySizeInKb <Int32>]
 [-WebApplicationFirewallConfigurationRequestBodyCheck] [-Zone <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzApplicationGateway -InputObject <INetworkIdentity> -AutoscaleConfigurationMinCapacity <Int32>
 -WebApplicationFirewallConfigurationEnabled
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
 [-IdentityUserAssignedIdentity <Hashtable>] [-Location <String>] [-Probe <IApplicationGatewayProbe[]>]
 [-ProvisioningState <String>] [-RedirectConfiguration <IApplicationGatewayRedirectConfiguration[]>]
 [-RequestRoutingRule <IApplicationGatewayRequestRoutingRule[]>] [-ResourceGuid <String>]
 [-RewriteRuleSet <IApplicationGatewayRewriteRuleSet[]>] [-SkuCapacity <Int32>]
 [-SkuName <ApplicationGatewaySkuName>] [-SkuTier <ApplicationGatewayTier>]
 [-SslCertificate <IApplicationGatewaySslCertificate[]>]
 [-SslPolicyCIPherSuite <ApplicationGatewaySslCipherSuite[]>]
 [-SslPolicyDisabledSslProtocol <ApplicationGatewaySslProtocol[]>]
 [-SslPolicyMinProtocolVersion <ApplicationGatewaySslProtocol>]
 [-SslPolicyName <ApplicationGatewaySslPolicyName>] [-SslPolicyType <ApplicationGatewaySslPolicyType>]
 [-Tag <Hashtable>] [-TrustedRootCertificate <IApplicationGatewayTrustedRootCertificate[]>]
 [-UrlPathMap <IApplicationGatewayUrlPathMap[]>]
 [-WebApplicationFirewallConfigurationDisabledRuleGroup <IApplicationGatewayFirewallDisabledRuleGroup[]>]
 [-WebApplicationFirewallConfigurationExclusion <IApplicationGatewayFirewallExclusion[]>]
 [-WebApplicationFirewallConfigurationFileUploadLimitInMb <Int32>]
 [-WebApplicationFirewallConfigurationMaxRequestBodySize <Int32>]
 [-WebApplicationFirewallConfigurationMaxRequestBodySizeInKb <Int32>]
 [-WebApplicationFirewallConfigurationRequestBodyCheck] [-Zone <String[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzApplicationGateway -InputObject <INetworkIdentity> [-Parameter <IApplicationGateway>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
To construct, see NOTES section for AUTHENTICATIONCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayAuthenticationCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for BACKENDADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for BACKENDHTTPSETTINGSCOLLECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for CUSTOMERRORCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for FRONTENDIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendIPConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for FRONTENDPORT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFrontendPort[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for GATEWAYIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayIPConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for HTTPLISTENER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHttpListener[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases: ApplicationGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

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

### -Parameter
Application gateway resource
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway
Parameter Sets: Create, CreateViaIdentity
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
To construct, see NOTES section for PROBE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for REDIRECTCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for REQUESTROUTINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRequestRoutingRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for REWRITERULESET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRewriteRuleSet[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for SSLCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for TRUSTEDROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayTrustedRootCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for URLPATHMAP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayUrlPathMap[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for WEBAPPLICATIONFIREWALLCONFIGURATIONDISABLEDRULEGROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallDisabledRuleGroup[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
To construct, see NOTES section for WEBAPPLICATIONFIREWALLCONFIGURATIONEXCLUSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### AUTHENTICATIONCERTIFICATE <IApplicationGatewayAuthenticationCertificate[]>: Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Data <String>]`: Certificate public data.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the authentication certificate that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### BACKENDADDRESSPOOL <IApplicationGatewayBackendAddressPool[]>: Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
    - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
    - `[IPAddress <String>]`: IP address
  - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[OutboundRuleId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[BackendIPConfigurationId <String>]`: Resource ID.
      - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
      - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
      - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[FrontendIPConfigurationId <String>]`: Resource ID.
      - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
      - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
      - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[DdosCustomPolicyId <String>]`: Resource ID.
        - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
          - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
          - `[Subnet <ISubnet>]`: The reference of the subnet resource.
            - `[AddressPrefix <String>]`: The address prefix for the subnet.
            - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
              - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
              - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
              - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
              - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
              - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
              - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
              - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
              - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
              - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
              - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
              - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
              - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
              - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
              - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
              - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
            - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
              - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
              - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
            - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
            - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[NatGatewayId <String>]`: Resource ID.
            - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[NetworkSecurityGroupId <String>]`: Resource ID.
            - `[NetworkSecurityGroupLocation <String>]`: Resource location.
            - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
            - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
            - `[ProvisioningState <String>]`: The provisioning state of the resource.
            - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
            - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
              - `[Link <String>]`: Link to the external resource
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
              - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
              - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
              - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[RouteTableEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
            - `[RouteTableId <String>]`: Resource ID.
            - `[RouteTableLocation <String>]`: Resource location.
            - `[RouteTablePropertiesProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[RouteTableTag <IResourceTags>]`: Resource tags.
            - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
            - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
              - `[Link <String>]`: Link to the external resource.
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
              - `[Location <String[]>]`: A list of locations.
              - `[ProvisioningState <String>]`: The provisioning state of the resource.
              - `[Service <String>]`: The type of the endpoint service.
            - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
              - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
                - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                - `[Service <String>]`: Service endpoint name.
                - `[ServiceResource <String[]>]`: A list of service resources.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
          - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
          - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
        - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
        - `[PublicIPPrefixId <String>]`: Resource ID.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Version <IPVersion?>]`: The public IP address version.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
    - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### BACKENDHTTPSETTINGSCOLLECTION <IApplicationGatewayBackendHttpSettings[]>: Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `ConnectionDrainingDrainTimeoutInSec <Int32>`: The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
  - `ConnectionDrainingEnabled <Boolean>`: Whether connection draining is enabled or not.
  - `[AffinityCookieName <String>]`: Cookie name to use for the affinity cookie.
  - `[AuthenticationCertificate <ISubResource[]>]`: Array of references to application gateway authentication certificates.
    - `[Id <String>]`: Resource ID.
  - `[CookieBasedAffinity <ApplicationGatewayCookieBasedAffinity?>]`: Cookie based affinity.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[HostName <String>]`: Host header to be sent to the backend servers.
  - `[Name <String>]`: Name of the backend http settings that is unique within an Application Gateway.
  - `[Path <String>]`: Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
  - `[PickHostNameFromBackendAddress <Boolean?>]`: Whether to pick host header should be picked from the host name of the backend server. Default value is false.
  - `[Port <Int32?>]`: The destination port on the backend.
  - `[ProbeEnabled <Boolean?>]`: Whether the probe is enabled. Default value is false.
  - `[ProbeId <String>]`: Resource ID.
  - `[Protocol <ApplicationGatewayProtocol?>]`: The protocol used to communicate with the backend.
  - `[ProvisioningState <String>]`: Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RequestTimeout <Int32?>]`: Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout. Acceptable values are from 1 second to 86400 seconds.
  - `[TrustedRootCertificate <ISubResource[]>]`: Array of references to application gateway trusted root certificates.
  - `[Type <String>]`: Type of the resource.

#### CUSTOMERRORCONFIGURATION <IApplicationGatewayCustomError[]>: Custom error configurations of the application gateway resource.
  - `[CustomErrorPageUrl <String>]`: Error page URL of the application gateway customer error.
  - `[StatusCode <ApplicationGatewayCustomErrorStatusCode?>]`: Status code of the application gateway customer error.

#### FRONTENDIPCONFIGURATION <IApplicationGatewayFrontendIPConfiguration[]>: Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the frontend IP configuration that is unique within an Application Gateway.
  - `[PrivateIPAddress <String>]`: PrivateIPAddress of the network interface IP Configuration.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[ProvisioningState <String>]`: Provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddressId <String>]`: Resource ID.
  - `[SubnetId <String>]`: Resource ID.
  - `[Type <String>]`: Type of the resource.

#### FRONTENDPORT <IApplicationGatewayFrontendPort[]>: Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the frontend port that is unique within an Application Gateway
  - `[Port <Int32?>]`: Frontend port
  - `[ProvisioningState <String>]`: Provisioning state of the frontend port resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### GATEWAYIPCONFIGURATION <IApplicationGatewayIPConfiguration[]>: Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the IP configuration that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the application gateway subnet resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[SubnetId <String>]`: Resource ID.
  - `[Type <String>]`: Type of the resource.

#### HTTPLISTENER <IApplicationGatewayHttpListener[]>: Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[CustomErrorConfiguration <IApplicationGatewayCustomError[]>]`: Custom error configurations of the HTTP listener.
    - `[CustomErrorPageUrl <String>]`: Error page URL of the application gateway customer error.
    - `[StatusCode <ApplicationGatewayCustomErrorStatusCode?>]`: Status code of the application gateway customer error.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[FrontendPortId <String>]`: Resource ID.
  - `[HostName <String>]`: Host name of HTTP listener.
  - `[Name <String>]`: Name of the HTTP listener that is unique within an Application Gateway.
  - `[Protocol <ApplicationGatewayProtocol?>]`: Protocol of the HTTP listener.
  - `[ProvisioningState <String>]`: Provisioning state of the HTTP listener resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RequireServerNameIndication <Boolean?>]`: Applicable only if protocol is https. Enables SNI for multi-hosting.
  - `[SslCertificateId <String>]`: Resource ID.
  - `[Type <String>]`: Type of the resource.

#### PARAMETER <IApplicationGateway>: Application gateway resource
  - `AutoscaleConfigurationMinCapacity <Int32>`: Lower bound on number of Application Gateway capacity
  - `WebApplicationFirewallConfigurationEnabled <Boolean>`: Whether the web application firewall is enabled or not.
  - `WebApplicationFirewallConfigurationFirewallMode <ApplicationGatewayFirewallMode>`: Web application firewall mode.
  - `WebApplicationFirewallConfigurationRuleSetType <String>`: The type of the web application firewall rule set. Possible values are: 'OWASP'.
  - `WebApplicationFirewallConfigurationRuleSetVersion <String>`: The version of the rule set type.
  - `[AuthenticationCertificate <IApplicationGatewayAuthenticationCertificate[]>]`: Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Data <String>]`: Certificate public data.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the authentication certificate that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[AutoscaleConfigurationMaxCapacity <Int32?>]`: Upper bound on number of Application Gateway capacity
  - `[BackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[OutboundRuleId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
        - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
        - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[BackendIPConfigurationId <String>]`: Resource ID.
        - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
        - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[FrontendIPConfigurationId <String>]`: Resource ID.
        - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
        - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
        - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
        - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
        - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
        - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
        - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
          - `[DdosCustomPolicyId <String>]`: Resource ID.
          - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
          - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
          - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
          - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
          - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPConfigurationId <String>]`: Resource ID.
          - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
            - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
            - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
            - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
            - `[Subnet <ISubnet>]`: The reference of the subnet resource.
              - `[AddressPrefix <String>]`: The address prefix for the subnet.
              - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
                - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
                - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
                - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
                - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
                - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
                - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
                - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
                - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
                - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
                - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
                - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
                - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
                - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
                - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
              - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
                - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
                - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
              - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[NatGatewayId <String>]`: Resource ID.
              - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[NetworkSecurityGroupId <String>]`: Resource ID.
              - `[NetworkSecurityGroupLocation <String>]`: Resource location.
              - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
              - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
              - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
              - `[ProvisioningState <String>]`: The provisioning state of the resource.
              - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
              - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
                - `[Link <String>]`: Link to the external resource
                - `[LinkedResourceType <String>]`: Resource type of the linked resource.
                - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
                - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
                - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
                - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
              - `[RouteTableEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
              - `[RouteTableId <String>]`: Resource ID.
              - `[RouteTableLocation <String>]`: Resource location.
              - `[RouteTablePropertiesProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
              - `[RouteTableTag <IResourceTags>]`: Resource tags.
              - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
              - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
                - `[Link <String>]`: Link to the external resource.
                - `[LinkedResourceType <String>]`: Resource type of the linked resource.
                - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
                - `[Location <String[]>]`: A list of locations.
                - `[ProvisioningState <String>]`: The provisioning state of the resource.
                - `[Service <String>]`: The type of the endpoint service.
              - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
                - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
                  - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                  - `[Service <String>]`: Service endpoint name.
                  - `[ServiceResource <String[]>]`: A list of service resources.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
            - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
            - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
          - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
          - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
          - `[PublicIPPrefixId <String>]`: Resource ID.
          - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
          - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
          - `[Version <IPVersion?>]`: The public IP address version.
          - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
        - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
        - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[BackendHttpSettingsCollection <IApplicationGatewayBackendHttpSettings[]>]`: Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `ConnectionDrainingDrainTimeoutInSec <Int32>`: The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
    - `ConnectionDrainingEnabled <Boolean>`: Whether connection draining is enabled or not.
    - `[AffinityCookieName <String>]`: Cookie name to use for the affinity cookie.
    - `[AuthenticationCertificate <ISubResource[]>]`: Array of references to application gateway authentication certificates.
    - `[CookieBasedAffinity <ApplicationGatewayCookieBasedAffinity?>]`: Cookie based affinity.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[HostName <String>]`: Host header to be sent to the backend servers.
    - `[Name <String>]`: Name of the backend http settings that is unique within an Application Gateway.
    - `[Path <String>]`: Path which should be used as a prefix for all HTTP requests. Null means no path will be prefixed. Default value is null.
    - `[PickHostNameFromBackendAddress <Boolean?>]`: Whether to pick host header should be picked from the host name of the backend server. Default value is false.
    - `[Port <Int32?>]`: The destination port on the backend.
    - `[ProbeEnabled <Boolean?>]`: Whether the probe is enabled. Default value is false.
    - `[ProbeId <String>]`: Resource ID.
    - `[Protocol <ApplicationGatewayProtocol?>]`: The protocol used to communicate with the backend.
    - `[ProvisioningState <String>]`: Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RequestTimeout <Int32?>]`: Request timeout in seconds. Application Gateway will fail the request if response is not received within RequestTimeout. Acceptable values are from 1 second to 86400 seconds.
    - `[TrustedRootCertificate <ISubResource[]>]`: Array of references to application gateway trusted root certificates.
    - `[Type <String>]`: Type of the resource.
  - `[CustomErrorConfiguration <IApplicationGatewayCustomError[]>]`: Custom error configurations of the application gateway resource.
    - `[CustomErrorPageUrl <String>]`: Error page URL of the application gateway customer error.
    - `[StatusCode <ApplicationGatewayCustomErrorStatusCode?>]`: Status code of the application gateway customer error.
  - `[EnableFip <Boolean?>]`: Whether FIPS is enabled on the application gateway resource.
  - `[EnableHttp2 <Boolean?>]`: Whether HTTP2 is enabled on the application gateway resource.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FirewallPolicyId <String>]`: Resource ID.
  - `[FrontendIPConfiguration <IApplicationGatewayFrontendIPConfiguration[]>]`: Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the frontend IP configuration that is unique within an Application Gateway.
    - `[PrivateIPAddress <String>]`: PrivateIPAddress of the network interface IP Configuration.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: Provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddressId <String>]`: Resource ID.
    - `[SubnetId <String>]`: Resource ID.
    - `[Type <String>]`: Type of the resource.
  - `[FrontendPort <IApplicationGatewayFrontendPort[]>]`: Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the frontend port that is unique within an Application Gateway
    - `[Port <Int32?>]`: Frontend port
    - `[ProvisioningState <String>]`: Provisioning state of the frontend port resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[GatewayIPConfiguration <IApplicationGatewayIPConfiguration[]>]`: Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the IP configuration that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the application gateway subnet resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[SubnetId <String>]`: Resource ID.
    - `[Type <String>]`: Type of the resource.
  - `[HttpListener <IApplicationGatewayHttpListener[]>]`: Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[CustomErrorConfiguration <IApplicationGatewayCustomError[]>]`: Custom error configurations of the HTTP listener.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[FrontendIPConfigurationId <String>]`: Resource ID.
    - `[FrontendPortId <String>]`: Resource ID.
    - `[HostName <String>]`: Host name of HTTP listener.
    - `[Name <String>]`: Name of the HTTP listener that is unique within an Application Gateway.
    - `[Protocol <ApplicationGatewayProtocol?>]`: Protocol of the HTTP listener.
    - `[ProvisioningState <String>]`: Provisioning state of the HTTP listener resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RequireServerNameIndication <Boolean?>]`: Applicable only if protocol is https. Enables SNI for multi-hosting.
    - `[SslCertificateId <String>]`: Resource ID.
    - `[Type <String>]`: Type of the resource.
  - `[IdentityType <ResourceIdentityType?>]`: The type of identity used for the resource. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine.
  - `[IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]`: The list of user identities associated with resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    - `[(Any) <IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]`: This indicates any property can be added to this object.
  - `[Probe <IApplicationGatewayProbe[]>]`: Probes of the application gateway resource.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Host <String>]`: Host name to send the probe to.
    - `[Interval <Int32?>]`: The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from 1 second to 86400 seconds.
    - `[MatchBody <String>]`: Body that must be contained in the health response. Default value is empty.
    - `[MatchStatusCode <String[]>]`: Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
    - `[MinServer <Int32?>]`: Minimum number of servers that are always marked healthy. Default value is 0.
    - `[Name <String>]`: Name of the probe that is unique within an Application Gateway.
    - `[Path <String>]`: Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
    - `[PickHostNameFromBackendHttpSetting <Boolean?>]`: Whether the host header should be picked from the backend http settings. Default value is false.
    - `[Protocol <ApplicationGatewayProtocol?>]`: The protocol used for the probe.
    - `[ProvisioningState <String>]`: Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Timeout <Int32?>]`: The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.
    - `[Type <String>]`: Type of the resource.
    - `[UnhealthyThreshold <Int32?>]`: The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold. Acceptable values are from 1 second to 20.
  - `[ProvisioningState <String>]`: Provisioning state of the application gateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RedirectConfiguration <IApplicationGatewayRedirectConfiguration[]>]`: Redirect configurations of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[IncludePath <Boolean?>]`: Include path in the redirected url.
    - `[IncludeQueryString <Boolean?>]`: Include query string in the redirected url.
    - `[Name <String>]`: Name of the redirect configuration that is unique within an Application Gateway.
    - `[PathRule <ISubResource[]>]`: Path rules specifying redirect configuration.
    - `[RedirectType <ApplicationGatewayRedirectType?>]`: HTTP redirection type.
    - `[RequestRoutingRule <ISubResource[]>]`: Request routing specifying redirect configuration.
    - `[TargetListenerId <String>]`: Resource ID.
    - `[TargetUrl <String>]`: Url to redirect the request to.
    - `[Type <String>]`: Type of the resource.
    - `[UrlPathMap <ISubResource[]>]`: Url path maps specifying default redirect configuration.
  - `[RequestRoutingRule <IApplicationGatewayRequestRoutingRule[]>]`: Request routing rules of the application gateway resource.
    - `[BackendAddressPoolId <String>]`: Resource ID.
    - `[BackendHttpSettingId <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[HttpListenerId <String>]`: Resource ID.
    - `[Name <String>]`: Name of the request routing rule that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the request routing rule resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RedirectConfigurationId <String>]`: Resource ID.
    - `[RewriteRuleSetId <String>]`: Resource ID.
    - `[RuleType <ApplicationGatewayRequestRoutingRuleType?>]`: Rule type.
    - `[Type <String>]`: Type of the resource.
    - `[UrlPathMapId <String>]`: Resource ID.
  - `[ResourceGuid <String>]`: Resource GUID property of the application gateway resource.
  - `[RewriteRuleSet <IApplicationGatewayRewriteRuleSet[]>]`: Rewrite rules for the application gateway resource.
    - `[Name <String>]`: Name of the rewrite rule set that is unique within an Application Gateway.
    - `[RewriteRule <IApplicationGatewayRewriteRule[]>]`: Rewrite rules in the rewrite rule set.
      - `[ActionSetRequestHeaderConfiguration <IApplicationGatewayHeaderConfiguration[]>]`: Request Header Actions in the Action Set
        - `[HeaderName <String>]`: Header name of the header configuration
        - `[HeaderValue <String>]`: Header value of the header configuration
      - `[ActionSetResponseHeaderConfiguration <IApplicationGatewayHeaderConfiguration[]>]`: Response Header Actions in the Action Set
      - `[Condition <IApplicationGatewayRewriteRuleCondition[]>]`: Conditions based on which the action set execution will be evaluated.
        - `[IgnoreCase <Boolean?>]`: Setting this paramter to truth value with force the pattern to do a case in-sensitive comparison.
        - `[Negate <Boolean?>]`: Setting this value as truth will force to check the negation of the condition given by the user.
        - `[Pattern <String>]`: The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition
        - `[Variable <String>]`: The condition parameter of the RewriteRuleCondition.
      - `[Name <String>]`: Name of the rewrite rule that is unique within an Application Gateway.
      - `[RuleSequence <Int32?>]`: Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.
  - `[SkuCapacity <Int32?>]`: Capacity (instance count) of an application gateway.
  - `[SkuName <ApplicationGatewaySkuName?>]`: Name of an application gateway SKU.
  - `[SkuTier <ApplicationGatewayTier?>]`: Tier of an application gateway.
  - `[SslCertificate <IApplicationGatewaySslCertificate[]>]`: SSL certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Data <String>]`: Base-64 encoded pfx certificate. Only applicable in PUT Request.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[KeyVaultSecretId <String>]`: Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
    - `[Name <String>]`: Name of the SSL certificate that is unique within an Application Gateway.
    - `[Password <String>]`: Password for the pfx file specified in data. Only applicable in PUT request.
    - `[ProvisioningState <String>]`: Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicCertData <String>]`: Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
    - `[Type <String>]`: Type of the resource.
  - `[SslPolicyCipherSuite <ApplicationGatewaySslCipherSuite[]>]`: Ssl cipher suites to be enabled in the specified order to application gateway.
  - `[SslPolicyDisabledSslProtocol <ApplicationGatewaySslProtocol[]>]`: Ssl protocols to be disabled on application gateway.
  - `[SslPolicyMinProtocolVersion <ApplicationGatewaySslProtocol?>]`: Minimum version of Ssl protocol to be supported on application gateway.
  - `[SslPolicyName <ApplicationGatewaySslPolicyName?>]`: Name of Ssl predefined policy
  - `[SslPolicyType <ApplicationGatewaySslPolicyType?>]`: Type of Ssl Policy
  - `[TrustedRootCertificate <IApplicationGatewayTrustedRootCertificate[]>]`: Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[Data <String>]`: Certificate public data.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[KeyVaultSecretId <String>]`: Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
    - `[Name <String>]`: Name of the trusted root certificate that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[UrlPathMap <IApplicationGatewayUrlPathMap[]>]`: URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
    - `[DefaultBackendAddressPoolId <String>]`: Resource ID.
    - `[DefaultBackendHttpSettingId <String>]`: Resource ID.
    - `[DefaultRedirectConfigurationId <String>]`: Resource ID.
    - `[DefaultRewriteRuleSetId <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the URL path map that is unique within an Application Gateway.
    - `[PathRule <IApplicationGatewayPathRule[]>]`: Path rule of URL path map resource.
      - `[BackendAddressPoolId <String>]`: Resource ID.
      - `[BackendHttpSettingId <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Name of the path rule that is unique within an Application Gateway.
      - `[Path <String[]>]`: Path rules of URL path map.
      - `[ProvisioningState <String>]`: Path rule of URL path map resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[RedirectConfigurationId <String>]`: Resource ID.
      - `[RewriteRuleSetId <String>]`: Resource ID.
      - `[Type <String>]`: Type of the resource.
    - `[ProvisioningState <String>]`: Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[WebApplicationFirewallConfigurationDisabledRuleGroup <IApplicationGatewayFirewallDisabledRuleGroup[]>]`: The disabled rule groups.
    - `RuleGroupName <String>`: The name of the rule group that will be disabled.
    - `[Rule <Int32[]>]`: The list of rules that will be disabled. If null, all rules of the rule group will be disabled.
  - `[WebApplicationFirewallConfigurationExclusion <IApplicationGatewayFirewallExclusion[]>]`: The exclusion list.
    - `MatchVariable <String>`: The variable to be excluded.
    - `Selector <String>`: When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
    - `SelectorMatchOperator <String>`: When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion applies to.
  - `[WebApplicationFirewallConfigurationFileUploadLimitInMb <Int32?>]`: Maximum file upload size in Mb for WAF.
  - `[WebApplicationFirewallConfigurationMaxRequestBodySize <Int32?>]`: Maximum request body size for WAF.
  - `[WebApplicationFirewallConfigurationMaxRequestBodySizeInKb <Int32?>]`: Maximum request body size in Kb for WAF.
  - `[WebApplicationFirewallConfigurationRequestBodyCheck <Boolean?>]`: Whether allow WAF to check request Body.
  - `[Zone <String[]>]`: A list of availability zones denoting where the resource needs to come from.

#### PROBE <IApplicationGatewayProbe[]>: Probes of the application gateway resource.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Host <String>]`: Host name to send the probe to.
  - `[Interval <Int32?>]`: The probing interval in seconds. This is the time interval between two consecutive probes. Acceptable values are from 1 second to 86400 seconds.
  - `[MatchBody <String>]`: Body that must be contained in the health response. Default value is empty.
  - `[MatchStatusCode <String[]>]`: Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
  - `[MinServer <Int32?>]`: Minimum number of servers that are always marked healthy. Default value is 0.
  - `[Name <String>]`: Name of the probe that is unique within an Application Gateway.
  - `[Path <String>]`: Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
  - `[PickHostNameFromBackendHttpSetting <Boolean?>]`: Whether the host header should be picked from the backend http settings. Default value is false.
  - `[Protocol <ApplicationGatewayProtocol?>]`: The protocol used for the probe.
  - `[ProvisioningState <String>]`: Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Timeout <Int32?>]`: The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.
  - `[Type <String>]`: Type of the resource.
  - `[UnhealthyThreshold <Int32?>]`: The probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold. Acceptable values are from 1 second to 20.

#### REDIRECTCONFIGURATION <IApplicationGatewayRedirectConfiguration[]>: Redirect configurations of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IncludePath <Boolean?>]`: Include path in the redirected url.
  - `[IncludeQueryString <Boolean?>]`: Include query string in the redirected url.
  - `[Name <String>]`: Name of the redirect configuration that is unique within an Application Gateway.
  - `[PathRule <ISubResource[]>]`: Path rules specifying redirect configuration.
    - `[Id <String>]`: Resource ID.
  - `[RedirectType <ApplicationGatewayRedirectType?>]`: HTTP redirection type.
  - `[RequestRoutingRule <ISubResource[]>]`: Request routing specifying redirect configuration.
  - `[TargetListenerId <String>]`: Resource ID.
  - `[TargetUrl <String>]`: Url to redirect the request to.
  - `[Type <String>]`: Type of the resource.
  - `[UrlPathMap <ISubResource[]>]`: Url path maps specifying default redirect configuration.

#### REQUESTROUTINGRULE <IApplicationGatewayRequestRoutingRule[]>: Request routing rules of the application gateway resource.
  - `[BackendAddressPoolId <String>]`: Resource ID.
  - `[BackendHttpSettingId <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[HttpListenerId <String>]`: Resource ID.
  - `[Name <String>]`: Name of the request routing rule that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the request routing rule resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RedirectConfigurationId <String>]`: Resource ID.
  - `[RewriteRuleSetId <String>]`: Resource ID.
  - `[RuleType <ApplicationGatewayRequestRoutingRuleType?>]`: Rule type.
  - `[Type <String>]`: Type of the resource.
  - `[UrlPathMapId <String>]`: Resource ID.

#### REWRITERULESET <IApplicationGatewayRewriteRuleSet[]>: Rewrite rules for the application gateway resource.
  - `[Name <String>]`: Name of the rewrite rule set that is unique within an Application Gateway.
  - `[RewriteRule <IApplicationGatewayRewriteRule[]>]`: Rewrite rules in the rewrite rule set.
    - `[ActionSetRequestHeaderConfiguration <IApplicationGatewayHeaderConfiguration[]>]`: Request Header Actions in the Action Set
      - `[HeaderName <String>]`: Header name of the header configuration
      - `[HeaderValue <String>]`: Header value of the header configuration
    - `[ActionSetResponseHeaderConfiguration <IApplicationGatewayHeaderConfiguration[]>]`: Response Header Actions in the Action Set
    - `[Condition <IApplicationGatewayRewriteRuleCondition[]>]`: Conditions based on which the action set execution will be evaluated.
      - `[IgnoreCase <Boolean?>]`: Setting this paramter to truth value with force the pattern to do a case in-sensitive comparison.
      - `[Negate <Boolean?>]`: Setting this value as truth will force to check the negation of the condition given by the user.
      - `[Pattern <String>]`: The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition
      - `[Variable <String>]`: The condition parameter of the RewriteRuleCondition.
    - `[Name <String>]`: Name of the rewrite rule that is unique within an Application Gateway.
    - `[RuleSequence <Int32?>]`: Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.

#### SSLCERTIFICATE <IApplicationGatewaySslCertificate[]>: SSL certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Data <String>]`: Base-64 encoded pfx certificate. Only applicable in PUT Request.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[KeyVaultSecretId <String>]`: Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
  - `[Name <String>]`: Name of the SSL certificate that is unique within an Application Gateway.
  - `[Password <String>]`: Password for the pfx file specified in data. Only applicable in PUT request.
  - `[ProvisioningState <String>]`: Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicCertData <String>]`: Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
  - `[Type <String>]`: Type of the resource.

#### TRUSTEDROOTCERTIFICATE <IApplicationGatewayTrustedRootCertificate[]>: Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Data <String>]`: Certificate public data.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[KeyVaultSecretId <String>]`: Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
  - `[Name <String>]`: Name of the trusted root certificate that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### URLPATHMAP <IApplicationGatewayUrlPathMap[]>: URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[DefaultBackendAddressPoolId <String>]`: Resource ID.
  - `[DefaultBackendHttpSettingId <String>]`: Resource ID.
  - `[DefaultRedirectConfigurationId <String>]`: Resource ID.
  - `[DefaultRewriteRuleSetId <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the URL path map that is unique within an Application Gateway.
  - `[PathRule <IApplicationGatewayPathRule[]>]`: Path rule of URL path map resource.
    - `[BackendAddressPoolId <String>]`: Resource ID.
    - `[BackendHttpSettingId <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the path rule that is unique within an Application Gateway.
    - `[Path <String[]>]`: Path rules of URL path map.
    - `[ProvisioningState <String>]`: Path rule of URL path map resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RedirectConfigurationId <String>]`: Resource ID.
    - `[RewriteRuleSetId <String>]`: Resource ID.
    - `[Type <String>]`: Type of the resource.
  - `[ProvisioningState <String>]`: Provisioning state of the backend http settings resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### WEBAPPLICATIONFIREWALLCONFIGURATIONDISABLEDRULEGROUP <IApplicationGatewayFirewallDisabledRuleGroup[]>: The disabled rule groups.
  - `RuleGroupName <String>`: The name of the rule group that will be disabled.
  - `[Rule <Int32[]>]`: The list of rules that will be disabled. If null, all rules of the rule group will be disabled.

#### WEBAPPLICATIONFIREWALLCONFIGURATIONEXCLUSION <IApplicationGatewayFirewallExclusion[]>: The exclusion list.
  - `MatchVariable <String>`: The variable to be excluded.
  - `Selector <String>`: When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
  - `SelectorMatchOperator <String>`: When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion applies to.

## RELATED LINKS

