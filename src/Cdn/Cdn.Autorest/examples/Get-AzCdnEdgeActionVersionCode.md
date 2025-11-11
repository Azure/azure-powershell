### Example 1: Get Edge Action Version Code
```powershell
Get-AzCdnEdgeActionVersionCode -ResourceGroupName "testps-rg-da16jm" -EdgeActionName "edgeaction001" -Version "v1"
```

```output
Name    : main.js
Content : function handleRequest(request, response) {
    // Edge action logic here
    console.log('Processing request:', request.url);
    response.setHeader('X-Edge-Action', 'v1');
    return response;
}
```

Get the source code for a specific Edge Action Version
