### Example 1: Get the number of available IP addresses needed for the AML file system information provided.
```powershell
Get-AzStorageCacheAmlFileSystemSubnetRequiredSize -SkuName "AMLFS-Durable-Premium-250" -StorageCapacityTiB 16
```

```output
8
```

Get the number of available IP addresses needed for the AML file system information provided.