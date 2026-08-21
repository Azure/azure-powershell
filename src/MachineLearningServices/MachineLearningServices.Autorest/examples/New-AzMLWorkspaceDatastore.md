### Example 1: Create or update datastore
```powershell
# The datastore type includes AzureBlob, AzureDataLakeGen1, AzureDataLakeGen2, AzureFile.
# You can use following command to create it then pass it as value to Datastore parameter of the New-AzMLWorkspaceDatastore cmdlet.
# New-AzMLWorkspaceDatastoreBlobObject
# New-AzMLWorkspaceDatastoreDataLakeGen1Object
# New-AzMLWorkspaceDatastoreDataLakeGen2Object
# New-AzMLWorkspaceDatastoreFileObject
# You can specify credentials when creating a datastore type. The following commands can be used to create credentials.
# New-AzMLWorkspaceDatastoreKeyCredentialObject
# New-AzMLWorkspaceDatastoreCredentialsObject
# New-AzMLWorkspaceDatastoreNoneCredentialsObject
# New-AzMLWorkspaceDatastoreSasCredentialsObject
# New-AzMLWorkspaceDatastoreServicePrincipalCredentialsObject

$accountKey = New-AzMLWorkspaceDatastoreKeyCredentialObject -Key "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
$datastoreBlob = New-AzMLWorkspaceDatastoreBlobObject -AccountName 'mmstorageeastus' -ContainerName "globaldatasets" -Endpoint "core.windows.net" -Protocol "https" -ServiceDataAccessAuthIdentity 'None' -Credentials $accountKey
New-AzMLWorkspaceDatastore -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name blobdatastore -Datastore $datastoreBlob
```

```output
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/datastores/blobdatastore
Name                         : blobdatastore
Property                     : {
                                 "credentials": {
                                   "credentialsType": "AccountKey"
                                 },
                                 "datastoreType": "AzureBlob",
                                 "isDefault": false,
                                 "accountName": "mmstorageeastus",
                                 "containerName": "globaldatasets",
                                 "endpoint": "core.windows.net",
                                 "protocol": "https",
                                 "serviceDataAccessAuthIdentity": "None"
                               }
ResourceGroupName            : ml-test
SystemDataCreatedAt          : 11/5/2025 8:56:55 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 8:56:55 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Type                         : Microsoft.MachineLearningServices/workspaces/datastores
```

These commands create a datastore for specified workspace.
