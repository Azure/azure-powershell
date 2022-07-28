### Example 1: Get all supported buildpack resource.
```powershell
Get-AzSpringCloudBuildServiceSupportedBuildpack -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01
```

```output
Name                         ResourceGroupName BuildpackId
----                         ----------------- -----------
tanzu-buildpacks-java-azure  springcloudrg     tanzu-buildpacks/java-azure
tanzu-buildpacks-dotnet-core springcloudrg     tanzu-buildpacks/dotnet-core
tanzu-buildpacks-go          springcloudrg     tanzu-buildpacks/go
tanzu-buildpacks-nodejs      springcloudrg     tanzu-buildpacks/nodejs
tanzu-buildpacks-python      springcloudrg     tanzu-buildpacks/python
```

Get all supported buildpack resource.

### Example 2: Get the supported buildpack resource by name
```powershell
Get-AzSpringCloudBuildServiceSupportedBuildpack -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -Name tanzu-buildpacks-python
```

```output
Name                    ResourceGroupName BuildpackId
----                    ----------------- -----------
tanzu-buildpacks-python springcloudrg     tanzu-buildpacks/python
```

Get the supported buildpack resource by name.

