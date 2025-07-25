### Example 1: Updates the description for the WcfRelay in the specified Relay namespace with InputObject
```powershell
$wcf = Get-AzWcfRelay -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name wcfRelay-01
$wcf.UserMetadata = "User Meta Data"
Set-AzWcfRelay -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name wcfRelay-01 -InputObject $wcf | Format-List
```

```output
CreatedAt                    : 1/1/0001 12:00:00 AM 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfrelays/wcfRe 
                               lay-01
IsDynamic                    : False
ListenerCount                : 0
Location                     : eastus
Name                         : wcfRelay-01
RelayType                    : NetTcp
RequiresClientAuthorization  : False
RequiresTransportSecurity    : False
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays
UpdatedAt                    : 1/1/0001 12:00:00 AM
UserMetadata                 : User Meta Data
```

This command updates the description for the WcfRelay in the specified Relay namespace.

### Example 2: Updates the description for the WcfRelay in the specified Relay namespace with Properties
```powershell
Set-AzWcfRelay -ResourceGroupName Relay-ServiceBus-EastUS -Namespace namespace-pwsh01 -Name wcfRelay-01 -UserMetadata "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored." | Format-List
```

```output
CreatedAt                    : 3/30/2023 1:56:56 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Relay-ServiceBus-EastUS/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfrelays/wcfRe 
                               lay-01
IsDynamic                    : False
ListenerCount                : 0
Location                     : eastus
Name                         : wcfRelay-01
RelayType                    : NetTcp
RequiresClientAuthorization  : False
RequiresTransportSecurity    : False
ResourceGroupName            : Relay-ServiceBus-EastUS
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays
UpdatedAt                    : 3/30/2023 2:53:03 AM
UserMetadata                 : usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store descriptive data, such as list    
                               of teams and their contact information also user-defined configuration settings can be stored.
```

This command updates the specified WcfRelay with a new description in the specified namespace.
This example updates the UserMetadata property with new value.