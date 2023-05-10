### Example 1: Creates or updates Account.
```powershell
New-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp -Location eastus -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -Sku 'Standard'
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Creates or updates Account.