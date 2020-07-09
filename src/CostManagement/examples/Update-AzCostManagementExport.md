### Example 1: Update a cost management export by name
```powershell
PS C:\> Update-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name exportinfo-ps-t -RecurrencePeriodFrom (Get-Date).ToString()

```

This command updates a cost management export by name.

### Example 2: Update a cost management export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name exportinfo-ps-t
PS C:\> Update-AzCostManagementExport -InputObject $export -RecurrencePeriodFrom (Get-Date).ToString()

{{ Add output here }}
```

This command updates a cost management export by object.

