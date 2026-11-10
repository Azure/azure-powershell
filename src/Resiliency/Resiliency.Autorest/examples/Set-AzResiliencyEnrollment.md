### Example 1: Replace an enrollment
```powershell
Set-AzResiliencyEnrollment -ResourceGroupName contoso-rg -UsagePlanName contoso-usage-plan -Name contoso-enrollment -ServiceGroupId "/providers/Microsoft.Management/serviceGroups/contoso-sg"
```

Replaces the enrollment with the supplied definition (PUT).
