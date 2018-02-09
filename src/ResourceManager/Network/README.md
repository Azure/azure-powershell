# Network
## Tests
If the test requires to register for a feature, here is an example how to register for a feature.
```powershell
# If you're not registered with the provider...
Register-AzureRmResourceProvider -ProviderNamespace Microsoft.Network
# Register the feature
Register-AzureRmProviderFeature -FeatureName AllowApplicationSecurityGroups -ProviderNamespace Microsoft.Network
# Check registration
Get-AzureRmProviderFeature -FeatureName AllowApplicationSecurityGroups -ProviderNamespace Microsoft.Network
```

### ApplicationSecurityGroupTests
Register the feature `AllowApplicationSecurityGroups` for `Microsoft.Network` to your subscription.

### LoadBalancerTests
Register the feature `AllowILBAllPortsRule` for `Microsoft.Network` to your subscription.

### PublicIpAddressTests
[Enable Availability Zones](https://ms.portal.azure.com/#blade/Microsoft_Azure_Compute/EnableAvailabilityZonesBlade) for your subscription.

### VirtualNetworkTests
Register the feature `AllowSecureVnets` for `Microsoft.Network` to your subscription. Unfortunately, this cannot be registered via the `Register-AzureRmProviderFeature` cmdlet. Attempting to will simply show `Pending` as the `RegistrationState` indefinitely. You must contact [Anupam Vij](Anupam.Vij@microsoft.com) to enable the feature on your subscription.