### Example 1: Get-AzConnectedNetworkVendor using vendor name
```powershell
<<<<<<< HEAD
Get-AzConnectedNetworkVendor -Name myVendor
```

```output
=======
PS C:\> Get-AzConnectedNetworkVendor -Name myVendor


>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor
Name                         : myVendor
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 9/7/2021 3:02:02 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/7/2021 3:02:03 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors

```

Getting information about the vendor with vendor name myVendor.

### Example 2: Get-AzConnectedNetworkVendor using Identity
```powershell
<<<<<<< HEAD
$vendor = @{ VendorName = "myVendor1"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Get-AzConnectedNetworkVendor -InputObject $vendor
```

```output
=======
PS C:\> $vendor = @{ VendorName = "myVendor1"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
PS C:\> Get-AzConnectedNetworkVendor -InputObject $vendor


>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor1
Name                         : myVendor1
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 9/7/2021 3:02:02 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 9/7/2021 3:02:03 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors

```

Creating an identity with VendorName myVendor1 and the given subscription. Getting information about the vendor using this identity.