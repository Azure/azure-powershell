### Example 1: Create/Update a resource provider custom rollout.
```powershell
<<<<<<< HEAD
New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -CanaryRegion "Eastus2EUAP"
```

```output
=======
PS C:\> New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -CanaryRegion "Eastus2EUAP"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                Type
----                ----
customRollout1      Microsoft.ProviderHub/providerRegistrations/customRollouts
```

Create/Update a resource provider custom rollout.
