### Example 1: Create an in-memory object for LimitValue
```powershell
PS C:\> New-AzQuotaLimitObject -Value 1003

LimitObjectType LimitType Value
--------------- --------- -----
LimitValue                1003
```

This command create an in-memory object for LimitValue as value of the parameter Limit in the New/Update-AzQuota cmdlet.

