### Example 1: Add Weekly tag to Backup Policy
```powershell
PS C:\> $criteria = New-AzDataProtectionPolicyTagCriteriaClientObject -AbsoluteCriteria FirstOfWeek
PS C:\> Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -Criteria $criteria

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command adds a weekly tag to given backup policy

### Example 2: Remove Weeky tag from Backup Policy
```powershell
PS C:\> Edit-AzDataProtectionPolicyTagClientObject -Policy $pol -Name Weekly -RemoveRule

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command removes Weekly tag from backup policy.

