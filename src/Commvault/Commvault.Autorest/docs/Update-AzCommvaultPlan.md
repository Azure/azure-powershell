---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/update-azcommvaultplan
schema: 2.0.0
---

# Update-AzCommvaultPlan

## SYNOPSIS
Update a CommvaultPlan

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCommvaultPlan -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-RetentionNumberOfSnapshot <Int32>] [-Schedule <ISchedule[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityCloudAccountExpanded
```
Update-AzCommvaultPlan -CloudAccountInputObject <ICommvaultIdentity> -Name <String>
 [-RetentionNumberOfSnapshot <Int32>] [-Schedule <ISchedule[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzCommvaultPlan -InputObject <ICommvaultIdentity> [-RetentionNumberOfSnapshot <Int32>]
 [-Schedule <ISchedule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a CommvaultPlan

## EXAMPLES

### Example 1: Update the retention of a backup plan
```powershell
Update-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name plan-daily -RetentionNumberOfSnapshot 14
```

Changes the backup plan so that it keeps 14 snapshots.

### Example 2: Update the schedule of a backup plan
```powershell
$schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'daily'; RunsEvery = 1; Time = '23:30'; TimeZone = 'UTC' }
Update-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name plan-daily -Schedule $schedule
```

Changes the backup plan so that the daily incremental backup runs at 23:30 UTC.

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

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: UpdateViaIdentityCloudAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Plan resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCloudAccountExpanded
Aliases: PlanName

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

### -RetentionNumberOfSnapshot
Number of Snapshots

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

### -Schedule
The Commvault Plan Schedule

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ISchedule[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultPlan

## NOTES

## RELATED LINKS

