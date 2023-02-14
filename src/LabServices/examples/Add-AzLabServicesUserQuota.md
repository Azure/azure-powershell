### Example 1: Increase student usage quota.
```powershell
<<<<<<< HEAD
Add-AzLabServicesUserQuota -ResourceGroupName "group name" -LabName "lab name" -Email 'student@contoso.com' -UsageQuotaToAddToExisting $(New-Timespan -Hours 4)
```

```output
=======
PS C:\> Add-AzLabUserQuota -ResourceGroupName "group name" -LabName "lab name" -Email 'student@contoso.com' -UsageQuotaToAddToExisting $(New-Timespan -Hours 4)

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name           Type
----           ----
testuser       Microsoft.LabServices/labs/users
```

This command increase the students quota by 4 hours.

### Example 2: Increase student usage quota with User object.
```powershell
<<<<<<< HEAD
$user = Get-AzLabServicesUser -ResourceGroupName "group name" -LabName "lab name" -UserName 'ContosoUser12345'
$user | Add-AzLabServicesUserQuota -UsageQuotaToAddToExisting $(New-Timespan -Hours 5)
```

```output
=======
PS C:\> $user = Get-AzLabUser -ResourceGroupName "group name" -LabName "lab name" -UserName 'ContosoUser12345'
PS C:\> $user | Add-AzLabUserQuota -UsageQuotaToAddToExisting $(New-Timespan -Hours 5)

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                 Type
----                 ----
ContosoUser12345     Microsoft.LabServices/labs/users
```

Increase the student quota by 5 hours.