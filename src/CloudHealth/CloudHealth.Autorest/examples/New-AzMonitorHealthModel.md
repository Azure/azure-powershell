### Example 1: Create a health model
```powershell
# Create the health model azpwsh-healthmodel1 with a system-assigned identity
New-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Location eastus2 -EnableSystemAssignedIdentity
```

Creates a health model with a system-assigned managed identity.
