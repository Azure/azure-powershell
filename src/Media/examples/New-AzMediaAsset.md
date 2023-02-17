### Example 1: Creates or updates an Asset in the Media Services account.
```powershell
New-AzMediaAsset -AccountName azpsms -Name azpsms-asset -ResourceGroupName azps_test_group -AlternateId "123" -Container "con" -Description "description" -StorageAccountName azpssa
```

```output
Name         ResourceGroupName
----         -----------------
azpsms-asset azps_test_group
```

Creates or updates an Asset in the Media Services account.