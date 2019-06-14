# Multi-API support for AutoRest v3 generators

> see https://aka.ms/autorest

``` yaml
input-file:
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/applicationGateway.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/applicationSecurityGroup.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/availableDelegations.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/azureFirewall.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/azureFirewallFqdnTag.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/checkDnsAvailability.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/ddosCustomPolicy.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/ddosProtectionPlan.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/endpointService.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/expressRouteCircuit.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/expressRouteCrossConnection.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/expressRouteGateway.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/expressRoutePort.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/interfaceEndpoint.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/loadBalancer.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/natGateway.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/networkInterface.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/networkProfile.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/networkSecurityGroup.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/networkWatcher.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/operation.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/publicIpAddress.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/publicIpPrefix.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/routeFilter.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/routeTable.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/serviceCommunity.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/serviceEndpointPolicy.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/usage.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/virtualNetwork.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/virtualNetworkGateway.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/virtualNetworkTap.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/virtualWan.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/vmssNetworkInterface.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/vmssPublicIpAddress.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/webapplicationfirewall.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/checkDnsAvailability.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/endpointService.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/expressRouteCircuit.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/loadBalancer.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/networkInterface.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/networkSecurityGroup.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/operation.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/publicIpAddress.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/routeTable.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/usage.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/virtualNetwork.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/virtualNetworkGateway.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2015-06-15/expressRouteCircuit.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/preview/2015-05-01-preview/network.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/network.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/applicationGateway.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/applicationSecurityGroup.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/network.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/networkWatcher.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/routeFilter.json
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2017-10-01/serviceCommunity.json
require: $(repo)/profiles/readme.md
```