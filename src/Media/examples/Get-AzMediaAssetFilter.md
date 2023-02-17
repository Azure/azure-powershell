### Example 1: List the details of Assets Filter associated with the specified Asset by Media Asset Name.
```powershell
Get-AzMediaAssetFilter -AccountName azpsms -ResourceGroupName azps_test_group -AssetName azpsms-asset
```

```output
Name                ResourceGroupName
----                -----------------
azpsms-asset-filter azps_test_group
```

List the details of Assets Filter associated with the specified Asset by Media Asset Name.

### Example 2: Get the details of an Asset Filter associated with the specified Asset by Media Asset Filter Name.
```powershell
Get-AzMediaAssetFilter -AccountName azpsms -ResourceGroupName azps_test_group -AssetName azpsms-asset -FilterName azpsms-asset-filter
```

```output
Name                ResourceGroupName
----                -----------------
azpsms-asset-filter azps_test_group
```

Get the details of an Asset Filter associated with the specified Asset by Media Asset Filter Name.