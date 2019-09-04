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

### CreateExpanded (Default)
```
New-AzApplicationGateway -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthenticationCertificate <IApplicationGatewayAuthenticationCertificate[]>]
 [-AutoscaleMaximumCapacity <Int32>] [-AutoscaleMinimumCapacity <Int32>]
 [-BackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-BackendHttpSetting <IApplicationGatewayBackendHttpSettings[]>] [-CheckWafRequestBody]
 [-CustomError <IApplicationGatewayCustomError[]>] [-EnableFips] [-EnableHttp2] [-EnableWaf] [-Etag <String>]
 [-FirewallPolicyId <String>] [-FrontendIPConfiguration <IApplicationGatewayFrontendIPConfiguration[]>]
 [-FrontendPort <IApplicationGatewayFrontendPort[]>]
 [-GatewayIPConfiguration <IApplicationGatewayIPConfiguration[]>]
 [-HttpListener <IApplicationGatewayHttpListener[]>] [-Id <String>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-Probe <IApplicationGatewayProbe[]>] [-ProvisioningState <String>]
 [-RedirectConfiguration <IApplicationGatewayRedirectConfiguration[]>]
 [-RequestRoutingRule <IApplicationGatewayRequestRoutingRule[]>] [-ResourceGuid <String>]
 [-RewriteRuleSet <IApplicationGatewayRewriteRuleSet[]>] [-SkuCapacity <Int32>]
 [-SkuName <ApplicationGatewaySkuName>] [-SkuTier <ApplicationGatewayTier>]
 [-SslCertificate <IApplicationGatewaySslCertificate[]>]
 [-SslCipherSuite <ApplicationGatewaySslCipherSuite[]>]
 [-SslDisabledProtocol <ApplicationGatewaySslProtocol[]>]
 [-SslMinimumProtocolVersion <ApplicationGatewaySslProtocol>]
 [-SslPolicyName <ApplicationGatewaySslPolicyName>] [-SslPolicyType <ApplicationGatewaySslPolicyType>]
 [-Tag <Hashtable>] [-TrustedRootCertificate <IApplicationGatewayTrustedRootCertificate[]>]
 [-UrlPathMap <IApplicationGatewayUrlPathMap[]>] [-UserAssignedIdentity <Hashtable>]
 [-WafDisabledRuleGroup <IApplicationGatewayFirewallDisabledRuleGroup[]>]
 [-WafExclusion <IApplicationGatewayFirewallExclusion[]>] [-WafFileUploadLimitInMb <Int32>]
 [-WafFirewallMode <ApplicationGatewayFirewallMode>] [-WafMaximumRequestBodySize <Int32>]
 [-WafMaximumRequestBodySizeInKb <Int32>] [-WafRuleSetType <String>] [-WafRuleSetVersion <String>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzApplicationGateway -Name <String> -ResourceGroupName <String> -ApplicationGateway <IApplicationGateway>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzApplicationGateway -InputObject <INetworkIdentity> -ApplicationGateway <IApplicationGateway>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzApplicationGateway -InputObject <INetworkIdentity>
 [-AuthenticationCertificate <IApplicationGatewayAuthenticationCertificate[]>]
 [-AutoscaleMaximumCapacity <Int32>] [-AutoscaleMinimumCapacity <Int32>]
 [-BackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-BackendHttpSetting <IApplicationGatewayBackendHttpSettings[]>] [-CheckWafRequestBody]
 [-CustomError <IApplicationGatewayCustomError[]>] [-EnableFips] [-EnableHttp2] [-EnableWaf] [-Etag <String>]
 [-FirewallPolicyId <String>] [-FrontendIPConfiguration <IApplicationGatewayFrontendIPConfiguration[]>]
 [-FrontendPort <IApplicationGatewayFrontendPort[]>]
 [-GatewayIPConfiguration <IApplicationGatewayIPConfiguration[]>]
 [-HttpListener <IApplicationGatewayHttpListener[]>] [-Id <String>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-Probe <IApplicationGatewayProbe[]>] [-ProvisioningState <String>]
 [-RedirectConfiguration <IApplicationGatewayRedirectConfiguration[]>]
 [-RequestRoutingRule <IApplicationGatewayRequestRoutingRule[]>] [-ResourceGuid <String>]
 [-RewriteRuleSet <IApplicationGatewayRewriteRuleSet[]>] [-SkuCapacity <Int32>]
 [-SkuName <ApplicationGatewaySkuName>] [-SkuTier <ApplicationGatewayTier>]
 [-SslCertificate <IApplicationGatewaySslCertificate[]>]
 [-SslCipherSuite <ApplicationGatewaySslCipherSuite[]>]
 [-SslDisabledProtocol <ApplicationGatewaySslProtocol[]>]
 [-SslMinimumProtocolVersion <ApplicationGatewaySslProtocol>]
 [-SslPolicyName <ApplicationGatewaySslPolicyName>] [-SslPolicyType <ApplicationGatewaySslPolicyType>]
 [-Tag <Hashtable>] [-TrustedRootCertificate <IApplicationGatewayTrustedRootCertificate[]>]
 [-UrlPathMap <IApplicationGatewayUrlPathMap[]>] [-UserAssignedIdentity <Hashtable>]
 [-WafDisabledRuleGroup <IApplicationGatewayFirewallDisabledRuleGroup[]>]
 [-WafExclusion <IApplicationGatewayFirewallExclusion[]>] [-WafFileUploadLimitInMb <Int32>]
 [-WafFirewallMode <ApplicationGatewayFirewallMode>] [-WafMaximumRequestBodySize <Int32>]
 [-WafMaximumRequestBodySizeInKb <Int32>] [-WafRuleSetType <String>] [-WafRuleSetVersion <String>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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

### -ApplicationGateway
Application gateway resource
To construct, see NOTES section for APPLICATIONGATEWAY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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
Aliases: AuthenticationCertificates

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoscaleMaximumCapacity
Upper bound on number of Application Gateway capacity

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoscaleMinimumCapacity
Lower bound on number of Application Gateway capacity

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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
Aliases: BackendAddressPools

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendHttpSetting
Backend http settings of the application gateway resource.
For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
To construct, see NOTES section for BACKENDHTTPSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHttpSettings[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: BackendHttpSettingsCollection

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CheckWafRequestBody
Whether allow WAF to check request Body.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomError
Custom error configurations of the application gateway resource.
To construct, see NOTES section for CUSTOMERROR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: CustomErrorConfiguration

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

### -EnableFips
Whether FIPS is enabled on the application gateway resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableWaf
Whether the web application firewall is enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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
Aliases: FrontendIPConfigurations

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
Aliases: FrontendPorts

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
Aliases: GatewayIPConfigurations

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
Aliases: HttpListeners

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Probe
Probes of the application gateway resource.
To construct, see NOTES section for PROBE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbe[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: Probes

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
Aliases: RedirectConfigurations

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
Aliases: RequestRoutingRules

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
Default value: None
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
Aliases: SslCertificates

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslCipherSuite
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

### -SslDisabledProtocol
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

### -SslMinimumProtocolVersion
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

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
Aliases: UrlPathMaps

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UserAssignedIdentity
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

### -WafDisabledRuleGroup
The disabled rule groups.
To construct, see NOTES section for WAFDISABLEDRULEGROUP properties and create a hash table.

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

### -WafExclusion
The exclusion list.
To construct, see NOTES section for WAFEXCLUSION properties and create a hash table.

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

### -WafFileUploadLimitInMb
Maximum file upload size in Mb for WAF.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WafFirewallMode
Web application firewall mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WafMaximumRequestBodySize
Maximum request body size for WAF.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WafMaximumRequestBodySizeInKb
Maximum request body size in Kb for WAF.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WafRuleSetType
The type of the web application firewall rule set.
Possible values are: 'OWASP'.

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

### -WafRuleSetVersion
The version of the rule set type.

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### APPLICATIONGATEWAY <IApplicationGateway>: Application gateway resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

#### AUTHENTICATIONCERTIFICATE <IApplicationGatewayAuthenticationCertificate[]>: Authentication certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[Data <String>]`: Certificate public data.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the authentication certificate that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the authentication certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### BACKENDADDRESSPOOL <IApplicationGatewayBackendAddressPool[]>: Backend address pool of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
    - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
    - `[IPAddress <String>]`: IP address
  - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
    - `[Id <String>]`: Resource ID.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[OutboundRuleId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Id <String>]`: Resource ID.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[Id <String>]`: Resource ID.
    - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### BACKENDHTTPSETTING <IApplicationGatewayBackendHttpSettings[]>: Backend http settings of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `ConnectionDrainingDrainTimeoutInSec <Int32>`: The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
  - `ConnectionDrainingEnabled <Boolean>`: Whether connection draining is enabled or not.
  - `[Id <String>]`: Resource ID.
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

#### CUSTOMERROR <IApplicationGatewayCustomError[]>: Custom error configurations of the application gateway resource.
  - `[CustomErrorPageUrl <String>]`: Error page URL of the application gateway customer error.
  - `[StatusCode <ApplicationGatewayCustomErrorStatusCode?>]`: Status code of the application gateway customer error.

#### FRONTENDIPCONFIGURATION <IApplicationGatewayFrontendIPConfiguration[]>: Frontend IP addresses of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the frontend IP configuration that is unique within an Application Gateway.
  - `[PrivateIPAddress <String>]`: PrivateIPAddress of the network interface IP Configuration.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[ProvisioningState <String>]`: Provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddressId <String>]`: Resource ID.
  - `[SubnetId <String>]`: Resource ID.
  - `[Type <String>]`: Type of the resource.

#### FRONTENDPORT <IApplicationGatewayFrontendPort[]>: Frontend ports of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the frontend port that is unique within an Application Gateway
  - `[Port <Int32?>]`: Frontend port
  - `[ProvisioningState <String>]`: Provisioning state of the frontend port resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### GATEWAYIPCONFIGURATION <IApplicationGatewayIPConfiguration[]>: Subnets of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the IP configuration that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the application gateway subnet resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[SubnetId <String>]`: Resource ID.
  - `[Type <String>]`: Type of the resource.

#### HTTPLISTENER <IApplicationGatewayHttpListener[]>: Http listeners of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
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

#### INPUTOBJECT <INetworkIdentity>: Identity Parameter
  - `[ApplicationGatewayName <String>]`: The name of the application gateway.
  - `[ApplicationSecurityGroupName <String>]`: The name of the application security group.
  - `[AuthorizationName <String>]`: The name of the authorization.
  - `[AzureFirewallName <String>]`: The name of the Azure Firewall.
  - `[BackendAddressPoolName <String>]`: The name of the backend address pool.
  - `[CircuitName <String>]`: The name of the express route circuit.
  - `[ConnectionMonitorName <String>]`: The name of the connection monitor.
  - `[ConnectionName <String>]`: The name of the vpn connection.
  - `[CrossConnectionName <String>]`: The name of the ExpressRouteCrossConnection (service key of the circuit).
  - `[DdosCustomPolicyName <String>]`: The name of the DDoS custom policy.
  - `[DdosProtectionPlanName <String>]`: The name of the DDoS protection plan.
  - `[DefaultSecurityRuleName <String>]`: The name of the default security rule.
  - `[DevicePath <String>]`: The path of the device.
  - `[ExpressRouteGatewayName <String>]`: The name of the ExpressRoute gateway.
  - `[ExpressRoutePortName <String>]`: The name of the ExpressRoutePort resource.
  - `[FrontendIPConfigurationName <String>]`: The name of the frontend IP configuration.
  - `[GatewayName <String>]`: The name of the gateway.
  - `[IPConfigurationName <String>]`: The name of the ip configuration name.
  - `[Id <String>]`: Resource identity path
  - `[InboundNatRuleName <String>]`: The name of the inbound nat rule.
  - `[InterfaceEndpointName <String>]`: The name of the interface endpoint.
  - `[LinkName <String>]`: The name of the ExpressRouteLink resource.
  - `[LoadBalancerName <String>]`: The name of the load balancer.
  - `[LoadBalancingRuleName <String>]`: The name of the load balancing rule.
  - `[LocalNetworkGatewayName <String>]`: The name of the local network gateway.
  - `[Location <String>]`: The location of the subnet.
  - `[LocationName <String>]`: Name of the requested ExpressRoutePort peering location.
  - `[NatGatewayName <String>]`: The name of the nat gateway.
  - `[NetworkInterfaceName <String>]`: The name of the network interface.
  - `[NetworkProfileName <String>]`: The name of the NetworkProfile.
  - `[NetworkWatcherName <String>]`: The name of the network watcher.
  - `[NsgName <String>]`: The name of the network security group.
  - `[OutboundRuleName <String>]`: The name of the outbound rule.
  - `[P2SVpnServerConfigurationName <String>]`: The name of the P2SVpnServerConfiguration.
  - `[PacketCaptureName <String>]`: The name of the packet capture session.
  - `[PeeringName <String>]`: The name of the peering.
  - `[PolicyName <String>]`: The name of the policy
  - `[PredefinedPolicyName <String>]`: Name of Ssl predefined policy.
  - `[ProbeName <String>]`: The name of the probe.
  - `[PublicIPAddressName <String>]`: The name of the subnet.
  - `[PublicIPPrefixName <String>]`: The name of the PublicIpPrefix.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RouteFilterName <String>]`: The name of the route filter.
  - `[RouteName <String>]`: The name of the route.
  - `[RouteTableName <String>]`: The name of the route table.
  - `[RuleName <String>]`: The name of the rule.
  - `[SecurityRuleName <String>]`: The name of the security rule.
  - `[ServiceEndpointPolicyDefinitionName <String>]`: The name of the service endpoint policy definition.
  - `[ServiceEndpointPolicyName <String>]`: The name of the service endpoint policy.
  - `[SubnetName <String>]`: The name of the subnet.
  - `[SubscriptionId <String>]`: The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[TapConfigurationName <String>]`: The name of the tap configuration.
  - `[TapName <String>]`: The name of the virtual network tap.
  - `[VirtualHubName <String>]`: The name of the VirtualHub.
  - `[VirtualMachineScaleSetName <String>]`: The name of the virtual machine scale set.
  - `[VirtualWanName <String>]`: The name of the VirtualWAN being retrieved.
  - `[VirtualWanName1 <String>]`: The name of the VirtualWAN for which configuration of all vpn-sites is needed.
  - `[VirtualWanName2 <String>]`: The name of the VirtualWan.
  - `[VirtualmachineIndex <String>]`: The virtual machine index.
  - `[VnetGatewayConnectionName <String>]`: The name of the virtual network gateway connection for which the configuration script is generated.
  - `[VnetGatewayName <String>]`: The name of the virtual network gateway.
  - `[VnetName <String>]`: The name of the virtual network.
  - `[VnetPeeringName <String>]`: The name of the virtual network peering.
  - `[VpnSiteName <String>]`: The name of the VpnSite being retrieved.

#### PROBE <IApplicationGatewayProbe[]>: Probes of the application gateway resource.
  - `[Id <String>]`: Resource ID.
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
  - `[Id <String>]`: Resource ID.
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
  - `[Id <String>]`: Resource ID.
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
  - `[Id <String>]`: Resource ID.
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
  - `[Id <String>]`: Resource ID.
  - `[Data <String>]`: Base-64 encoded pfx certificate. Only applicable in PUT Request.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[KeyVaultSecretId <String>]`: Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
  - `[Name <String>]`: Name of the SSL certificate that is unique within an Application Gateway.
  - `[Password <String>]`: Password for the pfx file specified in data. Only applicable in PUT request.
  - `[ProvisioningState <String>]`: Provisioning state of the SSL certificate resource Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicCertData <String>]`: Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
  - `[Type <String>]`: Type of the resource.

#### TRUSTEDROOTCERTIFICATE <IApplicationGatewayTrustedRootCertificate[]>: Trusted Root certificates of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[Data <String>]`: Certificate public data.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[KeyVaultSecretId <String>]`: Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
  - `[Name <String>]`: Name of the trusted root certificate that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the trusted root certificate resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### URLPATHMAP <IApplicationGatewayUrlPathMap[]>: URL path map of the application gateway resource. For default limits, see [Application Gateway limits](https://docs.microsoft.com/azure/azure-subscription-service-limits#application-gateway-limits).
  - `[Id <String>]`: Resource ID.
  - `[DefaultBackendAddressPoolId <String>]`: Resource ID.
  - `[DefaultBackendHttpSettingId <String>]`: Resource ID.
  - `[DefaultRedirectConfigurationId <String>]`: Resource ID.
  - `[DefaultRewriteRuleSetId <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the URL path map that is unique within an Application Gateway.
  - `[PathRule <IApplicationGatewayPathRule[]>]`: Path rule of URL path map resource.
    - `[Id <String>]`: Resource ID.
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

#### WAFDISABLEDRULEGROUP <IApplicationGatewayFirewallDisabledRuleGroup[]>: The disabled rule groups.
  - `RuleGroupName <String>`: The name of the rule group that will be disabled.
  - `[Rule <Int32[]>]`: The list of rules that will be disabled. If null, all rules of the rule group will be disabled.

#### WAFEXCLUSION <IApplicationGatewayFirewallExclusion[]>: The exclusion list.
  - `MatchVariable <String>`: The variable to be excluded.
  - `Selector <String>`: When matchVariable is a collection, operator used to specify which elements in the collection this exclusion applies to.
  - `SelectorMatchOperator <String>`: When matchVariable is a collection, operate on the selector to specify which elements in the collection this exclusion applies to.

## RELATED LINKS

