### Example 1: Delete an entity
```powershell
# Delete the entity frontend-service
Remove-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service
```

Deletes the entity from the health model.
