### Example 1: Annotate an entity with a maintenance window
```powershell
# Add a data annotation to the entity frontend-service
Add-AzMonitorHealthModelEntityDataAnnotation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -Description 'Planned maintenance window' -AnnotationDetail @{ startTime = '2026-08-10T09:00:00Z'; endTime = '2026-08-10T11:00:00Z' }
```

Adds a data annotation with a start and end time to the entity.
