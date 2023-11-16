### Example 1: Increase student usage quota.
```powershell
Add-AzLabServicesUserQuota -ResourceGroupName "group name" -LabName "lab name" -Email 'student@contoso.com' -UsageQuotaToAddToExisting $(New-TimeSpan -Hours 4)
```

```output
Name           Type
----           ----
testuser       Microsoft.LabServices/labs/users
```

This command increase the students quota by 4 hours.

### Example 2: Increase student usage quota with User object.
```powershell
$user = Get-AzLabServicesUser -ResourceGroupName "group name" -LabName "lab name" -UserName 'ContosoUser12345'
$user | Add-AzLabServicesUserQuota -UsageQuotaToAddToExisting $(New-TimeSpan -Hours 5)
```

```output
Name                 Type
----                 ----
ContosoUser12345     Microsoft.LabServices/labs/users
```

Increase the student quota by 5 hours.