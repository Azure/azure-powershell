### Example 1: Create a connection
```powershell
New-AzStorageMoverConnection -Name "example-connection" -ResourceGroupName "examples-rg" -StorageMoverName "examples-storageMoverName" -PrivateLinkServiceId "/subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.Network/privateLinkServices/example-pls" -Description "Example Connection Description"
```

```output
Id                           : /subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.StorageMover/storageMovers/examples-storageMoverName/connections/example-connection
Name                         : example-connection
Property                     : {
                                 "description": "Example Connection Description",
                                 "privateLinkServiceId": "/subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.Network/privateLinkServices/example-pls",
                                 "connectionStatus": "Pending Approval"
                               }
SystemDataCreatedAt          : 7/1/2023 1:01:01 AM
SystemDataCreatedBy          : user@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/1/2023 2:01:01 AM
SystemDataLastModifiedBy     : user@example.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/connections
```

This command creates a connection for a Storage mover.

