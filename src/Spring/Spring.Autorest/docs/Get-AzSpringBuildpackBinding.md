---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringbuildpackbinding
schema: 2.0.0
---

# Get-AzSpringBuildpackBinding

## SYNOPSIS
Get a buildpack binding by name.

## SYNTAX

### List (Default)
```
Get-AzSpringBuildpackBinding -BuilderName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringBuildpackBinding -BuilderName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildpackBinding -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuilder
```
Get-AzSpringBuildpackBinding -BuilderInputObject <ISpringAppsIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildpackBinding -BuilderName <String> -BuildServiceInputObject <ISpringAppsIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringBuildpackBinding -BuilderName <String> -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a buildpack binding by name.

## EXAMPLES

### Example 1: List buildpack binding by name.
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BuilderName azps-builder
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

List buildpack binding by name.

### Example 2: Get a buildpack binding by name.
```powershell
Get-AzSpringBuildpackBinding -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BuilderName azps-builder -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

### Example 3: Get a buildpack binding by name.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildpackBinding -BuildServiceInputObject $buildserviceObj -BuilderName azps-builder -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

### Example 4: Get a buildpack binding by name.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildpackBinding -SpringInputObject $serviceObj -BuilderName azps-builder -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

### Example 5: Get a buildpack binding by name.
```powershell
$builderservicebuilderObj = Get-AzSpringBuildServiceBuilder -resourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-builder
Get-AzSpringBuildpackBinding -BuilderInputObject $builderservicebuilderObj -Name azps
```

```output
BindingType                  : ApplicationInsights
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder/buildpackBindings/azps
LaunchPropertyProperties     : {
                                 "abc": "def",
                                 "any-string": "any-string",
                                 "sampling-rate": "12.0"
                               }
LaunchPropertySecret         : {
                                 "connection-string": "*"
                               }
Name                         : azps
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2023-12-19 上午 03:57:38
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2023-12-19 上午 03:57:38
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders/buildpackBindings
```

Get a buildpack binding by name.

## PARAMETERS

### -BuilderInputObject
Identity Parameter
To construct, see NOTES section for BUILDERINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: GetViaIdentityBuilder
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BuilderName
The name of the builder resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBuildService, GetViaIdentitySpring, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildServiceInputObject
Identity Parameter
To construct, see NOTES section for BUILDSERVICEINPUTOBJECT properties and create a hash table.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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
The name of the Buildpack Binding Name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBuilder, GetViaIdentityBuildService, GetViaIdentitySpring
Aliases: BuildpackBindingName

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
To construct, see NOTES section for SPRINGINPUTOBJECT properties and create a hash table.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IBuildpackBindingResource

## NOTES

## RELATED LINKS

