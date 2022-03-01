### Example 1: Create Azure MySQL data source object
```powershell
New-AzPurviewAzureMySqlDataSourceObject -Kind 'AzureMySql' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -Port 3306 -ServerEndpoint 'nause.mysql.database.azure.com'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzureMySql
LastModifiedAt           :
Location                 :
Name                     :
Port                     : 3306
ResourceGroup            :
ResourceName             :
Scan                     :
ServerEndpoint           : nause.mysql.database.azure.com
SubscriptionId           :
```

Create Azure MySQL data source object

