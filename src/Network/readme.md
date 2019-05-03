<!-- region Generated -->
# Az.Network
This directory contains the PowerShell module for the Network service.

---
## Status
[![Az.Network](https://img.shields.io/powershellgallery/v/Az.Network.svg?style=flat-square&label=Az.Network "Az.Network")](https://www.powershellgallery.com/packages/Az.Network/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.4.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Network`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
  # - $(repo)/specification/network/resource-manager/readme.enable-multi-api.md
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/network/resource-manager/readme.md

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
  - $(repo)/specification/network/resource-manager/Microsoft.Network/stable/2019-02-01/network.json
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

subject-prefix: ''
module-version: 0.0.1
skip-model-cmdlets: true

directive:
  - where:
      enum-name: SecurityRuleProtocol
      enum-value-name: ''
    set:
      enum-value-name: All
```
