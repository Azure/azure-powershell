### Example 1: List all Hybrid Connections within the Relay namespace
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   connection-01 lucas-relay-rg
```

This cmdlet lists all Hybrid Connections within the Relay namespace.

### Example 2: Gets a HybridConnection within the Relay namespace
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01 | Format-List
```

```output
CreatedAt                    : 12/20/2022 6:29:13 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microso
                               ft.Relay/namespaces/namespace-pwsh01/hybridconnections/connection-01
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
UpdatedAt                    : 12/20/2022 6:29:40 AM
UserMetadata                 : 
```

This cmdlet gets a HybridConnection within the Relay namespace.

### Example 3: Gets a HybridConnection within the Relay namespace by pipeline
```powershell
Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 | Get-AzRelayHybridConnection
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   connection-01 lucas-relay-rg
```

This command gets a HybridConnection within the Relay namespace by pipeline.