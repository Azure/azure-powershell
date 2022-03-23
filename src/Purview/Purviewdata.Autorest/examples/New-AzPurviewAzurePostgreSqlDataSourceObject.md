### Example 1: Create Azure PostgreSQL data source object
```powershell
New-AzPurviewAzurePostgreSqlDataSourceObject -Kind 'AzurePostgreSql' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -Port 5432 -ServerEndpoint 'nause.postgres.database.azure.com'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzurePostgreSql
LastModifiedAt           :
Location                 :
Name                     :
Port                     : 5432
ResourceGroup            :
ResourceName             :
Scan                     :
ServerEndpoint           : nause.postgres.database.azure.com
SubscriptionId           :
```

Create Azure PostgreSQL data source object0

