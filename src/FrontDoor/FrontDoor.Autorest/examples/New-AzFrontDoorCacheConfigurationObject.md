### Example 1: Create a cache configuration object
```powershell
New-AzFrontDoorCacheConfigurationObject -CacheDuration "0.12:00:00" -DynamicCompression "Enabled" -QueryParameterStripDirective "StripAllExcept"
```

```output
CacheDuration DynamicCompression QueryParameter QueryParameterStripDirective
------------- ------------------ -------------- ----------------------------
12:00:00      Enabled                           StripAllExcept
```

Create a cache configuration object.