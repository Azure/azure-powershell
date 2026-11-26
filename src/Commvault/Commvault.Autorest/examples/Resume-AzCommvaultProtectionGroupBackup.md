### Example 1: Resume the backups of a protection group
```powershell
Resume-AzCommvaultProtectionGroupBackup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms
```

Resumes the scheduled backups of a protection group whose backups were stopped.

