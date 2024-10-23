### Example 1: Create a SmbStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeSmbStorageClassTypePropertiesObject `
    -Source "//ip:port" `
    -Domain "domain" `
    -Username "username" `
    -Password $(ConvertTo-SecureString 'password' -AsPlainText) `
    -SubDir "subdir"
```

Create a `SmbStorageClassTypeProperties` object.

