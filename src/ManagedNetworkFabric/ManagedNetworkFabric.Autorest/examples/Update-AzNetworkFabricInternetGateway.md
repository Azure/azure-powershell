### Example 1: Update the Internet Gateway
```powershell
$gatewayRuleId="/subscriptions/<identity>/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/InternetGatewayRules/Igatewayrulename"

Update-AzNetworkFabricInternetGateway -Name $name -ResourceGroupName $resourceGroupName -InternetGatewayRuleId $gatewayRuleId
```

```output
Annotation Id
---------- --
           /subscriptions/<identity>/providers/Microsoft.ManagedNetworkFabric/locations/EASTUS/operationStatuses/797b2b4…
```

This command updates the properties of the given Internet Gateway.

