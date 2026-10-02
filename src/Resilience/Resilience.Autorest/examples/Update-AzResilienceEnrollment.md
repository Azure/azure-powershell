### Example 1: Update an enrollment
```powershell
Update-AzResilienceEnrollment `
  -Name 'enr-payments' `
  -ResourceGroupName 'rg-resiliency-prod' `
  -UsagePlanName 'up-payments'
```

Updates the specified enrollment, preserving properties that are not supplied.
