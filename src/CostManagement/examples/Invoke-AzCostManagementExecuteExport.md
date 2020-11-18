### Example 1: Invoke Export by ExportName and Scope
```powershell
PS C:\> Invoke-AzCostManagementExecuteExport -ExportName 'TestExport' -Scope 'subscriptions/**********'

{{ Add output here }}
```

Invoke Export by ExportName and Scope

### Example 2: Invoke Export by InputObject
```powershell
PS C:\> $getExport = Get-AzCostManagementExport -Name 'TestExport' -Scope 'subscriptions/**********'
Invoke-AzCostManagementExecuteExport -InputObject $getExport

{{ Add output here }}
```

Invoke Export by InputObject

