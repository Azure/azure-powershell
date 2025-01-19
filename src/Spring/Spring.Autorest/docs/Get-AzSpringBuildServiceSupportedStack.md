---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/get-azspringbuildservicesupportedstack
schema: 2.0.0
---

# Get-AzSpringBuildServiceSupportedStack

## SYNOPSIS
Get the supported stack resource.

## SYNTAX

### List (Default)
```
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSpringBuildServiceSupportedStack -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringBuildServiceSupportedStack -InputObject <ISpringAppsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBuildService
```
Get-AzSpringBuildServiceSupportedStack -BuildServiceInputObject <ISpringAppsIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySpring
```
Get-AzSpringBuildServiceSupportedStack -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the supported stack resource.

## EXAMPLES

### Example 1: List supported stack resource.
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Name                             ResourceGroupName      StackId                     Version
----                             -----------------      -------                     -------
io.buildpacks.stacks.bionic-base azps_test_group_spring io.buildpacks.stacks.bionic base
io.buildpacks.stacks.bionic-full azps_test_group_spring io.buildpacks.stacks.bionic full
io.buildpacks.stacks.jammy-base  azps_test_group_spring io.buildpacks.stacks.jammy  base
io.buildpacks.stacks.jammy-full  azps_test_group_spring io.buildpacks.stacks.jammy  full
io.buildpacks.stacks.jammy-tiny  azps_test_group_spring io.buildpacks.stacks.jammy  tiny
```

List supported stack resource.

### Example 2: Get the supported stack resource.
```powershell
Get-AzSpringBuildServiceSupportedStack -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name io.buildpacks.stacks.bionic-base
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedSt
                               acks/io.buildpacks.stacks.bionic-base
Name                         : io.buildpacks.stacks.bionic-base
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedStacks
Version                      : base
```

Get the supported stack resource.

### Example 3: Get the supported stack resource.
```powershell
$serviceObj = Get-AzSpringService -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringBuildServiceSupportedStack -SpringInputObject $serviceObj -Name io.buildpacks.stacks.bionic-base
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedSt
                               acks/io.buildpacks.stacks.bionic-base
Name                         : io.buildpacks.stacks.bionic-base
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedStacks
Version                      : base
```

Get the supported stack resource.

### Example 4: Get the supported stack resource.
```powershell
$buildserviceObj = Get-AzSpringBuildService -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
Get-AzSpringBuildServiceSupportedStack -BuildServiceInputObject $buildserviceObj -Name io.buildpacks.stacks.bionic-base
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/supportedSt
                               acks/io.buildpacks.stacks.bionic-base
Name                         : io.buildpacks.stacks.bionic-base
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/buildServices/supportedStacks
Version                      : base
```

Get the supported stack resource.

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
The name of the stack resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISupportedStackResource

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISupportedStacksCollection

## NOTES

## RELATED LINKS

