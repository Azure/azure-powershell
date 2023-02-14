### Example 1: Remove-AzConnectedNetworkVendor via vendor name
```powershell
<<<<<<< HEAD
Remove-AzConnectedNetworkVendor -Name MyVendor
=======
PS C:\> Remove-AzConnectedNetworkVendor -Name MyVendor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deleting the vendor with name MyVendor

### Example 2: Remove-AzConnectedNetworkVendor via InputObject
```powershell
<<<<<<< HEAD
$vendor = Get-AzConnectedNetworkVendor -Name MyVendor1
Remove-AzConnectedNetworkVendor -InputObject $vendor
=======
PS C:\> $vendor = Get-AzConnectedNetworkVendor -Name MyVendor1
PS C:\> Remove-AzConnectedNetworkVendor -InputObject $vendor

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deleting the vendor with name MyVendor1