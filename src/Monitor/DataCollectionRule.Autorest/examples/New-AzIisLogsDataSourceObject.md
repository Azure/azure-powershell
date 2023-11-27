### Example 1: Create iis logs data source object
```powershell
New-AzIisLogsDataSourceObject -Stream "Microsoft-W3CIISLog" -LogDirectory "c:\\test" -Name "iisLogsDataSource"
```

```output
LogDirectory Name              Stream
------------ ----              ------
{c:\\test}   iisLogsDataSource {Microsoft-W3CIISLog}
```

This command creates iis logs data source object.

