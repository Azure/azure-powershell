### Example 1: Get the upload location for the user to be able to upload the source.
```powershell
Get-AzContainerRegistryBuildSourceUploadUrl -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
RelativePath                                                    UploadUrl
------------                                                    ---------
source/202301300000/a550fd34-8a5b-4ef1-982f-70028aa731b5.tar.gz https://acrtaskprodeus020.blob.core.windows.net/container-141ab62…
```

Get the upload location for the user to be able to upload the source.

