### Example 1: Create the scope filters of the scan
```powershell
$filterObj = New-AzPurviewFilterObject -ExcludeUriPrefix @('https://foo.file.core.windows.net/share1/user/temp') -IncludeUriPrefix @('https://foo.file.core.windows.net/share1/user','https://foo.file.core.windows.net/share1/aggregated')
New-AzPurviewFilter -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' -Body $filterObj
```

```output
ExcludeUriPrefix  : {https://foo.file.core.windows.net/share1/user/temp}
Id                : datasources/DataScanTestData-Parv/scans/Scan1ForDemo/filters/custom
IncludeUriPrefix  : {https://foo.file.core.windows.net/share1/user,
                    https://foo.file.core.windows.net/share1/aggregated}
Name              : custom
```

Create the scope filters of the scan named 'Scan1ForDemo' for datasource 'DataScanTestData'

