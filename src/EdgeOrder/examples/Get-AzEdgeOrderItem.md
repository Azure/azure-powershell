### Example 1: Get orderItem details
```powershell
$orderItem = Get-AzEdgeOrderItem -Name examplePowershell -SubscriptionId "SubscriptionId" -ResourceGroupName "resourceGroupName"   
$ordderItem | Format-List
```

```output
ForwardAddressContactDetail    : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.ContactDetails
ForwardAddressShippingAddress  : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.ShippingAddress
ForwardAddressValidationStatus : Valid
Id                             : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/orderItems/OrderItem-211115074927900249117427
Location                       : eastus
Name                           : OrderItem-211115074927900249117427
OrderId                        : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/Order-211115074927650235470998
OrderItemDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.OrderItemDetails
ReturnAddressContactDetail     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.ContactDetails
ReturnAddressShippingAddress   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.ShippingAddress
ReturnAddressValidationStatus  : Valid
StartTime                      : 11/15/2021 7:49:29 AM
SystemData                     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.SystemData
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.TrackedResourceTags
Type                           : Microsoft.EdgeOrder/orderItems
```

Get orderItem details