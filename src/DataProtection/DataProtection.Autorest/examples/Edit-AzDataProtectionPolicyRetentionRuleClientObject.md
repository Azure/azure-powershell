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

The first command gets the default policy template. The second command creates a weekly lifecycle object. The third command adds a weekly retention rule to the default policy.

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

For AzureBlob, OperationalStore retention rules **must** be named `Default_OperationalStore`. The rule is added additively — the existing `Default` (Vault) retention rule on the policy template is preserved.

Note: passing `-Name Default` with an OperationalStore lifecycle now errors out (it was previously the buggy `-OverwriteLifeCycle $true`/`$false` patterns that produced a duplicate-`Default` rule).

