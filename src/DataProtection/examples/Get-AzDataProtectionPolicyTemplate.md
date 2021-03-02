### Example 1: Get Azure Disk default policy template
```powershell
PS C:\> Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command returns a default policy template for a given datasource type. Use this policy template to create a new policy.


