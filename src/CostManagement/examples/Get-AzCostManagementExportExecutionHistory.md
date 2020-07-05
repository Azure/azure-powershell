### Example 1: Get execution history of cost management export
```powershell
PS C:\> Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName "ps-customcolum-t"

Name Type
---- ----
```

This command gets execution history of cost management export.

### Example 2: Get execution history of cost management export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName "ps-customcolum-t"
PS C:\> Get-AzCostManagementExportExecutionHistory -InputObject $export

Name Type
---- ----
```

This command gets execution history of cost management export by object.

