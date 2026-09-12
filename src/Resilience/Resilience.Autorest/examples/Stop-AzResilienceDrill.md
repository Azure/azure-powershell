### Example 1: Stop a drill
```powershell
Stop-AzResilienceDrill `
  -Name 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -Attestation 'Success' `
  -AttestationNote 'Drill completed; all tier-1 services recovered within RTO.'
```

Stops the running drill and records the attestation outcome.
