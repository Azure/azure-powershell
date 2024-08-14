---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradminschedule
schema: 2.0.0
---

# Update-AzDevCenterAdminSchedule

## SYNOPSIS
Partially updates a Scheduled.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDevCenterAdminSchedule -PoolName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-State <ScheduleEnableStatus>] [-Tag <Hashtable>] [-Time <String>]
 [-TimeZone <String>] [-Type <ScheduledType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminSchedule -InputObject <IDevCenterIdentity> [-State <ScheduleEnableStatus>]
 [-Tag <Hashtable>] [-Time <String>] [-TimeZone <String>] [-Type <ScheduledType>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially updates a Scheduled.

## EXAMPLES

### Example 1: Update a schedule
```powershell
New-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
```

This command updates a schedule in the pool "DevPool".

### Example 2: Update a schedule using InputObject
```powershell
$scheduleInput = Get-AzDevCenterAdminSchedule -PoolName DevPool -ProjectName DevProject -ResourceGroupName testRg

New-AzDevCenterAdminSchedule -InputObject $scheduleInput -State "Disabled" -Time "17:30" -TimeZone "America/New_York"
```

This command updates a schedule in the pool "DevPool".

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -PoolName
Name of the pool.

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

### -ProjectName
The name of the project.

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

### -State
Indicates whether or not this scheduled task is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.ScheduleEnableStatus
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

### -Time
The target time to trigger the action.
The format is HH:MM.

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

### -TimeZone
The IANA timezone id at which the schedule should execute.

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

### -Type
Supported type this scheduled task represents.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.ScheduledType
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.ISchedule

## NOTES

## RELATED LINKS

