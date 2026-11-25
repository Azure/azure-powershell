### Example 1: Create a NeuroShield in manual response mode
```powershell
New-AzNetworkSecurityNeuroShield -ResourceGroupName 'myResourceGroup' -Name 'myNeuroShield' -Location '<supported-region>' -ResponseMode Manual -SeverityThreshold Medium
```

Creates a NeuroShield. Replace the location placeholder with a region enabled for your subscription.
