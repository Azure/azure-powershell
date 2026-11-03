### Example 1: List recommended signals for an entity
```powershell
# Retrieve the recommended signals for the entity frontend-service
Get-AzMonitorHealthModelEntitySignalRecommendation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service
```

Returns recommended signals for the entity.
The entity must have an Azure resource assigned.
