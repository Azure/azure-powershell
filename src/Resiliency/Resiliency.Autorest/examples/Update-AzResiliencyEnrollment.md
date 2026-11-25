### Example 1: Update an enrollment
```powershell
Update-AzResiliencyEnrollment -ResourceGroupName contoso-rg -UsagePlanName contoso-usage-plan -Name contoso-enrollment -ServiceGroupId "/providers/Microsoft.Management/serviceGroups/contoso-sg"
```

Updates the service group of an existing enrollment.
