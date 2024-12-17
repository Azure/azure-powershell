---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicytriggerclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyTriggerClientObject

## SYNOPSIS
Updates Backup schedule of an existing backup policy.

## SYNTAX

### RemoveBackupSchedule (Default)
```
Edit-AzDataProtectionPolicyTriggerClientObject -Policy <IBackupPolicy> [-RemoveSchedule]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ModifyBackupSchedule
```
Edit-AzDataProtectionPolicyTriggerClientObject -Policy <IBackupPolicy> -Schedule <String[]>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Updates Backup schedule of an existing backup policy.

## EXAMPLES

### Example 1: Add Daily schedule to Azure Backup rule.
```powershell
$schedule = New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays (Get-Date) -IntervalType Daily -IntervalCount 1
Edit-AzDataProtectionPolicyTriggerClientObject -Policy $pol -Schedule $schedule
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command updates backup schedule of given policy to daily backup.

## PARAMETERS

### -Policy
Backup Policy object.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupPolicy
Parameter Sets: (All)
Aliases:

Required: True
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

### -RemoveSchedule
Specifies whether to remove the backup Schedule.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveBackupSchedule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schedule
Schedule to be associated to backup policy.

```yaml
Type: System.String[]
Parameter Sets: ModifyBackupSchedule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupPolicy

## NOTES

## RELATED LINKS
