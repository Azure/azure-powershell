### Example 1: Create Amazon SQL data source object
```powershell
PS C:\> New-AzPurviewAmazonSqlDataSourceObject -Kind 'AmazonSql' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -Port 1433 -ServerEndpoint DummyEdnpoint -VpcEndpointServiceName com.amazonaws.ypce.wus.123456789

CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AmazonSql
LastModifiedAt           :
Name                     :
Port                     : 1433
Scan                     :
ServerEndpoint           : DummyEdnpoint
VpcEndpointServiceName   : com.amazonaws.ypce.wus.123456789
```

Create Amazon SQL data source object

