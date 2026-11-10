### Example 1: Get the default fleet summary
```powershell
Get-AzNetworkSecurityNeuroShieldSummary -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield'
```

Gets the NeuroShield's default aggregate fleet summary.

### Example 2: List summaries
```powershell
Get-AzNetworkSecurityNeuroShieldSummary -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -Top 50
```

Uses the list parameter set to retrieve summaries.
