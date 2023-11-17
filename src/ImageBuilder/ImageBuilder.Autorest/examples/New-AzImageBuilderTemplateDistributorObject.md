### Example 1: Create a managed image distributor.
```powershell
New-AzImageBuilderTemplateDistributorObject -ManagedImageDistributor -ArtifactTag @{tag='azpstest'} -ImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image" -RunOutputName "runoutput-01" -Location eastus
```

```output
RunOutputName ImageId                                                                                                             Location
------------- -------                                                                                                             --------
runoutput-01  /subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image eastus
```

This command creates a managed image distributor.

### Example 2: Create a VHD distributor.
```powershell
New-AzImageBuilderTemplateDistributorObject -ArtifactTag @{tag='vhd'} -VhdDistributor -RunOutputName image-vhd
```

```output
RunOutputName Uri
------------- ---
image-vhd
```

This command creates a VHD distributor.

### Example 3: Create a shared image distributor.
```powershell
New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{"test"="dis-share"} -GalleryImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image" -ReplicationRegion "eastus" -RunOutputName "runoutput-01"
```

```output
RunOutputName ExcludeFromLatest GalleryImageId                                                        ReplicationRegion StorageAccountType
------------- ----------------- --------------                                                        ----------------- -------
runoutput-01                    /subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder... {eastus}
```

This command creates a shared image distributor.