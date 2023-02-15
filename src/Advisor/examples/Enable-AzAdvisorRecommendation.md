### Example 1: Enable recommendation by resource Id
```powershell
Enable-AzAdvisorRecommendation -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/automanagehcrprg/providers/microsoft.compute/virtualmachines/arcbox-capi-mgmt/providers/Microsoft.Advisor/recommendations/42963553-61de-5334-2d2e-47f3a0099d41
```

```output
Name                                 Category Resource Group   Impact ImpactedField
----                                 -------- --------------   ------ -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   Microsoft.Compute/virtualMachines
```

Enable recommendation by resource Id

### Example 2: Enable recommendation byrecommendation name
```powershell
Enable-AzAdvisorRecommendation -RecommendationName 42963553-61de-5334-2d2e-47f3a0099d41
```

```output
Name                                 Category Resource Group   Impact ImpactedField
----                                 -------- --------------   ------ -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   Microsoft.Compute/virtualMachines
```

Enable recommendation byrecommendation name

