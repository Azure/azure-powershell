### Example 1: Create a RwxStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeRwxStorageClassTypePropertiesObject `
    -BackingStorageClassName "default"
```

Create a `RwxStorageClassTypeProperties` object and set `default` storage class as its backing storage class.

