### Example 1: Validate drill execution validation
```powershell
Test-AzResilienceDrillExecutionValidation `
  -DrillName 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ValidateForExecutionPropertySourceLocation @('eastus')
```

Checks whether the operation can proceed and reports qualified and unqualified resources.
