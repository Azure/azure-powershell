### Example 1: Get execution history of cost management export
```powershell
PS C:\> Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName "ps-customcolum-t"

ExecutionType ProcessingStartTime   ProcessingEndTime     Status    FileName
------------- -------------------   -----------------     ------    --------
OnDemand      6/29/2020 6:03:26 AM  6/29/2020 6:04:28 AM  Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_041c4d56-f25e-4e37-99fb-ab201309e07f.csv
Scheduled     6/30/2020 12:02:53 PM 6/30/2020 12:03:34 PM Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_cd5bd8b1-014f-4521-b20a-69168288263d.csv
```

This command gets execution history of cost management export.

### Example 2: Get execution history of cost management export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -ExportName "ps-customcolum-t"
PS C:\> $export | Get-AzCostManagementExportExecutionHistory -InputObject $export

ExecutionType ProcessingStartTime   ProcessingEndTime     Status    FileName
------------- -------------------   -----------------     ------    --------
OnDemand      6/29/2020 6:03:26 AM  6/29/2020 6:04:28 AM  Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_041c4d56-f25e-4e37-99fb-ab201309e07f.csv
Scheduled     6/30/2020 12:02:53 PM 6/30/2020 12:03:34 PM Completed ad-hoc/ps-customcolum-t/20200601-20200630/ps-customcolum-t_cd5bd8b1-014f-4521-b20a-69168288263d.csv
```

This command gets execution history of cost management export by object.

