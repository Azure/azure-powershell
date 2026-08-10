### Example 1: Get the health history of an entity
```powershell
Get-AzMonitorHealthModelEntityHistory -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service
```

Returns how the entity's health state changed over time.
