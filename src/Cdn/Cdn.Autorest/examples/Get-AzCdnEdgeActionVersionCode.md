### Example 1: Get Edge Action Version Code
```powershell
Get-AzCdnEdgeActionVersionCode -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -VersionName version001
```

```output
Code                               ResourceGroupName EdgeActionName VersionName
----                               ----------------- -------------- -----------
function handleRequest(request)... testps-rg-da16jm  edgeaction001  version001
```

Get the source code for a specific Edge Action Version
