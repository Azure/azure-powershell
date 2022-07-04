### Example 1: Get address details
```powershell
$address = Get-AzEdgeOrderAddress -SubscriptionId SubscriptionId -ResourceGroupName "resourceGroupName"
$address | Format-List
```

```output
AddressValidationStatus      : Valid
ContactDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
Id                           : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/addresses/pwvalidaddress
Location                     : eastus
Name                         : pwvalidaddress
ShippingAddress              : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.TrackedResourceTags
Type                         : Microsoft.EdgeOrder/addresses

AddressValidationStatus      : Valid
ContactDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
Id                           : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/addresses/pwvalidaddress215
Location                     : eastus
Name                         : pwvalidaddress215
ShippingAddress              : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.TrackedResourceTags
Type                         : Microsoft.EdgeOrder/addresses

AddressValidationStatus      : Valid
ContactDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
Id                           : /subscriptions/"SubscriptionId"/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/addresses/TestPwAddress
Location                     : eastus
Name                         : TestPwAddress
ShippingAddress              : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.TrackedResourceTags
Type                         : Microsoft.EdgeOrder/addresses
```

Get address details