### Example 1: Get a Storage account migration 
```powershell
Get-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresroucegroup
```

```output
DetailMigrationFailedDetailedReason :
DetailMigrationFailedReason         :
DetailMigrationStatus               : SubmittedForConversion
DetailTargetSkuName                 : Standard_LRS
Id                                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresroucegroup/providers/Microsoft.Storage/storageAccounts/myaccount/accountMigrations/default
Name                                : default
ResourceGroupName                   : myresroucegroup
Type                                : Microsoft.Storage/storageAccounts/accountMigrations
```

This command gets the migration status of the storage account myaccount under resource group myresourcegroup.


