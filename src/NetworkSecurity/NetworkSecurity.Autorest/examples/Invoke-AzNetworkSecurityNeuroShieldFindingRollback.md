### Example 1: Roll back a finding mitigation
```powershell
Invoke-AzNetworkSecurityNeuroShieldFindingRollback -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -FindingId '<finding-id>'
```

Requests rollback for the specified finding.
