### Example 1: Update a connection
```powershell
Update-AzStorageMoverConnection -Name "example-connection" -ResourceGroupName "examples-rg" -StorageMoverName "examples-storageMoverName" -Description "Updated Connection Description"
```

```output
Id                           : /subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.StorageMover/storageMovers/examples-storageMoverName/connections/example-connection
Name                         : example-connection
Property                     : {
                                 "description": "Updated Connection Description",
                                 "privateLinkServiceId": "/subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.Network/privateLinkServices/example-pls",
                                 "connectionStatus": "Approved"
                               }
SystemDataCreatedAt          : 7/1/2023 1:01:01 AM
SystemDataCreatedBy          : user@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/1/2023 2:01:01 AM
SystemDataLastModifiedBy     : user@example.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/connections
```

This command updates the description of a connection.

