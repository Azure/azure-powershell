### Example 1: Updates the specified HybridConnection with a new UserMetadata in the specified namespace.
```powershell
Set-AzRelayHybridConnection -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name connection-01 -UserMetadata "Update UserMetaData" | Format-List
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridconnectio 
                               ns/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : Update UserMetaData
```

This command updates the specified HybridConnection with a new UserMetadata in the specified namespace.
This example updates the UserMetadata property with new value.

### Example 2: Updates a HybridConnection in the specified Relay namespace
```powershell
$connection = Get-AzRelayHybridConnection -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name connection-01
$connection.UserMetadata = "testHybirdConnection"
Set-AzRelayHybridConnection -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name connection-01 -InputObject $connection | Format-List
```

```output
CreatedAt                    : 3/30/2023 3:34:25 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridconnectio 
                               ns/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 3/30/2023 6:28:37 AM
UserMetadata                 : testHybirdConnection
```

This command updates a HybridConnection in the specified Relay namespace.