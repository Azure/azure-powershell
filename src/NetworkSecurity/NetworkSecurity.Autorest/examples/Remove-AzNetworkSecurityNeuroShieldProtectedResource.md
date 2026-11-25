### Example 1: Remove a protected resource registration
```powershell
Remove-AzNetworkSecurityNeuroShieldProtectedResource -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource'
```

Removes the protected resource registration and waits for the asynchronous operation to complete.
