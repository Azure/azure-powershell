---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azcontainerapp
schema: 2.0.0
---

# Update-AzContainerApp

## SYNOPSIS
Create a Container App.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Configuration <IConfiguration>] [-EnableSystemAssignedIdentity <Boolean>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <String>] [-ManagedBy <String>] [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>]
 [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateInitContainer <IInitContainer[]>] [-TemplateRevisionSuffix <String>]
 [-TemplateServiceBind <IServiceBind[]>] [-TemplateTerminationGracePeriodSecond <Int64>]
 [-TemplateVolume <IVolume[]>] [-UserAssignedIdentity <String[]>] [-WorkloadProfileName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerApp -InputObject <IAppIdentity> [-Configuration <IConfiguration>]
 [-EnableSystemAssignedIdentity <Boolean>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-ManagedBy <String>] [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>] [-ScaleRule <IScaleRule[]>]
 [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>] [-TemplateInitContainer <IInitContainer[]>]
 [-TemplateRevisionSuffix <String>] [-TemplateServiceBind <IServiceBind[]>]
 [-TemplateTerminationGracePeriodSecond <Int64>] [-TemplateVolume <IVolume[]>]
 [-UserAssignedIdentity <String[]>] [-WorkloadProfileName <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Container App.

## EXAMPLES

### Example 1: Update container app.
```powershell
$newSecretObject = New-AzContainerAppSecretObject -Name "yourkey" -Value "yourvalue"
$configuration = New-AzContainerAppConfigurationObject -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $newSecretObject 

Update-AzContainerApp -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Configuration $configuration -Tag @{"123"="abc"}
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Update container app.

### Example 2: Update container app.
```powershell
$secretObject = Get-AzContainerAppSecret -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
$newSecretObject1 = New-AzContainerAppSecretObject -Name "yourkey" -Value "yourvalue"
$newSecretObject2 = New-AzContainerAppSecretObject -Name $secretObject.Name -Value $secretObject.Value -Identity $secretObject.Identity -KeyVaultUrl $secretObject.KeyVaultUrl
$configuration = New-AzContainerAppConfigurationObject -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $newSecretObject1,$newSecretObject2

Update-AzContainerApp -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Configuration $configuration -Tag @{"123"="abc"}
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Update container app.

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

### -Configuration
Non versioned Container App configuration properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

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

### -ExtendedLocationType
The type of the extended location.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedBy
The fully qualified resource ID of the resource that manages this resource.
Indicates if this resource is managed by another Azure resource.
If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource.

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

### -Name
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ContainerAppName

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ScaleMaxReplica
Optional.
Maximum number of container replicas.
Defaults to 10 if not set.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMinReplica
Optional.
Minimum number of container replicas.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleRule
Scaling rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateContainer
List of container definitions for the Container App.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IContainer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateInitContainer
List of specialized containers that run before app containers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IInitContainer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateRevisionSuffix
User friendly suffix that is appended to the revision name

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

### -TemplateServiceBind
List of container app services bound to the app

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IServiceBind[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateTerminationGracePeriodSecond
Optional duration in seconds the Container App Instance needs to terminate gracefully.
Value must be non-negative integer.
The value zero indicates stop immediately via the kill signal (no opportunity to shut down).
If this value is nil, the default grace period will be used instead.
Set this value longer than the expected cleanup time for your process.
Defaults to 30 seconds.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateVolume
List of volume definitions for the Container App.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IVolume[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadProfileName
Workload profile name to pin for container app execution.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IContainerApp

## NOTES

## RELATED LINKS
