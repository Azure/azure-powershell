### Example 1: Get all supported buildpack resource.
```powershell
Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01
```

```output
Name                         ResourceGroupName BuildpackId
----                         ----------------- -----------
tanzu-buildpacks-java-azure  Springrg     tanzu-buildpacks/java-azure
tanzu-buildpacks-dotnet-core Springrg     tanzu-buildpacks/dotnet-core
tanzu-buildpacks-go          Springrg     tanzu-buildpacks/go
tanzu-buildpacks-nodejs      Springrg     tanzu-buildpacks/nodejs
tanzu-buildpacks-python      Springrg     tanzu-buildpacks/python
```

Get all supported buildpack resource.

### Example 2: Get the supported buildpack resource by name
```powershell
Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName Springrg -ServiceName sspring-portal01 -Name tanzu-buildpacks-python
```

```output
Name                    ResourceGroupName BuildpackId
----                    ----------------- -----------
tanzu-buildpacks-python Springrg     tanzu-buildpacks/python
```

Get the supported buildpack resource by name.

