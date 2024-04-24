---
external help file:
Module Name: Az.EdgeOrder
online version: https://learn.microsoft.com/powershell/module/az.edgeorder/get-azedgeorderitem
schema: 2.0.0
---

# Get-AzEdgeOrderItem

## SYNOPSIS
Gets an order item.

## SYNTAX

### List (Default)
```
Get-AzEdgeOrderItem [-SubscriptionId <String[]>] [-Expand <String>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzEdgeOrderItem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzEdgeOrderItem -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an order item.

## EXAMPLES

### Example 1: Get orderItem details
```powershell
$orderItem = Get-AzEdgeOrderItem -Name examplePowershell -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName"   
$ordderItem | Format-List
```

```output
ForwardAddressContactDetail    : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
ForwardAddressShippingAddress  : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
ForwardAddressValidationStatus : Valid
Id                             : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/orderItems/OrderItem-211115074927900249117427
Location                       : eastus
Name                           : OrderItem-211115074927900249117427
OrderId                        : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/Order-211115074927650235470998
OrderItemDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.OrderItemDetails
ReturnAddressContactDetail     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
ReturnAddressShippingAddress   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
ReturnAddressValidationStatus  : Valid
StartTime                      : 11/15/2021 7:49:29 AM
SystemData                     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.TrackedResourceTags
Type                           : Microsoft.EdgeOrder/orderItems
```

Get orderItem details

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

### -Expand
$expand is supported on device details, forward shipping details and reverse shipping details parameters.
Each of these can be provided as a comma separated list.
Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively.

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

### -Filter
$filter is supported to filter based on order id.
Filter supports only equals operation.

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the order item

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OrderItemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.IOrderItemResource

## NOTES

## RELATED LINKS

