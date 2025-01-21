### Example 1: Create an in-memory object for AzureBlobDatastore
```powershell
New-AzMLWorkspaceDatastoreBlobObject -AccountName mlworkspace1 -ContainerName "dataset001" -Endpoint "core.windows.net" -Protocol "https" -ServiceDataAccessAuthIdentity 'None'
```

```output
DatastoreType Description IsDefault ResourceGroup SubscriptionId AccountName  ContainerName    Endpoint         Protocol ServiceDataAccessAuthIdentity
------------- ----------- --------- ------------- -------------- -----------  -------------    --------         -------- -----------------------------
AzureBlob                                                        mlworkspace1 dataset001-work2 core.windows.net https    None
```

This command creates an in-memory object for AzureBlobDatastore.
