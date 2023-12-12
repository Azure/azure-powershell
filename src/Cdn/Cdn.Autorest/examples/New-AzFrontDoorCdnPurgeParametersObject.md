### Example 1: Create an in-memory object for AfdPurgeParameters
```powershell
$contentPath = "/a"
$content = New-AzFrontDoorCdnPurgeParametersObject -ContentPath $contentPath
```

```output
ContentPath
-----------
{/a}
```

Create an in-memory object for AfdPurgeParameters
