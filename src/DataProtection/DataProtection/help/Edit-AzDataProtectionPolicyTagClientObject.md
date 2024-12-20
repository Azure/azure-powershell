---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicytagclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyTagClientObject

## SYNOPSIS
Adds or removes schedule tag in an existing backup policy.

## SYNTAX

### RemoveTag (Default)
```
Edit-AzDataProtectionPolicyTagClientObject -Policy <IBackupPolicy> -Name <TagName> [-RemoveRule]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### updateTag
```
Edit-AzDataProtectionPolicyTagClientObject -Policy <IBackupPolicy> -Name <TagName>
 -Criteria <IScheduleBasedBackupCriteria[]> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Adds or removes schedule tag in an existing backup policy.

## EXAMPLES

### Example 1: Add Weekly tag to Backup Policy
```powershell
$criteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -Criteria $criteria
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command adds a weekly tag to given backup policy

### Example 2: Remove Weeky tag from Backup Policy
```powershell
Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -RemoveRule
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command removes Weekly tag from backup policy.

## PARAMETERS

### -Criteria
Criterias to be associated with the schedule tag.
To construct, see NOTES section for CRITERIA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IScheduleBasedBackupCriteria[]
Parameter Sets: updateTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Schedule tag.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.TagName
Parameter Sets: (All)
Aliases:
Accepted values: Daily, Weekly, Monthly, Yearly

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Backup Policy Object.
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

### -RemoveRule
Specify whether to remove the tag from the given policy object.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveTag
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
