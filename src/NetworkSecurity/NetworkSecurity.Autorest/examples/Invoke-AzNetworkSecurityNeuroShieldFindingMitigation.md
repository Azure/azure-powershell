### Example 1: Mitigate a finding
```powershell
Invoke-AzNetworkSecurityNeuroShieldFindingMitigation -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -FindingId '<finding-id>'
```

Requests mitigation of the specified finding.
