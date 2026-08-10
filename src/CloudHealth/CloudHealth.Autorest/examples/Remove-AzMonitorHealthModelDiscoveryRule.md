### Example 1: Delete a discovery rule
```powershell
Remove-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms
```

Deletes the discovery rule. Entities it already created are kept.
