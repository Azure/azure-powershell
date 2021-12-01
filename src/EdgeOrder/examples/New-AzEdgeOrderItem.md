### Example 1: Creates a new orderItem
```powershell
PS C:\> $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName ContactName -EmailList @("emailId") -Phone Phone
PS C:\> $ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\> $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
PS C:\> $details = New-AzEdgeOrderOrderItemDetailsObject -OrderItemType "Purchase"  -ProductDetail  @{"HierarchyInformation"=$HierarchyInformation}
PS C:\> $orderItem = New-AzEdgeOrderItem -Name "examplePowershell" -ResourceGroupName ResourceGroup -ForwardAddressContactDetail $contactDetail -Location "eastus" -OrderId "/subscriptions/"SubscriptionId"/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/pwOrderItem11" -OrderItemDetail $details -SubscriptionId SubscriptionId -ForwardShippingAddress $ShippingDetails

PS C:\> $orderItem = New-AzEdgeOrderItem -Name "examplePowershell" -ResourceGroupName "resourceGroupName" -ForwardAddressContactDetail $contactDetail -Location "eastus" -OrderId "/subscriptions/"SubscriptionId"/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/pwOrderItem11" -OrderItemDetail $details -SubscriptionId SubscriptionId -ForwardShippingAddress $ShippingDetails
PS C:\> $DebugPreference = "Continue"
# You can use `$DebugPreference = "Continue"`, with any example/usecase to get exact details of error in below format when creation command fails.
# {
#   "Error": {
#     "Code": "StaticValidationGenericCountryCodeHasInvalidLength",
#     "Message": "The attribute country code does not meet length constraints.\r\nEnter a value with 2 characters for country code.",
#     "Details": [
#       null
#     ],
#     "Target": null
#   }
# } 
PS C:\> $orderItem = New-AzEdgeOrderItem -Name "examplePowershell" -ResourceGroupName "resourceGroupName" -ForwardAddressContactDetail $contactDetail -Location "eastus" -OrderId "/subscriptions/"SubscriptionId"/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/pwOrderItem11" -OrderItemDetail $details -SubscriptionId SubscriptionId -ForwardShippingAddress $ShippingDetails
PS C:\> $orderItem | fl

ForwardAddressContactDetail    : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
ForwardAddressShippingAddress  : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
ForwardAddressValidationStatus : Valid
Id                             : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/orderItems/examplePowershell
Location                       : eastus
Name                           : examplePowershell
OrderId                        : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/pwOrderItem11
OrderItemDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.OrderItemDetails
ReturnAddressContactDetail     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
ReturnAddressShippingAddress   : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
ReturnAddressValidationStatus  :
StartTime                      : 11/16/2021 10:34:51 AM
SystemData                     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.TrackedResourceTags
Type                           : Microsoft.EdgeOrder/orderItems

```

Creates a new orderItem.

### Example 2: Creates a new orderItem with preference set for transport, encryption and management resource
```powershell
PS C:\> $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName "ContactName2" -EmailList $env.EmailList -Phone $env.Phone
PS C:\> $ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 $env.StreetAddress1 -StateOrProvince $env.StateOrProvince -Country $env.Country -City $env.City -PostalCode $env.PostalCode -AddressType $env.AddressType
PS C:\> $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"
PS C:\> $preference = New-AzEdgeOrderPreferencesObject -EncryptionPreference @{DoubleEncryptionStatus = "Disabled"} -TransportPreference @{PreferredShipmentType = "MicrosoftManaged"} -ManagementResourcePreference @{PreferredManagementResourceId = "/subscriptions/managementSubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/1GPUtest"}
PS C:\> $details = New-AzEdgeOrderOrderItemDetailsObject -OrderItemType "Purchase"  -ProductDetail  @{"HierarchyInformation"=$HierarchyInformation} -Preference $preference
PS C:\> New-AzEdgeOrderItem -Name "OrderItemNameWithPref" -ResourceGroupName "resourceGroupName" -ForwardAddressContactDetail $contactDetail -Location "eastus" -OrderId "/subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/locations/eastus/orders/pwPrefOrder" -OrderItemDetail $details -SubscriptionId $env.SubscriptionId -ForwardShippingAddress $ShippingDetails

Location Name                  Type
-------- ----                  ----
eastus   OrderItemNameWithPref Microsoft.EdgeOrder/orderItems
```
Creates a new orderItem with preference set for transport, encryption and management resource