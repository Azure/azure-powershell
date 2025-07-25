### Example 1: Create a NfsStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeNfsStorageClassTypePropertiesObject `
    -Server "0.0.0.0" `
    -Share "/share" `
    -MountPermission "777" `
    -OnDelete "Delete" `
    -SubDir "subdir"
```

Create a `NfsStorageClassTypeProperties` object.

