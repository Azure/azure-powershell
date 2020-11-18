### Example 1: Invoke AzCostManagementQuery by Scope
```powershell
PS C:\> Invoke-AzCostManagementQuery -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Timeframe MonthToDate -Type Usage
Invoke-AzCostManagementQuery -Scope "/subscriptions/***********" -Timeframe MonthToDate -Type Usage -DatasetGranularity 'Daily'

NextLink Column                Row
-------- ------                ---
         {UsageDate, Currency} {20201101 USD, 20201102 USD, 20201103 USD, 20201104 USD…}
```

Invoke AzCostManagementQuery by Scope

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}


{{ Add output here }}
```

{{ Add description here }}