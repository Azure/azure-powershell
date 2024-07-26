### Example 1: Create a AksArcDiskStorageClassTypeProperties
```powershell
$typeProperties = New-AzKubernetesRuntimeAksArcDiskStorageClassTypePropertiesObject `
    -StoragePathId /subscription/xxx/xxx
    -FsType ext4
```

Create a `AksArcDiskStorageClassTypeProperties` object with storage path Id and fs type.

