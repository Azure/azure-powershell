### Example 1: Create a cache configuration object
```powershell
New-AzFrontDoorCacheConfigurationObject -CacheDuration "0.12:00:00" -DynamicCompression "Enabled" -QueryParameterStripDirective "StripAllExcept"
```

```output
CacheDuration                : 0.12:00:00
DynamicCompression          : Enabled
QueryParameterStripDirective : StripAllExcept
```

Create a cache configuration object.