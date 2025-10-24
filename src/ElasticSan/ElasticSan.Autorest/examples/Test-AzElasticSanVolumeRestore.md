### Example 1: Validate whether a list of backed up disk snapshots can be restored into ElasticSan volumes.
```powershell
Test-AzElasticSanVolumeRestore -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -DiskSnapshotId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myresourcegroup/providers/Microsoft.Compute/snapshots/mydisksnapshot"
```

```output
ValidationStatus
----------------
Success
```

This command validates whether a list of backed up disk snapshots can be restored into ElasticSan volumes.
