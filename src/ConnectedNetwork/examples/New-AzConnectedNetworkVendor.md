### Example 1: New-AzConnectedNetworkVendor
```powershell
New-AzConnectedNetworkVendor -Name myVendor
```

```output
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor
Name                         : myVendor
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 11/23/2021 6:18:55 PM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/23/2021 6:19:08 PM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors
```

Creating a vendor with name myVendor.

### Example 2: New-AzConnectedNetworkVendor with SubscriptionId 
```powershell
New-AzConnectedNetworkVendor -Name myVendor2 -SubscriptionId xxxxx-22222-xxxxx-22222
```

```output
Id                           : /subscriptions/xxxxx-22222-xxxxx-22222/providers/Microsoft.HybridNetwork/vendors/myVendor2
Name                         : myVendor2
ProvisioningState            : Succeeded
ResourceGroupName            :
Sku                          :
SystemDataCreatedAt          : 11/23/2021 6:20:28 PM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/23/2021 6:20:32 PM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Type                         : microsoft.hybridnetwork/vendors
```

Creating a vendor with name myVendor2 in xxxxx-22222-xxxxx-22222 subscription.