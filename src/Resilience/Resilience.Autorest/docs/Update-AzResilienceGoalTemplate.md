---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/update-azresiliencegoaltemplate
schema: 2.0.0
---

# Update-AzResilienceGoalTemplate

## SYNOPSIS
Update a GoalTemplate

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> [-GoalType <String>]
 [-RegionalRecoveryPointObjective <String>] [-RegionalRecoveryTimeObjective <String>]
 [-RequireDisasterRecovery <String>] [-RequireHighAvailability <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> -Property <IGoalTemplateUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzResilienceGoalTemplate -InputObject <IResilienceIdentity> -Property <IGoalTemplateUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzResilienceGoalTemplate -InputObject <IResilienceIdentity> [-GoalType <String>]
 [-RegionalRecoveryPointObjective <String>] [-RegionalRecoveryTimeObjective <String>]
 [-RequireDisasterRecovery <String>] [-RequireHighAvailability <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroup
```
Update-AzResilienceGoalTemplate -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 -Property <IGoalTemplateUpdate> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityServiceGroupExpanded
```
Update-AzResilienceGoalTemplate -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 [-GoalType <String>] [-RegionalRecoveryPointObjective <String>] [-RegionalRecoveryTimeObjective <String>]
 [-RequireDisasterRecovery <String>] [-RequireHighAvailability <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a GoalTemplate

## EXAMPLES

### Example 1: Update a goal template
```powershell
Update-AzResilienceGoalTemplate -Name 'gt-tier1-resiliency' -ServiceGroupName 'azcmdlet-testing'
```

Updates the specified goal template, preserving properties that are not supplied.

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

### -GoalType
Type of Goal Template created by customer

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the goalTemplate

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityServiceGroup, UpdateViaIdentityServiceGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: GoalTemplateName

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

### -Property
Goal template a AzureResilienceProviderHub resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalTemplateUpdate
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RegionalRecoveryPointObjective
Regional recovery point objective specified by customer.
eg, PT15M for 15 minutes

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegionalRecoveryTimeObjective
Regional recovery time objective specified by customer.
eg, PT15M for 15 minutes

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireDisasterRecovery
Option specified by customer under disaster recovery section of goal template

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireHighAvailability
Option specified by customer under high availability section of goal template

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: UpdateViaIdentityServiceGroup, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalTemplateUpdate

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalTemplate

## NOTES

## RELATED LINKS

