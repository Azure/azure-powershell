### Example 1: Create a resource provider custom rollout.
```powershell
New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -SpecificationCanaryRegion "Eastus2EUAP"
```

```output
Name                Type
----                ----
customRollout1      Microsoft.ProviderHub/providerRegistrations/customRollouts
```

Create a resource provider custom rollout.
