## Applicability
Az.Network supports the retrieval of private link resource in `Get-AzPrivateLinkResource` as well as the management of private endpoint connection in `Approve-AzPrivateEndpointConnect`, `Deny-AzPrivateEndpointConnect`, `Remove-AzPrivateEndpointConnect` and `Set-AzPrivateEndpointConnect`. 

For providers who 
- supports the features of private linke resource and private endpoint connection already
- and want to onboard these features in Azure PowerShell, 

they need register provider configuration in [ProviderConfiguration.cs](https://github.com/Azure/azure-powershell/blob/main/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/ProviderConfiguration.cs#L12).

Notes: No additional commands for the features of private linke resource and private endpoint connection need to be added.

## Prerequisite
We assume the API for `List` private link resource and `Get` private endpoint connection is available in the provider that claims to support private endpoint connection features. That means it supports following APIs:

```
# List Private Link Resource API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateLinkResources"
```
```
# Get Private Endpoint Connection API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateEndpointConnections/{PrivateEndpointConnection-Name}"
```

if "List Private Endpoint Connection API" is not available, `privateEndpointConnections` must be included in the properties of top resource returned by 
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}". So that `Private Endpoint Connections` will be retrieved from the top resource.

```
# List Private Endpoint Connection API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateEndpointConnections"
```

## Code Changes Needed
To add corresponding {Provider}, {Top-Level-Resource} and {API-Version} into [ProviderConfiguration.cs](https://github.com/Azure/azure-powershell/blob/main/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/ProviderConfiguration.cs#L12), we need to follow 
in following pattern:
```
RegisterConfiguration("{Provider}/{Top-Level-Resource}", "{API-Version}", bool hasPrivateEndppointConnectionsURI, bool hasPrivateLinkResourceURI)
```
- "{Provider}/{Top-Level-Resource}" describes the type of provider. For example, "Microsoft.Sql/servers".
- "{API-Version}" specifies the API version to be used. For example, "2018-06-01-preview".
- `hasPrivateEndppointConnectionsURI` marks the provider whether provides "List Private Endpoint Connection API".
```
# Get Private Link Resource API
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateLinkResources/{PrivateLinkResource-Name}"
```
- `hasPrivateLinkResourceURI` marks the provider whether providers "Get Private Endpoint Connection API".

For instance, for provider "Microsoft.Sql/servers" with API version "2018-06-01-preview", it supports "List Private Endpoint Connection API" and "Get Private Endpoint Connection API". So it's registration configuration should be
```
RegisterConfiguration("Microsoft.Sql/servers", "2018-06-01-preview", true, true);
```

## End-To-End Test

### Item Needed

+ Top level resource
```
New-Az{Top-Level-Resource} -ResourceGroupName {rg_name} -Name {top_level_resource_name}

$TopLevelResource = Get-Az{Top-Level-Resource} -ResourceGroupName {rg_name} -Name {top_level_resource_name}
```

+ private link resource
```
$PrivateLinkResource = Get-AzPrivateLinkResource -PrivateLinkResourceId $TopLevelResource.Id
```

+ subnet config (object in memory)
```
$SubnetConfig = New-AzVirtualNetworkSubnetConfig -Name {config_name} -AddressPrefix "11.0.1.0/24"      -PrivateEndpointNetworkPolicies "Disabled"
```

+ virtual network
```
New-AzVirtualNetwork -ResourceGroupName {rg_name} -Name {vnet_name} -Location {location} -AddressPrefix "11.0.0.0/16" -Subnet $SubnetConfig

$VNet=Get-AzVirtualNetwork -ResourceGroupName {rg_name} -Name {vnet_name}
```

+ private link service connection (object in memory)
```
$PLSConnection = New-AzPrivateLinkServiceConnection -Name {pls_connection_name} -PrivateLinkServiceId $TopLevelResource.Id -GroupId $TopLevelResource.GroupId
```

+ endpoint
```
New-AzPrivateEndpoint -ResourceGroupName {rg_name} -Name {endpoint_name} -Location {location} -Subnet $VNet.subnets[0] -PrivateLinkServiceConnection $PLSConnection -ByManualRequest
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
$TopLevelResource = Get-Az{Top-Level-Resource} -ResourceGroupName {rg_name} -Name {top_level_resource_name}

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
