### Example 1: Run an ad-hoc backup of a virtual machine
```powershell
Backup-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -BackupOptionBackupCopyImmediately -BackupOptionJobDescription 'Ad-hoc backup job' -BackupOptionNotifyUserOnJobCompletion -BackupOptionRunSnapShotBackup -VMList @{ VMGuid = '40000000-aaaa-4bbb-8ccc-000000000000' }
```

Starts an ad-hoc backup job for the specified virtual machine in the protection group.

### Example 2: Run an ad-hoc backup by using a JSON request
```powershell
Backup-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -JsonString '{"vmList":[{"vmGuid":"40000000-aaaa-4bbb-8ccc-000000000000"}],"backupOptions":{"backupLevel":"FULL","jobDescription":"Ad-hoc backup job","backupCopyImmediately":true,"runSnapShotBackup":true,"notifyUserOnJobCompletion":true}}'
```

Starts a full ad-hoc backup job by passing the request body as a JSON string.

