### Example 1: Get the status of an asynchronous operation
```powershell
Get-AzResilienceOperationStatus `
  -Location 'eastus' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Returns the current status of a long-running operation.
