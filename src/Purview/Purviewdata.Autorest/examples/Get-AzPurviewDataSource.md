### Example 1: Get a data source by name
```powershell
Get-AzPurviewDataSource -Endpoint 'https://brs-2.purview.azure.com/' -Name 'NewDataSource'
```

```output
CollectionLastModifiedAt : 2/9/2022 2:49:14 AM
CollectionReferenceName  : brs-2
CollectionType           : CollectionReference
CreatedAt                : 2/9/2022 2:49:14 AM
Endpoint                 : https://data123scantest.blob.core.windows.net/
Id                       : datasources/NewDataSource
Kind                     : AzureStorage
LastModifiedAt           : 2/9/2022 3:02:56 AM
Location                 : westus
Name                     : NewDataSource
ResourceGroup            : rg
ResourceName             : datascantest
Scan                     :
SubscriptionId           : 4348d67b-ffc5-465d-b5dd-xxxxxxxxx
```

Get a data source named 'NewDataSource'

### Example 2: Get all data sources
```powershell
Get-AzPurviewDataSource -Endpoint 'https://brs-2.purview.azure.com/'
```

```output
CollectionLastModifiedAt : 1/31/2022 10:28:16 AM
CollectionReferenceName  : brs-2
CollectionType           : CollectionReference
CreatedAt                : 1/31/2022 10:28:16 AM
Endpoint                 : https://0cb22aa692584b54b09files.file.core.windows.net/
Id                       : datasources/AzureFileStorage-f1B
Kind                     : AzureFileService
LastModifiedAt           : 1/31/2022 10:28:16 AM
Location                 : westus2
Name                     : AzureFileStorage-f1B
ResourceGroup            : scanning-wus2-df-files
ResourceName             : 0cb22aa692584b54b09files
Scan                     :
SubscriptionId           : aa41bbd9-a6aa-44a8-b5cb-xxxxxxxxx

CollectionLastModifiedAt : 2/9/2022 2:49:14 AM
CollectionReferenceName  : brs-2
CollectionType           : CollectionReference
CreatedAt                : 2/9/2022 2:49:14 AM
Endpoint                 : https://datascan123test.blob.core.windows.net/
Id                       : datasources/NewDataSource
Kind                     : AzureStorage
LastModifiedAt           : 2/9/2022 3:02:56 AM
Location                 : westus
Name                     : NewDataSource
ResourceGroup            : rg
ResourceName             : datascantest
Scan                     :
SubscriptionId           : 4348d67b-ffc5-465d-b5dd-xxxxxxxxx
```

Get all data sources

