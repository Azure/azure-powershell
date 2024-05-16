### Example 1: Get Simplified Solutions
```powershell
$resourceName = "sampleRName"
            
Get-AzSelfHelpSimplifiedSolution -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/aits-data-inestion/providers/Microsoft.KeyVault/vaults/kv-akshayko519290291381" -SResourceName $resourceName
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
sampleRName                                                                                                                                                aits-data-inestion
```

Get the simplified Solutions using the applicable solutionResourceName while creating the simplified Solutions.


