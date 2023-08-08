### Example 1: Start a Storage account migration
```powershell
Start-AzStorageAccountMigration -AccountName myaccount -ResourceGroupName myresourcegroup -TargetSku Standard_LRS -Name migration1 -AsJob
```

This command starts a migration to Standard_LRS for Storage account myaccount under resource group myresourcegroup.

### Example 2: Start a Storage account migration by pipeline
```powershell
Get-AzStorageAccount -ResourceGroupName myresourcegroup -Name myaccount | Start-AzStorageAccountMigration  -TargetSku Standard_LRS -AsJob
```

The first command gets a Storage account Id, and then the second command starts a migration to Standard_LRS for Storage account myaccount under resource group myresourcegroup.

### Example 3: Start a Storage account migration with Json string input
```powershell
$properties = '{
   "properties": {
     "targetSkuName": "Standard_ZRS"
   }
}'
 Start-AzStorageAccountMigration -ResourceGroupName myresourcegroup -AccountName myaccount -JsonString $properties -AsJob
```

This command starts a Storage account migration by inputting the TargetSkuName property with a Json string.

### Example 4: Start a Storage account migration with a Json file path input
```powershell
# Before executing the cmdlet, make sure you have a json file that contains {"properties": {"targetSkuName": <TargetSKU>}} 
Start-AzStorageAccountMigration -ResourceGroupName myresourcegroup -AccountName myaccount -JsonFilePath properties.json -AsJob
```

This command starts a Storage account migration by inputting the TargetSkuName property with a Json file path.
