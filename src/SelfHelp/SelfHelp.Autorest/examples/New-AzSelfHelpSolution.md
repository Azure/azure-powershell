### Example 1: Create New SelfHelp Solution
```powershell
$criteria = [ordered]@{ 
    "name" ="SolutionId" 
    "value" = "apollo-cognitve-search-custom-skill" 
} 

$parameters = [ordered]@{ 
        "SearchText" = "Can not Search" 
} 

New-AzSelfHelpSolution -ResourceName test-resource234 -Scope  /subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/DiagnosticsRp-Ev2AssistId-Public-Dev/providers/Microsoft.KeyVault/vaults/DiagRp-Ev2PublicDev -Parameter $parameters -TriggerCriterion $criteria 
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
        test-resource234    DiagnosticsRp-Ev2AssistId-Public-Dev
```

Creates a SelfHelp Solution for a resource.