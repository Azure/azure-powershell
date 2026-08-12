### Example 1: Connect two entities
```powershell
# Create the relationship frontend-to-backend between two entities
New-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend -ParentEntityName frontend-service -ChildEntityName backend-api
```

Creates a parent-child relationship between two entities.
