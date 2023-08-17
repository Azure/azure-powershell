### Example 1: Disable recommendation by recommendation name
```powershell
Disable-AzAdvisorRecommendation -RecommendationName 42963553-61de-5334-2d2e-47f3a0099d41 -Day 1
```

```output
SuppressionId                        Name                     Resource Group   Ttl
-------------                        ----                     --------------   ---
5b931ff3-42a3-5f80-797f-8e018a6dfaf5 HardcodedSuppressionName automanagehcrprg 1.00:00:00
```

Disable recommendation by recommendation name

### Example 2: Disable recommendation by recommendation resource id
```powershell
Disable-AzAdvisorRecommendation -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/automanagehcrprg/providers/microsoft.compute/virtualmachines/arcbox-capi-mgmt/providers/Microsoft.Advisor/recommendations/42963553-61de-5334-2d2e-47f3a0099d41 -Day 1
```

```output
SuppressionId                        Name                     Resource Group   Ttl
-------------                        ----                     --------------   ---
5b931ff3-42a3-5f80-797f-8e018a6dfaf5 HardcodedSuppressionName automanagehcrprg 1.00:00:00
```

Disable recommendation by recommendation resource id

