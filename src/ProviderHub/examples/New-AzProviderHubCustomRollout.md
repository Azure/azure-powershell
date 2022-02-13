### Example 1: Create/Update a resource provider custom rollout.
```powershell
PS C:\> New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -CanaryRegion "Eastus2EUAP"

Name                Type
----                ----
customRollout1      Microsoft.ProviderHub/providerRegistrations/customRollouts
```

Create/Update a resource provider custom rollout.
