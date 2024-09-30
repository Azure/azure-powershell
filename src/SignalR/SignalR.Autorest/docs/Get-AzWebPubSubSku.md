---
external help file:
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/get-azwebpubsubsku
schema: 2.0.0
---

# Get-AzWebPubSubSku

## SYNOPSIS
List all available skus of the resource.

## SYNTAX

```
Get-AzWebPubSubSku -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List all available skus of the resource.

## EXAMPLES

### Example 1: List all available SKUs of a Web PubSub resource
```powershell
Get-AzWebPubSubSku -ResourceGroupName psdemo -ResourceName psdemo-wps | Format-List
```

```output
CapacityAllowedValue : {0, 1}
CapacityDefault      : 1
CapacityMaximum      : 1
CapacityMinimum      : 0
CapacityScaleType    : Manual
Family               :
Name                 : Free_F1
ResourceType         : Microsoft.SignalRService/WebPubSub
Size                 :
SkuCapacity          :
Tier                 : Free

CapacityAllowedValue : {0, 1, 2, 5…}
CapacityDefault      : 1
CapacityMaximum      : 100
CapacityMinimum      : 0
CapacityScaleType    : Automatic
Family               :
Name                 : Standard_S1
ResourceType         : Microsoft.SignalRService/WebPubSub
Size                 :
SkuCapacity          :
Tier                 : Standard
```

The example lists the SKUs of a Web PubSub resource and then pipes the result to `Format-List` to see all the property values of the result.
We can see from the result that there are two SKUs, one's Tier is "Free", and the other is "Standard".

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -SubscriptionId
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.ISkuList

## NOTES

## RELATED LINKS

