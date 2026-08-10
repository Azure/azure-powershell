### Example 1: Report a health state for an entity
```powershell
Invoke-AzMonitorHealthModelIngestEntityHealthReport -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -SignalName checkout-latency -HealthState Degraded -Value 142.5 -ExpiresInMinute 60
```

Pushes an external health signal into the model. The report expires after 60 minutes unless it is sent again.
