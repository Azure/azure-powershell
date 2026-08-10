### Example 1: Create a health model
```powershell
New-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Location eastus2 -EnableSystemAssignedIdentity
```

Creates a health model with a system-assigned managed identity, which discovery rules and signals use to read monitoring data.
