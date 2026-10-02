---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/new-azresiliencegoaltemplate
schema: 2.0.0
---

# New-AzResilienceGoalTemplate

## SYNOPSIS
Create a GoalTemplate

## SYNTAX

### CreateExpanded (Default)
```
New-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String>
 [-RegionalRecoveryPointObjective <String>] [-RegionalRecoveryTimeObjective <String>]
 [-RequireDisasterRecovery <String>] [-RequireHighAvailability <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> -Resource <IGoalTemplate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzResilienceGoalTemplate -InputObject <IResilienceIdentity> -Resource <IGoalTemplate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzResilienceGoalTemplate -InputObject <IResilienceIdentity> [-RegionalRecoveryPointObjective <String>]
 [-RegionalRecoveryTimeObjective <String>] [-RequireDisasterRecovery <String>]
 [-RequireHighAvailability <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityServiceGroup
```
New-AzResilienceGoalTemplate -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 -Resource <IGoalTemplate> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityServiceGroupExpanded
```
New-AzResilienceGoalTemplate -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 [-RegionalRecoveryPointObjective <String>] [-RegionalRecoveryTimeObjective <String>]
 [-RequireDisasterRecovery <String>] [-RequireHighAvailability <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzResilienceGoalTemplate -Name <String> -ServiceGroupName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a GoalTemplate

## EXAMPLES

### Example 1: Create a goal template
```powershell
New-AzResilienceGoalTemplate `
  -Name 'gt-tier1-resiliency' `
  -ServiceGroupName 'azcmdlet-testing' `
  -RequireDisasterRecovery 'Required' `
  -RequireHighAvailability 'Required'
```

Creates a new goal template in the specified service group.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: Create, CreateExpanded, CreateViaIdentityServiceGroup, CreateViaIdentityServiceGroupExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### -RegionalRecoveryPointObjective
Regional recovery point objective specified by customer.
eg, PT15M for 15 minutes

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityServiceGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityServiceGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityServiceGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Goal template a AzureResilienceProviderHub resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalTemplate
Parameter Sets: Create, CreateViaIdentity, CreateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CreateViaIdentityServiceGroup, CreateViaIdentityServiceGroupExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalTemplate

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalTemplate

## NOTES

## RELATED LINKS

