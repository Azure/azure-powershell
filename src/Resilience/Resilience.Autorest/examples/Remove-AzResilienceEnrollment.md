### Example 1: Delete an enrollment
```powershell
Remove-AzResilienceEnrollment `
  -Name 'enr-payments' `
  -ResourceGroupName 'rg-resiliency-prod' `
  -UsagePlanName 'up-payments'
```

Deletes the specified enrollment.
