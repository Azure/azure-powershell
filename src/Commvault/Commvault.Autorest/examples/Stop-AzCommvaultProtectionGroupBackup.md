### Example 1: Stop the backups of a protection group
```powershell
Stop-AzCommvaultProtectionGroupBackup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Reason 'Maintenance' -Comment 'Planned maintenance window'
```

Stops the scheduled backups of the protection group and records the reason and a comment.

### Example 2: Stop the backups of a protection group by using a JSON request
```powershell
Stop-AzCommvaultProtectionGroupBackup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -JsonString '{"reason":"Maintenance","comment":"Planned maintenance window"}'
```

Stops the scheduled backups by passing the request body as a JSON string.

