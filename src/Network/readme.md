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
      subject: VirtualNetworkAvailableSubnetDelegation
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
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
    set:
      alias: Set-AzNetworkWatcherConfigFlowLog
  - where:
      verb: Get
      subject: ^NetworkWatcherTroubleshooting$
    set:
      verb: Start
      alias: Start-AzNetworkWatcherResourceTroubleshooting

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

# Dns
  - where:
      verb: Test
      subject: DnsNameAvailability
    set:
      alias: Test-AzDnsAvailability

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
  - where:
      verb: Get
      subject: NetworkInterfaceTapConfiguration
    set:
      alias: Get-AzNetworkInterfaceTapConfig
  - where:
      verb: Remove
      subject: NetworkInterfaceTapConfiguration
    set:
      alias: Remove-AzNetworkInterfaceTapConfig
  - where:
      verb: Set
      subject: NetworkInterfaceTapConfiguration
    set:
      alias: Set-AzNetworkInterfaceTapConfig

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
  - where:
      verb: Test
      subject: VirtualNetworkIPAddressAvailability
    set:
      alias: Test-AzPrivateIPAddressAvailability

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
      alias: ${verb}-Az${subject-prefix}${subject}
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

# Parameter Rename
## Name
  - where: # Property path
      verb: Get
      subject: ApplicationGatewayBackendHealth|ApplicationGatewayBackendHealthOnDemand
      parameter-name: ApplicationGatewayName
    set:
      parameter-name: Name
      alias: ApplicationGatewayName
  - where:
      verb: Get
      subject: ApplicationGatewaySslPredefinedPolicy
      parameter-name: PredefinedPolicyName
    set:
      parameter-name: Name
      alias: PredefinedPolicyName
  - where:
      verb: Get
      subject: ApplicationGatewayWafPolicy
      parameter-name: PolicyName
    set:
      parameter-name: Name
      alias: PolicyName
  - where:
      verb: Get|New|Remove
      subject: ExpressRouteCircuit
      parameter-name: CircuitName
    set:
      parameter-name: Name
      alias: CircuitName
  - where:
      verb: Get|Remove
      subject: ExpressRouteCircuitAuthorization
      parameter-name: AuthorizationName
    set:
      parameter-name: Name
      alias: AuthorizationName
  - where:
      verb: Get|Remove
      subject: ExpressRouteConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      verb: Get|Set
      subject: ExpressRouteCrossConnection
      parameter-name: CrossConnectionName
    set:
      parameter-name: Name
      alias: CrossConnectionName
  - where:
      verb: Get|Remove
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: PeeringName
    set:
      parameter-name: Name
      alias: PeeringName
  - where:
      verb: Get|Remove
      subject: NetworkInterfaceTapConfiguration
      parameter-name: TapConfigurationName
    set:
      parameter-name: Name
      alias: TapConfigurationName
  - where:
      verb: Get
      subject: VirtualHubVnetConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where: # Property path
      verb: Get|Reset|Set
      subject: VnetGatewayConnectionSharedKey
      parameter-name: VnetGatewayConnectionName
    set:
      parameter-name: Name
      alias: VnetGatewayConnectionName
  - where: # Property path
      verb: Get
      subject: VnetGatewaySupportedVpnDevice|VnetGatewayVpnClientIPsecParameter
      parameter-name: VnetGatewayName
    set:
      parameter-name: Name
      alias: VnetGatewayName
  - where: # Property path
      verb: Get
      subject: VnetGatewayVpnDeviceConfigurationScript
      parameter-name: VnetGatewayConnectionName
    set:
      parameter-name: Name
      alias: VnetGatewayConnectionName
  - where:
      verb: Get|New|Remove
      subject: VnetTap
      parameter-name: TapName
    set:
      parameter-name: Name
      alias: TapName
  - where: # Property path
      verb: Get
      subject: VnetUsage
      parameter-name: VnetName
    set:
      parameter-name: Name
      alias: VnetName
  - where:
      verb: Get|Remove
      subject: VpnConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      verb: Get|New|Remove
      subject: VpnGateway
      parameter-name: GatewayName
    set:
      parameter-name: Name
      alias: GatewayName
## Other
  - where: # Little to no documentation. Not sure how this parameter works or is used.
      verb: Get
      subject: ApplicationGatewayBackendHealth|ApplicationGatewayBackendHealthOnDemand|LoadBalancer|NetworkInterface|NetworkProfile|NetworkSecurityGroup|PublicIPAddress|RouteFilter|RouteTable|Vnet
      parameter-name: Expand
    set:
      parameter-name: ExpandResource
  - where:
      verb: Get
      subject: ExpressRouteCircuitArpTable|ExpressRouteCircuitRouteTable|ExpressRouteCircuitRouteTableSummary|ExpressRouteCircuitStat
      parameter-name: CircuitName
    set:
      alias: ExpressRouteCircuitName
  - where: # This parameter needs a validate set, as [AzurePrivatePeering, AzurePublicPeering, MicrosoftPeering] are listed as the only valid values in current cmdlets.
      verb: Get
      subject: ExpressRouteCircuitArpTable|ExpressRouteCircuitRouteTable|ExpressRouteCircuitRouteTableSummary|ExpressRouteCircuitStat|ExpressRouteCrossConnectionArpTable|ExpressRouteCrossConnectionRouteTable|ExpressRouteCrossConnectionRouteTableSummary
      parameter-name: PeeringName
    set:
      alias: PeeringType
  - where:
      subject: NetworkWatcherAvailableProvider|NetworkWatcherReachabilityReport
      parameter-name: AzureLocation
    set:
      parameter-name: Location
  - where: # REMOVE BEFORE RELEASE: Unnecessary custom client-side Location implementation
      subject: NetworkWatcherAvailableProvider|NetworkWatcherReachabilityReport
      parameter-name: InputObject
    set:
      alias: NetworkWatcherLocation
  - where: # REMOVE BEFORE RELEASE: Unnecessary custom client-side Location implementation
      subject: ^NetworkWatcher(?!(AvailableProvider|ReachabilityReport))(.*)
      parameter-name: InputObject
    set:
      alias: Location
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Get
      subject: NetworkWatcherAvailableProvider|NetworkWatcherFlowLogStatus|NetworkWatcherNetworkConfigurationDiagnostic|NetworkWatcherNextHop|NetworkWatcherReachabilityReport|NetworkWatcherTopology|NetworkWatcherTroubleshootingResult
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Get
      subject: NetworkWatcherConnectionMonitor|NetworkWatcherConnectionMonitorState|NetworkWatcherPacketCapture
      parameter-name: InputObject
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: New
      subject: NetworkWatcherConnectionMonitor|NetworkWatcherPacketCapture
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Remove
      subject: NetworkWatcher|NetworkWatcherConnectionMonitor|NetworkWatcherPacketCapture
      parameter-name: InputObject
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Set
      subject: NetworkWatcherConnectionMonitor|NetworkWatcherFlowLogConfiguration
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Start|Stop
      subject: NetworkWatcherConnectionMonitor
      parameter-name: InputObject
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Start
      subject: NetworkWatcherTroubleshooting
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Stop
      subject: NetworkWatcherPacketCapture
      parameter-name: InputObject
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Test
      subject: NetworkWatcherConnectivity|NetworkWatcherIPFlow
      parameter-name: Parameter
    set:
      alias: NetworkWatcher

# Other Fixes
  - where:
      subject: (.*)Stat$
    set:
      subject: $1Statistic
```
