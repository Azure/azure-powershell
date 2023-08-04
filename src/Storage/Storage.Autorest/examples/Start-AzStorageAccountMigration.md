### Example 1: Start a Storage account migration
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -AsJob
```

This command starts a migration to Standard_LRS for Storage account myaccount under resource group myresourcegroup.

### Example 2: Start a Storage account migration by pipeline
```powershell
Get-AzStorageAccount -ResourceGroup myresourcegroup -Name myaccount | Start-AzStorageAccountMigration  -TargetSku Standard_LRS -AsJob
```

The first command gets a Storage account Id, and then the second command starts a migration to Standard_LRS for Storage account myaccount under resource group myresourcegroup.

