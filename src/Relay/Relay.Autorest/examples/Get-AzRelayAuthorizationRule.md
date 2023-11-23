### Example 1: List all Authorization Rules of the Relay namespace
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus   RootManageSharedAccessKey lucas-relay-rg
eastus   authRule-03               lucas-relay-rg
```

This cmdlet lists all Authorization Rules of the Relay namespace.

### Example 2: Get the specified authorization rule description for a given Relay namespace
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03 | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/authorizationrules/authRule-03
Location                     : eastus
Name                         : authRule-03
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/AuthorizationRules
```

This cmdlet gets the specified authorization rule description for a given Relay namespace.

### Example 3: List all Authorization Rules of the Hybrid Connection
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   authRule-01 lucas-relay-rg
```

This cmdlet lists all Authorization Rules of the Hybrid Connection.

### Example 4: Get the specified authorization rule description for a given Hybrid Connection
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01 | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/hybridconnections/connection-01/authorizationrules/authRule-01
Location                     : eastus
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections/authorizationrules
```

This cmdlet gets the specified authorization rule description for a given Hybrid Connection.

### Example 5: List all Authorization Rules of the Wcf Relay
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   authRule-01 lucas-relay-rg
```

This cmdlet lists all Authorization Rules of the Wcf Relay.

### Example 6: Get the specified authorization rule description for a given Wcf Relay
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay connection-01 -Name authRule-01 | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/wcfrelays/connection-01/authorizationrules/authRule-01
Location                     : eastus
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays/authorizationrules
```

This cmdlet gets the specified authorization rule description for a given Wcf Relay.

### Example 7: Get the specified authorization rule description by pipeline
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 | Get-AzRelayAuthorizationRule
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus   RootManageSharedAccessKey lucas-relay-rg
eastus   authRule-03               lucas-relay-rg
```

This cmdlet gets the specified authorization rule description by pipeline.