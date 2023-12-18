### Example 1: Create a custom text log data source object
```powershell
New-AzLogFilesDataSourceObject -FilePattern "C:\\JavaLogs\\*.log" -Stream "Custom-TabularData-ABC" -Name myTabularLogDataSource -SettingTextRecordStartTimestampFormat "yyyy-MM-ddTHH:mm:ssK"
```

```output
FilePattern                           : {C:\\JavaLogs\\*.log}
Format                                : text
Name                                  : myTabularLogDataSource
SettingTextRecordStartTimestampFormat : yyyy-MM-ddTHH:mm:ssK
Stream                                : {Custom-TabularData-ABC}
```

This command creates a custom text log data source object.

