### Example 1: Lists storage container URLs with shared access signatures (SAS) for uploading and downloading Asset content.
```powershell
Get-AzMediaAssetContainerSas -AccountName azpsms -ResourceGroupName azps_test_group -AssetName azpsms-asset
```

```output
https://azpssa.blob.core.windows.net/asset-xxxxxxxxxxxxxxxx
https://azpssa.blob.core.windows.net/asset-xxxxxxxxxxxxxxxx
```

Lists storage container URLs with shared access signatures (SAS) for uploading and downloading Asset content.
The signatures are derived from the storage account keys.