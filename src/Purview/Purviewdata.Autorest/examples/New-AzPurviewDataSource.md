### Example 1: Create a data source
```powershell
$obj = New-AzPurviewAzureStorageDataSourceObject -Kind 'AzureStorage' -CollectionReferenceName parv-brs-2 -CollectionType 'CollectionReference' -Endpoint https://datascantest.blob.core.windows.net/
New-AzPurviewDataSource -Endpoint 'https://parv-brs-2.purview.azure.com/' -Name 'NewDataSource' -Body $obj
```

```output
CollectionLastModifiedAt : 2/15/2022 10:36:25 AM
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                : 2/15/2022 10:36:25 AM
Endpoint                 : https://datascantest.blob.core.windows.net/
Id                       : datasources/NewDataSource
Kind                     : AzureStorage
LastModifiedAt           : 2/15/2022 10:36:25 AM
Location                 :
Name                     : NewDataSource
ResourceGroup            :
ResourceName             :
Scan                     :
SubscriptionId           :
```

Create a data source named 'NewDataSource'

