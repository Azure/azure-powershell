### Example 1: Invoke query usage of the cost management export 
```powershell
PS C:\> Invoke-AzCostManagementUsageQuery -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Timeframe MonthToDate -Type Usage  -DatasetGranularity 'daily'

NextLink Column                Row
-------- ------                ---
         {UsageDate, Currency} {20200701 USD, 20200702 USD, 20200703 USD, 20200704 USD…}
```

this command invokes query usage of the cost management export.


