### Example 1: Get the history of one signal on an entity
```powershell
Get-AzMonitorHealthModelEntitySignalHistory -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -SignalName checkout-latency
```

Returns the recorded values for a single signal. SignalName is required.
