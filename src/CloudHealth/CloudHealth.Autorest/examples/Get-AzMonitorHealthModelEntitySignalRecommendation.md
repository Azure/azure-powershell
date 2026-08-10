### Example 1: List recommended signals for an entity
```powershell
Get-AzMonitorHealthModelEntitySignalRecommendation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service
```

Suggests signals for the entity based on the Azure resource assigned to it. The entity must have a resource assigned.
