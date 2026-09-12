### Example 1: List the annotations on an entity
```powershell
# Retrieve all data annotations on the entity frontend-service
Get-AzMonitorHealthModelEntityDataAnnotation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service
```

Returns the data annotations recorded against the entity.
