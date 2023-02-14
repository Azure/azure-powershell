### Example 1: Get order details
```powershell
<<<<<<< HEAD
$order = Get-AzEdgeOrder -Name pwOrderItem11 -SubscriptionId "SubscriptionId" -Location "eastus" -ResourceGroupName "resourceGroupName"
$order | Format-List
```

```output
=======
PS C:\> $order = Get-AzEdgeOrder -Name pwOrderItem11 -SubscriptionId "SubscriptionId" -Location "eastus" -ResourceGroupName "resourceGroupName"
PS C:\> $order | fl

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
CurrentStageDisplayName      :
CurrentStageName             : Placed
CurrentStageStartTime        : 11/16/2021 10:35:00 AM
CurrentStageStatus           : Succeeded
Id                           : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/pwOrderItem11
Name                         : pwOrderItem11
OrderItemId                  : {/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/orderItems/examplePowershell}
OrderStageHistory            : {, }
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Type                         : Microsoft.EdgeOrder/orders
```
Get order details
