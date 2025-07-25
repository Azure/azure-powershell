### Example 1: Invoke Export by ExportName and Scope
```powershell
Invoke-AzCostManagementExecuteExport -ExportName 'TestExport' -Scope 'subscriptions/**********'
```

Invoke Export by ExportName and Scope

### Example 2: Invoke Export by InputObject
```powershell
$getExport = Get-AzCostManagementExport -Name 'TestExport' -Scope 'subscriptions/**********'
Invoke-AzCostManagementExecuteExport -InputObject $getExport
```

Invoke Export by InputObject

