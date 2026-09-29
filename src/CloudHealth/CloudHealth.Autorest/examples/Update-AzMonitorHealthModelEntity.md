### Example 1: Tighten the health objective and unhealthy severity of an entity
```powershell
# Update the health objective and unhealthy severity of the entity frontend-service
Update-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -HealthObjective 99.95 -Impact Standard -UnhealthySeverity Sev1 -UnhealthyDescription 'Checkout is failing for customers'
```

Updates the health objective, impact, unhealthy severity and unhealthy description of the entity.

### Example 2: Change the display name of an entity
```powershell
# Update the display name of the entity frontend-service
Update-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-service -DisplayName 'Frontend Service (EU)'
```

Updates the display name shown for the entity in the health model.
