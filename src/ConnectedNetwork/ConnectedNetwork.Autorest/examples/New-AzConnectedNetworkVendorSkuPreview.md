### Example 1: New-AzConnectedNetworkVendorSkuPreview using preview subscription, sku name, vendor name and subscription
```powershell
New-AzConnectedNetworkVendorSkuPreview -PreviewSubscription xxxxx-00000-xxxxx-00000 -SkuName mySku -VendorName myVendor -SubscriptionId xxxxx-22222-xxxxx-22222
```

```output
Id                           : /subscriptions/xxxxx-22222-xxxxx-22222/providers/Microsoft.HybridNetwork/vendors/myVendor/vendorSkus/mySku/previewSubscriptions/xxxxx-00000-xxxxx-00000
Name                         : xxxxx-00000-xxxxx-00000
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 12/6/2021 5:37:35 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/6/2021 5:37:35 AM
SystemDataLastModifiedBy     : user@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.hybridnetwork/vendors/vendorskus/previewsubscriptions

```

Creating preview subscription for subscription xxxxx-00000-xxxxx-00000 of a vendor sku mySku with vendor name myVendor, which is allowed to deploy network function.