### Example 1: Change the display name of a relationship
```powershell
Update-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend -DisplayName 'Frontend depends on Backend API'
```

Updates the display name of an existing relationship.
