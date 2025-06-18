### Example 1: Update a data source
```powershell
Update-AzPurviewDataSource -Endpoint 'https://parv-brs-2.purview.azure.com/' -Name 'NewDataSource' -Kind SqlServerDatabase
```

```output
CollectionLastModifiedAt : 2/15/2022 10:36:25 AM
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                : 2/15/2022 10:36:25 AM
Endpoint                 : https://datascantest.blob.core.windows.net/
Id                       : datasources/NewDataSource
Kind                     : SqlServerDatabase
LastModifiedAt           : 2/15/2022 10:36:25 AM
Location                 :
Name                     : NewDataSource
ResourceGroup            :
ResourceName             :
Scan                     :
SubscriptionId           :
```

Update a data source