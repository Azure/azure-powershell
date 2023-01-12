### Example 1: Create a check service provider availability object
```powershell
$providerAvailability = New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
$providerAvailability
```

```output
PeeringServiceLocation PeeringServiceProvider
---------------------- ----------------------
Osaka                  IIJ
```

Creates a CheckServiceProviderAvailabilityInputObject with the specified location and provider and stores it in memory
