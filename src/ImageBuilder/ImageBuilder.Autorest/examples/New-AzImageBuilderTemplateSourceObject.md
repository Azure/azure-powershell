### Example 1: Create a managed image source.
```powershell
New-AzImageBuilderTemplateSourceObject -ManagedImageSource -ImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image"
```

```output
ImageId
-------
/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/images/azps-vm-image
```

This command creates a managed image source.

### Example 2: Create a shared image source.
```powershell
New-AzImageBuilderTemplateSourceObject -SharedImageVersionSource -ImageVersionId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image/versions/1.0.0" 
```

```output
ExactVersion ImageVersionId
------------ --------------
             /subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute...
```

This command creates a shared image source.

### Example 3: Create a platfrom image source.
```powershell
New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher 'Canonical' -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest'
```

```output
ExactVersion Offer        Publisher Sku       Version
------------ -----        --------- ---       -------
             UbuntuServer Canonical 18.04-LTS latest
```

This command creates a platfrom image source.