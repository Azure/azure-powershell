### Example 1: Updates the description for the WcfRelay in the specified Relay namespace
```powershell
$wcf = Get-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-01
$wcf.UserMetadata = "User Date"
Set-AzWcfRelay -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name wcf-01 -InputObject $wcf | fl
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfRela
                               ys/wcf-01
IsDynamic                    : 
ListenerCount                : 
Location                     : 
Name                         : wcf-01
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
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : User Date
```

This command updates the description for the WcfRelay in the specified Relay namespace.