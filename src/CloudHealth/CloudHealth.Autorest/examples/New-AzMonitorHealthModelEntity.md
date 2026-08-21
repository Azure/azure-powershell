### Example 1: Add an entity to a health model
```powershell
# Create the entity frontend-service in the health model
New-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -DisplayName 'Frontend Service' -Impact Standard -HealthObjective 99.9
```

Creates an entity with a health objective of 99.9 percent.
