### Example 1: Create an in-memory object for BuildpacksGroupProperties
```powershell
$pack = @()
$pack += New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/dotnet-core"
$pack += New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/python"
$pack += New-AzSpringCloudBuildpackObject -Id "tanzu-buildpacks/java-azure"
New-AzSpringCloudBuildpacksGroupObject -Name 'packtest' -Buildpack $pack
```

```output
Name
----
packtest
```

Create an in-memory object for BuildpacksGroupProperties.