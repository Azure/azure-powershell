### Example 1: Replace an enrollment
```powershell
Set-AzResilienceEnrollment `
  -Name 'enr-payments' `
  -ResourceGroupName 'rg-resiliency-prod' `
  -UsagePlanName 'up-payments' `
  -ServiceGroupId '/providers/Microsoft.Management/serviceGroups/azcmdlet-testing'
```

Replaces the specified enrollment. Properties that are not supplied are reset.
