### Example 1: Start a Scan Run
```powershell
Start-AzPurviewScanResultScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' -RunId '758a0499-b45e-40e3-9c06-408e2f3ac050' -ScanLevel 'Full'
```

```output
EndTime ScanResultId                         StartTime            Status
------- ------------                         ---------            ------
        758a0499-b45e-40e3-9c06-408e2f3ac050 2/15/2022 2:34:06 PM Accepted
```

Start a Scan Run with scanResultId '758a0499-b45e-40e3-9c06-408e2f3ac050'

