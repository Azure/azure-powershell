### Example 1: Roll back a mitigation
```powershell
Invoke-AzNetworkSecurityNeuroShieldMitigationRollback -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -MitigationId '<mitigation-id>'
```

Rolls back the specified mitigation.
