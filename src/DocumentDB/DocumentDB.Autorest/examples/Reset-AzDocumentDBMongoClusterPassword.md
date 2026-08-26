### Example 1: Reset the administrator password of a mongo cluster
```powershell
$password = ConvertTo-SecureString 'CliReset2026!Pw' -AsPlainText -Force
Reset-AzDocumentDBMongoClusterPassword -Name myCluster -ResourceGroupName myResourceGroup -AdministratorPassword $password
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myCluster   eastus2  Succeeded
```

Reset the administrator password of a mongo cluster. The administrator user name is
read from the existing cluster, so only the new password is supplied. The `-Password`
alias can be used in place of `-AdministratorPassword`.
