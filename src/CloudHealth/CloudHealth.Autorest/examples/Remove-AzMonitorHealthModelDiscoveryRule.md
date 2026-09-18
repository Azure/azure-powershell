### Example 1: Delete a discovery rule
```powershell
# Delete the discovery rule discover-vms
Remove-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms
```

Deletes the discovery rule and the entity that represents it in the health model.
