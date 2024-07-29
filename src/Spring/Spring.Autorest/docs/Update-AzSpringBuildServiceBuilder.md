---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/update-azspringbuildservicebuilder
schema: 2.0.0
---

# Update-AzSpringBuildServiceBuilder

## SYNOPSIS
Update a KPack builder.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringBuildServiceBuilder -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-BuildpackGroup <IBuildpacksGroupProperties[]>] [-StackId <String>]
 [-StackVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityBuildServiceExpanded
```
Update-AzSpringBuildServiceBuilder -BuildServiceInputObject <ISpringAppsIdentity> -Name <String>
 [-BuildpackGroup <IBuildpacksGroupProperties[]>] [-StackId <String>] [-StackVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringBuildServiceBuilder -InputObject <ISpringAppsIdentity>
 [-BuildpackGroup <IBuildpacksGroupProperties[]>] [-StackId <String>] [-StackVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentitySpringExpanded
```
Update-AzSpringBuildServiceBuilder -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-BuildpackGroup <IBuildpacksGroupProperties[]>] [-StackId <String>] [-StackVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a KPack builder.

## EXAMPLES

### Example 1: Update a KPack builder.
```powershell
$buildpackObj = New-AzSpringBuildpackObject -Id "tanzu-buildpacks/java-azure"
$buildgroupObj = New-AzSpringBuildpacksGroupObject -Buildpack $buildpackObj -Name "mix"
Update-AzSpringBuildServiceBuilder -Name azps-builder -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -BuildpackGroup $buildgroupObj -StackId "io.buildpacks.stacks.bionic" -StackVersion "base"
```

```output
BuildpackGroup               : {{
                                 "name": "mix",
                                 "buildpacks": [
                                   {
                                     "id": "tanzu-buildpacks/java-azure"
                                   }
                                 ]
                               }}
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/buildServices/default/builders/az
                               ps-builder
Name                         : azps-builder
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
StackId                      : io.buildpacks.stacks.bionic
StackVersion                 : base
SystemDataCreatedAt          : 2024-05-24 上午 08:14:37
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-28 上午 10:47:05
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/buildServices/builders
```

Update a KPack builder.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildpackGroup
Builder buildpack groups.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IBuildpacksGroupProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildServiceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentityBuildServiceExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the builder resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityBuildServiceExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StackId
Id of the ClusterStack.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StackVersion
Version of the ClusterStack

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IBuilderResource

## NOTES

## RELATED LINKS

