### Example 1: Updates the specified HybridConnection with a new description in the specified namespace.
```powershell
Set-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01 -UserMetadata "Test UserMetadata updated" | fl
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridc
                               onnections/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : Test UserMetadata updated
```

This command updates the specified HybridConnection with a new description in the specified namespace.
This example updates the UserMetadata property with new value.

### Example 2: Updates a HybridConnection in the specified Relay namespace
```powershell
$connection = Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01
$connection.UserMetadata = "testHybirdConnection"
Set-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01 -InputObject $connection                                                                     
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01/hybridc
                               onnections/connection-01
ListenerCount                : 0
Location                     : eastus
Name                         : connection-01
RequiresClientAuthorization  : True
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : Test UserMetadata updated
```

This command updates a HybridConnection in the specified Relay namespace.