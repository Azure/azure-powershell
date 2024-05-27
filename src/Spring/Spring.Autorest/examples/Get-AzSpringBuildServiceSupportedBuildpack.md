### Example 1: List supported buildpack resource.
```powershell
Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Name                               ResourceGroupName      BuildpackId
----                               -----------------      -----------
tanzu-buildpacks-java-native-image azps_test_group_spring tanzu-buildpacks/java-native-image
tanzu-buildpacks-java-azure        azps_test_group_spring tanzu-buildpacks/java-azure
tanzu-buildpacks-dotnet-core       azps_test_group_spring tanzu-buildpacks/dotnet-core
tanzu-buildpacks-go                azps_test_group_spring tanzu-buildpacks/go
tanzu-buildpacks-python            azps_test_group_spring tanzu-buildpacks/python
tanzu-buildpacks-nodejs            azps_test_group_spring tanzu-buildpacks/nodejs
tanzu-buildpacks-web-servers       azps_test_group_spring tanzu-buildpacks/web-servers
tanzu-buildpacks-php               azps_test_group_spring tanzu-buildpacks/php
```

List supported buildpack resource.

### Example 2: Get the supported buildpack resource.
```powershell
Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name tanzu-buildpacks-dotnet-core
```

```output
BuildpackId                  : tanzu-buildpacks/dotnet-core
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedBu
                               ildpacks/tanzu-buildpacks-dotnet-core
Name                         : tanzu-buildpacks-dotnet-core
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedBuildpacks
```

Get the supported buildpack resource.

### Example 3: Get the supported buildpack resource.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildServiceSupportedBuildpack -BuildServiceInputObject $buildserviceObj -Name tanzu-buildpacks-dotnet-core
```

```output
BuildpackId                  : tanzu-buildpacks/dotnet-core
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedBu
                               ildpacks/tanzu-buildpacks-dotnet-core
Name                         : tanzu-buildpacks-dotnet-core
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedBuildpacks
```

Get the supported buildpack resource.

### Example 4: Get the supported buildpack resource.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildServiceSupportedBuildpack -SpringInputObject $serviceObj -Name tanzu-buildpacks-dotnet-core
```

```output
BuildpackId                  : tanzu-buildpacks/dotnet-core
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedBu
                               ildpacks/tanzu-buildpacks-dotnet-core
Name                         : tanzu-buildpacks-dotnet-core
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedBuildpacks
```

Get the supported buildpack resource.