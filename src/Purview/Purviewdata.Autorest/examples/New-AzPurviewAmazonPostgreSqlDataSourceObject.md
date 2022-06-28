### Example 1: Create Amazon PostgreSQL data source object
```powershell
New-AzPurviewAmazonPostgreSqlDataSourceObject -Kind 'AmazonPostgreSql' -Port 5432 -VpcEndpointServiceName 'com.amazonaws.ypce.wus.123456789' -ServerEndpoint 'DummyServer' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AmazonPostgreSql
LastModifiedAt           :
Name                     :
Port                     : 5432
Scan                     :
ServerEndpoint           : DummyServer
VpcEndpointServiceName   : com.amazonaws.ypce.wus.123456789
```

Create Amazon PostgreSQL data source object

