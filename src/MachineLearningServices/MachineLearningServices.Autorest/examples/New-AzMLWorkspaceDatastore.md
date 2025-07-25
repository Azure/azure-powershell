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
New-AzMLWorkspaceDatastore -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-demo -Name blobdatastore -Datastore $datastoreBlob
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----          -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
blobdatastore 5/27/2022 7:15:04 AM UserName (Example)  User                    5/27/2022 7:15:05 AM     UserName (Example)       User                         ml-rg-test
```

These commands create a datastore for specified workspace.
