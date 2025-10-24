### Example 1: Validate whether a disk snapshot backup can be taken for list of volumes.
```powershell
Test-AzElasticSanVolumeBackup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -VolumeName myvolume
```

```output
ValidationStatus
----------------
Success
```

This command validates whether a disk snapshot backup can be taken for list of volumes.
