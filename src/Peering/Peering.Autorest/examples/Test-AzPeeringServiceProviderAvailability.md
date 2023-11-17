### Example 1: Check if provider is available at a location
```powershell
$providerAvailability = New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
Test-AzPeeringServiceProviderAvailability -CheckServiceProviderAvailabilityInput $providerAvailability
```

```output
"Available"
```

Check whether the given provider is available at the given location
