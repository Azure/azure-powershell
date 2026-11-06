### Example 1: List protected resources
```powershell
Get-AzNetworkSecurityNeuroShieldProtectedResource -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield'
```

Lists the NeuroShield's protected resources.

### Example 2: Get a protected resource
```powershell
Get-AzNetworkSecurityNeuroShieldProtectedResource -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource'
```

Gets the specified protected resource.
