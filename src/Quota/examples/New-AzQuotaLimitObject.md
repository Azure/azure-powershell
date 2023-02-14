### Example 1: Create an in-memory object for LimitValue
```powershell
<<<<<<< HEAD
New-AzQuotaLimitObject -Value 1003
```

```output
=======
PS C:\> New-AzQuotaLimitObject -Value 1003

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
LimitObjectType LimitType Value
--------------- --------- -----
LimitValue                1003
```

This command create an in-memory object for LimitValue as value of the parameter Limit in the New/Update-AzQuota cmdlet.

