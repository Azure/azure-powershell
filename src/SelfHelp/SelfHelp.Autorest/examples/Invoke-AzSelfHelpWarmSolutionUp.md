### Example 1: Warm up the solution resource
```powershell
$resourceName = "sampleRName"
$parameters = [ordered]@{ 
    "ProductId" = "13491"
}
Invoke-AzSelfHelpWarmSolutionUp -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/aits-data-inestion/providers/Microsoft.KeyVault/vaults/kv-akshayko519290291381" -SolutionResourceName $resourceName -Parameter $parameters
```

```output
[No output]
```

Warm up the solution resource by preloading asynchronous diagnostics results into cache


