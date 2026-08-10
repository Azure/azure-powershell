### Example 1: Add an entity to a health model
```powershell
New-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -DisplayName 'Frontend Service' -Impact Standard -HealthObjective 99.9
```

Creates an entity representing a service, with a health objective of 99.9 percent.
