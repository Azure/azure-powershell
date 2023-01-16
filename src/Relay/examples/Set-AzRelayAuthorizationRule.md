### Example 1: Adds Send from the access rights of the authorization rule for the Relay namespace
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03 -Rights 'Listen' | fl
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace
                               -pwsh01/authorizationRules/authRule-03
Location                     : eastus
Name                         : authRule-03
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/AuthorizationRules
```

This cmdlet adds Send from the access rights of the authorization rule for the Relay namespace.

### Example 2: Adds Send from the access rights of the authorization rule for the Relay namespace with InputeObject parameter
```powershell
$authRule = Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03
$authRule.Rights += 'Send'
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03 -InputObject $authRule | fl
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace
                               -pwsh01/authorizationRules/authRule-03
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

This cmdlet adds Send from the access rights of the authorization rule for the Relay namespace with InputeObject parameter.

### Example 3: Adds Send from the access rights of the authorization rule for the Hybrid Connection
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01 -Rights 'Listen' | fl
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace
                               -pwsh01/hybridConnections/connection-01/authorizationRules/authRule-01
Location                     : 
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

This cmdlet adds Send from the access rights of the authorization rule for the Hybrid Connection.

### Example 4: Adds Send from the access rights of the authorization rule for the Hybrid Connection with InputeObject parameter
```powershell
$authRule = Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01
$authRule.Rights += 'Send'
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01 -InputObject $authRule | fl
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace
                               -pwsh01/hybridConnections/connection-01/authorizationRules/authRule-01
Location                     : 
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

This cmdlet adds Send from the access rights of the authorization rule for the Hybrid Connection with InputeObject parameter.

### Example 5: Adds Send from the access rights of the authorization rule for the Wcf Relay
```powershell
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01 -Name authRule-01 -Rights 'Listen' | fl
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfRela
                               ys/wcf-01/authorizationRules/authRule-01
Location                     : 
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays/authorizationrules
```

This cmdlet adds Send from the access rights of the authorization rule for the Wcf Relay.

### Example 6: Adds Send from the access rights of the authorization rule for the Wcf Relay with InputeObject parameter
```powershell
$authRule = Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01 -Name authRule-01
$authRule.Rights += 'Send'
Set-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01 -Name authRule-01 -InputObject $authRule | fl
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01/wcfRela
                               ys/wcf-01/authorizationRules/authRule-01
Location                     : 
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

This cmdlet adds Send from the access rights of the authorization rule for the Wcf Relay with InputeObject parameter.