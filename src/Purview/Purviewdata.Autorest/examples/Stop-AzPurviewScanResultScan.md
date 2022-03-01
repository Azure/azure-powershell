### Example 1: Stop a scan run by run id
```powershell
Stop-AzPurviewScanResultScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' -RunId '663623f3-8728-4b10-b5c8-8ed8dbc2ae7e'
```

```output
EndTime ScanResultId StartTime            Status
------- ------------ ---------            ------
                     2/15/2022 2:47:55 PM Accepted
```

Stop a scan run by run id '663623f3-8728-4b10-b5c8-8ed8dbc2ae7e'

