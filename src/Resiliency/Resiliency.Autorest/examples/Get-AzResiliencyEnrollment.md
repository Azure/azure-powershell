### Example 1: List enrollments of a usage plan
```powershell
Get-AzResiliencyEnrollment -ResourceGroupName contoso-rg -UsagePlanName contoso-usage-plan
```

Lists all service group enrollments under usage plan `contoso-usage-plan`.

### Example 2: Get an enrollment
```powershell
Get-AzResiliencyEnrollment -ResourceGroupName contoso-rg -UsagePlanName contoso-usage-plan -Name contoso-enrollment
```

Gets enrollment `contoso-enrollment`.
