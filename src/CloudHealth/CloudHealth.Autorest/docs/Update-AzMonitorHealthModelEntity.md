---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/update-azmonitorhealthmodelentity
schema: 2.0.0
---

# Update-AzMonitorHealthModelEntity

## SYNOPSIS
Update a Entity

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMonitorHealthModelEntity -HealthModelName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CanvaPositionX <Single>] [-CanvaPositionY <Single>]
 [-DegradedActionGroupId <String[]>] [-DegradedDescription <String>] [-DegradedSeverity <String>]
 [-DisplayName <String>] [-HealthObjective <Single>] [-IconCustomData <String>] [-IconName <String>]
 [-Impact <String>] [-SignalGroup <ISignalGroups>] [-Tag <Hashtable>] [-UnhealthyActionGroupId <String[]>]
 [-UnhealthyDescription <String>] [-UnhealthySeverity <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMonitorHealthModelEntity -InputObject <ICloudHealthIdentity> [-CanvaPositionX <Single>]
 [-CanvaPositionY <Single>] [-DegradedActionGroupId <String[]>] [-DegradedDescription <String>]
 [-DegradedSeverity <String>] [-DisplayName <String>] [-HealthObjective <Single>] [-IconCustomData <String>]
 [-IconName <String>] [-Impact <String>] [-SignalGroup <ISignalGroups>] [-Tag <Hashtable>]
 [-UnhealthyActionGroupId <String[]>] [-UnhealthyDescription <String>] [-UnhealthySeverity <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityHealthmodelExpanded
```
Update-AzMonitorHealthModelEntity -HealthmodelInputObject <ICloudHealthIdentity> -Name <String>
 [-CanvaPositionX <Single>] [-CanvaPositionY <Single>] [-DegradedActionGroupId <String[]>]
 [-DegradedDescription <String>] [-DegradedSeverity <String>] [-DisplayName <String>]
 [-HealthObjective <Single>] [-IconCustomData <String>] [-IconName <String>] [-Impact <String>]
 [-SignalGroup <ISignalGroups>] [-Tag <Hashtable>] [-UnhealthyActionGroupId <String[]>]
 [-UnhealthyDescription <String>] [-UnhealthySeverity <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Entity

## EXAMPLES

### Example 1: Tighten the health objective and unhealthy severity of an entity
```powershell
# Update the health objective and unhealthy severity of the entity frontend-service
Update-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -HealthObjective 99.95 -Impact Standard -UnhealthySeverity Sev1 -UnhealthyDescription 'Checkout is failing for customers'
```

Updates the health objective, impact, unhealthy severity and unhealthy description of the entity.

### Example 2: Change the display name of an entity
```powershell
# Update the display name of the entity frontend-service
Update-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -DisplayName 'Frontend Service (EU)'
```

Updates the display name shown for the entity in the health model.

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

### -CanvaPositionX
X Coordinate

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanvaPositionY
Y Coordinate

```yaml
Type: System.Single
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

### -DegradedActionGroupId
Optional list of action group resource IDs to be notified when the alert is triggered.

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

### -DegradedDescription
The alert rule description.

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

### -DegradedSeverity
The severity of triggered alert.

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

### -DisplayName
Display name

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

### -HealthmodelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: UpdateViaIdentityHealthmodelExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HealthModelName
Name of health model resource

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

### -HealthObjective
Health objective as a percentage of time the entity should be healthy.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconCustomData
Custom data.
Base64-encoded SVG data.
If set, this overrides the built-in icon.

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

### -IconName
Name of the built-in icon, or 'Custom' to use customData

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

### -Impact
Impact of the entity in health state propagation

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the entity.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded
Aliases: EntityName

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

### -SignalGroup
Signal groups which are assigned to this entity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalGroups
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
The value must be an UUID.

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
Optional set of tags (key-value pairs)

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

### -UnhealthyActionGroupId
Optional list of action group resource IDs to be notified when the alert is triggered.

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

### -UnhealthyDescription
The alert rule description.

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

### -UnhealthySeverity
The severity of triggered alert.

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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEntity

## NOTES

## RELATED LINKS

