### Example 1: Delete a signal definition
```powershell
# Delete the signal definition cpu-utilization
Remove-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name cpu-utilization
```

Deletes the signal definition from the health model.
