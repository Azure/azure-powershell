### Example 1: Update a Multi-Cloud Connector endpoint
```powershell
Update-AzStorageMoverMultiCloudConnectorEndpoint -Name "my-mc-endpoint" -ResourceGroupName "my-resource-group" -StorageMoverName "my-storage-mover" -Description "My updated Multi-Cloud endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.StorageMover/storageMovers/my-storage-mover/endpoints/my-mc-endpoint
Name                         : my-mc-endpoint
Property                     : {
                                 "endpointType": "AzureMultiCloudConnector",
                                 "description": "My updated Multi-Cloud endpoint",
                                 "provisioningState": "Succeeded",
                                 "awsS3BucketId": "my-s3-bucket",
                                 "multiCloudConnectorId": "samplearmid"
                               }
SystemDataCreatedAt          : 6/27/2023 4:30:13 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/14/2023 8:00:00 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the description of an Azure Multi-Cloud Connector endpoint.

