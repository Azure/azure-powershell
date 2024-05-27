### Example 1: Remove-AzConnectedNetworkVendorSkuPreview via sku name, vendor name and preview subscription
```powershell
Remove-AzConnectedNetworkVendorSkuPreview -SkuName mySku -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
```

Deleting the preview information of sku mySku with vendor name myVendor for the given preview subscription.

### Example 2: Remove-AzConnectedNetworkVendorSkuPreview via Identity
```powershell
$sku = Get-AzConnectedNetworkVendorSkuPreview -SkuName mySku1 -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
Remove-AzConnectedNetworkVendorSkuPreview -InputObject $sku
```

Creating an identity with skuname mySku1, vendor name myVendor and preview subscription. Deleting the preview information using the given identity.