### Example 1: Create a in-memory object for HeaderField
```powershell
PS C:\> New-AzApplicationInsightsWebTestHeaderFieldObject -Name 'version' -Value '2.0.1'

Name    Value
----    -----
version 2.0.1
```

This command creates a in-memory object for HeaderField,  As value of the `RequestHeader` parameter in `New-AzApplicationInsightsWebTest`.