---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/get-azeventhubcluster
schema: 2.0.0
---

# Get-AzEventHubCluster

## SYNOPSIS
Lists the available Event Hubs Clusters within an ARM resource group

## SYNTAX

### List (Default)
```
Get-AzEventHubCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzEventHubCluster -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists the available Event Hubs Clusters within an ARM resource group

## EXAMPLES

### Example 1: Get an EventHub cluster
```powershell
Get-AzEventHubCluster -ResourceGroupName myResourceGroup -Name DefaultCluster-11
```

```output
Capacity                     : 1
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/DefaultCluster-11
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : DefaultCluster-11
ResourceGroupName            : myResourceGroup
SkuName                      : Dedicated
Status                       :
SupportsScaling              : False
Tag                          : {}
```

Gets details of EventHubs dedicated cluster by the name `DefaultCluster-11`.

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
Name of the resource group within the azure subscription.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.ICluster

## NOTES

## RELATED LINKS

