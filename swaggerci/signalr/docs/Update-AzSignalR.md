---
external help file:
Module Name: Az.SignalR
online version: https://docs.microsoft.com/en-us/powershell/module/az.signalr/update-azsignalr
schema: 2.0.0
---

# Update-AzSignalR

## SYNOPSIS
Operation to update an exiting resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSignalR -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-CorAllowedOrigin <String[]>] [-DisableAadAuth] [-DisableLocalAuth] [-Feature <ISignalRFeature[]>]
 [-IdentityType <ManagedIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-Kind <ServiceKind>]
 [-LiveTraceConfigurationCategory <ILiveTraceCategory[]>] [-LiveTraceConfigurationEnabled <String>]
 [-Location <String>] [-NetworkAcLDefaultAction <AclAction>]
 [-NetworkAcLPrivateEndpoint <IPrivateEndpointAcl[]>] [-PublicNetworkAccess <String>]
 [-PublicNetworkAllow <SignalRRequestType[]>] [-PublicNetworkDeny <SignalRRequestType[]>]
 [-ResourceLogConfigurationCategory <IResourceLogCategory[]>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <SignalRSkuTier>] [-Tag <Hashtable>] [-TlClientCertEnabled]
 [-UpstreamTemplate <IUpstreamTemplate[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSignalR -InputObject <ISignalRIdentity> [-CorAllowedOrigin <String[]>] [-DisableAadAuth]
 [-DisableLocalAuth] [-Feature <ISignalRFeature[]>] [-IdentityType <ManagedIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Kind <ServiceKind>]
 [-LiveTraceConfigurationCategory <ILiveTraceCategory[]>] [-LiveTraceConfigurationEnabled <String>]
 [-Location <String>] [-NetworkAcLDefaultAction <AclAction>]
 [-NetworkAcLPrivateEndpoint <IPrivateEndpointAcl[]>] [-PublicNetworkAccess <String>]
 [-PublicNetworkAllow <SignalRRequestType[]>] [-PublicNetworkDeny <SignalRRequestType[]>]
 [-ResourceLogConfigurationCategory <IResourceLogCategory[]>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <SignalRSkuTier>] [-Tag <Hashtable>] [-TlClientCertEnabled]
 [-UpstreamTemplate <IUpstreamTemplate[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to update an exiting resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorAllowedOrigin
Gets or sets the list of origins that should be allowed to make cross-origin calls (for example: http://example.com:12345).
Use "*" to allow all.
If omitted, allow all by default.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -DisableAadAuth
DisableLocalAuthEnable or disable aad authWhen set as true, connection with AuthType=aad won't work.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableLocalAuth
DisableLocalAuthEnable or disable local auth with AccessKeyWhen set as true, connection with AccessKey=xxx won't work.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Feature
List of the featureFlags.FeatureFlags that are not included in the parameters for the update operation will not be modified.And the response will only include featureFlags that are explicitly set.
When a featureFlag is not explicitly set, its globally default value will be usedBut keep in mind, the default value doesn't mean "false".
It varies in terms of different FeatureFlags.
To construct, see NOTES section for FEATURE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.Api20220201.ISignalRFeature[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Represents the identity type: systemAssigned, userAssigned, None

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Support.ManagedIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
Get or set the user assigned identities

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.ISignalRIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
The kind of the service, it can be SignalR or RawWebSockets

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Support.ServiceKind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiveTraceConfigurationCategory
Gets or sets the list of category configurations.
To construct, see NOTES section for LIVETRACECONFIGURATIONCATEGORY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.Api20220201.ILiveTraceCategory[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LiveTraceConfigurationEnabled
Indicates whether or not enable live trace.When it's set to true, live trace client can connect to the service.Otherwise, live trace client can't connect to the service, so that you are unable to receive any log, no matter what you configure in "categories".Available values: true, false.Case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The GEO location of the resource.
e.g.
West US | East US | North Central US | South Central US.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAcLDefaultAction
Azure Networking ACL Action.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Support.AclAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAcLPrivateEndpoint
ACLs for requests from private endpoints
To construct, see NOTES section for NETWORKACLPRIVATEENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.Api20220201.IPrivateEndpointAcl[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -PublicNetworkAccess
Enable or disable public network access.
Default to "Enabled".When it's Enabled, network ACLs still apply.When it's Disabled, public network access is always disabled no matter what you set in network ACLs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAllow
Allowed request types.
The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Support.SignalRRequestType[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkDeny
Denied request types.
The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Support.SignalRRequestType[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceLogConfigurationCategory
Gets or sets the list of category configurations.
To construct, see NOTES section for RESOURCELOGCONFIGURATIONCATEGORY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.Api20220201.IResourceLogCategory[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Optional, integer.
The unit count of the resource.
1 by default.If present, following values are allowed: Free: 1 Standard: 1,2,5,10,20,50,100

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the SKU.
Required.Allowed values: Standard_S1, Free_F1

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Optional tier of this particular SKU.
'Standard' or 'Free'.
`Basic` is deprecated, use `Standard` instead.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Support.SignalRSkuTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags of the service which is a list of key value pairs that describe the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TlClientCertEnabled
Request client certificate during TLS handshake if enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpstreamTemplate
Gets or sets the list of Upstream URL templates.
Order matters, and the first matching template takes effects.
To construct, see NOTES section for UPSTREAMTEMPLATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.Api20220201.IUpstreamTemplate[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.ISignalRIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SignalR.Models.Api20220201.ISignalRResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FEATURE <ISignalRFeature[]>: List of the featureFlags.FeatureFlags that are not included in the parameters for the update operation will not be modified.And the response will only include featureFlags that are explicitly set. When a featureFlag is not explicitly set, its globally default value will be usedBut keep in mind, the default value doesn't mean "false". It varies in terms of different FeatureFlags.
  - `Flag <FeatureFlags>`: FeatureFlags is the supported features of Azure SignalR service.         - ServiceMode: Flag for backend server for SignalR service. Values allowed: "Default": have your own backend server; "Serverless": your application doesn't have a backend server; "Classic": for backward compatibility. Support both Default and Serverless mode but not recommended; "PredefinedOnly": for future use.         - EnableConnectivityLogs: "true"/"false", to enable/disable the connectivity log category respectively.         - EnableMessagingLogs: "true"/"false", to enable/disable the connectivity log category respectively.         - EnableLiveTrace: Live Trace allows you to know what's happening inside Azure SignalR service, it will give you live traces in real time, it will be helpful when you developing your own Azure SignalR based web application or self-troubleshooting some issues. Please note that live traces are counted as outbound messages that will be charged. Values allowed: "true"/"false", to enable/disable live trace feature.
  - `Value <String>`: Value of the feature flag. See Azure SignalR service document https://docs.microsoft.com/azure/azure-signalr/ for allowed values.
  - `[Property <ISignalRFeatureProperties>]`: Optional properties related to this feature.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

INPUTOBJECT <ISignalRIdentity>: Identity Parameter
  - `[CertificateName <String>]`: Custom certificate name
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[Name <String>]`: Custom domain name.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ResourceName <String>]`: The name of the resource.
  - `[SharedPrivateLinkResourceName <String>]`: The name of the shared private link resource
  - `[SubscriptionId <String>]`: Gets subscription Id which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

LIVETRACECONFIGURATIONCATEGORY <ILiveTraceCategory[]>: Gets or sets the list of category configurations.
  - `[Enabled <String>]`: Indicates whether or the live trace category is enabled.         Available values: true, false.         Case insensitive.
  - `[Name <String>]`: Gets or sets the live trace category's name.         Available values: ConnectivityLogs, MessagingLogs.         Case insensitive.

NETWORKACLPRIVATEENDPOINT <IPrivateEndpointAcl[]>: ACLs for requests from private endpoints
  - `Name <String>`: Name of the private endpoint connection
  - `[Allow <SignalRRequestType[]>]`: Allowed request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.
  - `[Deny <SignalRRequestType[]>]`: Denied request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.

RESOURCELOGCONFIGURATIONCATEGORY <IResourceLogCategory[]>: Gets or sets the list of category configurations.
  - `[Enabled <String>]`: Indicates whether or the resource log category is enabled.         Available values: true, false.         Case insensitive.
  - `[Name <String>]`: Gets or sets the resource log category's name.         Available values: ConnectivityLogs, MessagingLogs.         Case insensitive.

UPSTREAMTEMPLATE <IUpstreamTemplate[]>: Gets or sets the list of Upstream URL templates. Order matters, and the first matching template takes effects.
  - `UrlTemplate <String>`: Gets or sets the Upstream URL template. You can use 3 predefined parameters {hub}, {category} {event} inside the template, the value of the Upstream URL is dynamically calculated when the client request comes in.         For example, if the urlTemplate is `http://example.com/{hub}/api/{event}`, with a client request from hub `chat` connects, it will first POST to this URL: `http://example.com/chat/api/connect`.
  - `[AuthType <UpstreamAuthType?>]`: Upstream auth type enum.
  - `[CategoryPattern <String>]`: Gets or sets the matching pattern for category names. If not set, it matches any category.         There are 3 kind of patterns supported:             1. "*", it to matches any category name.             2. Combine multiple categories with ",", for example "connections,messages", it matches category "connections" and "messages".             3. The single category name, for example, "connections", it matches the category "connections".
  - `[EventPattern <String>]`: Gets or sets the matching pattern for event names. If not set, it matches any event.         There are 3 kind of patterns supported:             1. "*", it to matches any event name.             2. Combine multiple events with ",", for example "connect,disconnect", it matches event "connect" and "disconnect".             3. The single event name, for example, "connect", it matches "connect".
  - `[HubPattern <String>]`: Gets or sets the matching pattern for hub names. If not set, it matches any hub.         There are 3 kind of patterns supported:             1. "*", it to matches any hub name.             2. Combine multiple hubs with ",", for example "hub1,hub2", it matches "hub1" and "hub2".             3. The single hub name, for example, "hub1", it matches "hub1".
  - `[ManagedIdentityResource <String>]`: The Resource indicating the App ID URI of the target resource.         It also appears in the aud (audience) claim of the issued token.

## RELATED LINKS

