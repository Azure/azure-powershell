### Example 1: Start a Scan Run
```powershell
<<<<<<< HEAD
Start-AzPurviewScanResultScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' -RunId '758a0499-b45e-40e3-9c06-408e2f3ac050' -ScanLevel 'Full'
```

```output
=======
PS C:\> Start-AzPurviewScanResultScan -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' -RunId '758a0499-b45e-40e3-9c06-408e2f3ac050' -ScanLevel 'Full'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
EndTime ScanResultId                         StartTime            Status
------- ------------                         ---------            ------
        758a0499-b45e-40e3-9c06-408e2f3ac050 2/15/2022 2:34:06 PM Accepted
```

Start a Scan Run with scanResultId '758a0499-b45e-40e3-9c06-408e2f3ac050'

