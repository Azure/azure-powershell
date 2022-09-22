### Example 1: Get the scope filters of the scan
```powershell
Get-AzPurviewFilter -Endpoint 'https://brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData' -ScanName 'Scan1ForDemo'
```

```output
ExcludeUriPrefix  : {https://foo.file.core.windows.net/share1/user/temp}
Id                : datasources/DataScanTestData/scans/Scan1ForDemo/filters/custom
IncludeUriPrefix  : {https://foo.file.core.windows.net/share1/user,
                    https://foo.file.core.windows.net/share1/aggregated}
Name              : custom
```

Get the scope filters of the scan named 'Scan1ForDemo' for datasource 'DataScanTestData'

