### Example 1: Connect two entities
```powershell
New-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend -ParentEntityName frontend-service -ChildEntityName backend-api
```

Makes the frontend service depend on the backend API, so the child's health rolls up into the parent.
