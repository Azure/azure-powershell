### Example 1: Change the probing gateway used by an association
```powershell
$gatewayId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/demo-rg/providers/Microsoft.Network/probingGateways/gateway-west"
Update-AzPrivateTrafficManagerProfileProbingGateway -Name "gateway-east" -PrivateTrafficManagerProfileName "basic-profile" -ResourceGroupName "demo-rg" -ProbingGatewayId $gatewayId
```

This command updates the association to reference a different existing probing gateway.

