### Example 1: Delete the AzCostManagementExport by Scope and Name
```powershell
PS C:\> Remove-AzCostManagementExport -Scope 'subscriptions/********' -name 'TestExportDatasetAggregationInfoYouri'


```

Delete the AzCostManagementExport By Scope and ExportName

### Example 2: Delete the AzCostManagementExport by Export Object
```powershell
PS C:\> $getExport = Get-AzCostManagementExport -Scope 'subscriptions/*********' -name 'TestExportDatasetAggregationYouori'
Remove-AzCostManagementExport -InputObject $getExport


```

Delete the AzCostManagementExport By InputObject

