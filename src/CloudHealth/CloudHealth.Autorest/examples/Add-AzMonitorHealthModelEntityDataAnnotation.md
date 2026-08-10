### Example 1: Annotate an entity with a maintenance window
```powershell
Add-AzMonitorHealthModelEntityDataAnnotation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -Description 'Planned maintenance window' -AnnotationDetail @{ startTime = '2026-08-10T09:00:00Z'; endTime = '2026-08-10T11:00:00Z' }
```

Records a maintenance window so the health history shows why the entity was degraded.
