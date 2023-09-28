### Example 1: {{ Add title here }}
```powershell
$criteria = [ordered]@{
    "name" ="SolutionId"
    "value" = "keyvault-lostdeletedkeys-apollo-solution"
}
$parameters = [ordered]@{
        "SearchText" = "Can not RDP"
        "vault_name" = "DemoKeyvault"
}
New-AzSelfHelpSolution -ResourceName test-resource -Scope  /subscriptions/<subid>/resourceGroups/testRG/providers/Microsoft.KeyVault/kv/testDB -Parameter $parameters -TriggerCriterion $criteria
```

```output
New-AzSelfHelpSolution_CreateExpanded: The server responded with an unrecognized response, Status: OK
```

Creates a SelfHelp Solution for a resource.