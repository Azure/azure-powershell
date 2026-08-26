### Example 1: Restore a mongo cluster to a point in time
```powershell
$password = ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
Restore-AzDocumentDBMongoCluster -Name myRestoredCluster -ResourceGroupName myResourceGroup -Location eastus2 `
    -SourceCluster myCluster -RestoreTime '2026-01-01T00:00:00Z' `
    -AdministratorUserName testadmin -AdministratorPassword $password
```

```output
Name                 Location ProvisioningState
----                -------- -----------------
myRestoredCluster   eastus2  Succeeded
```

Restore a new mongo cluster from a source cluster at a given point in time. The
restore time must fall within the source cluster's backup retention window; read
`properties.backup.earliestRestoreTime` on the source cluster for the earliest
available point.
