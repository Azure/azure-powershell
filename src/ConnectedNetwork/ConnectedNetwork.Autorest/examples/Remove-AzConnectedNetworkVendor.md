### Example 1: Remove-AzConnectedNetworkVendor via vendor name
```powershell
PS C:\> Remove-AzConnectedNetworkVendor -Name MyVendor

```

Deleting the vendor with name MyVendor

### Example 2: Remove-AzConnectedNetworkVendor via InputObject
```powershell
PS C:\> $vendor = Get-AzConnectedNetworkVendor -Name MyVendor1
PS C:\> Remove-AzConnectedNetworkVendor -InputObject $vendor

```

Deleting the vendor with name MyVendor1