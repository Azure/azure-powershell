### Example 1: Import image from a public/azure registry to an azure container registry.
```powershell
Import-AzContainerRegistryImage -SourceImage library/busybox:latest -ResourceGroupName $resourceGroupName -RegistryName $RegistryName -SourceRegistryUri docker.io -TargetTag busybox:latest
```

Import busybox to ACR. Note:
"library/" need to be add before source image. "busybox:latest" => "library/busybox:latest"
Credential needed if source registry is not publicly available
SourceRegistryResourceId or SourceRegistryUri is required for this cmdlet
