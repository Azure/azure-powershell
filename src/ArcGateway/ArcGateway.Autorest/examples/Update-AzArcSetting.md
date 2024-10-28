### Example 1: Patch the base Settings of the target resource
```powershell
Update-AzArcSetting -ResourceGroupName "ytongtest" -SubscriptionId "00000000-0000-0000-0000-000000000000" -BaseProvider "Microsoft.HybridCompute" -BaseResourceName "testmachine" -BaseResourceType "machines" -GatewayResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ytongtest/providers/Microsoft.HybridCompute/gateways/myArcGateway"
```

```output

```

Patch the base Settings of the target resource