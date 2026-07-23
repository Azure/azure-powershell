### Example 1: Update a filter
```powershell
Update-AzPurviewFilter -Endpoint 'https://parv-brs-2.purview.azure.com/' -DataSourceName 'DataScanTestData-Parv' -ScanName 'Scan1ForDemo' -ExcludeUriPrefix @('https://foo.file.core.windows.net/share1/user/temp') -IncludeUriPrefix @('https://foo.file.core.windows.net/share1/user','https://foo.file.core.windows.net/share1/aggregated')
```

```output
ExcludeUriPrefix  : {https://foo.file.core.windows.net/share1/user/temp}
Id                : datasources/DataScanTestData-Parv/scans/Scan1ForDemo/filters/custom
IncludeUriPrefix  : {https://foo.file.core.windows.net/share1/user,
                    https://foo.file.core.windows.net/share1/aggregated}
Name              : custom
```

Update a filter