### Example 1: Remove a volume 
```powershell
Remove-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name myvolume
```

This command removes a volume. 

### Example 2: Remove a soft deleted volume permanently
```powershell
$deletevolume = Get-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -AccessSoftDeletedResource true
Remove-AzElasticSanVolume -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -Name $deletevolume[0].Name -DeleteType permanent
```

This removes a soft deleted volume permanently.