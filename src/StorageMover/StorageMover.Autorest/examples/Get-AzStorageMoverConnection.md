### Example 1: Get all connections under a Storage mover
```powershell
Get-AzStorageMoverConnection -ResourceGroupName "examples-rg" -StorageMoverName "examples-storageMoverName"
```

```output
Id                           : /subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.StorageMover/storageMovers/examples-storageMoverName/connections/example-connection
Name                         : example-connection
Property                     : {
                                 "description": "Example Connection Description",
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

This command gets all connections under a Storage mover.

### Example 2: Get a specific connection
```powershell
Get-AzStorageMoverConnection -ResourceGroupName "examples-rg" -StorageMoverName "examples-storageMoverName" -Name "example-connection"
```

```output
Id                           : /subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.StorageMover/storageMovers/examples-storageMoverName/connections/example-connection
Name                         : example-connection
Property                     : {
                                 "description": "Example Connection Description",
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

This command gets a specific connection.

