### Example 1: Create an enrollment
```powershell
New-AzResilienceEnrollment `
  -Name 'enr-payments' `
  -ResourceGroupName 'rg-resiliency-prod' `
  -UsagePlanName 'up-payments' `
  -ServiceGroupId '/providers/Microsoft.Management/serviceGroups/azcmdlet-testing'
```

Creates a new enrollment in the specified resource group.
