### Example 1: Restore a soft-deleted volume
```powershell
Restore-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume
```

This command restores the soft-deleted volume `myvolume` to the `myvolumegroup` volume group. Use the volume name returned by the API that lists soft-deleted volumes for the volume group.

