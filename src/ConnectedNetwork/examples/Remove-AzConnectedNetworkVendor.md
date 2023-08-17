### Example 1: Remove-AzConnectedNetworkVendor via vendor name
```powershell
Remove-AzConnectedNetworkVendor -Name MyVendor
```

Deleting the vendor with name MyVendor

### Example 2: Remove-AzConnectedNetworkVendor via InputObject
```powershell
$vendor = Get-AzConnectedNetworkVendor -Name MyVendor1
Remove-AzConnectedNetworkVendor -InputObject $vendor
```

Deleting the vendor with name MyVendor1