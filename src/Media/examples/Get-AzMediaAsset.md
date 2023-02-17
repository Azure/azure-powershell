### Example 1: List the details of Assets in the Media Services account by Media Name.
```powershell
Get-AzMediaAsset -AccountName azpsms -ResourceGroupName azps_test_group
```

```output
Name           ResourceGroupName
----           -----------------
azpsms-asset   azps_test_group
azpsms-asset-2 azps_test_group
```

List the details of Assets in the Media Services account by Media Name.

### Example 2: Get the details of an Asset in the Media Services account by Media Asset Name.
```powershell
Get-AzMediaAsset -AccountName azpsms -ResourceGroupName azps_test_group -Name azpsms-asset
```

```output
Name         ResourceGroupName
----         -----------------
azpsms-asset azps_test_group
```

Get the details of an Asset in the Media Services account by Media Asset Name.