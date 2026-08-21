### Example 1: Delete a relationship
```powershell
# Delete the relationship frontend-to-backend
Remove-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend
```

Deletes the relationship between the two entities.
