# Network
## Running Tests
There is a [Jenkins job](https://azuresdkci.westus2.cloudapp.azure.com/view/PowerShell/job/ps-network-test/) available for running Network Scenario tests. To run, use the [Build with Parameters](https://azuresdkci.westus2.cloudapp.azure.com/view/PowerShell/job/ps-network-test/build) button and enter the appropriate information. You can change the `fork` and `branch` for the [azure-powershell](https://github.com/Azure/azure-powershell) GitHub repo. Additionally, you can use your own service principal and subscription by entering the `clientID`, `clientSecret`, `tenantId`, and `subId`. The default values use our test subscription and service principal for running tests.

The test results are created as build artifacts in the Jenkins job. The `NetworkTests.htm` is the xUnit tests results log. The artifacts also contain a folder, `src/ResourceManager/Network/Commands.Network.Test/bin/Debug/SessionRecords`. This folder has subfolders for all the session records created when running the tests. 

**Note:** A session records are created for all tests, despite if they pass or fail. Make sure to only use session records from passing tests if you use these files to update the stored records in the repo.

## Feature Registration
Some tests may fail if you do not have the appropriate features enabled on your subscription. If the test requires a certain feature, here is an example how to register for a feature.
```powershell
# If your subscription is not registered with the provider...
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
Register for the [Load Balancer Standard Preview](https://docs.microsoft.com/en-us/azure/load-balancer/load-balancer-standard-overview#sign-up-by-using-powershell) on your subscription.

### PublicIpAddressTests
[Enable Availability Zones](https://ms.portal.azure.com/#blade/Microsoft_Azure_Compute/EnableAvailabilityZonesBlade) for your subscription.  
Register for the [Standard SKU Preview](https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-public-ip-address#register-for-the-standard-sku-preview) on your subscription.

### VirtualNetworkTests
Register the feature `AllowSecureVnets` for `Microsoft.Network` to your subscription. Unfortunately, this cannot be registered via the `Register-AzureRmProviderFeature` cmdlet. Attempting to will simply show `Pending` as the `RegistrationState` indefinitely. You must contact [Anupam Vij](Anupam.Vij@microsoft.com) to enable the feature on your subscription.
