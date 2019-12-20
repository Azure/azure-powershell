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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

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
  - $(this-folder)/resources/specs-used.md
  # Including this file would drag in every version, and the filter would take a lot longer. 
  # - $(repo)/specification/network/resource-manager/readme.md

title: Network
subject-prefix: ''
module-version: 4.0.2
make-sub-resources-byreference: true

directive:
# we must pick a model to not inline when there is a circular reference (previously it was picking an arbitrary one, and this was very bad)
  - no-inline: 
    - IPConfiguration 

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
  - where: # Fix casing
      subject: (.*)IPaddress(.*)
    set:
      subject: $1IPAddress$2

# Vmss
  - where:
      subject: (.*)VirtualMachineScaleSet(.*)
    set:
      alias: ${verb}-Az${subject-prefix}${subject}
  - where:
      parameter-name: (.*)VirtualMachineScaleSet(.*)
    set:
      alias: $1VirtualMachineScaleSet$2
  - where:
      subject: (.*)VirtualMachineScaleSet(.*)
    set:
      subject: $1Vmss$2
  - where:
      parameter-name: (.*)VirtualMachineScaleSet(.*)
    set:
      parameter-name: $1Vmss$2

# VM
  - where:
      subject: (.*)VirtualMachine(.*)
    set:
      alias: ${verb}-Az${subject-prefix}${subject}
  - where:
      parameter-name: (.*)VirtualMachine(.*)
    set:
      alias: $1VirtualMachine$2
  - where:
      subject: (.*)VirtualMachine(.*)
    set:
      subject: $1VM$2
  - where:
      parameter-name: (.*)VirtualMachine(.*)
    set:
      parameter-name: $1VM$2

# Public IP
  - where:
      verb: Get
      subject: PublicIPAddressVmssPublicIPAddress
      variant: List
    set:
      variant: ListVmss
  - where:
      verb: Get
      subject: PublicIPAddressVmssPublicIPAddress
      variant: Get
    set:
      variant: GetVmss
  - where:
      verb: Get
      subject: PublicIPAddressVmssPublicIPAddress
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Get
      subject: PublicIPAddressVmssPublicIPAddress
      parameter-name: PublicIPAddressName
    set:
      parameter-name: Name
      alias: PublicIPAddressName
  - where:
      verb: Get
      subject: PublicIPAddressVmssPublicIPAddress
    set:
      subject: PublicIPAddress
  - where:
      verb: Get
      subject: PublicIPAddressVmssVMPublicIPAddress
      variant: List
    set:
      variant: ListVmssVM
  - where:
      verb: Get
      subject: PublicIPAddressVmssVMPublicIPAddress
    set:
      subject: PublicIPAddress

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
      subject: ^AvailableVirtualNetworkSubnetDelegation$|^AvailableResourceGroupVirtualNetworkSubnetDelegation$
    set:
      subject: VirtualNetworkAvailableSubnetDelegation
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
  - where:
      verb: Get
      subject: NetworkWatcherPacketCaptureStatus
      parameter-name: PacketCaptureName
    set:
      parameter-name: Name
      alias: PacketCaptureName
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
  - where:
      verb: Get
      subject: NetworkWatcherReachabilityReport
      parameter-name: ProviderLocation(.*)
    set:
      alias: $1
  - where:
      verb: Get
      subject: NetworkWatcherReachabilityReport
      parameter-name: ProviderLocation(.*)
    set:
      parameter-name: Provider$1

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
      subject: ^ApplicationGatewayAvailableRequestHeader$|^ApplicationGatewayAvailableResponseHeader$|^ApplicationGatewayAvailableServerVariable$
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
  - where:
      subject: ^ApplicationGateway(.*)
      parameter-name: ^WebApplicationFirewall(.*)
    set:
      parameter-name: Waf$1
  - where:
      model-name: ^ApplicationGateway(.*)
      property-name: ^WebApplicationFirewall(.*)
    set:
      property-name: Waf$1

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
  - where:
      verb: Get
      subject: NetworkInterfaceVmssNetworkInterface
      variant: List
    set:
      variant: ListVmss
  - where:
      verb: Get
      subject: NetworkInterfaceVmssNetworkInterface
      variant: Get
    set:
      variant: GetVmss
  - where:
      verb: Get
      subject: NetworkInterfaceVmssNetworkInterface
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Get
      subject: NetworkInterfaceVmssNetworkInterface
      parameter-name: NetworkInterfaceName
    set:
      parameter-name: Name
      alias: NetworkInterfaceName
  - where:
      verb: Get
      subject: NetworkInterfaceVmssNetworkInterface
    set:
      subject: NetworkInterface
  - where:
      verb: Get
      subject: NetworkInterfaceVmssVMNetworkInterface
      variant: List
    set:
      variant: ListVmssVM
  - where:
      verb: Get
      subject: NetworkInterfaceVmssVMNetworkInterface
    set:
      subject: NetworkInterface
  - where:
      verb: Get
      subject: NetworkInterfaceVmssIPConfiguration
      variant: List
    set:
      variant: ListVmss
  - where:
      verb: Get
      subject: NetworkInterfaceVmssIPConfiguration
      variant: Get
    set:
      variant: GetVmss
  - where:
      verb: Get
      subject: NetworkInterfaceVmssIPConfiguration
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Get
      subject: NetworkInterfaceVmssIPConfiguration
    set:
      subject: NetworkInterfaceIPConfiguration

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
      verb: ^New$|^Set$
      subject: ^LoadBalancerInboundNatRule$|^NetworkSecurityRule$|^RouteTableRoute$|^VirtualNetworkPeering$|^VirtualNetworkSubnet$|^P2SVpnServerConfiguration$|^ServiceEndpointPolicyDefinition$
      parameter-name: Name
    clear-alias: true

# General Changes
  - where:
      subject: (.*)VirtualNetwork(.*)
    set:
      alias: ${verb}-Az${subject-prefix}${subject}
  - where:
      parameter-name: (.*)VirtualNetwork(.*)
    set:
      alias: $1VirtualNetwork$2
  - where:
      subject: (.*)VirtualNetwork(.*)
    set:
      subject: $1Vnet$2
  - where:
      parameter-name: (.*)VirtualNetwork(.*)
    set:
      parameter-name: $1Vnet$2
  - where:
      property-name: (.*)VirtualNetwork(.*)
    set:
      property-name: $1Vnet$2

# Parameter Rename
## Name
  - where: # Property path
      verb: Get
      subject: ^ApplicationGatewayBackendHealth$|^ApplicationGatewayBackendHealthOnDemand$
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
      subject: ApplicationGatewayWafPolicy
      parameter-name: PolicyName
    set:
      parameter-name: Name
      alias: PolicyName
  - where:
      subject: ExpressRouteCircuit
      parameter-name: CircuitName
    set:
      parameter-name: Name
      alias: CircuitName
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: ExpressRouteCircuitAuthorization
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: ExpressRouteCircuitAuthorization
      parameter-name: AuthorizationName
    set:
      parameter-name: Name
      alias: AuthorizationName
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: ExpressRouteConnection
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: ExpressRouteConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      subject: ExpressRouteCrossConnection
      parameter-name: CrossConnectionName
    set:
      parameter-name: Name
      alias: CrossConnectionName
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: PeeringName
    set:
      parameter-name: Name
      alias: PeeringName
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: NetworkInterfaceTapConfiguration
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
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
      verb: ^Get$|^Reset$|^Set$
      subject: VnetGatewayConnectionSharedKey
      parameter-name: VnetGatewayConnectionName
    set:
      parameter-name: Name
      alias: VnetGatewayConnectionName
  - where: # Property path
      verb: Get
      subject: ^VnetGatewaySupportedVpnDevice$|^VnetGatewayVpnClientIPsecParameter$
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
      verb: ^Get$|^Remove$
      subject: VpnConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      subject: VpnGateway
      parameter-name: GatewayName
    set:
      parameter-name: Name
      alias: GatewayName
## Other
  - where: # Little to no documentation. Not sure how this parameter works or is used.
      verb: Get
      subject: ^ApplicationGatewayBackendHealth$|^ApplicationGatewayBackendHealthOnDemand$|^LoadBalancer$|^NetworkInterface$|^NetworkProfile$|^NetworkSecurityGroup$|^PublicIPAddress$|^RouteFilter$|^RouteTable$|^Vnet$
      parameter-name: Expand
    set:
      alias: ExpandResource
  - where:
      verb: Get
      subject: ExpressRouteCircuitPeeringStat
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Get
      subject: ExpressRouteCircuitPeeringStat
      variant: Get
    set:
      subject: ExpressRouteCircuitStat
      variant: Peering
  - where:
      verb: Get
      subject: ^ExpressRouteCircuitArpTable$|^ExpressRouteCircuitRouteTable$|^ExpressRouteCircuitRouteTableSummary$|^ExpressRouteCircuitStat$
      parameter-name: CircuitName
    set:
      alias: ExpressRouteCircuitName
  - where: # This parameter needs a validate set, as [AzurePrivatePeering, AzurePublicPeering, MicrosoftPeering] are listed as the only valid values in current cmdlets.
      verb: Get
      subject: ^ExpressRouteCircuitArpTable$|^ExpressRouteCircuitRouteTable$|^ExpressRouteCircuitRouteTableSummary$|^ExpressRouteCircuitStat$|^ExpressRouteCrossConnectionArpTable$|^ExpressRouteCrossConnectionRouteTable$|^ExpressRouteCrossConnectionRouteTableSummary$
      parameter-name: PeeringName
    set:
      alias: PeeringType
  - where:
      subject: ^NetworkWatcherAvailableProvider$|^NetworkWatcherReachabilityReport$
      parameter-name: AzureLocation
    set:
      parameter-name: Location
  - where:
      verb: ^Get$|^New$|^Remove$
      subject: VpnConnection
      parameter-name: GatewayName
    set:
      alias: ParentResourceName
  - where:
      verb: Set
      subject: ExpressRouteCrossConnection
      parameter-name: ServiceProviderNote
    set:
      alias: ServiceProviderNotes
  - where:
      verb: Set
      subject: ExpressRouteCrossConnection
      parameter-name: Peering
    set:
      alias: Peerings
  - where:
      verb: Get
      subject: NetworkWatcherNextHop
      parameter-name: TargetResourceId
    set:
      parameter-name: TargetVMResourceId
      alias: TargetVirtualMachineId
  - where:
      verb: Get
      subject: NetworkWatcherNextHop
      parameter-name: TargetNicResourceId
    set:
      alias: TargetNetworkInterfaceId
  - where:
      verb: Get
      subject: VnetGatewayVpnDeviceConfigurationScript
      parameter-name: Vendor
    set:
      alias: DeviceVendor
  - where:
      verb: New
      subject: ^LoadBalancer$|^PublicIPAddress$|^PublicIPPrefix$
      parameter-name: SkuName
    set:
      alias: Sku
  - where:
      verb: New
      subject: NetworkSecurityGroup
      parameter-name: SecurityRule
    set:
      alias: SecurityRules
  - where:
      subject: PublicIPPrefix
      parameter-name: PublicIPAddressVersion
    set:
      alias: IPAddressVersion
  - where:
      subject: Vnet
      parameter-name: AddressSpaceAddressPrefix
    set:
      parameter-name: AddressPrefix
  - where:
      model-name: VirtualNetwork
      property-name: AddressSpaceAddressPrefix
    set:
      property-name: AddressPrefix
  - where:
      subject: Vnet
      parameter-name: DhcpOptionDnsServer
    set:
      parameter-name: DnsServer
  - where:
      model-name: VirtualNetwork
      property-name: DhcpOptionDnsServer
    set:
      property-name: DnsServer
  - where:
      verb: New
      subject: VpnConnection
      parameter-name: RemoteVpnSiteId
    set:
      alias: VpnSiteId
  - where:
      verb: New
      subject: VpnConnection
      parameter-name: ConnectionBandwidth
    set:
      alias: ConnectionBandwidthInMbps
  - where:
      verb: New
      subject: VpnGateway
      parameter-name: Connection
    set:
      alias: VpnConnection
  - where: # Uses VirtualHub.Name/VirtualHubName to do a Get call to get the resource ID for VirtualHubId. Decide if this kind of logic needs to be implemented??
      verb: New
      subject: ^VpnGateway$|^ExpressRouteGateway$
      parameter-name: ResourceGroupName
    set:
      alias:
        - VirtualHub
        - VirtualHubName
  - where:
      verb: ^Set$|^New$
      subject: ExpressRouteGateway
      parameter-name: BoundMin
    set:
      parameter-name: MinimumScaleUnit
      alias: MinScaleUnits
  - where:
      model-name: ExpressRouteGateway
      property-name: BoundMin
    set:
      property-name: MinimumScaleUnit
  - where:
      verb: ^Set$|^New$
      subject: ExpressRouteGateway
      parameter-name: BoundMax
    set:
      parameter-name: MaximumScaleUnit
      alias: MaxScaleUnits
  - where:
      model-name: ExpressRouteGateway
      property-name: BoundMax
    set:
      property-name: MaximumScaleUnit
  - where:
      verb: Set
      subject: VnetGatewayVpnClientIPsecParameter
      parameter-name: VpnclientIPsecParam
    set:
      parameter-name: VpnClientIPsecParameter
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: GatewayIPConfiguration
    set:
      alias: GatewayIPConfigurations
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: SslCertificate
    set:
      alias: SslCertificates
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: AuthenticationCertificate
    set:
      alias: AuthenticationCertificates
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: FrontendIPConfiguration
    set:
      alias: FrontendIPConfigurations
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: FrontendPort
    set:
      alias: FrontendPorts
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: Probe
    set:
      alias: Probes
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: BackendAddressPool
    set:
      alias: BackendAddressPools
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: HttpListener
    set:
      alias: HttpListeners
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: UrlPathMap
    set:
      alias: UrlPathMaps
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: RequestRoutingRule
    set:
      alias: RequestRoutingRules
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: RedirectConfiguration
    set:
      alias: RedirectConfigurations
  - where:
      verb: New
      subject: ApplicationGateway
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      verb: ^New$|^Set$
      subject: ExpressRouteCircuit
      parameter-name: ServiceProviderPropertyBandwidthInMbps
    set:
      parameter-name: ServiceProviderBandwidthInMbps
      alias: BandwidthInMbps
  - where:
      model-name: ExpressRouteCircuit
      property-name: ServiceProviderPropertyBandwidthInMbps
    set:
      property-name: ServiceProviderBandwidthInMbps
  - where:
      verb: ^New$|^Set$
      subject: ExpressRouteCircuit
      parameter-name: ServiceProviderPropertyPeeringLocation
    set:
      parameter-name: ServiceProviderPeeringLocation
      alias: PeeringLocation
  - where:
      model-name: ExpressRouteCircuit
      property-name: ServiceProviderPropertyPeeringLocation
    set:
      property-name: ServiceProviderPeeringLocation
  - where:
      verb: ^New$|^Set$
      subject: ExpressRouteCircuit
      parameter-name: ServiceProviderPropertyServiceProviderName
    set:
      parameter-name: ServiceProviderName
  - where:
      model-name: ExpressRouteCircuit
      property-name: ServiceProviderPropertyServiceProviderName
    set:
      property-name: ServiceProviderName
  - where:
      verb: ^New$|^Set$
      subject: ExpressRouteCircuit
      parameter-name: AllowClassicOperation
    set:
      parameter-name: AllowClassicOperations
  - where:
      model-name: ExpressRouteCircuit
      property-name: AllowClassicOperation
    set:
      property-name: AllowClassicOperations
  - where:
      verb: ^New$|^Set$
      subject: LocalNetworkGateway
      parameter-name: LocalNetworkAddressSpaceAddressPrefix
    set:
      parameter-name: AddressPrefix
  - where:
      model-name: LocalNetworkGateway
      property-name: LocalNetworkAddressSpaceAddressPrefix
    set:
      property-name: AddressPrefix
  - where:
      subject: ^LocalNetworkGateway$|^VnetGateway$|^VpnSite$|^VnetGatewayConnection$|^VpnGateway$
      parameter-name: ^BgpSettingAsn$|^BgpPropertyAsn$
    set:
      parameter-name: BgpAsn
      alias: Asn
  - where:
      model-name: ^LocalNetworkGateway$|^VirtualNetworkGateway$|^VpnSite$|^VirtualNetworkGatewayConnection$|^VpnGateway$
      property-name: ^BgpSettingAsn$|^BgpPropertyAsn$
    set:
      property-name: BgpAsn
  - where:
      subject: ^LocalNetworkGateway$|^VnetGateway$|^VpnSite$|^VnetGatewayConnection$|^VpnGateway$
      parameter-name: ^BgpSettingBgpPeeringAddress$|^BgpPropertyBgpPeeringAddress$
    set:
      parameter-name: BgpPeeringAddress
  - where:
      model-name: ^LocalNetworkGateway$|^VirtualNetworkGateway$|^VpnSite$|^VirtualNetworkGatewayConnection$|^VpnGateway$
      property-name: ^BgpSettingBgpPeeringAddress$|^BgpPropertyBgpPeeringAddress$
    set:
      property-name: BgpPeeringAddress
  - where:
      subject: ^LocalNetworkGateway$|^VnetGateway$|^VpnSite$|^VnetGatewayConnection$|^VpnGateway$
      parameter-name: ^BgpSettingPeerWeight$|^BgpPropertyPeerWeight$
    set:
      parameter-name: BgpPeerWeight
      alias:
        - PeerWeight
        - BgpPeeringWeight
  - where:
      model-name: ^LocalNetworkGateway$|^VirtualNetworkGateway$|^VpnSite$|^VirtualNetworkGatewayConnection$|^VpnGateway$
      property-name: ^BgpSettingPeerWeight$|^BgpPropertyPeerWeight$
    set:
      property-name: BgpPeerWeight
  - where:
      subject: NetworkInterface
      parameter-name: ^NetworkSecurityGroupProperties(.*)$
    set:
      parameter-name: NetworkSecurityGroup$1
  - where:
      model-name: NetworkInterface
      property-name: ^NetworkSecurityGroupProperties(.+)$
    set:
      property-name: NetworkSecurityGroup$1
  - where:
      model-name: NetworkInterface
      property-name: PropertiesNetworkSecurityGroupPropertiesNetworkInterfaces
    set:
      property-name: NetworkSecurityGroupAdditionalNetworkInterface
  - where:
      model-name: NetworkInterface
      property-name: PropertiesNetworkSecurityGroupPropertiesSubnets
    set:
      property-name: NetworkSecurityGroupSubnet
  - where:
      subject: NetworkInterface
      parameter-name: ^DnsSetting(.*)$
    set:
      parameter-name: $1
  - where:
      model-name: NetworkInterface
      property-name: ^DnsSetting(.+)$
    set:
      property-name: $1

# Network Security Group
  - where:
      subject: (.*)NetworkSecurityGroup(.*)
    set:
      alias: ${verb}-Az${subject-prefix}${subject}
  - where:
      parameter-name: (.*)NetworkSecurityGroup(.*)
    set:
      alias: $1NetworkSecurityGroup$2
  - where:
      subject: (.*)NetworkSecurityGroup(.*)
    set:
      subject: $1Nsg$2
  - where:
      parameter-name: (.*)NetworkSecurityGroup(.*)
    set:
      parameter-name: $1Nsg$2
  - where:
      property-name: (.*)NetworkSecurityGroup(.*)
    set:
      property-name: $1Nsg$2
  - where:
      model-name: NetworkConfigurationDiagnosticResult
      property-name: NetworkSecurityGroupResultEvaluatedNsg
    set:
      property-name: NsgResultEvaluatedNsg

# Other Fixes
  - where:
      subject: (.*)Stat$
    set:
      subject: $1Statistic
  - where:
      parameter-name: ^(.*)InSecond$
    set:
      parameter-name: $1InSeconds
  - where:
      parameter-name: ^(.*)InMinute$
    set:
      parameter-name: $1InMinutes
  - where:
      parameter-name: ^(.*)InHour$
    set:
      parameter-name: $1InHours
  - where:
      parameter-name: ^(.*)InDay$
    set:
      parameter-name: $1InDays
  - where:
      property-name: ^(.*)InSecond$
    set:
      property-name: $1InSeconds
  - where:
      property-name: ^(.*)InMinute$
    set:
      property-name: $1InMinutes
  - where:
      property-name: ^(.*)InHour$
    set:
      property-name: $1InHours
  - where:
      property-name: ^(.*)InDay$
    set:
      property-name: $1InDays
  - where:
      parameter-name: ^(.*)IPaddress(.*)$
    set:
      parameter-name: $1IPAddress$2
  - where:
      parameter-name: ^(.*)IPallocation(.*)$
    set:
      parameter-name: $1IPAllocation$2
  - where:
      parameter-name: ^(.*)VIP(.*)$
    set:
      parameter-name: $1Vip$2

# More fixes
  - where:
      verb: New
      subject: NetworkWatcherPacketCapture
      parameter-name: Target
    set:
      parameter-name: TargetResourceId
      alias: TargetVirtualMachineId
  - where:
      verb: New
      subject: NetworkWatcherPacketCapture
      parameter-name: StorageLocationFilePath
    set:
      parameter-name: StorageFilePath
      alias: LocalFilePath
  - where:
      verb: New
      subject: NetworkWatcherPacketCapture
      parameter-name: StorageLocationStorageId
    set:
      parameter-name: StorageAccountId
  - where:
      verb: New
      subject: NetworkWatcherPacketCapture
      parameter-name: StorageLocationStoragePath
    set:
      parameter-name: StoragePathUri
      alias: StoragePath
  - where:
      subject: PublicIPAddress
      parameter-name: ^PublicIP(.*)$
    set:
      parameter-name: $1
  - where:
      model-name: PublicIPAddress
      property-name: ^PublicIP(.+)$
    set:
      property-name: $1
  - where:
      subject: PublicIPAddress
      parameter-name: AddressVersion
    set:
      parameter-name: IPAddressVersion
  - where:
      model-name: PublicIPAddress
      property-name: Version
    set:
      property-name: IPAddressVersion
  - where:
      subject: PublicIPAddress
      parameter-name: DdosSettingProtectionCoverage
    set:
      parameter-name: DdosProtectionCoverage
  - where:
      model-name: PublicIPAddress
      property-name: DdosSettingProtectionCoverage
    set:
      property-name: DdosProtectionCoverage
  - where:
      subject: PublicIPAddress
      parameter-name: ^DnsSetting(.*)$
    set:
      parameter-name: $1
  - where:
      subject: PublicIPAddress
      parameter-name: ^DnsSetting(.+)$
    set:
      parameter-name: $1
  - where:
      subject: VirtualHub
      parameter-name: RouteTableRoute
    set:
      parameter-name: Route
      alias: RouteTable
  - where:
      model-name: VirtualHub
      property-name: RouteTableRoute
    set:
      property-name: Route
  - where:
      subject: VirtualHub
      parameter-name: VnetConnection
    set:
      alias: HubVnetConnection
  - where:
      verb: New
      subject: VnetGateway
      parameter-name: IPConfiguration
    set:
      alias: IpConfigurations
  - where:
      verb: ^New$|^Set$
      subject: VnetGateway
      parameter-name: Active
    set:
      parameter-name: EnableActiveActive
      alias: EnableActiveActiveFeature
  - where:
      model-name: VirtualNetworkGateway
      property-name: Active
    set:
      property-name: EnableActiveActive
  - where:
      verb: ^New$|^Set$
      subject: VnetGateway
      parameter-name: ^VpnClientConfigurationVpnClient(.*)$
    set:
      parameter-name: VpnClient$1
  - where:
      model-name: VirtualNetworkGateway
      property-name: ^VpnClientConfigurationVpnClient(.+)$
    set:
      property-name: VpnClient$1
  - where:
      verb: ^New$|^Set$
      subject: VnetGateway
      parameter-name: ^VpnClientConfiguration(.*)$
    set:
      parameter-name: VpnClient$1
  - where:
      model-name: VirtualNetworkGateway
      property-name: ^VpnClientConfiguration(.+)$
    set:
      property-name: VpnClient$1
  - where:
      verb: ^New$|^Set$
      subject: VnetGateway
      parameter-name: VpnClientRootCertificate
    set:
      alias: VpnClientRootCertificates
  - where:
      verb: ^New$|^Set$
      subject: VnetGateway
      parameter-name: VpnClientRevokedCertificate
    set:
      alias: VpnClientRevokedCertificates
  - where:
      verb: ^New$|^Set$
      subject: VnetGateway
      parameter-name: VpnClientAddressPoolAddressPrefix
    set:
      parameter-name: VpnClientAddressPrefix
      alias: VpnClientAddressPool
  - where:
      model-name: VirtualNetworkGateway
      property-name: VpnClientAddressPoolAddressPrefix
    set:
      property-name: VpnClientAddressPrefix
  - where:
      verb: ^New$|^Set$
      subject: VnetGatewayConnection
      parameter-name: LocalNetworkAddressSpaceAddressPrefix
    set:
      parameter-name: LocalNetworkAddressPrefix
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkAddressSpaceAddressPrefix
    set:
      property-name: LocalNetworkAddressPrefix
  - where:
      verb: ^New$|^Set$
      subject: VnetGatewayConnection
      parameter-name: UsePolicyBasedTrafficSelector
    set:
      parameter-name: UsePolicyBasedTrafficSelectors
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: UsePolicyBasedTrafficSelector
    set:
      property-name: UsePolicyBasedTrafficSelectors
  - where:
      verb: ^New$|^Set$
      subject: VnetGatewayConnection
      parameter-name: IPsecPolicy
    set:
      alias: IpsecPolicies
  - where:
      subject: VpnSite
      parameter-name: ^DeviceProperty(.*)$
    set:
      parameter-name: $1
  - where:
      model-name: VpnSite
      property-name: ^DeviceProperty(.+)$
    set:
      property-name: $1
  - where:
      subject: VpnSite
      parameter-name: AddressSpaceAddressPrefix
    set:
      parameter-name: AddressPrefix
      alias: AddressSpace
  - where:
      model-name: VpnSite
      property-name: AddressSpaceAddressPrefix
    set:
      property-name: AddressPrefix
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: Enabled
    set:
      parameter-name: EnableFlowLog
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: NetworkWatcherFlowAnalyticConfigurationEnabled
    set:
      parameter-name: EnableTrafficAnalytics
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: RetentionPolicyEnabled
    set:
      parameter-name: EnableRetention
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: StorageId
    set:
      parameter-name: StorageAccountId
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: RetentionPolicyDay
    set:
      parameter-name: RetentionInDays
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: NetworkWatcherFlowAnalyticConfigurationWorkspaceId
    set:
      parameter-name: WorkspaceGuid
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion
    set:
      parameter-name: WorkspaceLocation
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId
    set:
      parameter-name: WorkspaceResourceId
  - where:
      verb: Set
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval
    set:
      parameter-name: TrafficAnalyticsInterval
  - where:
      verb: Test
      subject: NetworkWatcherConnectivity
      parameter-name: SourceResourceId
    set:
      alias: SourceId
  - where:
      verb: Test
      subject: NetworkWatcherConnectivity
      parameter-name: DestinationResourceId
    set:
      alias: DestinationId
  - where:
      verb: Test
      subject: NetworkWatcherConnectivity
      parameter-name: Protocol
    set:
      alias: ProtocolConfiguration
  - where:
      verb: Test
      subject: NetworkWatcherIPFlow
      parameter-name: TargetResourceId
    set:
      alias: TargetVirtualMachineId
  - where:
      verb: Test
      subject: NetworkWatcherIPFlow
      parameter-name: TargetNicResourceId
    set:
      parameter-name: NetworkInterfaceResourceId
      alias: TargetNetworkInterfaceId

# Combine
  - where:
      verb: Get
      subject: ExpressRouteCircuitRouteTable
      variant: (.*)
    set:
      variant: Circuit$1
  - where:
      verb: Get
      subject: ExpressRouteCrossConnectionRouteTable
      variant: (.*)
    set:
      variant: CrossConnection$1
  - where:
      verb: Get
      subject: ExpressRouteCircuitRouteTable
    set:
      alias: ${verb}-Az${subject-prefix}${subject}
  - where:
      verb: Get
      subject: ExpressRouteCircuitRouteTable
    set:
      subject: ExpressRouteRouteTable
  - where:
      verb: Get
      subject: ExpressRouteCrossConnectionRouteTable
    set:
      alias: ${verb}-Az${subject-prefix}${subject}
  - where:
      verb: Get
      subject: ExpressRouteCrossConnectionRouteTable
    set:
      subject: ExpressRouteRouteTable
  - where:
      verb: Get
      subject: ApplicationGatewayBackendHealthOnDemand
    hide: true
  - where:
      verb: Get
      subject: ApplicationGatewayBackendHealthOnDemand
      variant: ^Demand$|^DemandViaIdentity$
    remove: true

# Parameter parameters
  - where:
      subject: ApplicationGateway
      parameter-name: Parameter
    set:
      parameter-name: ApplicationGateway
  - where:
      subject: ApplicationGatewayWafPolicy
      parameter-name: Parameter
    set:
      parameter-name: WafPolicy
  - where:
      subject: ApplicationSecurityGroup
      parameter-name: Parameter
    set:
      parameter-name: SecurityGroup
  - where:
      subject: DdosCustomPolicy
      parameter-name: Parameter
    set:
      parameter-name: DdosCustomPolicy
  - where:
      subject: DdosProtectionPlan
      parameter-name: Parameter
    set:
      parameter-name: DdosProtectionPlan
  - where:
      subject: ExpressRouteCircuit
      parameter-name: Parameter
    set:
      parameter-name: ExpressRouteCircuit
  - where:
      subject: ExpressRouteCrossConnection
      parameter-name: Parameter
    set:
      parameter-name: ExpressRouteCrossConnection
  - where:
      subject: ExpressRoutePort
      parameter-name: Parameter
    set:
      parameter-name: ExpressRoutePort
  - where:
      subject: Firewall
      parameter-name: Parameter
    set:
      parameter-name: Firewall
  - where:
      subject: InterfaceEndpoint
      parameter-name: Parameter
    set:
      parameter-name: InterfaceEndpoint
  - where:
      subject: LoadBalancer
      parameter-name: Parameter
    set:
      parameter-name: LoadBalancer
  - where:
      subject: LocalNetworkGateway
      parameter-name: Parameter
    set:
      parameter-name: LocalNetworkGateway
  - where:
      subject: NatGateway
      parameter-name: Parameter
    set:
      parameter-name: NatGateway
  - where:
      subject: NetworkInterface
      parameter-name: Parameter
    set:
      parameter-name: NetworkInterface
  - where:
      subject: NetworkProfile
      parameter-name: Parameter
    set:
      parameter-name: NetworkProfile
  - where:
      subject: NetworkWatcher
      parameter-name: Parameter
    set:
      parameter-name: NetworkWatcher
  - where:
      subject: NetworkWatcherAvailableProvider
      parameter-name: Parameter
    set:
      parameter-name: AvailableProvider
  - where:
      subject: NetworkWatcherConnectionMonitor
      parameter-name: Parameter
    set:
      parameter-name: ConnectionMonitor
  - where:
      subject: NetworkWatcherConnectivity
      parameter-name: Parameter
    set:
      parameter-name: Connectivity
  - where:
      subject: NetworkWatcherFlowLogConfiguration
      parameter-name: Parameter
    set:
      parameter-name: FlowLogConfiguration
  - where:
      subject: NetworkWatcherFlowLogStatus
      parameter-name: Parameter
    set:
      parameter-name: FlowLogStatus
  - where:
      subject: NetworkWatcherIPFlow
      parameter-name: Parameter
    set:
      parameter-name: IPFlow
  - where:
      subject: NetworkWatcherNetworkConfigurationDiagnostic
      parameter-name: Parameter
    set:
      parameter-name: NetworkConfigurationDiagnostic
  - where:
      subject: NetworkWatcherNextHop
      parameter-name: Parameter
    set:
      parameter-name: NextHop
  - where:
      subject: NetworkWatcherPacketCapture
      parameter-name: Parameter
    set:
      parameter-name: PacketCapture
  - where:
      subject: NetworkWatcherReachabilityReport
      parameter-name: Parameter
    set:
      parameter-name: ReachabilityReport
  - where:
      subject: NetworkWatcherTopology
      parameter-name: Parameter
    set:
      parameter-name: Topology
  - where:
      subject: NetworkWatcherTroubleshooting
      parameter-name: Parameter
    set:
      parameter-name: Troubleshooting
  - where:
      subject: NetworkWatcherTroubleshootingResult
      parameter-name: Parameter
    set:
      parameter-name: Troubleshooting
  - where:
      subject: NetworkWatcherVMSecurityRule
      parameter-name: Parameter
    set:
      parameter-name: SecurityGroupView
  - where:
      subject: Nsg
      parameter-name: Parameter
    set:
      parameter-name: Nsg
  - where:
      subject: P2SVpnGatewayVpnProfile
      parameter-name: Parameter
    set:
      parameter-name: VpnProfile
  - where:
      subject: PublicIPAddress
      parameter-name: Parameter
    set:
      parameter-name: PublicIPAddress
  - where:
      subject: PublicIPPrefix
      parameter-name: Parameter
    set:
      parameter-name: PublicIPPrefix
  - where:
      subject: RouteTable
      parameter-name: Parameter
    set:
      parameter-name: RouteTable
  - where:
      subject: ServiceEndpointPolicy
      parameter-name: Parameter
    set:
      parameter-name: ServiceEndpointPolicy
  - where:
      subject: Vnet
      parameter-name: Parameter
    set:
      parameter-name: Vnet
  - where:
      subject: VnetGateway
      parameter-name: Parameter
    set:
      parameter-name: VnetGateway
  - where:
      subject: VnetGatewayConnection
      parameter-name: Parameter
    set:
      parameter-name: VnetGatewayConnection
  - where:
      subject: VnetGatewayConnectionSharedKey
      parameter-name: Parameter
    set:
      parameter-name: ConnectionSharedKey
  - where:
      subject: VnetGatewayVpnClientPackage
      parameter-name: Parameter
    set:
      parameter-name: VpnClientPackage
  - where:
      subject: VnetGatewayVpnDeviceConfigurationScript
      parameter-name: Parameter
    set:
      parameter-name: VpnDeviceConfigurationScript
  - where:
      subject: VnetGatewayVpnProfile
      parameter-name: Parameter
    set:
      parameter-name: VpnProfile
  - where:
      subject: VnetTap
      parameter-name: VnetTap
    set:
      parameter-name: AdditionalVnetTap
  - where:
      model-name: VirtualNetworkTap
      property-name: PropertiesDestinationNetworkInterfaceIPConfigurationPropertiesVnetTaps
    set:
      property-name: AdditionalVnetTap
  - where:
      subject: VnetTap
      parameter-name: Parameter
    set:
      parameter-name: VnetTap

# Parameter (ending) parameters
  - where:
      subject: ExpressRouteCircuitAuthorization
      parameter-name: AuthorizationParameter
    set:
      parameter-name: Authorization
  - where:
      subject: ExpressRouteCircuitConnection
      parameter-name: ExpressRouteCircuitConnectionParameter
    set:
      parameter-name: ExpressRouteCircuitConnection
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: PeeringParameter
    set:
      parameter-name: Peering
  - where:
      subject: ExpressRouteConnection
      parameter-name: PutExpressRouteConnectionParameter
    set:
      parameter-name: ExpressRouteConnection
  - where:
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: PeeringParameter
    set:
      parameter-name: CrossConnectionPeering
  - where:
      subject: ExpressRouteGateway
      parameter-name: PutExpressRouteGatewayParameter
    set:
      parameter-name: ExpressRouteGateway
  - where:
      subject: LoadBalancerInboundNatRule
      parameter-name: InboundNatRuleParameter
    set:
      parameter-name: InboundNatRule
  - where:
      subject: NetworkInterfaceTapConfiguration
      parameter-name: TapConfigurationParameter
    set:
      parameter-name: TapConfiguration
  - where:
      subject: NetworkSecurityRule
      parameter-name: SecurityRuleParameter
    set:
      parameter-name: SecurityRule
  - where:
      subject: P2SVpnGateway
      parameter-name: P2SVpnGatewayParameter
    set:
      parameter-name: P2SVpnGateway
  - where:
      subject: P2SVpnServerConfiguration
      parameter-name: P2SVpnServerConfigurationParameter
    set:
      parameter-name: P2SVpnServerConfiguration
  - where:
      subject: RouteFilter
      parameter-name: RouteFilterParameter
    set:
      parameter-name: RouteFilter
  - where:
      subject: RouteFilterRule
      parameter-name: RouteFilterRuleParameter
    set:
      parameter-name: RouteFilterRule
  - where:
      subject: RouteTableRoute
      parameter-name: RouteParameter
    set:
      parameter-name: Route
  - where:
      subject: VirtualHub
      parameter-name: VirtualHubParameter
    set:
      parameter-name: VirtualHub
  - where:
      subject: VirtualWan
      parameter-name: WanParameter
    set:
      parameter-name: VirtualWan
  - where:
      subject: VnetGatewayVpnClientIPsecParameter
      parameter-name: VpnClientIPsecParameter
    set:
      parameter-name: VpnClientIPsecPolicy
      alias: VpnClientIPsecParameter
  - where:
      subject: VnetGatewayVpnClientIPsecParameter
    set:
      subject: VnetGatewayVpnClientIPsecPolicy
  - where:
      subject: VnetPeering
      parameter-name: VnetPeeringParameter
    set:
      parameter-name: VnetPeering
  - where:
      subject: VnetSubnet
      parameter-name: SubnetParameter
    set:
      parameter-name: Subnet
  - where:
      subject: VnetSubnetNetworkPolicy
      parameter-name: PrepareNetworkPoliciesRequestParameter
    set:
      parameter-name: NetworkPolicyRequest
  - where:
      subject: VpnConnection
      parameter-name: VpnConnectionParameter
    set:
      parameter-name: VpnConnection
  - where:
      subject: VpnGateway
      parameter-name: VpnGatewayParameter
    set:
      parameter-name: VpnGateway
  - where:
      subject: VpnSite
      parameter-name: VpnSiteParameter
    set:
      parameter-name: VpnSite

# ApplicationGateway Parameters
  - where:
      subject: ApplicationGateway
      parameter-name: (.*)Configuration(.+)
    set:
      parameter-name: $1$2
  - where:
      model-name: ApplicationGateway
      property-name: (.*)Configuration(.+)
    set:
      property-name: $1$2
  - where:
      subject: ApplicationGateway
      parameter-name: AutoscaleMaxCapacity
    set:
      parameter-name: AutoscaleMaximumCapacity
  - where:
      model-name: ApplicationGateway
      property-name: AutoscaleMaxCapacity
    set:
      property-name: AutoscaleMaximumCapacity
  - where:
      subject: ApplicationGateway
      parameter-name: AutoscaleMinCapacity
    set:
      parameter-name: AutoscaleMinimumCapacity
  - where:
      model-name: ApplicationGateway
      property-name: AutoscaleMinCapacity
    set:
      property-name: AutoscaleMinimumCapacity
  - where:
      subject: ApplicationGateway
      parameter-name: BackendHttpSettingsCollection
    set:
      parameter-name: BackendHttpSetting
      alias: BackendHttpSettingsCollection
  - where:
      model-name: ApplicationGateway
      property-name: BackendHttpSettingsCollection
    set:
      property-name: BackendHttpSetting
  - where:
      subject: ApplicationGateway
      parameter-name: CustomErrorConfiguration
    set:
      parameter-name: CustomError
      alias: CustomErrorConfiguration
  - where:
      model-name: ApplicationGateway
      property-name: CustomErrorConfiguration
    set:
      property-name: CustomError
  - where:
      subject: ApplicationGateway
      parameter-name: EnableFIPs
    set:
      parameter-name: EnableFips
  - where:
      subject: ApplicationGateway
      parameter-name: SslPolicyCIPherSuite
    set:
      parameter-name: SslCipherSuite
  - where:
      model-name: ApplicationGateway
      property-name: SslPolicyCipherSuite
    set:
      property-name: SslCipherSuite
  - where:
      subject: ApplicationGateway
      parameter-name: SslPolicyDisabledSslProtocol
    set:
      parameter-name: SslDisabledProtocol
  - where:
      model-name: ApplicationGateway
      property-name: SslPolicyDisabledSslProtocol
    set:
      property-name: SslDisabledProtocol
  - where:
      subject: ApplicationGateway
      parameter-name: SslPolicyMinProtocolVersion
    set:
      parameter-name: SslMinimumProtocolVersion
  - where:
      model-name: ApplicationGateway
      property-name: SslPolicyMinProtocolVersion
    set:
      property-name: SslMinimumProtocolVersion
  - where:
      subject: ApplicationGateway
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      model-name: ApplicationGateway
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity
  - where:
      subject: ApplicationGateway
      parameter-name: WafEnabled
    set:
      parameter-name: EnableWaf
  - where:
      model-name: ApplicationGateway
      property-name: WafEnabled
    set:
      property-name: EnableWaf
  - where:
      subject: ApplicationGateway
      parameter-name: WafMaxRequestBodySize(.*)
    set:
      parameter-name: WafMaximumRequestBodySize$1
  - where:
      model-name: ApplicationGateway
      property-name: WafMaxRequestBodySize(.*)
    set:
      property-name: WafMaximumRequestBodySize$1
  - where:
      subject: ApplicationGateway
      parameter-name: WafRequestBodyCheck
    set:
      parameter-name: CheckWafRequestBody
  - where:
      model-name: ApplicationGateway
      property-name: WafRequestBodyCheck
    set:
      property-name: CheckWafRequestBody

# ExpressRouteCircuitPeering Parameters
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: ExpressRouteCircuitPeering
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: PeeringName
    set:
      parameter-name: Name
      alias: PeeringName
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: ^IPv6PeeringConfigMicrosoftPeeringConfig(.*)$
    set:
      parameter-name: IPv6$1
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: ^IPv6PeeringConfig(.*)$
    set:
      parameter-name: IPv6$1
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: (.*)Properties(.*)
    set:
      parameter-name: $1$2
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: ^StatPrimarybytes(.*)$
    set:
      parameter-name: PrimaryBytes$1
  - where:
      subject: ExpressRouteCircuitPeering
      parameter-name: ^StatSecondarybytes(.*)$
    set:
      parameter-name: SecondaryBytes$1

# Various Parameters
  - where:
      subject: ApplicationGatewayBackendHealth
      parameter-name: PickHostNameFromBackendHttpSetting
    set:
      parameter-name: UseHostNameFromBackendHttpSetting
  - where:
      subject: ApplicationGatewayBackendHealth
      parameter-name: Host
    set:
      parameter-name: HostName
  - where:
      subject: ApplicationGatewayWafPolicy
      parameter-name: ^PolicySetting(.*)$
    set:
      parameter-name: $1
  - where:
      subject: DdosCustomPolicy
      parameter-name: ProtocolCustomSetting
    set:
      parameter-name: Format
  - where:
      model-name: DdosCustomPolicy
      property-name: ProtocolCustomSetting
    set:
      property-name: Format
  - where:
      subject: ExpressRouteCircuit
      parameter-name: GlobalReachEnabled
    set:
      parameter-name: EnableGlobalReach
  - where:
      model-name: ExpressRouteCircuit
      property-name: GlobalReachEnabled
    set:
      property-name: EnableGlobalReach
  - where:
      subject: ExpressRouteCircuitAuthorization
      parameter-name: AuthorizationKey
    set:
      parameter-name: Key
  - where:
      subject: ExpressRouteCircuitAuthorization
      parameter-name: AuthorizationUseStatus
    set:
      parameter-name: UseStatus
  - where:
      subject: ExpressRouteCircuitConnection
      parameter-name: ExpressRouteCircuitPeeringId
    set:
      parameter-name: CircuitPeeringId
  - where:
      subject: ExpressRouteCircuitConnection
      parameter-name: PeerExpressRouteCircuitPeeringId
    set:
      parameter-name: PeerCircuitPeeringId
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: ExpressRouteCircuitConnection
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: ExpressRouteCircuitConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: ^IPv6PeeringConfigMicrosoftPeeringConfig(.*)$
    set:
      parameter-name: IPv6$1
  - where:
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: ^IPv6PeeringConfig(.*)$
    set:
      parameter-name: IPv6$1
  - where:
      subject: Firewall
      parameter-name: ThreatIntelMode
    set:
      parameter-name: ThreatIntelligenceMode
      alias: ThreatIntelMode
  - where:
      model-name: AzureFirewall
      property-name: ThreatIntelMode
    set:
      property-name: ThreatIntelligenceMode
  - where:
      subject: Firewall
      parameter-name: ^(.*)Collection$
    set:
      parameter-name: $1
      alias: $1Collection
  - where:
      model-name: AzureFirewall
      property-name: ^(.*)Collection$
    set:
      property-name: $1
  - where:
      subject: LoadBalancerBackendAddressPool
      parameter-name: BackendAddressPoolName
    set:
      parameter-name: Name
  - where:
      subject: LoadBalancerFrontendIPConfiguration
      parameter-name: FrontendIPConfigurationName
    set:
      parameter-name: Name
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: LoadBalancerInboundNatRule
      variant: ^CreateExpanded$|^CreateExpanded1$|^CreateViaIdentityExpanded$|^CreateViaIdentityExpanded1$|^UpdateExpanded$|^UpdateExpanded1$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: LoadBalancerInboundNatRule
      parameter-name: InboundNatRuleName
    set:
      parameter-name: Name
      alias: InboundNatRuleName
  - where:
      subject: LoadBalancerInboundNatRule
      parameter-name: BackendIPConfigurationPropertiesProvisioningState
    set:
      parameter-name: BackendIPConfigurationProvisioningState
  - where:
      subject: LoadBalancerLoadBalancingRule
      parameter-name: LoadBalancingRuleName
    set:
      parameter-name: Name
  - where:
      subject: LoadBalancerOutboundRule
      parameter-name: OutboundRuleName
    set:
      parameter-name: Name
  - where:
      subject: LoadBalancerProbe
      parameter-name: ProbeName
    set:
      parameter-name: Name
  - where:
      subject: NetworkInterface
      parameter-name: ^NsgProperties(.*)$
    set:
      parameter-name: Nsg$1
  - where:
      model-name: NetworkInterface
      property-name: ^NsgProperties(.+)$
    set:
      property-name: Nsg$1
  - where:
      subject: NetworkInterfaceIPConfiguration
      parameter-name: IPConfigurationName
    set:
      parameter-name: Name
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: NetworkSecurityRule
      variant: ^CreateExpanded$|^CreateExpanded1$|^CreateViaIdentityExpanded$|^CreateViaIdentityExpanded1$|^UpdateExpanded$|^UpdateExpanded1$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: NetworkSecurityRule
      parameter-name: SecurityRuleName
    set:
      parameter-name: Name
      alias: SecurityRuleName
  - where:
      subject: NetworkSecurityRule
      parameter-name: PropertiesDestinationAddressPrefixes
    set:
      parameter-name: AdditionalDestinationAddressPrefix
  - where:
      subject: NetworkSecurityRule
      parameter-name: PropertiesDestinationPortRanges
    set:
      parameter-name: AdditionalDestinationPortRange
  - where:
      subject: NetworkSecurityRule
      parameter-name: PropertiesSourceAddressPrefixes
    set:
      parameter-name: AdditionalSourceAddressPrefix
  - where:
      subject: NetworkSecurityRule
      parameter-name: PropertiesSourcePortRanges
    set:
      parameter-name: AdditionalSourcePortRange
  - where:
      subject: NetworkWatcherConnectivity
      parameter-name: ^(.*)Configuration(.*)$
    set:
      parameter-name: $1$2
  - where:
      subject: NetworkWatcherFlowLogConfiguration
    set:
      subject: NetworkWatcherFlowLogInformation
  - where:
      verb: Get
      subject: NetworkWatcherFlowLogStatus
    set:
      subject: NetworkWatcherFlowLogInformation
      alias: Get-AzNetworkWatcherFlowLogStatus
  - where:
      subject: NetworkWatcherNextHop
      parameter-name: TargetNicResourceId
    set:
      parameter-name: TargetNetworkInterfaceResourceId
  - where:
      verb: Get
      subject: NetworkWatcherTroubleshootingResult
    set:
      subject: NetworkWatcherTroubleshooting
      alias: Get-AzNetworkWatcherTroubleshootingResult
  - where:
      subject: P2SVpnGateway
      parameter-name: GatewayName
    set:
      parameter-name: Name
      alias: GatewayName
  - where:
      subject: P2SVpnGateway
      parameter-name: VpnClientAddressPoolAddressPrefix
    set:
      parameter-name: VpnClientAddressPrefix
  - where:
      model-name: P2SVpnGateway
      property-name: VpnClientAddressPoolAddressPrefix
    set:
      property-name: VpnClientAddressPrefix
  - where:
      subject: P2SVpnGateway
      parameter-name: VpnClientConnectionHealthAllocatedIPAddress
    set:
      parameter-name: VpnClientAllocatedIPAddress
  - where:
      model-name: P2SVpnGateway
      property-name: VpnClientConnectionHealthAllocatedIPAddress
    set:
      property-name: VpnClientAllocatedIPAddress
  - where:
      subject: P2SVpnGateway
      parameter-name: VpnClientConnectionHealthVpnClientConnectionsCount
    set:
      parameter-name: VpnClientConnectionCount
  - where:
      model-name: P2SVpnGateway
      property-name: VpnClientConnectionHealthVpnClientConnectionsCount
    set:
      property-name: VpnClientConnectionCount
  - where:
      subject: P2SVpnGateway
      parameter-name: VpnGatewayScaleUnit
    set:
      parameter-name: ScaleUnit
  - where:
      model-name: P2SVpnGateway
      property-name: VpnGatewayScaleUnit
    set:
      property-name: ScaleUnit
  - where:
      model-name: P2SVpnGateway
      property-name: VpnClientConnectionHealthTotalEgressBytesTransferred
    set:
      property-name: VpnClientEgressBytesTransferred
  - where:
      model-name: P2SVpnGateway
      property-name: VpnClientConnectionHealthTotalIngressBytesTransferred
    set:
      property-name: VpnClientIngressBytesTransferred
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: P2SVpnServerConfiguration
      variant: ^CreateExpanded$|^CreateViaIdentityExpanded$|^UpdateExpanded$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: P2SVpnServerConfiguration
      variant: ^CreateExpanded$|^CreateViaIdentityExpanded$|^UpdateExpanded$
      parameter-name: PropertiesName
    set:
      parameter-name: ResourceName2
  - where:
      subject: P2SVpnServerConfiguration
      parameter-name: P2SVpnServerConfigurationName
    set:
      parameter-name: Name
      alias: P2SVpnServerConfigurationName
  - where:
      subject: P2SVpnServerConfiguration
      parameter-name: PropertiesEtag
    set:
      parameter-name: Etag
  - where:
      subject: P2SVpnServerConfiguration
      parameter-name: ^P2SVpnServerConfigRadius(.*)$
    set:
      parameter-name: Radius$1
  - where:
      subject: P2SVpnServerConfiguration
      parameter-name: ^P2SVpnServerConfigVpn(.*)$
    set:
      parameter-name: Vpn$1
  - where:
      subject: PeerExpressRouteCircuitConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
  - where:
      subject: PublicIPAddress
      parameter-name: IPConfigurationProperty
    set:
      parameter-name: IPConfigurationFormat
  - where:
      model-name: PublicIPAddress
      property-name: IPConfigurationProperty
    set:
      property-name: IPConfigurationFormat
  - where:
      model-name: PublicIPAddress
      property-name: IPConfigurationPropertiesProvisioningState
    set:
      property-name: IPConfigurationProvisioningState
  - where:
      model-name: PublicIPAddress
      property-name: PropertiesIpConfigurationPropertiesPublicIPAddress
    set:
      property-name: InnerPublicIPAddress
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: RouteFilterRule
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: RouteFilterRule
      parameter-name: RuleName
    set:
      parameter-name: Name
      alias: RuleName
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: RouteTableRoute
      variant: ^CreateExpanded$|^CreateExpanded1$|^CreateViaIdentityExpanded$|^CreateViaIdentityExpanded1$|^UpdateExpanded$|^UpdateExpanded1$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: RouteTableRoute
      parameter-name: RouteName
    set:
      parameter-name: Name
      alias: RouteName
  - where:
      subject: ServiceEndpointPolicy
      parameter-name: ServiceEndpointPolicyDefinition
    set:
      parameter-name: Definition
      alias: ServiceEndpointPolicyDefinition
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: ServiceEndpointPolicyDefinition
      variant: ^CreateExpanded$|^CreateViaIdentityExpanded$|^UpdateExpanded$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: ServiceEndpointPolicyDefinition
      parameter-name: ServiceEndpointPolicyDefinitionName
    set:
      parameter-name: Name
      alias: ServiceEndpointPolicyDefinitionName
  - where:
      subject: VnetGateway
      parameter-name: ^VpnClient(.*)$
    set:
      parameter-name: $1
      alias: VpnClient$1
  - where:
      model-name: VirtualNetworkGateway
      property-name: ^VpnClient(.+)$
    set:
      property-name: $1
  - where:
      model-name: VirtualNetworkGateway
      property-name: IpsecPolicy
    set:
      property-name: IPsecPolicy
  - where:
      subject: VnetGatewayConnection
      parameter-name: ExpressRouteGatewayBypass
    set:
      parameter-name: BypassExpressRouteGateway
      alias: ExpressRouteGatewayBypass
  - where:
      subject: VnetGatewayConnection
      parameter-name: LocalNetworkGateway2Etag
    set:
      parameter-name: Etag2
  - where:
      subject: VnetGatewayConnection
      parameter-name: LocalNetworkGateway2Id
    set:
      parameter-name: Id2
  - where:
      subject: VnetGatewayConnection
      parameter-name: LocalNetworkGateway2Location
    set:
      parameter-name: Location2
  - where:
      subject: VnetGatewayConnection
      parameter-name: LocalNetworkGateway2PropertiesResourceGuid
    set:
      parameter-name: ResourceGuid2
  - where:
      subject: VnetGatewayConnection
      parameter-name: LocalNetworkGateway2Tag
    set:
      parameter-name: Tag2
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: ExpressRouteGatewayBypass
    set:
      property-name: BypassExpressRouteGateway
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkGateway2Etag
    set:
      property-name: Etag2
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkGateway2Id
    set:
      property-name: Id2
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkGateway2Location
    set:
      property-name: Location2
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkGateway2PropertiesResourceGuid
    set:
      property-name: ResourceGuid2
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkGateway2Tag
    set:
      property-name: Tag2
  - where:
      model-name: VirtualNetworkGatewayConnection
      property-name: LocalNetworkGateway2PropertiesProvisioningState
    set:
      property-name: ProvisioningState2
  - where:
      subject: VnetGatewayVpnClientIPsecPolicy
      parameter-name: DhGroup
    set:
      parameter-name: DHGroup
  - where:
      subject: VnetGatewayVpnClientIPsecPolicy
      parameter-name: SaDataSizeKilobyte
    set:
      parameter-name: SADataSizeInKilobytes
  - where:
      subject: VnetGatewayVpnClientIPsecPolicy
      parameter-name: SaLifeTimeSecond
    set:
      parameter-name: SALifetimeInSeconds
  - where:
      subject: ^VnetGatewayVpnClientPackage$|^VnetGatewayVpnProfile$
      parameter-name: RadiusServerAuthCertificate
    set:
      parameter-name: RadiusServerAuthenticationCertificate
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: VnetPeering
      variant: ^CreateExpanded$|^CreateExpanded1$|^CreateViaIdentityExpanded$|^CreateViaIdentityExpanded1$|^UpdateExpanded$|^UpdateExpanded1$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: VnetPeering
      parameter-name: VnetPeeringName
    set:
      parameter-name: Name
      alias: VnetPeeringName
  - where:
      subject: VnetPeering
      parameter-name: RemoteAddressSpaceAddressPrefix
    set:
      parameter-name: RemoteAddressPrefix
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: VnetSubnet
      variant: ^CreateExpanded$|^CreateExpanded1$|^CreateViaIdentityExpanded$|^CreateViaIdentityExpanded1$|^UpdateExpanded$|^UpdateExpanded1$
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: VnetSubnet
      parameter-name: SubnetName
    set:
      parameter-name: Name
      alias: SubnetName
  - where:
      subject: VnetSubnet
      parameter-name: AddressPrefix
    set:
      parameter-name: AdditionalAddressPrefix
  - where:
      subject: VnetSubnet
      parameter-name: PropertiesAddressPrefix
    set:
      parameter-name: AddressPrefix
  - where:
      subject: VnetSubnet
      parameter-name: ^(.*)Properties(.*)$
    set:
      parameter-name: $1$2
  - where:
      subject: VnetSubnetNetworkPolicy
      parameter-name: ResourceGroupName1
    set:
      parameter-name: IntentPolicyResourceGroupName
  - where:
      subject: VnetTap
      parameter-name: ^(.*)FrontEndIPConfigurationProperties(.*)$
    set:
      parameter-name: $1$2
  - where:
      subject: VnetTap
      parameter-name: ^(.*)FrontEndIPConfiguration(.*)$
    set:
      parameter-name: $1$2
      alias: $1FrontEndIPConfiguration$2
  - where:
      subject: VnetTap
      parameter-name: ^(.*)IPConfigurationProperties(.*)$
    set:
      parameter-name: $1$2
  - where:
      subject: VnetTap
      parameter-name: ^(.*)IPConfiguration(.*)$
    set:
      parameter-name: $1$2
      alias: $1IPConfiguration$2
  - where:
      model-name: VirtualNetworkTap
      property-name: ^(.*)FrontEndIPConfigurationProperties(.+)$
    set:
      property-name: $1$2
  - where:
      model-name: VirtualNetworkTap
      property-name: ^(.*)FrontEndIPConfiguration(.+)$
    set:
      property-name: $1$2
  - where:
      model-name: VirtualNetworkTap
      property-name: ^(.*)IPConfigurationProperties(.+)$
    set:
      property-name: $1$2
  - where:
      model-name: VirtualNetworkTap
      property-name: ^(.*)IPConfiguration(.+)$
    set:
      property-name: $1$2
  - where:
      model-name: VirtualNetworkTap
      property-name: ^(.+)Ipaddress$
    set:
      property-name: $1IPAddress
  - where:
      model-name: VirtualNetworkTap
      property-name: ^(.+)IpallocationMethod$
    set:
      property-name: $1IPAllocationMethod
  - where: # This parameter needs removed
      verb: ^New$|^Set$
      subject: VpnConnection
      parameter-name: Name
    set:
      parameter-name: ResourceName
  - where:
      subject: VpnConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      subject: VpnConnection
      parameter-name: VpnConnectionProtocolType
    set:
      parameter-name: ProtocolType
      alias: VpnConnectionProtocolType
  - where:
      subject: VpnGateway
      parameter-name: VpnGatewayScaleUnit
    set:
      parameter-name: ScaleUnit
      alias: VpnGatewayScaleUnit
  - where:
      subject: VpnSite
      parameter-name: IsSecuritySite
    set:
      parameter-name: SecuritySite
  - where:
      model-name: VpnSite
      property-name: IsSecuritySite
    set:
      property-name: SecuritySite
  - where:
      model-name: NetworkInterface
      property-name: ^InterfaceEndpointProperties(.+)$
    set:
      property-name: InterfaceEndpoint$1

## Formatting
  - where:
      model-name: ^ApplicationSecurityGroup$|^DdosCustomPolicy$|^DdosProtectionPlan$|^NetworkProfile$|^NetworkSecurityGroup$|^ServiceEndpointPolicy$
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          ProvisioningState: Provisioning State
  - where:
      model-name: ApplicationGateway
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - SkuName
          - SslPolicyName
          - EnableHttp2
          - EnableFips
          - OperationalState
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          SkuName: SKU Name
          SslPolicyName: Policy Name
          EnableHttp2: HTTP2 Enabled
          EnableFips: FIPS Enabled
          OperationalState: Operational State
          ProvisioningState: Provisioning State
  - where:
      model-name: AzureFirewall
    set:
      format-table:
        properties:
          - Name
          - Location
          - ThreatIntelligenceMode
          - ProvisioningState
        labels:
          ThreatIntelligenceMode: Threat Intelligence Mode
          ProvisioningState: Provisioning State
  - where:
      model-name: ExpressRouteCircuit
    set:
      format-table:
        properties:
          - Name
          - Location
          - AllowClassicOperations
          - CircuitProvisioningState
          - ServiceProviderProvisioningState
          - ServiceProviderNote
          - ProvisioningState
          - SkuName
          - ServiceProviderName
        labels:
          AllowClassicOperations: Classic Operations Allowed
          CircuitProvisioningState: Circuit Provisioning State
          ServiceProviderProvisioningState: Service Provider Provisioning State
          ServiceProviderNote: Notes
          ProvisioningState: Provisioning State
          SkuName: SKU Name
          ServiceProviderName: Service Provider Name
  - where:
      model-name: ExpressRouteCrossConnection
    set:
      format-table:
        properties:
          - Name
          - Location
          - PrimaryAzurePort
          - SecondaryAzurePort
          - STag
          - PeeringLocation
          - BandwidthInMbps
          - ServiceProviderProvisioningState
          - ServiceProviderNote
          - ProvisioningState
        labels:
          PrimaryAzurePort: Primary Port
          SecondaryAzurePort: Secondary Port
          PeeringLocation: Peering Location
          BandwidthInMbps: Bandwidth [Mbps]
          ServiceProviderProvisioningState: Service Provider Provisioning State
          ServiceProviderNote: Notes
          ProvisioningState: Provisioning State
  - where:
      model-name: ExpressRouteGateway
    set:
      format-table:
        properties:
          - Name
          - Location
          - MinimumScaleUnit
          - MaximumScaleUnit
          - ProvisioningState
        labels:
          MinimumScaleUnit: Min Scale Unit
          MaximumScaleUnit: Max Scale Unit
          ProvisioningState: Provisioning State
  - where:
      model-name: ExpressRoutePort
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - PeeringLocation
          - EtherType
          - Mtu
          - BandwidthInGbps
          - ProvisionedBandwidthInGbps
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          PeeringLocation: Peering Location
          EtherType: Ether Type
          Mtu: MTU
          BandwidthInGbps: Bandwidth [Gbps]
          ProvisionedBandwidthInGbps: Provisioned Bandwidth [Gbps]
          ProvisioningState: Provisioning State
  - where:
      model-name: InterfaceEndpoint
    set:
      format-table:
        properties:
          - Name
          - Location
          - Fqdn
          - Owner
          - ProvisioningState
        labels:
          Fqdn: Domain Name
          ProvisioningState: Provisioning State
  - where:
      model-name: ^LoadBalancer$|^NatGateway$
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - SkuName
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          SkuName: SKU Name
          ProvisioningState: Provisioning State
  - where:
      model-name: LocalNetworkGateway
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - GatewayIPAddress
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          GatewayIPAddress: Gateway IP Address
          ProvisioningState: Provisioning State
  - where:
      model-name: NetworkInterface
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - MacAddress
          - Primary
          - EnableAcceleratedNetworking
          - EnableIPForwarding
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          MacAddress: MAC Address
          EnableAcceleratedNetworking: Accelerated Networking Enabled
          EnableIPForwarding: IP Forwarding Enabled
          ProvisioningState: Provisioning State
  - where:
      model-name: ^NetworkWatcher$|^P2SVpnGateway$|^RouteFilter$
    set:
      format-table:
        properties:
          - Name
          - Location
          - Type
          - ProvisioningState
        labels:
          ProvisioningState: Provisioning State
  - where:
      model-name: PublicIPAddress
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - AllocationMethod
          - IPAddress
          - IPAddressVersion
          - IdleTimeoutInMinutes
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          AllocationMethod: Allocation Method
          IPAddress: IP Address
          IPAddressVersion: Version
          IdleTimeoutInMinutes: Idle Timeout [minutes]
          ProvisioningState: Provisioning State
  - where:
      model-name: PublicIPPrefix
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - IPPrefix
          - PublicIPAddressVersion
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          IPPrefix: IP Prefix
          PublicIPAddressVersion: Public IP Address Version
          ProvisioningState: Provisioning State
  - where:
      model-name: RouteTable
    set:
      format-table:
        properties:
          - Name
          - Location
          - DisableBgpRoutePropagation
          - ProvisioningState
        labels:
          DisableBgpRoutePropagation: BGP Route Propagation Disabled
          ProvisioningState: Provisioning State
  - where:
      model-name: VirtualHub
    set:
      format-table:
        properties:
          - Name
          - Location
          - AddressPrefix
          - ProvisioningState
        labels:
          AddressPrefix: Address Prefix
          ProvisioningState: Provisioning State
  - where:
      model-name: VirtualNetworkGateway
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - GatewayType
          - VpnType
          - EnableBgp
          - EnableActiveActive
          - SkuName
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          GatewayType: Gateway Type
          VpnType: VPN Type
          EnableBgp: BGP Enabled
          EnableActiveActive: Active-Active Enabled
          SkuName: SKU Name
          ProvisioningState: Provisioning State
  - where:
      model-name: VirtualNetworkGatewayConnection
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - ConnectionType
          - RoutingWeight
          - EnableBgp
          - ConnectionStatus
          - EgressBytesTransferred
          - IngressBytesTransferred
          - UsePolicyBasedTrafficSelectors
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          ConnectionType: Connection Type
          RoutingWeight: Routing Weight
          EnableBgp: BGP Enabled
          ConnectionStatus: Connection Status
          EgressBytesTransferred: Egress Bytes Transferred
          IngressBytesTransferred: Ingress Bytes Transferred
          UsePolicyBasedTrafficSelectors: Policy Based Traffic Selectors Used
          ProvisioningState: Provisioning State
  - where:
      model-name: VirtualNetwork
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - EnableDdosProtection
          - EnableVMProtection
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          EnableDdosProtection: DDOS Protection Enabled
          EnableVMProtection: VM Protection Enabled
          ProvisioningState: Provisioning State
  - where:
      model-name: VirtualNetworkTap
    set:
      format-table:
        properties:
          - ResourceGuid
          - Name
          - Location
          - DestinationPort
          - Primary
          - ProvisioningState
        labels:
          ResourceGuid: GUID
          DestinationPort: Destination Port
          ProvisioningState: Provisioning State
  - where:
      model-name: VirtualWan
    set:
      format-table:
        properties:
          - Name
          - Location
          - SecurityProviderName
          - AllowBranchToBranchTraffic
          - AllowVnetToVnetTraffic
          - DisableVpnEncryption
          - ProvisioningState
        labels:
          SecurityProviderName: Security Provider Name
          AllowBranchToBranchTraffic: Branch-Branch Traffic Allowed
          AllowVnetToVnetTraffic: Vnet-Vnet Traffic Allowed
          DisableVpnEncryption: VPN Encryption Disabled
          ProvisioningState: Provisioning State
  - where:
      model-name: VpnGateway
    set:
      format-table:
        properties:
          - Name
          - Location
          - Type
          - ScaleUnit
          - ProvisioningState
        labels:
          ScaleUnit: Scale Unit
          ProvisioningState: Provisioning State
  - where:
      model-name: VpnSite
    set:
      format-table:
        properties:
          - Name
          - Location
          - SiteKey
          - SecuritySite
          - ProvisioningState
        labels:
          SiteKey: Site Key
          SecuritySite: Security Site
          ProvisioningState: Provisioning State
# Fix the name of the module in the nuspec
  - from: Az.Network.nuspec
    where: $
    transform: $ = $.replace(/Microsoft Azure PowerShell(.) \$\(service-name\) cmdlets/, 'Microsoft Azure PowerShell - Networking service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\n\nFor more information on Networking, please visit the following$1 https://docs.microsoft.com/azure/networking/networking-overview');
# Add release notes
  - from: Az.Network.nuspec
    where: $
    transform: $ = $.replace('<releaseNotes></releaseNotes>', '<releaseNotes>Initial release of preview Network cmdlets - see https://aka.ms/azps4doc for more information.</releaseNotes>');
# Make the nuget package a preview
  - from: Az.Network.nuspec
    where: $
    transform: $ = $.replace(/<version>(\d+\.\d+\.\d+)<\/version>/, '<version>$1-preview</version>');
# Update the psd1 description
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell(.) Network cmdlets\"\}\'\"\);/, 'sb.AppendLine\(\$@\"\{Indent\}Description = \'\{\"Microsoft Azure PowerShell - Networking service cmdlets for Azure Resource Manager in Windows PowerShell and PowerShell Core.\\n\\nFor more information on Networking, please visit the following$1 https://docs.microsoft.com/azure/networking/\"\}\'\"\);');
# Make this a preview module
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'\'\"\);', 'sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}ReleaseNotes = \'Initial release of preview Network cmdlets - see https://aka.ms/azps4doc for more information.\'\"\);\n            sb.AppendLine\(\$@\"\{Indent\}\{Indent\}\{Indent\}Prerelease = \'preview\'\"\);' );
```
