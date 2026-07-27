### Example 1: Update the Internet Gateway
```powershell
$gatewayRuleId="/subscriptions/<identity>/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/InternetGatewayRules/Igatewayrulename"

Update-AzNetworkFabricInternetGateway -Name $name -ResourceGroupName $resourceGroupName -InternetGatewayRuleId $gatewayRuleId
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/internetGateways/example-internetGateway
```

This command updates the properties of the given Internet Gateway.

