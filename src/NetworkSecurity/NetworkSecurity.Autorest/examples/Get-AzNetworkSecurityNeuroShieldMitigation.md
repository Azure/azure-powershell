### Example 1: List mitigations across a NeuroShield
```powershell
Get-AzNetworkSecurityNeuroShieldMitigation -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield'
```

Lists mitigations across the NeuroShield's protected resources.

### Example 2: List mitigations for a protected resource
```powershell
Get-AzNetworkSecurityNeuroShieldMitigation -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource'
```

Lists mitigations for the specified protected resource.

### Example 3: Get a mitigation
```powershell
Get-AzNetworkSecurityNeuroShieldMitigation -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -MitigationId '<mitigation-id>'
```

Gets the specified mitigation.
