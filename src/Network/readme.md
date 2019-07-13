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
  # - $(repo)/specification/network/resource-manager/readme.enable-multi-api.md
  - $(this-folder)/resources/specs-used.md
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
      variant: Get
    set:
      variant: GetStatus
  - where:
      verb: Get
      subject: NetworkWatcherPacketCaptureStatus
      variant: GetViaIdentity
    remove: true
  - where:
      verb: Get
      subject: NetworkWatcherPacketCaptureStatus
      parameter-name: PacketCaptureName
    set:
      parameter-name: Name
      alias: PacketCaptureName
  - where:
      verb: Get
      subject: NetworkWatcherPacketCaptureStatus
    set:
      subject: NetworkWatcherPacketCapture
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
  # - where:
  #     verb: Get
  #     subject: NetworkWatcherReachabilityReport
  #     parameter-name: ProviderLocation(.*)
  #   set:
  #     parameter-name: Provider$1
  #     alias: $1
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
      verb: Get
      subject: ApplicationGatewayWafPolicy
      parameter-name: PolicyName
    set:
      parameter-name: Name
      alias: PolicyName
  - where:
      verb: ^Get$|^New$|^Remove$
      subject: ExpressRouteCircuit
      parameter-name: CircuitName
    set:
      parameter-name: Name
      alias: CircuitName
  - where:
      verb: ^Get$|^Remove$
      subject: ExpressRouteCircuitAuthorization
      parameter-name: AuthorizationName
    set:
      parameter-name: Name
      alias: AuthorizationName
  - where:
      verb: ^Get$|^Remove$
      subject: ExpressRouteConnection
      parameter-name: ConnectionName
    set:
      parameter-name: Name
      alias: ConnectionName
  - where:
      verb: ^Get$|^Set$
      subject: ExpressRouteCrossConnection
      parameter-name: CrossConnectionName
    set:
      parameter-name: Name
      alias: CrossConnectionName
  - where:
      verb: ^Get$|^Remove$
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: PeeringName
    set:
      parameter-name: Name
      alias: PeeringName
  - where:
      verb: ^Get$|^Remove$
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
      verb: ^Get$|^New$|^Remove$
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
      verb: ^Get$|^New$|^Remove$
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
      parameter-name: ExpandResource
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
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      subject: ExpressRouteCircuitAuthorization
      parameter-name: ResourceGroupName
    set:
      alias: ExpressRouteCircuit
  - where:
      subject: ^NetworkWatcherAvailableProvider$|^NetworkWatcherReachabilityReport$
      parameter-name: AzureLocation
    set:
      parameter-name: Location
  - where: # REMOVE BEFORE RELEASE: Unnecessary custom client-side Location implementation
      subject: ^NetworkWatcherAvailableProvider$|^NetworkWatcherReachabilityReport$
      parameter-name: ResourceGroupName
    set:
      alias: NetworkWatcherLocation
  - where: # REMOVE BEFORE RELEASE: Unnecessary custom client-side Location implementation
      subject: ^NetworkWatcher(?!(AvailableProvider$|ReachabilityReport$|ConnectionMonitor$))(.+)
      parameter-name: ResourceGroupName
    set:
      alias: Location
  - where: # REMOVE BEFORE RELEASE: Unnecessary custom client-side Location implementation
      verb: ^Get$|^Remove$|^Start$|^Stop$
      subject: ^NetworkWatcher$|^NetworkWatcherConnectionMonitor$
      parameter-name: ResourceGroupName
    set:
      alias: Location
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Get
      subject: ^NetworkWatcherAvailableProvider$|^NetworkWatcherFlowLogStatus$|^NetworkWatcherNetworkConfigurationDiagnostic$|^NetworkWatcherNextHop$|^NetworkWatcherReachabilityReport$|^NetworkWatcherTopology$|^NetworkWatcherTroubleshootingResult$
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Get
      subject: ^NetworkWatcherConnectionMonitor$|^NetworkWatcherConnectionMonitorState$|^NetworkWatcherPacketCapture$
      parameter-name: ResourceGroupName
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: New
      subject: ^NetworkWatcherConnectionMonitor$|^NetworkWatcherPacketCapture$
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Remove
      subject: ^NetworkWatcher$|^NetworkWatcherConnectionMonitor$|^NetworkWatcherPacketCapture$
      parameter-name: ResourceGroupName
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Set
      subject: ^NetworkWatcherConnectionMonitor$|^NetworkWatcherFlowLogConfiguration$
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: ^Start$|^Stop$
      subject: NetworkWatcherConnectionMonitor
      parameter-name: ResourceGroupName
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
      parameter-name: ResourceGroupName
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: Not a direct mapping to what NetworkWatcher in-memory object represented
      verb: Test
      subject: ^NetworkWatcherConnectivity$|^NetworkWatcherIPFlow$
      parameter-name: Parameter
    set:
      alias: NetworkWatcher
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter + resource ID parameter
      verb: ^Get$|^New$
      subject: ExpressRouteConnection
      parameter-name: ResourceGroupName
    set:
      alias:
        - ExpressRouteGatewayObject
        - ParentResourceId
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter + resource ID parameter
      verb: Get
      subject: VirtualHubVnetConnection
      parameter-name: ResourceGroupName
    set:
      alias:
        - ParentObject
        - ParentResourceId
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter + resource ID parameter
      verb: ^Get$|^New$
      subject: VpnConnection
      parameter-name: ResourceGroupName
    set:
      alias:
        - ParentObject
        - ParentResourceId
  - where:
      verb: ^Get$|^New$|^Remove$
      subject: VpnConnection
      parameter-name: GatewayName
    set:
      alias: ParentResourceName
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Get
      subject: ^ExpressRouteCrossConnectionArpTable$|^ExpressRouteCrossConnectionPeering$|^ExpressRouteCrossConnectionRouteTable$|^ExpressRouteCrossConnectionRouteTableSummary$
      parameter-name: ResourceGroupName
    set:
      alias: ExpressRouteCrossConnection
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter + PeerAddressType is in-memory object manipulation
      verb: Remove
      subject: ExpressRouteCrossConnectionPeering
      parameter-name: ResourceGroupName
    set:
      alias:
        - ExpressRouteCrossConnection
        - PeerAddressType
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: ExpressRouteCrossConnection
      parameter-name: Parameter
    set:
      alias: ExpressRouteCrossConnection
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
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: ^Get$|^Remove$|^Set$
      subject: ServiceEndpointPolicyDefinition
      parameter-name: ResourceGroupName
    set:
      alias: ServiceEndpointPolicy
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: ServiceEndpointPolicy
      parameter-name: ResourceGroupName
    set:
      alias: ServiceEndpointPolicy
  - where:
      verb: Get
      subject: VnetGatewayVpnDeviceConfigurationScript
      parameter-name: Vendor
    set:
      alias: DeviceVendor
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: Vnet
      parameter-name: ResourceGroupName
    set:
      alias: VirtualNetwork
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Test
      subject: VnetIPAddressAvailability
      parameter-name: ResourceGroupName
    set:
      alias: VirtualNetwork
  - where: # REMOVE BEFORE RELEASE: Parameters are used to update in-memory objects
      verb: New
      subject: Firewall
      parameter-name: ResourceGroupName
    set:
      alias:
        - VirtualNetworkName
        - PublicIpName
  - where:
      verb: New
      subject: ^LoadBalancer$|^PublicIPAddress$|^PublicIPPrefix$
      parameter-name: SkuName
    set:
      alias: Sku
  - where: # REMOVE BEFORE RELEASE: Not sure why AsJob was part of the cmdlet before
      verb: ^New$|^Remove$
      subject: NetworkProfile
      parameter-name: ResourceGroupName
    set:
      alias: AsJob
  - where:
      verb: New
      subject: NetworkSecurityGroup
      parameter-name: SecurityRule
    set:
      alias: SecurityRules
  - where: # REMOVE BEFORE RELEASE: This is the opposite of AutoStart
      verb: ^New$|^Set$
      subject: NetworkWatcherConnectionMonitor
      parameter-name: ResourceGroupName
    set:
      alias: ConfigureOnly
  - where:
      verb: New
      subject: PublicIPPrefix
      parameter-name: PublicIPAddressVersion
    set:
      alias: IpAddressVersion
  - where:
      verb: New
      subject: Vnet
      parameter-name: AddressSpaceAddressPrefix
    set:
      parameter-name: AddressPrefix
  - where:
      verb: New
      subject: Vnet
      parameter-name: DhcpOptionDnsServer
    set:
      parameter-name: DnsServer
  - where:
      verb: Set
      subject: LocalNetworkGateway
      parameter-name: LocalNetworkAddressSpaceAddressPrefix
    set:
      parameter-name: AddressPrefix
  - where: # REMOVE BEFORE RELEASE: These parameters are expanded into their properties as separate parameters
      verb: New
      subject: VnetTap
      parameter-name: ResourceGroupName
    set:
      alias:
        - DestinationNetworkInterfaceIPConfiguration
        - DestinationLoadBalancerFrontEndIPConfiguration
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: New
      subject: VpnConnection
      parameter-name: ResourceGroupName
    set:
      alias: VpnSite
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
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Reset
      subject: VnetGateway
      parameter-name: ResourceGroupName
    set:
      alias: VirtualNetworkGateway
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: ^Set$|^Start$|^Stop$
      subject: ApplicationGateway
      parameter-name: ResourceGroupName
    set:
      alias: ApplicationGateway
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: ExpressRouteCircuit
      parameter-name: ResourceGroupName
    set:
      alias: ExpressRouteCircuit
  - where: # REMOVE BEFORE RELEASE: InputObject removed for all Set cmdlets
      verb: Set
      subject: ^ExpressRouteConnection$|^ExpressRouteGateway$|^NetworkWatcherConnectionMonitor$|^VnetGatewayVpnClientIPsecParameter$
      parameter-name: ResourceGroupName
    set:
      alias: InputObject
  - where:
      verb: ^Set$|^New$
      subject: ExpressRouteGateway
      parameter-name: BoundMin
    set:
      parameter-name: MinimumScaleUnits
      alias: MinScaleUnits
  - where:
      verb: ^Set$|^New$
      subject: ExpressRouteGateway
      parameter-name: BoundMax
    set:
      parameter-name: MaximumScaleUnits
      alias: MaxScaleUnits
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: ExpressRoutePort
      parameter-name: ResourceGroupName
    set:
      alias: ExpressRoutePort
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: Firewall
      parameter-name: ResourceGroupName
    set:
      alias: AzureFirewall
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: LoadBalancer
      parameter-name: ResourceGroupName
    set:
      alias: LoadBalancer
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: NetworkInterface
      parameter-name: ResourceGroupName
    set:
      alias: NetworkInterface
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: NetworkInterfaceTapConfiguration
      parameter-name: ResourceGroupName
    set:
      alias: NetworkInterfaceTapConfig
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter and AsJob on non-long-running operation
      verb: Set
      subject: NetworkProfile
      parameter-name: ResourceGroupName
    set:
      alias:
        - NetworkProfile
        - AsJob
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: NetworkSecurityGroup
      parameter-name: ResourceGroupName
    set:
      alias: NetworkSecurityGroup
  - where: # REMOVE BEFORE RELEASE: Conflicts in hybrid profile with next directive
      verb: Set
      subject: PublicIPAddress
      parameter-name: PublicIPAddress
    set:
      parameter-name: PublicIPAddressParameter
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: PublicIPAddress
      parameter-name: ResourceGroupName
    set:
      alias: PublicIpAddress
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: PublicIPPrefix
      parameter-name: ResourceGroupName
    set:
      alias: PublicIpPrefix
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: RouteFilter
      parameter-name: ResourceGroupName
    set:
      alias: RouteFilter
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: RouteTable
      parameter-name: ResourceGroupName
    set:
      alias: RouteTable
  - where:
      verb: Set
      subject: VnetGatewayVpnClientIPsecParameter
      parameter-name: VpnclientIPsecParam
    set:
      parameter-name: VpnClientIPsecParameter
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: Set
      subject: VnetPeering
      parameter-name: ResourceGroupName
    set:
      alias: VirtualNetworkPeering
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter, UserAssignedIdentityId is used with Identity
      verb: New
      subject: ApplicationGateway
      parameter-name: ResourceGroupName
    set:
      alias:
        - Sku
        - SslPolicy
        - WebApplicationFirewallConfiguration
        - FirewallPolicy
        - AutoscaleConfiguration
        - UserAssignedIdentityId
        - Identity
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
      verb: New
      subject: ExpressRouteCircuit
      parameter-name: ServiceProviderPropertyBandwidthInMbps
    set:
      parameter-name: ServiceProviderBandwidthInMbps
      alias: BandwidthInMbps
  - where:
      verb: New
      subject: ExpressRouteCircuit
      parameter-name: ServiceProviderPropertyPeeringLocation
    set:
      parameter-name: ServiceProviderPeeringLocation
      alias: PeeringLocation
  - where:
      verb: New
      subject: ExpressRouteCircuit
      parameter-name: ServiceProviderPropertyServiceProviderName
    set:
      parameter-name: ServiceProviderName
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: New
      subject: ExpressRouteCircuit
      parameter-name: ResourceGroupName
    set:
      alias: ExpressRoutePort
  - where:
      verb: New
      subject: ExpressRouteCircuit
      parameter-name: AllowClassicOperation
    set:
      parameter-name: AllowClassicOperations
  - where:
      verb: New
      subject: LocalNetworkGateway
      parameter-name: LocalNetworkAddressSpaceAddressPrefix
    set:
      parameter-name: AddressPrefix
  - where:
      verb: New
      subject: LocalNetworkGateway
      parameter-name: BgpSettingAsn
    set:
      parameter-name: BgpAsn
      alias: Asn
  - where:
      verb: New
      subject: LocalNetworkGateway
      parameter-name: BgpSettingBgpPeeringAddress
    set:
      parameter-name: BgpPeeringAddress
  - where:
      verb: New
      subject: LocalNetworkGateway
      parameter-name: BgpSettingPeerWeight
    set:
      parameter-name: BgpPeerWeight
      alias: PeerWeight
  - where: # REMOVE BEFORE RELEASE: This is used instead of an in-memory object
      verb: New
      subject: NetworkInterface
      parameter-name: ResourceGroupName
    set:
      alias: SubnetId
  - where: # REMOVE BEFORE RELEASE: These parameters were expanded from the IPConfiguration object
      verb: New
      subject: NetworkInterface
      parameter-name: ResourceGroupName
    set:
      alias:
        - PublicIpAddressId
        - PublicIpAddress
        - LoadBalancerBackendAddressPoolId
        - LoadBalancerBackendAddressPool
        - LoadBalancerInboundNatRuleId
        - LoadBalancerInboundNatRule
        - ApplicationGatewayBackendAddressPoolId
        - ApplicationGatewayBackendAddressPool
        - ApplicationSecurityGroupId
        - ApplicationSecurityGroup
        - PrivateIpAddress
        - IpConfigurationName
  - where: # REMOVE BEFORE RELEASE: This is expanded into separate parameters
      verb: New
      subject: NetworkInterface
      parameter-name: ResourceGroupName
    set:
      alias: NetworkSecurityGroup
  - where:
      verb: New
      subject: NetworkInterface
      parameter-name: NetworkSecurityGroupPropertiesProvisioningState
    set:
      parameter-name: NetworkSecurityGroupProvisioningState
  - where:
      verb: New
      subject: NetworkInterface
      parameter-name: NetworkSecurityGroupPropertiesResourceGuid
    set:
      parameter-name: NetworkSecurityGroupResourceGuid
  - where:
      verb: New
      subject: NetworkInterface
      parameter-name: ^DnsSetting(.*)
    set:
      parameter-name: $1

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
      verb: New
      subject: PublicIPAddress
      parameter-name: ^PublicIP(.*)
    set:
      parameter-name: $1
  - where:
      verb: New
      subject: PublicIPAddress
      parameter-name: AddressVersion
    set:
      parameter-name: IpAddressVersion
  - where:
      verb: New
      subject: PublicIPAddress
      parameter-name: DdosSettingProtectionCoverage
    set:
      parameter-name: DdosProtectionCoverage
  - where:
      verb: New
      subject: PublicIPAddress
      parameter-name: ^DnsSetting(.*)
    set:
      parameter-name: $1
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: New
      subject: PublicIPAddress
      parameter-name: ResourceGroupName
    set:
      alias: PublicIpPrefix
  - where:
      verb: New
      subject: VirtualHub
      parameter-name: RouteTableRoute
    set:
      parameter-name: Route
      alias: RouteTable
  - where: # REMOVE BEFORE RELEASE: In-memory object parameter
      verb: New
      subject: VirtualHub
      parameter-name: ResourceGroupName
    set:
      alias: VirtualWan
  - where:
      verb: New
      subject: VirtualHub
      parameter-name: VnetConnection
    set:
      alias: HubVnetConnection
```