### Example 1: Change the display name of an entity
```powershell
Update-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -DisplayName 'Frontend Service (EU)'
```

Updates the display name shown for the entity in the health model.
