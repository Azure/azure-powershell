### Example 1: Create an in-memory object for BuildpacksGroupProperties.
```powershell
$buildpackObj = New-AzSpringBuildpackObject -Id "tanzu-buildpacks/java-azure"
New-AzSpringBuildpacksGroupObject -Buildpack $buildpackObj -Name "mix"
```

```output
Buildpack                                     Name
---------                                     ----
{{…                                           mix
```

Create an in-memory object for BuildpacksGroupProperties.