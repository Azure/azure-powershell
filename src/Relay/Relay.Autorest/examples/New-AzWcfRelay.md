### Example 1: Create a new Wcf Relay 
```powershell
New-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-02 -WcfRelayType 'NetTcp' -UserMetadata "test 01"
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
UpdatedAt                    : 12/20/2022 9:01:10 AM
UserMetadata                 : test 01
```

This command creates a new Wcf Relay.

### Example 2: Create a new Wcf Relay using an existing Wcf Relay as a parameter
```powershell
$wcf = Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-02
$wcf.UserMetadata = "User Date"
New-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-03 -InputObject $wcf
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
eastus   wcf-03 lucas-relay-rg
```

This command creates a new Wcf Relay using an existing Wcf Relay as a parameter.

### Example 3: Update an existing Wcf Relay
```powershell
$wcf = Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-02
$wcf.UserMetadata = "User Date"
New-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-02 -InputObject $wcf
```

```output
Location Name   ResourceGroupName
-------- ----   -----------------
eastus   wcf-02 lucas-relay-rg
```

This command updates an existing Wcf Relay.