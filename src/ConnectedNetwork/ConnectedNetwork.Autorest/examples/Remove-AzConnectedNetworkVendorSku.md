### Example 1: Remove-AzConnectedNetworkVendorSku via Sku name and Vendor name
```powershell
Remove-AzConnectedNetworkVendorSku -SkuName MySku -VendorName MyVendor
```

Deleting the sku MySku with Vendor name MyVendor.

### Example 2: Remove-AzConnectedNetworkVendorSku via Identity
```powershell
$sku = Get-AzConnectedNetworkVendorSku -SkuName MySku1 -VendorName MyVendor
Remove-AzConnectedNetworkVendorSku -InputObject $sku
```

Creating an identity with sku name MySku1 and vendor name MyVendor. Deleting the sku with the given Identity.