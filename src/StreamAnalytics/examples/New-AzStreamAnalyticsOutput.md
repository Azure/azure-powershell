### Example 1: Create an output to a stream analytics job
```powershell
New-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name output-01 -File .\test\template-json\StroageAccount.json
```
```output
Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 3819fb65-07f5-4dc3-83e1-d3149596f8d0
```

This command creates a new output in the stream analytics job.

(below is an example for "StroageAccount.json")
{
  "properties": {
    "serialization": {
      "type": "Json",
      "properties": {
        "encoding": "UTF8",
        "format": "LineSeparated"
      }
    },
    "datasource": {
      "type": "Microsoft.Storage/Blob",
      "properties": {
        "storageAccounts": [
          {
            "accountName": "xxxxxxxxxxxxxxx",
            "accountKey": "xxxxxxxxxxxxxxxx"
          }
        ],
        "container": "xxxxxxxxxxxxxxxxxxxx",
        "pathPattern": "cluster1/{client_id}",
        "dateFormat": "yyyy/MM/dd",
        "timeFormat": "HH",
        "authenticationMode": "ConnectionString"
      }
    }
  }
}

