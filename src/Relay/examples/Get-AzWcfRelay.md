### Example 1: List all Wcf Relays within the Relay namespace 
```powershell
Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
eastus   wcf-02 lucas-relay-rg
eastus   wcf-03 lucas-relay-rg
```

This cmdlet lists all Wcf Relays within the Relay namespace.

### Example 2: Get a Wcf Relay
```powershell
Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-02 | Format-List
```

```output
CreatedAt                    : 12/20/2022 9:01:10 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/wcfrelays/wcf-02
IsDynamic                    : False
ListenerCount                : 0
Location                     : eastus
Name                         : wcf-02
RelayType                    : NetTcp
RequiresClientAuthorization  : False
RequiresTransportSecurity    : False
ResourceGroupName            : lucas-relay-rg
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays
UpdatedAt                    : 12/20/2022 9:21:58 AM
UserMetadata                 : User Date
```

This cmdlet gets a Wcf Relay.

### Example 3: Get a Wcf Relay by pipeline
```powershell
Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 | Get-AzWcfRelay
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
eastus   wcf-02 lucas-relay-rg
eastus   wcf-03 lucas-relay-rg
```

This cmdlet gets a Wcf Relay by pipeline.