### Example 1: Get download URLs for a log file
```powershell
Get-AzHorizonDbLogFileDownloadUrl -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -LogFileName '22222222-2222-2222-2222-222222222222' | Format-List -Property DownloadUri, ExpiresAtUtc
```

```output
DownloadUri  : System.Security.SecureString
ExpiresAtUtc : 09/11/2026 13:00:00
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
