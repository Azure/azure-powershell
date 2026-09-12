### Example 1: Report a health state for an entity
```powershell
# Report the signal checkout-latency as Degraded on the entity frontend-service
Invoke-AzMonitorHealthModelIngestEntityHealthReport -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -SignalName checkout-latency -HealthState Degraded -Value 142.5 -ExpiresInMinute 60
```

Sends a health report for the named signal on the entity.
ExpiresInMinute sets how long the report stays valid.
