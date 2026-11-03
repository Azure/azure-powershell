### Example 1: Associate a probing gateway with a Basic profile
```powershell
$gatewayId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/demo-rg/providers/Microsoft.Network/probingGateways/gateway-east"
New-AzPrivateTrafficManagerProfileProbingGateway -Name "gateway-east" -PrivateTrafficManagerProfileName "basic-profile" -ResourceGroupName "demo-rg" -ProbingGatewayId $gatewayId
```

This command associates an existing probing gateway with a profile whose CustomTopologyMapMode is Disabled. It does not create the probing gateway infrastructure.

