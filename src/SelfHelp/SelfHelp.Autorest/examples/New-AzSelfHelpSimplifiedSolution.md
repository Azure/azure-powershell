### Example 1: Create a new simplified solution for a resource
```powershell
$resourceName = "sampleRName"
$solutionId = "9004345-7759"
$parameters = [ordered]@{ 

    "SearchText" = "Billing" 
} 
New-AzSelfHelpSimplifiedSolution -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/aits-data-inestion/providers/Microsoft.KeyVault/vaults/kv-akshayko519290291381" -SResourceName $resourceName -SolutionId $solutionId -Parameter $parameters
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
sampleRName    

```

Creates Simplified Solutions for an Azure subscription using 'solutionId' from Discovery Solutions as the input.


