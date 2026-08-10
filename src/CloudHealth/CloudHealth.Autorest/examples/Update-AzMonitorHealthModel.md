### Example 1: Update the tags on a health model
```powershell
Update-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Tag @{ environment = 'production' }
```

Replaces the tags on an existing health model.
