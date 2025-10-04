### Example 1: Create the Internet Gateway Rule Resource
```powershell
$ruleProperty = @{
    Action = "Allow"
    AddressList = @(
        "10.10.10.10"
    )
}

New-AzNetworkFabricInternetGatewayRule -Name $name -ResourceGroupName $resourceGroupName -Location $location -RuleProperty $ruleProperty
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFa…
```

This command creates the Internet Gateway Rule resource.

