### Example 1: Creates a Hybrid Connection in the specified Relay namespace
```powershell
New-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01 -UserMetadata "test 01" | Format-List
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
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
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : 
```

This cmdlet creates a Hybrid Connection in the specified Relay namespace.

### Example 2: Create a new Hybrid Connection using an existing Hybrid Connection as a parameter
```powershell
$connection = Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-01
$connection.RequiresClientAuthorization = $false
New-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-02 -InputObject $connection | Format-List
```

```output
CreatedAt                    : 12/20/2022 9:13:18 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/hybridconnections/connection-02
ListenerCount                : 0
Location                     : eastus
Name                         : connection-02
RequiresClientAuthorization  : False
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 12/20/2022 9:13:18 AM
UserMetadata                 : test 03
```

This cmdlet creates a new Hybrid Connection using an existing Hybrid Connection as a parameter.

### Example 3: Update an existing Hybrid Connection
```powershell
$connection = Get-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-02
$connection.UserMetadata = "TestHybirdConnection2"
New-AzRelayHybridConnection -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name connection-02 -InputObject $connection | Format-List
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/hybridconnections/connection-02
ListenerCount                : 0
Location                     : eastus
Name                         : connection-02
RequiresClientAuthorization  : False
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : TestHybirdConnection2
```

This cmdlet updates an existing Hybrid Connection.