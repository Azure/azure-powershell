---
external help file:
Module Name: Az.SignalR
online version: https://docs.microsoft.com/powershell/module/az.signalr/get-azwebpubsub
schema: 2.0.0
---

# Get-AzWebPubSub

## SYNOPSIS
Get the resource and its properties.

## SYNTAX

### List (Default)
```
Get-AzWebPubSub [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWebPubSub -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWebPubSub -InputObject <IWebPubSubIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzWebPubSub -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the resource and its properties.

## EXAMPLES

### Example 1: List all Web PubSub resources in a subscription
```powershell
Get-AzWebPubSub -SubscriptionId ef72249e-9785-4799-a76b-7cdd80e1b1d0
```

```output
Name                Location      SkuName
----                --------      -------
demo1               eastus        Standard_S1
demo2               eastus        Free_F1
```



### Example 2: List all Web PubSub resources in a resource group
```powershell
Get-AzWebPubSub -ResourceGroupName psdemo
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```



### Example 3: Get a specific Web PubSub resource
```powershell
Get-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```



### Example 4: Get a specific Web PubSub resource via identity object
```powershell
$identity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

$identity | Get-AzWebPubSub
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
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
The name of the resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ResourceName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IWebPubSubResource

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

