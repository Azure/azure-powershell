### Example 1: Create an in-memory object for EgressEndpointObject.

```powershell
$endpointDependency=New-AzNetworkCloudEndpointDependencyObject -DomainName domainName -Port 1234

New-AzNetworkCloudEgressEndpointObject -Category "azure-resource-management" -Endpoint ($endpointDependency)
```

```output
Category
--------
azure-resource-management
```

Create an in-memory object for EgressEndpoint.

