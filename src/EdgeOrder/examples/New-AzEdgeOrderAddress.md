### Example 1: Create a new address
```powershell
PS C:\> $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName ContactName -EmailList @("emailId") -Phone Phone
PS C:\> $ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
PS C:\> $address = New-AzEdgeOrderAddress -Name "TestPwAddress" -ResourceGroupName "resourceGroupName" -ContactDetail $contactDetail -SubscriptionId SubscriptionId -ShippingAddress $ShippingDetails -Location "eastus"
PS C:\> $address | fl

AddressValidationStatus      : Valid
ContactDetail                : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ContactDetails
Id                           : /subscriptions/SubscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.EdgeOrder/addresses/TestPwAddress
Location                     : eastus
Name                         : TestPwAddress
ShippingAddress              : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20211201.ShippingAddress
SystemData                     : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.SystemData
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.EdgeOrder.Models.Api20.TrackedResourceTags
Type                         : Microsoft.EdgeOrder/addresses
```
Creates a new address, to get insight on any failure you can set $debugPreference = "Continue" and run command again