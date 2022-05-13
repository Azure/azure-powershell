---
external help file:
Module Name: Az.WebPubSub
online version: https://docs.microsoft.com/en-us/powershell/module/az.webpubsub/new-azwebpubsubwebpubsub
schema: 2.0.0
---

# New-AzWebPubSubWebPubSub

## SYNOPSIS
Create or update a resource.

## SYNTAX

```
New-AzWebPubSubWebPubSub -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-DisableAadAuth] [-DisableLocalAuth] [-IdentityType <ManagedIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-LiveTraceConfigurationCategory <ILiveTraceCategory[]>]
 [-LiveTraceConfigurationEnabled <String>] [-Location <String>] [-NetworkAcLDefaultAction <AclAction>]
 [-NetworkAcLPrivateEndpoint <IPrivateEndpointAcl[]>] [-PublicNetworkAccess <String>]
 [-PublicNetworkAllow <WebPubSubRequestType[]>] [-PublicNetworkDeny <WebPubSubRequestType[]>]
 [-ResourceLogConfigurationCategory <IResourceLogCategory[]>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <WebPubSubSkuTier>] [-Tag <Hashtable>] [-TlClientCertEnabled] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a resource.

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

### -IdentityType
Represents the identity type: systemAssigned, userAssigned, None

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Support.ManagedIdentityType
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

### -LiveTraceConfigurationCategory
Gets or sets the list of category configurations.
To construct, see NOTES section for LIVETRACECONFIGURATIONCATEGORY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.ILiveTraceCategory[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Support.AclAction
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IPrivateEndpointAcl[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Support.WebPubSubRequestType[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Support.WebPubSubRequestType[]
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IResourceLogCategory[]
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Support.WebPubSubSkuTier
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IWebPubSubResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


LIVETRACECONFIGURATIONCATEGORY <ILiveTraceCategory[]>: Gets or sets the list of category configurations.
  - `[Enabled <String>]`: Indicates whether or the live trace category is enabled.         Available values: true, false.         Case insensitive.
  - `[Name <String>]`: Gets or sets the live trace category's name.         Available values: ConnectivityLogs, MessagingLogs.         Case insensitive.

NETWORKACLPRIVATEENDPOINT <IPrivateEndpointAcl[]>: ACLs for requests from private endpoints
  - `Name <String>`: Name of the private endpoint connection
  - `[Allow <WebPubSubRequestType[]>]`: Allowed request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.
  - `[Deny <WebPubSubRequestType[]>]`: Denied request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI.

RESOURCELOGCONFIGURATIONCATEGORY <IResourceLogCategory[]>: Gets or sets the list of category configurations.
  - `[Enabled <String>]`: Indicates whether or the resource log category is enabled.         Available values: true, false.         Case insensitive.
  - `[Name <String>]`: Gets or sets the resource log category's name.         Available values: ConnectivityLogs, MessagingLogs.         Case insensitive.

## RELATED LINKS

