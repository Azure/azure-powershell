### Example 1: Create or update data version
```powershell
New-AzMLWorkspaceDataVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name iris-data -Version 1 -DataType 'uri_file' -DataUri "https://mltestaccount03.blob.core.windows.net/azureml-blobstore-11111111-2222-3333-4444-123456789103/datasets/greenTaxiData.csv"
```

```output
DataType                     : uri_file
DataUri                      : https://mltestaccount03.blob.core.windows.net/azureml-blobstore-11111111-2222-3333-4444-123456789103/datasets/greenTaxiData.csv
Description                  : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/data/iris-data/versions/1
IsAnonymou                   : False
IsArchived                   : False
Name                         : 1
Property                     : {
                                 "isAnonymous": false,
                                 "isArchived": false,
                                 "dataType": "uri_file",
                                 "dataUri": "https://mltestaccount03.blob.core.windows.net/azureml-blobstore-11111111-2222-3333-4444-123456789103/datasets/greenTaxiData.csv"
                               }
ResourceBaseProperty         : {
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 9:23:40 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 9:23:40 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/data/versions
XmsAsyncOperationTimeout     : 
```

This command creates data version.
