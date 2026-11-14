### Example 1: List findings across a NeuroShield
```powershell
Get-AzNetworkSecurityNeuroShieldFinding -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield'
```

Lists findings across the NeuroShield's protected resources.

### Example 2: List findings for a protected resource
```powershell
Get-AzNetworkSecurityNeuroShieldFinding -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource'
```

Lists findings for the specified protected resource.

### Example 3: Get a finding
```powershell
Get-AzNetworkSecurityNeuroShieldFinding -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -FindingId '<finding-id>'
```

Gets the specified finding.
