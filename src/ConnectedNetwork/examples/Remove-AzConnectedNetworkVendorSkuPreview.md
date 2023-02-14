### Example 1: Remove-AzConnectedNetworkVendorSkuPreview via sku name, vendor name and preview subscription
```powershell
<<<<<<< HEAD
Remove-AzConnectedNetworkVendorSkuPreview -SkuName mySku -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
=======
PS C:\> Remove-AzConnectedNetworkVendorSkuPreview -SkuName mySku -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deleting the preview information of sku mySku with vendor name myVendor for the given preview subscription.

### Example 2: Remove-AzConnectedNetworkVendorSkuPreview via Identity
```powershell
<<<<<<< HEAD
$sku = Get-AzConnectedNetworkVendorSkuPreview -SkuName mySku1 -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
Remove-AzConnectedNetworkVendorSkuPreview -InputObject $sku
=======
PS C:\> $sku = Get-AzConnectedNetworkVendorSkuPreview -SkuName mySku1 -VendorName myVendor -PreviewSubscription xxxxx-22222-xxxxx-22222
PS C:\> Remove-AzConnectedNetworkVendorSkuPreview -InputObject $sku

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Creating an identity with skuname mySku1, vendor name myVendor and preview subscription. Deleting the preview information using the given identity.