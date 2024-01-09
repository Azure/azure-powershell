### Example 1: Increase student usage quota.
```powershell
Add-AzLabUserQuota -ResourceGroupName "group name" -LabName "lab name" -Email 'student@contoso.com' -UsageQuotaToAddToExisting $(New-Timespan -Hours 4)

Name           Type
----           ----
testuser       Microsoft.LabServices/labs/users
```

This command increase the students quota by 4 hours.

### Example 2: Increase student usage quota with User object.
```powershell
$user = Get-AzLabUser -ResourceGroupName "group name" -LabName "lab name" -UserName 'ContosoUser12345'
$user | Add-AzLabUserQuota -UsageQuotaToAddToExisting $(New-Timespan -Hours 5)

Name                 Type
----                 ----
ContosoUser12345     Microsoft.LabServices/labs/users
```

Increase the student quota by 5 hours.