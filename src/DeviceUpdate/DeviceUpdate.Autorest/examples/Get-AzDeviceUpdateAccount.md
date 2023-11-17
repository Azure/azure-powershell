### Example 1: Returns account details for the SubscriptionId.
```powershell
Get-AzDeviceUpdateAccount
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Returns account details for the SubscriptionId.

### Example 2: Returns account details for the given account name.
```powershell
Get-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Returns account details for the given account name.

### Example 3: Returns account details for the Resource Group Name.
```powershell
Get-AzDeviceUpdateAccount -ResourceGroupName azpstest_gp
```

```output
Name             Location Sku      ResourceGroupName
----             -------- ---      -----------------
azpstest-account eastus   Standard azpstest_gp
```

Returns account details for the Resource Group Name.