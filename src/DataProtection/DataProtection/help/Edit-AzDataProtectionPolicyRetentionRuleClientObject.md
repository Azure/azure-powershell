---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicyretentionruleclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyRetentionRuleClientObject

## SYNOPSIS
Adds or removes Retention Rule to existing Policy

## SYNTAX

### RemoveRetention (Default)
```
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy <IBackupPolicy> -Name <RetentionRuleName>
 [-RemoveRule] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AddRetention
```
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy <IBackupPolicy> -Name <RetentionRuleName>
 -IsDefault <Boolean> -LifeCycles <ISourceLifeCycle[]> [-OverwriteLifeCycle <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Adds or removes Retention Rule to existing Policy

## EXAMPLES

### Example 1: Add Weekly Retention Rule
```powershell
$pol = Get-AzDataProtectionPolicyTemplate
$lifecycle = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 5
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $lifecycle -IsDefault $false
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

The first command gets the default policy template.
The second command creates a weekly lifecycle object.
The third command adds a weekly retention rule to the default policy.

### Example 2: Remove Weekly Retention Rule
```powershell
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -RemoveRule
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command removes weekly retention rule if it exists in given backup policy.

## PARAMETERS

### -IsDefault
Specifies if retention rule is default retention rule.

```yaml
Type: System.Boolean
Parameter Sets: AddRetention
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LifeCycles
Life cycles associated with the retention rule.
To construct, see NOTES section for LIFECYCLES properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.ISourceLifeCycle[]
Parameter Sets: AddRetention
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Retention Rule Name

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RetentionRuleName
Parameter Sets: (All)
Aliases:
Accepted values: Default, Daily, Weekly, Monthly, Yearly

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverwriteLifeCycle
Specifies whether to modify an existing LifeCycle.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: AddRetention
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Backup Policy Object
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
Specifies whether to remove the retention rule.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveRetention
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
