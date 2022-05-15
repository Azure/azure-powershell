## Applicability
Az.Network supports the retrieval of private link resource in `Get-AzPrivateLinkResource` as well as the management of private endpoint connection by `Get-AzPrivateEndpointConnection`, `Approve-AzPrivateEndpointConnection`, `Deny-AzPrivateEndpointConnection`, `Remove-AzPrivateEndpointConnection` and `Set-AzPrivateEndpointConnection`. 

For provider who 
- supports the features of private link resource or private endpoint connection already
- and wants to onboard these features in Azure PowerShell, 
You need to register provider configuration in [ProviderConfiguration.cs](https://github.com/Azure/azure-powershell/blob/main/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/ProviderConfiguration.cs#L12).

Notes: No additional commands for the features of PrivateLinkResource and PrivateEndpointConnection need to be added.

## Prerequisite
We assume the API for `List` private link resource and `Get` private endpoint connection is available in the provider that claims to support private endpoint connection features. That means it supports following APIs:

```
# List Private Link Resource API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{topResourceType}/{topResourceName}/privateLinkResources"
```
```
# Get Private Endpoint Connection API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{topResourceType}/{topResourceName}/privateEndpointConnections/{privateEndpointConnectionName}"
```

if "List Private Endpoint Connection API" below is not available, `privateEndpointConnections` must be included in the properties of top resource returned by 
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{topResourceType}/{topResourceName}". So that `Get-AzPrivateEndpointConnect` will retrieve connections from the top resource.

```
# List Private Endpoint Connection API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{topResourceType}/{topResourceName}/privateEndpointConnections"
```

## Code Changes Needed
To add corresponding {Provider}, {topResourceType} and {API-Version} into [ProviderConfiguration.cs](https://github.com/Azure/azure-powershell/blob/main/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/ProviderConfiguration.cs#L12), we need to follow in following pattern:
```
RegisterConfiguration(string type, string apiVersion, bool hasConnectionsURI = false, bool supportGetPrivateLinkResource = false, bool supportPrivateLinkResource = true)
```
- `type` includes resource provider and resource type which supports PrivateLink feature. For example, "Microsoft.Sql/servers".
- `apiVersion` specifies the API version to be used. For example, "2018-06-01-preview".
- `hasConnectionsURI` marks whether the provider exposes "List Private Endpoint Connection API". Default value is false.
```
# Get Private Link Resource API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{topResourceType}/{topResourceName}/privateLinkResources/{privateLinkResourceName}"
```
- `supportGetPrivateLinkResource` marks whether the provider supports Get API of PrivateLinkResource. Default value is false.

For instance, for provider "Microsoft.Sql/servers" with API version "2018-06-01-preview", it supports "List Private Endpoint Connection API" and "Get Private Link Resource API". So its registration configuration should be:
```
RegisterConfiguration("Microsoft.Sql/servers", "2018-06-01-preview", true, true);
```

- `supportListPrivateLinkResource` marks whether the provider supports List API of PrivateLinkResource. Default value is true.

For instance, `Microsoft.Network/privateLinkServices` supports PrivateEndpointConnections but doesn't support resource type PrivateLinkResource (We assume List API is mandatory to resource support). Its configuration should be:
```
RegisterConfiguration("Microsoft.Network/privateLinkServices", "2020-05-01", true, false, false);
```

## End-To-End Test

### Item Needed

+ Top level resource
```
New-Az{topResourceType} -ResourceGroupName {rgName} -Name {topResourceName}

$TopLevelResource = Get-Az{topResourceType} -ResourceGroupName {rgName} -Name {topResourceName}
```

+ private link resource
```
$PrivateLinkResource = Get-AzPrivateLinkResource -PrivateLinkResourceId $TopLevelResource.Id
```

+ subnet config (object in memory)
```
$SubnetConfig = New-AzVirtualNetworkSubnetConfig -Name {configName} -AddressPrefix "11.0.1.0/24"      -PrivateEndpointNetworkPolicies "Disabled"
```

+ virtual network
```
New-AzVirtualNetwork -ResourceGroupName {rgName} -Name {vnetName} -Location {location} -AddressPrefix "11.0.0.0/16" -Subnet $SubnetConfig

$VNet=Get-AzVirtualNetwork -ResourceGroupName {rgName} -Name {vnetName}
```

+ private link service connection (object in memory)
```
$PLSConnection = New-AzPrivateLinkServiceConnection -Name {plsConnectionName} -PrivateLinkServiceId $TopLevelResource.Id -GroupId $TopLevelResource.GroupId
```

+ endpoint
```
New-AzPrivateEndpoint -ResourceGroupName {rgName} -Name {endpointName} -Location {location} -Subnet $VNet.subnets[0] -PrivateLinkServiceConnection $PLSConnection -ByManualRequest
```

### step-by-step
* Add `Network.csproj` to {Module}.sln, and `Microsoft.Azure.Management.Network` to {Module}.Test.csproj

* Create listed items above

* To get the connection, if `list` for private endpoint connection was supported,
```
$connection = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $TopLevelResource.Id
```

* To get the connection, if `list` for private endpoint connection was not supported,
```
$TopLevelResource = Get-Az{topResourceType} -ResourceGroupName {rgName} -Name {topResourceName}

$ConnectionId = $TopLevelResource.PrivateEndpointConnection[0].Id

$Connection = Get-AzPrivateEndpointConnection -ResourceId $ConnectionId
```

* Approve/Deny the connection
```
Approve-AzPrivateEndpointConnection -ResourceId $ConnectionId

or

Deny-AzPrivateEndpointConnection -ResourceId $ConnectionId
```

* Connection cannot be approved after rejection

* One top level resource can have maximum 3 private end point connection
