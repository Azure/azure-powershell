### Example 1: Enroll a service group in a usage plan
```powershell
New-AzResiliencyEnrollment -ResourceGroupName contoso-rg -UsagePlanName contoso-usage-plan -Name contoso-enrollment -ServiceGroupId "/providers/Microsoft.Management/serviceGroups/contoso-sg"
```

Enrolls service group `contoso-sg` in usage plan `contoso-usage-plan`.
