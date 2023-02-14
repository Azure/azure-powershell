### Example 1: Get-AzConnectedNetworkVendorSkuPreview using sku name, vendor name and preview subscription
```powershell
<<<<<<< HEAD
Get-AzConnectedNetworkVendorSkuPreview -SkuName mySku -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
```

```output
=======
PS C:\> Get-AzConnectedNetworkVendorSkuPreview -SkuName mySku -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorSkus/mySku/previewSubscriptions/xxxxx-22222-xxxxx-22222
Name                         : xxxxx-22222-xxxxx-22222
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 11/24/2021 4:41:22 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/24/2021 4:41:22 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.hybridnetwork/vendors/vendorskus/previewsubscriptions

```

Getting the preview information of a vendor sku mySku with vendor myVendor for the specified subscription.

### Example 2: Get-AzConnectedNetworkVendorSkuPreview via Identity
```powershell
<<<<<<< HEAD
$skuPreview = @{ SkuName = "mySku";  VendorName = "myVendor"; PreviewSubscription = "xxxxx-22222-xxxxx-22222"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
Get-AzConnectedNetworkVendorSkuPreview -InputObject $skuPreview
```

```output
=======
PS C:\> $skuPreview = @{ SkuName = "mySku";  VendorName = "myVendor"; PreviewSubscription = "xxxxx-22222-xxxxx-22222"; SubscriptionId = "xxxxx-00000-xxxxx-00000"}
PS C:\> Get-AzConnectedNetworkVendorSkuPreview -InputObject $skuPreview

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorSkus/mySku/previewSubscriptions/xxxxx-22222-xxxxx-22222
Name                         : xxxxx-22222-xxxxx-22222
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 11/24/2021 4:41:22 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/24/2021 4:41:22 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.hybridnetwork/vendors/vendorskus/previewsubscriptions

```

Creating a identity with SkuName mySku, VendorName myVendor, preview subscription and subscription id. Getting the preview information of this vendor sku using this identity.