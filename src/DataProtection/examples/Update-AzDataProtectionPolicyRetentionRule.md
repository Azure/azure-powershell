### Example 1: Add Weekly Retention Rule
```powershell
PS C:\> $pol = Get-AzDataProtectionPolicyTemplate
PS C:\> $lifecycle = New-AzDataProtectionRetentionLifeCycle -SourceDataStore OperationalStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 5
PS C:\> Update-AzDataProtectionPolicyRetentionRule -Policy $pol -Name Weekly -LifeCycles $lifecycle -IsDefault $false

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

The first command gets the default policy template. The second command creates a weekly lifecycle object. The third command adds a weekly retention rule to the default policy.

### Example 2: Remove Weekly Retention Rule
```powershell
PS C:\>  Update-AzDataProtectionPolicyRetentionRule -Policy $pol -Name Weekly -RemoveRule

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command removes weekly retention rule if it exists in given backup policy.

