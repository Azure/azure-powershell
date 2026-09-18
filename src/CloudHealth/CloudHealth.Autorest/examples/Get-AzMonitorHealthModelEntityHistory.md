### Example 1: Get the health history of an entity
```powershell
# Retrieve the health state history of the entity frontend-service
Get-AzMonitorHealthModelEntityHistory -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service
```

Returns the health state history recorded for the entity.
