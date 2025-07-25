### Example 1: Remove an authorization rule description of the Relay namespace
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03
```

```output
```

This cmdlet removes an authorization rule description of the Relay namespace.

### Example 2: Remove an authorization rule description of the Hybrid Connection
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01
```

```output
```

This cmdlet removes an authorization rule description of the Hybrid Connection.

### Example 3: Remove an authorization rule description of the Wcf Relay
```powershell
Remove-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-02 -Name authRule-01
```

```output
```

This cmdlet removes an authorization rule description of the Wcf Relay.

### Example 4: Remove authorization rule by pipeline
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-02 | Remove-AzRelayAuthorizationRule
```

```output
```

This cmdlet removes authorization rule by pipeline.