### Example 1: Invoke a cost mangement export by name
```powershell
PS C:\> Invoke-AzCostManagementExecuteExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName 'TestExport'

```

This command invokes a cost mangement export by name.

### Example 2: Invoke a cost mangement export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName 'TestExport'
PS C:\> Invoke-AzCostManagementExecuteExport -InputObject $export

```

This command invokes a cost mangement export by object.

