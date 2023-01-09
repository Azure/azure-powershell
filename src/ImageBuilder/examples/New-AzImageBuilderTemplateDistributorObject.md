### Example 1: Create a managed image distributor
```powershell
New-AzImageBuilderTemplateDistributorObject -ManagedImageDistributor -ArtifactTag @{tag='lucasManage'} -ImageId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/lucas-linux-imageshare -RunOutputName luacas-runout -Location eastus
```

```output
RunOutputName ImageId
------------- -------                                                                                                         
luacas-runout /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Co…
```

This command creates a managed image distributor.

### Example 2: Create a VHD distributor
```powershell
New-AzImageBuilderTemplateDistributorObject -ArtifactTag @{tag='vhd'} -VhdDistributor -RunOutputName image-vhd
```

```output
RunOutputName
-------------
image-vhd
```

This command creates a VHD distributor.

### Example 3: Create a shared image distributor
```powershell
New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/myimagegallery/images/lcuas-linux-share' -ReplicationRegion eastus2 -RunOutputName 'outname' -ExcludeFromLatest $false 
```

```output
RunOutputName ExcludeFromLatest GalleryImageId
------------- ----------------- --------------                                                                                
outname       False             /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/prov… 
```

This command creates a shared image distributor.


