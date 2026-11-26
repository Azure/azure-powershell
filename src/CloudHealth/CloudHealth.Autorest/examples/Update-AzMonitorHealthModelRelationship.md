### Example 1: Tag a relationship for ownership reporting
```powershell
# Replace the tags on the relationship frontend-to-backend
Update-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend -Tag @{ tier = 'critical'; owner = 'checkout-team' }
```

Replaces the tags on the relationship.
Display name and tags are the only mutable properties of a relationship.

### Example 2: Change the display name of a relationship
```powershell
# Update the display name of the relationship frontend-to-backend
Update-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend -DisplayName 'Frontend depends on Backend API'
```

Updates the display name of an existing relationship.
