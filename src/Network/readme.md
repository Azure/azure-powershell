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
require:
  - $(this-folder)/../readme.azure.md
  - $(repo)/specification/network/resource-manager/readme.enable-multi-api.md
  - $(repo)/specification/network/resource-manager/readme.md

subject-prefix: ''
module-version: 0.0.1

directive:
# General
  - where:
      enum-name: SecurityRuleProtocol
      enum-value-name: Asterisk
    set:
      enum-value-name: All
  - where:
      verb: Update
      subject: (.*)Tag$
    remove: true

# General Naming
  - where:
      subject: ^AzureFirewall(.*)
    set:
      subject: Firewall$1
  - where:
      subject: ^Route$
    set:
      subject: RouteTableRoute
  - where:
      subject: ^SecurityRule$
    set:
      subject: NetworkSecurityRule
  - where:
      subject: ^Usage$
    set:
      subject: NetworkUsage
  - where:
      subject: (.*)(?<!Scr)Ip(.*)
    set:
      subject: $1IP$2
  - where:
      parameter-name: (.*)(?<!Scr)Ip(.*)
    set:
      parameter-name: $1IP$2

# Vmss
  - where:
      subject: (.*)VirtualMachineScaleSet(.*)
    set:
      subject: Vmss$2
  - where:
      subject: VmssVMPublicIPaddress
    set:
      subject: VmssVMPublicIPAddress

# Subnet
  - where:
      subject: ^Subnet$
    set:
      subject: VirtualNetworkSubnet
  - where:
      subject: (.*)Delegation$
    set:
      subject: $1VirtualNetworkSubnetDelegation
  - where:
      verb: Get
      subject: AvailableResourceGroupVirtualNetworkSubnetDelegation
      variant: List
    set:
      variant: ResourceGroup
  - where:
      verb: Get
      subject: AvailableVirtualNetworkSubnetDelegation|AvailableResourceGroupVirtualNetworkSubnetDelegation
    set:
      subject: VirtualNetworkAvailableSubnetDelegation
  # - where: # Combine with Get-AzVirtualNetworkAvailableSubnetDelegation
  #     subject: AvailableResourceGroupVirtualNetworkSubnetDelegation
  #   hide: true
  - where:
      verb: Invoke
      subject: PrepareSubnetNetworkPolicy
    set:
      verb: Set
      subject: VirtualNetworkSubnetNetworkPolicy
  - where:
      verb: Get
      subject: AvailableVirtualNetworkSubnetDelegation
    set:
      alias: Get-AzAvailableServiceDelegation

# NetworkWatcher
  - where:
      subject: ^PacketCapture(.*)
    set:
      subject: NetworkWatcherPacketCapture$1
  - where: # Combine with Get-AzNetworkWatcherPacketCapture
      subject: NetworkWatcherPacketCaptureStatus
    hide: true
  - where:
      subject: ^ConnectionMonitor$
    set:
      subject: NetworkWatcherConnectionMonitor
  - where:
      verb: Invoke
      subject: QueryConnectionMonitor
    set:
      verb: Get
      subject: NetworkWatcherConnectionMonitorState
      alias: Get-AzNetworkWatcherConnectionMonitorReport
  - where:
      verb: Get
      subject: NetworkWatcherAvailableProvider
    set:
      alias: Get-AzNetworkWatcherReachabilityProvidersList
  - where:
      verb: Get
      subject: NetworkWatcherAzureReachabilityReport
    set:
      subject: NetworkWatcherReachabilityReport
  - where:
      verb: Get
      subject: NetworkWatcherNetworkConfigurationDiagnostic
    set:
      alias: Invoke-AzNetworkWatcherNetworkConfigurationDiagnostic

# ApplicationGateway
  - where:
      verb: Invoke
      subject: BackendApplicationGatewayHealth
    set:
      verb: Get
      subject: ApplicationGatewayBackendHealth
  - where:
      verb: Invoke
      subject: DemandApplicationGatewayBackendHealthOn
    set:
      verb: Get
      subject: ApplicationGatewayBackendHealthOnDemand
  - where: # Combine into Get-AzApplicationGatewayAvailableServerVariableAndHeader
      verb: Get
      subject: ApplicationGatewayAvailableRequestHeader|ApplicationGatewayAvailableResponseHeader|ApplicationGatewayAvailableServerVariable
    hide: true
  - where:
      verb: Get
      subject: ApplicationGatewayAvailableSslOption
    set:
      alias: Get-AzApplicationGatewayAvailableSslOptions
  - where:
      verb: Get
      subject: ApplicationGatewayAvailableWafRuleSet
    set:
      alias: Get-AzApplicationGatewayAvailableWafRuleSets
## WebApplicationFirewall
  - where:
      subject: ^WebApplicationFirewall(.*)
    set:
      subject: ApplicationGatewayWaf$1
  - where:
      verb: Get
      subject: ApplicationGatewayWafPolicy
    set:
      alias: Get-AzApplicationGatewayFirewallPolicy

# LoadBalancer
  - where:
      subject: ^InboundNatRule$
    set:
      subject: LoadBalancerInboundNatRule

# Vpn
  - where:
      verb: Invoke
      subject: DownloadVpnSiteConfiguration
    set:
      verb: Get
      subject: VpnSiteConfiguration

# VirtualNetworkGateway
  - where:
      subject: VirtualNetworkGatewayVpnclientIPsecParameter
    set:
      subject: VirtualNetworkGatewayVpnClientIPsecParameter
      alias: ${verb}-AzVpnClientIpsecParameter
  - where:
      verb: Invoke
      subject: DownloadVpnSiteConfiguration
    set:
      verb: Get
      subject: VpnSiteConfiguration
  - where:
      verb: Invoke
      subject: DownloadVpnSiteConfiguration
    set:
      verb: Get
      subject: VpnSiteConfiguration
  - where:
      verb: Invoke
      subject: GeneratevpnclientpackageVirtualNetworkGateway
    set:
      verb: New
      subject: VirtualNetworkGatewayVpnClientPackage
      alias: Get-AzVpnClientPackage
  - where:
      verb: Invoke
      subject: ScriptVirtualNetworkGatewayVpnDeviceConfiguration
    set:
      verb: Get
      subject: VirtualNetworkGatewayVpnDeviceConfigurationScript
  - where:
      verb: Invoke
      subject: SupportedVirtualNetworkGatewayVpnDevice
    set:
      verb: Get
      subject: VirtualNetworkGatewaySupportedVpnDevice
  - where:
      verb: Get
      subject: VirtualNetworkGatewayVpnDeviceConfigurationScript
    set:
      alias: Get-AzVirtualNetworkGatewayConnectionVpnDeviceConfigScript
  - where:
      verb: Get
      subject: VirtualNetworkUsage
    set:
      alias: Get-AzVirtualNetworkUsageList

# VirtualWan
  - where:
      verb: Invoke
      subject: SupportedSecurityProvider
    set:
      verb: Get
      subject: VirtualWanSupportedSecurityProvider

# NetworkInterface
  - where:
      verb: Get
      subject: NetworkInterfaceEffectiveNetworkSecurityGroup
    set:
      alias: Get-AzEffectiveNetworkSecurityGroup
  - where:
      verb: Get
      subject: NetworkInterfaceEffectiveRouteTable
    set:
      alias: Get-AzEffectiveRouteTable

# ExpressRouteCircuit
  - where:
      verb: Get
      subject: ExpressRouteCircuitStat
    set:
      alias: Get-AzExpressRouteCircuitStats

# VirtualNetwork
  - where:
      verb: Get
      subject: HubVirtualNetworkConnection
    set:
      subject: VirtualHubVirtualNetworkConnection
  - where:
      verb: Get
      subject: AvailableEndpointService
    set:
      subject: VirtualNetworkAvailableEndpointService

# Fix Alias Issues
  - where:
      verb: New|Set
      subject: LoadBalancerInboundNatRule|NetworkSecurityRule|RouteTableRoute|VirtualNetworkPeering|VirtualNetworkSubnet|P2SVpnServerConfiguration|ServiceEndpointPolicyDefinition
      parameter-name: Name
    clear-alias: true

# General Changes (at end)
  - where:
      subject: (.*)VirtualNetwork(.*)
    set:
      alias: ${verb}-$(prefix)${subject-prefix}${subject}
  # - where:
  #     parameter-name: (.*)VirtualNetwork(.*)
  #   set:
  #     alias: $1VirtualNetwork$2
  - where:
      subject: (.*)VirtualNetwork(.*)
    set:
      subject: $1Vnet$2
  - where:
      parameter-name: (.*)VirtualNetwork(.*)
    set:
      parameter-name: $1Vnet$2
```
