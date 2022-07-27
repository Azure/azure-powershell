---
external help file:
Module Name: Az.SignalR
online version: https://docs.microsoft.com/powershell/module/az.signalr/get-azwebpubsubhub
schema: 2.0.0
---

# Get-AzWebPubSubHub

## SYNOPSIS
Get a hub setting.

## SYNTAX

### List (Default)
```
Get-AzWebPubSubHub -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWebPubSubHub -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWebPubSubHub -InputObject <IWebPubSubIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a hub setting.

## EXAMPLES

### Example 1: List hub settings of a Web PubSub resource.
```powershell
Get-AzWebPubSubHub -ResourceGroupName psdemo -ResourceName psdemo-wps
```

```output
Name     AnonymousConnectPolicy
----     ----------------------
testHub  deny
testHub2 deny
```



### Example 2: Get a Web PubSub hub setting.
```powershell
Get-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```



### Example 3: Get a Web PubSub hub setting via identity.
```powershell
$hubIdentity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id
HubName = 'testHub' }
$hubIdentity | Get-AzWebPubSubHub
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```



## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The hub name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IWebPubSubHub

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IWebPubSubIdentity>`: Identity Parameter
  - `[HubName <String>]`: The hub name.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ResourceName <String>]`: The name of the resource.
  - `[SharedPrivateLinkResourceName <String>]`: The name of the shared private link resource
  - `[SubscriptionId <String>]`: Gets subscription Id which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

