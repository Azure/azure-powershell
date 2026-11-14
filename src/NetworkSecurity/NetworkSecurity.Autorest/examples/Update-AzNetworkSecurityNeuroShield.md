### Example 1: Update a NeuroShield's description and tags
```powershell
Update-AzNetworkSecurityNeuroShield -ResourceGroupName 'myResourceGroup' -Name 'myNeuroShield' -Description 'Production fleet protection' -Tag @{ environment = 'production' }
```

Patches the NeuroShield without replacing the resource.
