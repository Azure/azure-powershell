### Example 1: Create New SelfHelp Solution
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
Location Name             ResourceGroupName
-------- ----             -----------------
         test-resource    testRg
```

Creates a SelfHelp Solution for a resource.