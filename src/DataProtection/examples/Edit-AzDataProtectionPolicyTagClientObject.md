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

