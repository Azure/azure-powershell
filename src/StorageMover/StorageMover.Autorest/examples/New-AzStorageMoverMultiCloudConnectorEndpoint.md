### Example 1: Create a Multi-Cloud Connector endpoint
```powershell
New-AzStorageMoverMultiCloudConnectorEndpoint -Name "my-mc-endpoint" -ResourceGroupName "my-resource-group" -StorageMoverName "my-storage-mover" -AWSS3BucketId "my-s3-bucket" -Description "My Multi-Cloud endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.StorageMover/storageMovers/my-storage-mover/endpoints/my-mc-endpoint
Name                         : my-mc-endpoint
Property                     : {
                                 "endpointType": "AzureMultiCloudConnector",
                                 "description": "My Multi-Cloud endpoint",
                                 "provisioningState": "Succeeded",
                                 "awsS3BucketId": "my-s3-bucket",
                                 "multiCloudConnectorId": "samplearmid"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/13/2023 7:21:21 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an Azure Multi-Cloud Connector endpoint.

