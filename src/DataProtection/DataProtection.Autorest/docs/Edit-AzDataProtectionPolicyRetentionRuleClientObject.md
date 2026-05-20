---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/edit-azdataprotectionpolicyretentionruleclientobject
schema: 2.0.0
---

# Edit-AzDataProtectionPolicyRetentionRuleClientObject

## SYNOPSIS
Adds or removes Retention Rule to an existing backup policy.

## SYNTAX

### RemoveRetention (Default)
```
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Name <RetentionRuleName> -Policy <IBackupPolicy>
 -RemoveRule [<CommonParameters>]
```

### AddRetention
```
Edit-AzDataProtectionPolicyRetentionRuleClientObject -IsDefault <Boolean> -LifeCycles <ISourceLifeCycle[]>
 -Name <RetentionRuleName> -Policy <IBackupPolicy> [-OverwriteLifeCycle <Boolean?>] [<CommonParameters>]
```

## DESCRIPTION
Adds or removes Retention Rule to an existing backup policy.
Adding a retention rule whose `-Name` already exists on the policy is rejected unless `-OverwriteLifeCycle $true` is supplied.

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

### Example 3: Add an OperationalStore retention rule to an AzureBlob policy
```powershell
$pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
$opLifecycle = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLifecycle -IsDefault $true
```

```output
DatasourceType                                  ObjectType
--------------                                  ----------
{Microsoft.Storage/storageAccounts/blobServices} BackupPolicy
```

For AzureBlob, OperationalStore retention rules **must** be named `Default_OperationalStore`. The rule is added additively — the existing `Default` (VaultStore) retention rule on the policy template is preserved. Passing `-Name Default` with an OperationalStore lifecycle is rejected by validation.

Note: `-OverwriteLifeCycle` is deprecated and will be removed in a future release; duplicate retention rules are no longer permitted.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ISourceLifeCycle[]
Parameter Sets: AddRetention
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Retention Rule Name.
Note: Default retention rules cannot be removed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RetentionRuleName
Parameter Sets: (All)
Aliases:
Accepted values: Default, Daily, Weekly, Monthly, Yearly, Default_OperationalStore

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverwriteLifeCycle
[Deprecated] Specifies whether to modify an existing LifeCycle. Will be removed in a future release; duplicate retention rules are no longer permitted.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupPolicy
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupPolicy

## NOTES

### Validation rules

* **Duplicate retention rules are rejected.** Adding a rule whose `-Name` already exists on the policy throws `Retention rule '<Name>' already exists. Use -OverwriteLifeCycle $true to update it.` Pass `-OverwriteLifeCycle $true` to replace the existing rule's lifecycles in place.
* **Default rule removal.** `-Name Default` cannot be removed via `-RemoveRule`; the cmdlet throws `Removing Default Retention Rule is not allowed. Please try again with different rule name.`
* **`-OverwriteLifeCycle` is deprecated** and will be removed in a future release; duplicate retention rules are no longer permitted.

## RELATED LINKS

