## Prerequisite
API for `Get` private link resource and private endpoint connection need to be ready at:

#### Private Link Resource API
```
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateLinkResources"
```
```
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateLinkResources/{PrivateLinkResource-Name}"
```

#### Get Private Endpoint Connection API
```
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateEndpointConnections/{PrivateEndpointConnection-Name}"
```
#### List Private Endpoint Connection API
```
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}/privateEndpointConnections"
```

if "List Private Endpoint Connection API" is not available, `Private Endpoint Connection` will be retrieved from top resource
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{provider}/{Top-Level-Resource}/{Top-Level-Resource-Name}"
`privateEndpointConnections` need to be defined under this API

## Code Changes Needed
Add corresponding {Provider}, {Top-Level-Resource} and {API-Version} into [ProviderConfiguration.cs](https://github.com/Azure/azure-powershell/blob/master/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/ProviderConfiguration.cs#L12)
in following pattern:
```
RegisterConfiguration("{Provider}/{Top-Level-Resource}", "{API-Version}")
```
For example:

if "List Private Endpoint Connection API" is [available](https://github.com/Azure/azure-powershell/blob/master/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/GenericProvider.cs#L74),
```
RegisterConfiguration("Microsoft.Sql/servers", "2018-06-01-preview")
```
if "List Private Endpoint Connection API" is [not available](https://github.com/Azure/azure-powershell/blob/master/src/Network/Network/PrivateLinkService/PrivateLinkServiceProvider/GenericProvider.cs#L93), provide extra bool parameter 'false'
```
RegisterConfiguration("Microsoft.Storage/storageAccounts", "2019-06-01", false)
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