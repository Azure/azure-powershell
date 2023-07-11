### Example 1: Create an in-memory object for BuildpacksGroupProperties
```powershell
$pack = @()
$pack += New-AzSpringBuildpackObject -Id "tanzu-buildpacks/dotnet-core"
$pack += New-AzSpringBuildpackObject -Id "tanzu-buildpacks/python"
$pack += New-AzSpringBuildpackObject -Id "tanzu-buildpacks/java-azure"
New-AzSpringBuildpacksGroupObject -Name 'packtest' -Buildpack $pack
```

```output
Name
----
packtest
```

Create an in-memory object for BuildpacksGroupProperties.