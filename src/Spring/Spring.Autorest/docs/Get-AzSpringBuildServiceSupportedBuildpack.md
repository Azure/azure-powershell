---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringbuildservicesupportedbuildpack
schema: 2.0.0
---

# Get-AzSpringBuildServiceSupportedBuildpack

## SYNOPSIS
Get the supported buildpack resource.

## SYNTAX

### List (Default)
```
Get-AzSpringBuildServiceSupportedBuildpack -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringBuildServiceSupportedBuildpack -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildServiceSupportedBuildpack -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildServiceSupportedBuildpack -BuildServiceInputObject <ISpringAppsIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringBuildServiceSupportedBuildpack -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the supported buildpack resource.

## EXAMPLES

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

## PARAMETERS

### -BuildServiceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentityBuildService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the buildpack resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBuildService, GetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISupportedBuildpackResource

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISupportedBuildpacksCollection

## NOTES

## RELATED LINKS

