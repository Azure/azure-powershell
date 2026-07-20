### Example 1: Update a resource provider custom rollout.
```powershell
Update-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -SpecificationCanaryRegion "Eastus2EUAP"
```

```output
Name                Type
----                ----
customRollout1      Microsoft.ProviderHub/providerRegistrations/customRollouts
```

Update a resource provider custom rollout.
