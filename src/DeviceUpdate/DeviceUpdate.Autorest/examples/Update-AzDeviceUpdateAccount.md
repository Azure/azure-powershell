### Example 1: Updates account's patchable properties
```powershell
Update-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp -IdentityType 'SystemAssigned' -Tag @{"abc"="123"}
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Updates account's patchable properties

### Example 2: Updates account's patchable properties
```powershell
Get-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp | Update-AzDeviceUpdateAccount -IdentityType 'SystemAssigned' -Tag @{"abc"="123"}
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Updates account's patchable properties