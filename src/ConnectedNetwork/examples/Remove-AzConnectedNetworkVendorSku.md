### Example 1: Remove-AzConnectedNetworkVendorSku via Sku name and Vendor name
```powershell
<<<<<<< HEAD
Remove-AzConnectedNetworkVendorSku -SkuName MySku -VendorName MyVendor
=======
PS C:\> Remove-AzConnectedNetworkVendorSku -SkuName MySku -VendorName MyVendor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deleting the sku MySku with Vendor name MyVendor.

### Example 2: Remove-AzConnectedNetworkVendorSku via Identity
```powershell
$sku = Get-AzConnectedNetworkVendorSku -SkuName MySku1 -VendorName MyVendor
<<<<<<< HEAD
Remove-AzConnectedNetworkVendorSku -InputObject $sku
=======
PS C:\> Remove-AzConnectedNetworkVendorSku -InputObject $sku

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Creating an identity with sku name MySku1 and vendor name MyVendor. Deleting the sku with the given Identity.