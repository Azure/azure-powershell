<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
--->

## Upcoming Release

## Version 7.0.0
* [Breaking Change] Removed `Geo` as a valid input for parameter `VariableName` in `NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable`.
* Added AllowBranchToBranchTraffic property to New-AzRouteServer
* Added AllowBranchToBranchTraffic property to Get-AzRouteServer
* Changed Update-AzRouteServer functionality to fix bugs
    - AllowBranchToBranchTraffic is now a bool
    - Updating HubRoutingPreference property will not effect AllowBranchToBranchTraffic

## Version 6.2.0
* Added support for new Application Gateway SKU type, Basic SKU
* Onboarded `Microsoft.EventGrid/partnerNamespaces` to private link cmdlets
* Onboarded `Microsoft.EventGrid/namespaces` to private link cmdlets
* Fixed bug in `NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable` to add "GeoLocation" as a valid input for VariableName
* Added breaking change message for parameter `VariableName` in `NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable` to remove "Geo" as a valid input.

## Version 6.1.1
* Onboarded `Microsoft.ElasticSan/elasticSans` to private link cmdlets
* Fixed bug in `New-AzVirtualNetworkGateway` to include only non-empty `ExtendedLocation`

## Version 6.1.0
* Added new cmdlets to get Connection child resource of Network Virtual Appliance.
    -`Get-AzNetworkVirtualApplianceConnection`
* Updated cmdlets to return connections in Network Virtual Appliance
    -`Network Virtual Appliance`
* Allowed not to provide `Rules` in `PSApplicationGatewayFirewallPolicyManagedRuleGroupOverride`, which would return an empty `RuleID` to be passed to NRP.
* Added optional parameter 'AdminState' to Express Route Virtual Network Gateway
* Fixed bug that caused `Remove-AzApplicationGatewayAutoscaleConfiguration` to always fails
* Added read-only property `DefaultPredefinedSslPolicy` in PSApplicationGateway
* Updated cmdlet to added optional parameter `DomainNameLabelScope` to Public Ip Address
    - `New-AzPublicIpAddress`
* Fixed bug where HubRoutingPreference didn't show up when running 'Get-AzRouteServer'
* Updated `New-AzVirtualNetworkGateway` to remove validation for `ExtendedLocation` parameter

## Version 6.0.0
* Added new cmdlets for RouteMap child resource of VirtualHub.
    -`Get-AzRouteMap`
    -`New-AzRouteMapRuleCriterion`
    -`New-AzRouteMapRuleActionParameter`
    -`New-AzRouteMapRuleAction`
    -`New-AzRouteMapRule`
    -`New-AzRouteMap`
    -`Set-AzRouteMap`
    -`Remove-AzRouteMap`
* Updated cmdlets to add inbound/outbound route maps in routingConfiguration
    -`New-AzRoutingConfiguration`
* Added the command `New-AzFirewallPolicyApplicationRuleCustomHttpHeader`
* Added the method `AddCustomHttpHeaderToInsert` to `PSAzureFirewallPolicyApplicationRule`
* Added new cmdlets to support Rate Limiting Rule for Application Gateway WAF
    - `New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession`,
    - `New-AzApplicationGatewayFirewallCustomRuleGroupByVariable`,
    - Also updated cmdlet to add the property of `RateLimitDuration`, `RateLimitThreshold` and `GroupByUserSession`
    - `New-AzureApplicationGatewayFirewallCustomRule`
* Added support of `AdditionalNic` Property in `New-AzNetworkVirtualAppliance`
* Added the new cmdlet for supporting `AdditionalNic` Property
    - `New-AzVirtualApplianceAdditionalNicProperty`
* Added new cmdlets to support Log Scrubbing Feature for Application Gateway WAF Firewall Policy
    - `New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration`,
    - `New-AzApplicationGatewayFirewallPolicyLogScrubbingRule`,
    - Also updated cmdlet to add the property of `LogScrubbing`
    - `New-AzApplicationGatewayFirewallPolicySetting`
* Onboarded `Microsoft.HardwareSecurityModules/cloudHsmClusters` to private link cmdlets
* Updated cmdlet to add the property of `DisableRequestBodyEnforcement`, `RequestBodyInspectLimitInKB` and `DisableFileUploadEnforcement`
    - `New-AzApplicationGatewayFirewallPolicySetting`
* Added optional property `AuxiliarySku` to cmdlet `New-AzNetworkInterface` to help choose performance on an `AuxiliaryMode` enabled Network Interface.
* Added a new value `AcceleratedConnections` for existing property `AuxiliaryMode` for `New-AzNetworkInterface`
* Added new cmdlets to get virtual hub effective routes and in/outbound routes
    - `Get-AzVHubEffectiveRoute`
    - `Get-AzVHubInboundRoute`
    - `Get-AzVHubOutboundRoute`

## Version 5.7.0
* Onboarded `Microsoft.HardwareSecurityModules/cloudHsmClusters` to private link cmdlets
* Fixed the issue for `Update-AzCustomIpPrefix` that `NoInternetAdvertise` will should be set to false if not provided

## Version 5.6.0
* Updated `New-AzLoadBalancer` and `Set-AzLoadBalancer` to validate surface level parameters for global tier load balancers
* Added property 'AuthorizationStatus' to ExpressRouteCircuit
* Added property 'BillingType' to ExpressRoutePort
* Added support for connection flushing in network security group which when enabled, re-evaluates flows when rules are updated
    - `New-AzNetworkSecurityGroup`
* Added support for state in WAF Custom Rule
* Added `New-AzGatewayCustomBgpIpConfigurationObject` command
* Updated `New-AzVirtualNetworkGatewayConnection`, `Set-AzVirtualNetworkGatewayConnection` and `New-AzVpnSiteLinkConnection` to support GatewayCustomBgpIpConfiguration.
* Updated `Reset-AzVpnGateway` to support IpConfigurationId.
* Blocked some regions when creating/updating Basic Sku firewall
* Fixed bugs related to auto learn IP prefixes and Snat
* Updated multi-auth to be supported when both OpenVPN and IkeV2 protocols are used for VNG and VWAN VPN

## Version 5.5.0
* Updated cmdlets to add new property of `Snat` in Azure Firewall Policy.
    - `New-AzFirewallPolicySnat`
    - `New-AzFirewallPolicy`
    - `Set-AzFirewallPolicy`
* Fixed a bug that reverts classic fw private ranges to default when doing get & set
* Onboarded `Microsoft.Monitor/accounts` to private link cmdlets
* Onboarded `Microsoft.DBforMySQL/flexibleServers` to private link cmdlets

## Version 5.4.0
* Fixed a bug that does not enable to set Perform SNAT to Always
* Fixed the incorrect type of `-TotalBytesPerSession` in `New-AzNetworkWatcherPacketCapture`

## Version 5.3.0
* Added samples for retrieving Private Link IP Configuration using 'New-AzApplicationGatewayPrivateLinkIpConfiguration' with fix [#20440]
* Added `DdosProtectionPlan` property in `AzPublicIpAddress`
* Updated mapping in `AzPublicIpAddress` to always show/create DdosSettings
* Fixed a bug that added Ddos related properties when viewing PublicIpAddress and DdosProtectionPlan objects
* Fixed a Bug for Set-AzIpGroup cmdlet to support the `-WhatIf` parameter
* Fixed a Bug for `Add-AzLoadBalancerFrontendIpConfig`, `Add-AzLoadBalancerProbeConfig`, `Add-AzLoadBalancerBackendAddressPoolConfig`, `Set-AzLoadBalancer`, `New-AzLoadBalancerRuleConfig`, `Remove-AzLoadBalancerInboundNatRuleConfig` cmdlets to support the `-WhatIf` parameter. [#20416]
* Fixed a bug for DestinationPortBehavior in `Get-AzNetworkWatcherConnectionMonitor`, `New-AzNetworkWatcherConnectionMonitor` powershell command by adding this properties to get and set the DestinationPortBehavior information. [#15996]

## Version 5.2.0
* Added optional parameters `CustomBlockResponseStatusCode` and `CustomBlockResponseBody` parameter to `AzApplicationGatewayFirewallPolicySettings`
* Added a new cmdlet to get the application gateway waf manifest and rules
    - `Get-AzApplicationGatewayWafDynamicManifest`

## Version 5.1.2
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## Version 5.1.1
* Fixed bug with New-AzCustomIpPrefix

## Version 5.1.0
* Added possible value `LocalGateway` for parameter `GatewayType`
    - `New-AzVirtualNetworkGateway`
* Exposed `ExtendedLocation` and `VNetExtendedLocationResourceId` for `VirtualNetworkGateway`
    - `Get-AzVirtualNetworkGateway`
* Added new cmdlet to get firewall learned ip prefixes
    * `Get-AzFirewallLearnedIpPrefix`
* Fixed a bug that does not update firewall policy application, network and nat rules' descriptions even though description is provided via description parameter
* Updated `New-AzIpConfigurationBgpPeeringAddressObject` to remove validate null or empty check for CustomAddress in Azure Virtual Network Gateway
* Updated `New-AzVirtualNetworkGateway` to add validate null or empty check for CustomAddress in Azure Virtual Network Gateway
* Updated cmdlets to add new property of `VirtualNetworkGatewayPolicyGroup` and `VpnClientConnectionConfiguration` in Azure Virtual Network Gateway
    * `New-AzVirtualNetworkGateway`
    * `Set-AzVirtualNetworkGateway`
* Added new cmdlets to create
    * `New-AzVirtualNetworkGatewayPolicyGroup`
    * `New-AzVirtualNetworkGatewayPolicyGroupMember`
    * `New-AzVpnClientConnectionConfiguration`
* Added message in breaking change attribute to notify that load balancer sku default behavior will be changed
    * `New-AzLoadBalancer`
* Added cmdlet preview to notify customers to use default value or leave null for load balancer probe threshold property
    * `New-AzLoadBalancerProbeConfig`
    * `Set-AzLoadBalancerProbeConfig`
    * `Add-AzLoadBalancerProbeConfig`

## Version 5.0.0
* Added a new endpoint switch `AzureArcVM` in `New-AzNetworkWatcherConnectionMonitor`
* Updated `New-AzVirtualNetworkGatewayConnection` to support bypassing the ExpressRoute gateway when accessing private-links
* Updated `Update-AzCustomIpPrefix` to support no-internet advertise CustomIpPrefix
* Updated `New-AzNetworkInterface` to support create/update nic with DisableTcpStateTracking property
* Updated cmdlet to support specifying a VirtualRouterAsn on Virtual Hub
  * `New-AzVirtualHub`
  * `Update-AzVirtualHub`
* Updated cmdlet to support specifying an ASN on VPN Gateway
  * `New-AzVpnGateway`
  * `Update-AzVpnGateway`
* Updated `New-AzRoutingConfiguration` to support bypassing NVA for spoke vNet traffic
* Updated `Update-AzCustomIpPrefix` to support new parameters: Asn, Geo, ExpressRouteAdvertise
* Updated cmdlets to enable verification on client certificate revocation by using a new property VerifyClientRevocation in ApplicationGatewayClientAuthConfiguration
  * `New-AzApplicationGatewayClientAuthConfiguration`
  * `Set-AzApplicationGatewayClientAuthConfiguration`
* Updated `New-AzCustomIpPrefix` to support IPv4 Parent/Child CustomIpPrefix creation.
* Added Uppercase Transform in New-AzApplicationGatewayFirewallCondition
* Added DdosProtectionMode parameter in New-AzPublicIpAddress
* Added ProbeThreshold parameter to Load Balancer Probe
  * `Add-AzLoadBalancerProbeConfig`
  * `New-AzLoadBalancerProbeConfig`
  * `Set-AzLoadBalancerProbeConfig`
* Updated `New-AzApplicationGatewayFirewallPolicyManagedRuleOverride` to support specifying an action for a managed rule override in Application Gateway WAF Policy
* Added breaking change enum values/notification for the following network manager cmdlets
  * `Deploy-AzNetworkManagerCommit`
  * `New-AzNetworkManagerConnectivityConfiguration`
  * `New-AzNetworkManagerConnectivityGroupItem`
  * `New-AzNetworkManagerSecurityAdminRule`
  * `New-AzNetworkManagerSecurityAdminConfiguration`
  * `New-AzNetworkManagerAddressPrefixItem`
  * `New-AzNetworkManager`
* Added `EnableUDPLogOptimization` parameter to `New-AzFirewall`
* Fixed a bug that does not return HubIPAddresses and PrivateIPAddress during a Get-AzFirewall command
* Replaced `IdentifyTopFatFlow` parameter with 'EnableFatFlowLogging' parameter to `New-AzFirewall`
* Fixed a bug not able to add MSSQL application rules to an AZURE FIREWALL POLICY
* Onboard Project AzureML Registries to Private Link Common Cmdlets

## Version 4.20.1
* Added breaking change notification for `Get-AzFirewall`, `New-AzFirewall`, `Set-AzFirewall` and `New-AzFirewallHubIpAddress`

## Version 4.20.0
* Fixed a bug that removes existing resource tags during a Set-AzFirewallPolicy command
* Fixed required parameter `PrivateLinkResourceType` missing issue for the following cmdlets [#18655]
    - `Get-AzPrivateEndpointConnection`
    - `Set-AzPrivateEndpointConnection`
    - `Remove-AzPrivateEndpointConnection`
    - `Approve-AzPrivateEndpointConnection`
    - `Deny-AzPrivateEndpointConnection`
* Added breaking change attribute to notify that public ip address sku default behavior will be changed
    - `New-AzPublicIpAddress`
    - `New-AzLoadBalancer`
* Onboard Azure Virtual Network Manager Cmdlets
    - `New/Get/Remove/Set-AzNetworkManager`
    - `New/Get/Remove/Set-AzNetworkManagerGroup`
    - `New/Get/Remove/Set-AzNetworkManagerConnectivityConfiguration`
    - `New/Get/Remove/Set-AzNetworkManagerSecurityAdminConfiguration`
    - `New/Get/Remove/Set-AzNetworkManagerSecurityAdminRuleCollection`
    - `New/Get/Remove/Set-AzNetworkManagerSecurityAdminRule`
    - `Get-AzNetworkManagerActiveConnectivityConfiguration`
    - `Get-AzNetworkManagerActiveSecurityAdminRule`
    - `Get-AzNetworkManagerEffectiveConnectivityConfiguration`
    - `Get-AzNetworkManagerEffectiveSecurityAdminRule`
    - `Deploy-AzNetworkManagerCommit`
    - `Get-AzNetworkManagerDeploymentStatus`
    - `New-AzNetworkManagerAddressPrefixItem`
    - `New-AzNetworkManagerScope`
    - `New-AzNetworkManagerSecurityGroupItem`
    - `New-AzNetworkManagerHub`
    - `New-AzNetworkManagerConnectivityGroupItem`
    - `New/Get/Remove-AzNetworkManagerStaticMember`
    - `New/Get/Remove/Set-AzNetworkManagerScopeConnection`
    - `New/Get/Remove/Set-AzNetworkManagerSubscriptionConnection`
    - `New/Get/Remove/Set-AzNetworkManagerManagementGroupConnection`
* Onboard AgFoodPlatform to Private Link Common Cmdlets
* Onboard Project Oak Forest to Private Link Common Cmdlets

## Version 4.19.0
* Updated cmdlets to add new property of `ExplicitProxy` in Azure Firewall Policy.
    - `New-AzFirewallPolicyExplicitProxy`
    - `New-AzFirewallPolicy`
    - `Set-AzFirewallPolicy`
* Added new cmdlets to create packet captures for Network Watcher:
    - `New-AzNetworkWatcherPacketCaptureV2`
    - `New-AzPacketCaptureScopeConfig`
* Added support for CustomV2 ssl policies for Application Gateway.
    - Added `CustomV2` to the validation set of `PolicyType`
    - Added `TLSv1_3` to the validation set of `MinProtocolVersion`
    - Removed validation for null or empty cipher suites list since there can be empty cipher suites list for min protocol version of tls1.3
* Network Watcher Feature Change: Added new parameter i.e. AzureVMSS as source endpoint in ConnectionMonitor.
    - `New-AzNetworkWatcherConnectionMonitorEndpointObject`
* Added `IdentifyTopFatFlow` parameter to `AzureFirewall`
    - `New-AzFirewall`
* Enabled Azure Firewall forced tunneling by default (AzureFirewallManagementSubnet and ManagementPublicIpAddress are required) whenever basic sku firewall is created.
    - `New-AzFirewall`
* Fixed bug that causes an overflow due to incorrect SNAT private ranges IP validation.
* Added new cmdlets to create/manage L4(TCP/TLS) objects for ApplicationGateway:
	- `Get-AzApplicationGatewayListener`
	- `New-AzApplicationGatewayListener`
	- `Add-AzApplicationGatewayListener`
	- `Set-AzApplicationGatewayListener`
	- `Remove-AzApplicationGatewayListener`
	- `Get-AzApplicationGatewayBackendSetting`
	- `New-AzApplicationGatewayBackendSetting`
	- `Add-AzApplicationGatewayBackendSetting`
	- `Set-AzApplicationGatewayBackendSetting`
	- `Remove-AzApplicationGatewayBackendSetting`
	- `Get-AzApplicationGatewayRoutingRule`
	- `New-AzApplicationGatewayRoutingRule`
	- `Add-AzApplicationGatewayRoutingRule`
	- `Set-AzApplicationGatewayRoutingRule`
	- `Remove-AzApplicationGatewayRoutingRule`
* Updated cmdlet to add TCP/TLS Listener , BackendSetting , RoutingRule support for  Application Gateway:
	- `New-AzApplicationGateway`
* Updated cmdlets to add TCP/TLS protocol support for Application gateway Health Probe configuration:
	- `Set-AzApplicationGatewayProbeConfig`
	- `Add-AzApplicationGatewayProbeConfig`
	- `New-AzApplicationGatewayProbeConfig`
* Updated cmdlets to add basic sku support on Azure Firewall and Azure Firewall Policy:
    - `New-AzFirewall`
    - `New-AzFirewallPolicy`
    - `Set-AzFirewallPolicy`
* Added new cmdlets to create/manage authorization objects for ExpressRoutePort:
    - `Add-AzExpressRoutePortAuthorization`
    - `Get-AzExpressRoutePortAuthorization`
    - `Remove-AzExpressRoutePortAuthorization`
* Added option parameter `AuthorizationKey` to cmdlet `New-AzExpressRouteCircuit` to allow creating ExpressRoute Circuit on a ExpressRoutePort with a different owner.
* Fixed bug that can't display CustomIpPrefix in PublicIpPrefix.
* Updated cmdlets to add new property of `HubRoutingPreference` in VirtualHub and set property of `PreferredRoutingGateway` deprecated .
    - `New-AzVirtualHub`
    - `Update-AzVirtualHub`
* Added optional parameter `AuxiliaryMode` to cmdlet `New-AzNetworkInterface` to enable this network interface as Sirius enabled. Allowed values are None(default) and MaxConnections.
* Multipool feature change: Updated cmdlets to add new optional property: `ConfigurationPolicyGroups` object for associating policy groups.
    - `Update-AzVpnServerConfiguration`
    - `New-AzVpnServerConfiguration`
* Multipool feature change: Updated cmdlets to add new optional property: `P2SConnectionConfiguration` object for specifying multiple Connection configurations.
    - `Update-AzP2sVpnGateway`
    - `New-AzP2sVpnGateway`
* Multipool feature change: Added new cmdlets to support CRUD of Configuration policy groups for VpnServerConfiguration.
    - `Get-AzVpnServerConfigurationPolicyGroup`
    - `New-AzVpnServerConfigurationPolicyGroup`
    - `Update-AzVpnServerConfigurationPolicyGroup`
    - `Remove-AzVpnServerConfigurationPolicyGroup`
* Added new cmdlets for RoutingIntent child resource of VirtualHub.
    -`Add-AzRoutingPolicy`
    -`Get-AzRoutingPolicy`
    -`New-AzRoutingPolicy`
    -`Remove-AzRoutingPolicy`
    -`Set-AzRoutingPolicy`
    -`Get-AzRoutingIntent`
    -`New-AzRoutingIntent`
    -`Remove-AzRoutingIntent`
    -`Set-AzRoutingIntent`
* Updated cmdlets to add new option of `HubRoutingPreference` in RouteServer.
    - `New-AzRouteServer`
    - `Update-AzRouteServer`
* Fixed bug that can't parse CustomIpPrefixParent parameter from swagger to powershell.
* Added "Any" operator in New-AzApplicationGatewayFirewallCondition
* Made properties `ApplicationSecurityGroups` and `IpConfigurations` for `PrivateEndpoint` updatable in the cmdlet `Set-AzPrivateEndpoint`
* Onboarded Device Update for IoT Hub to Private Link Common Cmdlets

## Version 4.18.0
* [Breaking Change] Changed default value of `-PrivateEndpointNetworkPoliciesFlag` to `Disabled` in `Add-AzVirtualNetworkSubnetConfig` and `New-AzVirtualNetworkSubnetConfig`
* Fixed bugs that cannot parse virtual network encryption paramemters when updating exsiting vnet.

## Version 4.17.0
* Supported `Microsoft.Network/privateLinkServices` in `Get-AzPrivateEndpointConnection` [#16984].
* Provided friendly message if resource type is not supported for private endpoint connection features [#17091].
* Added `DisableIPsecProtection` to `Virtual Network Gateway`.

## Version 4.16.1
* Fixed `ArgumentNullException` in `Add-AzureRmRouteConfig` when `RouteTable.Routes` is null.
* Updated `New-AzFirewallPolicyIntrusionDetection` cmdlet:
    - Added parameter -PrivateRange

## Version 4.16.0
* Added support for retrieving the state of packet capture even when the provisioning state of the packet capture was failure
    - `Get-AzNetworkWatcherPacketCapture`
* Added support for accepting Vnet, Subnet and NIC resources as the TargetResourceId for the following cmdlets
    - `Set-AzNetworkWatcherFlowLog`
    - `New-AzNetworkWatcherFlowLog`

## Version 4.15.0
* Added new property `SqlSetting` for Azure Firewall Policy cmdlets
    - `Get-AzFirewallPolicy`
    - `New-AzFirewallPolicy`
    - `Set-AzFirewallPolicy`
* Added new to create new `SqlSetting` object for creating Azure Firewall Policy
    - `New-AzFirewallPolicySqlSetting`
* Added new cmdlet to support query Load Balancer inbound nat rule port mapping lists for backend addresses
    - `Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping`
    - Also updated cmdlets to support inbound nat rule V2 configurations
        - `New-AzLoadBalancerInboundNatRuleConfig`
        - `Set-AzLoadBalancerInboundNatRuleConfig`
        - `Add-AzLoadBalancerInboundNatRuleConfig`

## Version 4.14.0
* Used case-insensitive comparison for ResourceId (Set/New-NetworkWatcherFlowLog)
* Added new properties `ApplicationSecurityGroup`, `IpConfiguration` and `CustomNetworkInterfaceName` for Private Endpoint cmdlets
    - `Get-AzPrivateEndpoint`
    - `New-AzPrivateEndpoint`
* Added new cmdlet to create new `IpConfiguration` object for building Private Endpoint
    - `New-AzPrivateEndpointIpConfiguration`
* Added OrdinalIgnoreCase for string comparison of `ResourceIdentifier` type for FlowLog cmdlets
* Fixed typo in error message of `InvalidWorkspaceResourceId`

## Version 4.13.0
* Bugfix in PSAzureFirewallPolicyThreatIntelWhitelist for FirewallPolicy
* Added optional parameter `-IsSecuritySite` to the following cmdlet:
    - `New-AzVpnSite`
* Added support for new Match Variables in WAF Exclusions
* Onboard Virtual Network Encryption to Virtual Network Cmdlets
* Added support for NAT port range parameters in VPN NAT rule resources
    - `New-AzVpnGatewayNatRule.md`
    - `Update-AzVpnGatewayNatRule.md`
    - `New-AzVirtualNetworkGatewayNatRule.md`
    - `Update-AzVirtualNetworkGatewayNatRule.md`
* Added new cmdlets to support Per Rule Exclusions for Application Gateway WAF
    - `New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet`
    - `New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup`
    - `New-AzApplicationGatewayFirewallPolicyExclusionManagedRule`
    - Also updated cmdlet to add the property for configuring ExclusionManagedRuleSet within Exclusions
        - `New-AzApplicationGatewayFirewallPolicyExclusion`
* Bug Fix in Application Gateway Trusted Client Certificate cmdlets to load the entire cert chain from file.
## Version 4.12.0
* Support for Sku, ScaleUnits parameters of BastionHost resource.
    - `New-AzBastion`
    - `Set-AzBastion`
* Onboard Azure Resource Manager to Private Link Common Cmdlets
* Updated cmdlets to add properties to enable/disable BgpRouteTranslationForNat for VpnGateway.
    - `New-AzVpnGateway`
    - `Update-AzVpnGateway`
* Updated cmdlet to add property to disable InternetSecurity for P2SVpnGateway.
    - `New-AzP2sVpnGateway`
* Added new cmdlets for HubBgpConnection child resource of VirtualHub.
    - `Get-AzVirtualHubBgpConnection`
    - `New-AzVirtualHubBgpConnection`
    - `Update-AzVirtualHubBgpConnection`
    - `Remove-AzVirtualHubBgpConnection`
* Onboard Azure HDInsight to Private Link Common Cmdlets

## Version 4.11.0
* Updated cmdlet to add 'Subnet' property for IP based load balancer backend address pool.
    - `New-AzLoadBalancerBackendAddressConfig`
* Updated cmdlet to add 'TunnelInterface' property for backend pool related operations.
    - `New-AzLoadBalancerBackendAddressPool`
    - `Set-AzLoadBalancerBackendAddressPool`

## Version 4.10.0
* Added public ip address as an optional parameter to create route server
    - `New-AzRouteServer`
* Updated cmdlets to enable specification of edge zone
    - `New-AzPublicIpPrefix`
    - `New-AzLoadBalancer`
    - `New-AzPrivateLinkService`
    - `New-AzPrivateEndpoint`
* Added support for viewing extended location of virtual network in the console
    - `New-AzVirtualNetwork`
    - `Get-AzVirtualNetwork`
* Added support for viewing extended location of public IP address in the console
    - `New-AzPublicIpAddress`
    - `Get-AzPublicIpAddress`
    - `New-AzCustomIpPrefix`
    - `Update-AzCustomIpPrefix`

## Version 4.9.0
* Updated cmdlets for route server for a more stable way to add IP configuration.
* Added support for getting a single private link resource.
* Added more detailed description about GroupId in `New-AzPrivateLinkServiceConnection`
* Updated cmdlets to enable setting of PrivateRange on AzureFirewallPolicy.
    - `New-AzFirewallPolicy`
    - `Set-AzFirewallPolicy`
* Updated cmdlets to add NatRules in VirtualNetworkGateway and BgpRouteTranslationForNat.
    - `New-AzVirtualNetworkGateway`
    - `Set-AzVirtualNetworkGateway`
* Updated cmdlets to add EngressNatRules and EgressNatRules in VirtualNetworkGateway Connection.
    - `New-AzVirtualNetworkGatewayConnection`
    - `Set-AzVirtualNetworkGatewayConnection`
* Updated cmdlet to enable setting of FlowTimeout in VirtualNetwork.
    - `New-AzVirtualNetwork`
* Added cmdlets for Get/Create/Update/Delete VirtualNetworkGatewayNatRules.
    - `New-AzVirtualNetworkGatewayNatRule`
    - `Update-AzVirtualNetworkGatewayNatRule`
    - `Get-AzVirtualNetworkGatewayNatRule`
    - `Remove-AzVirtualNetworkGatewayNatRule`
* Added a new cmdlet for Sync on VirtualNetworkPeering
    - `Sync-AzVirtualNetworkPeering`
* Updated cmdlets to add new properties and redefined an existing property in the VirtualNetworkPeering
    - `Add-AzVirtualNetworkPeering`
    - `Get-AzVirtualNetworkPeering`
* Updated cmdlets to enable setting of PreferredRoutingGateway on VirtualHub.
    - `New-AzVirtualHub`
    - `Update-AzVirtualHub`
* Updated cmdlets to expose two read-only properties of client certificate.
    - `Get-AzApplicationGatewayTrustedClientCertificate`

## Version 4.8.0
* Updated validation to allow passing zero value for saDataSizeKilobytes parameter
    - `New-AzureRmIpsecPolicy`
* Added optional parameter `-EdgeZone` to the following cmdlets:
    - `New-AzNetworkInterface`
    - `New-AzPublicIpAddress`
    - `New-AzVirtualNetwork`

## Version 4.7.0
* Added new cmdlets to replace old product name `virtual router` with new name `route server` in the future.
    - `Get-AzRouteServerPeerAdvertisedRoute`
    - `Get-AzRouteServerPeerAdvertisedRoute`
    - Added deprecation attribute warning to the old cmdlets.
* Updated `set-azExpressRouteGateway` to allow parameter -MinScaleUnits without specifying -MaxScaleUnits
* Updated cmdlets to enable setting of VpnLinkConnectionMode on VpnSiteLinkConnections.
    - `New-AzVpnSiteLinkConnection`
    - `Update-AzVpnConnection`
* Added new cmdlet to fetch IKE Security Associations for VPN Site Link Connections.
    - `Get-VpnSiteLinkConnectionIkeSa`
* Added new cmdlet to reset a Virtual Network Gateway Connection.
    - `Reset-AzVirtualNetworkGatewayConnection`
* Added new cmdlet to reset a Vpn Site Link Connection.
    - `Reset-VpnSiteLinkConnection`
* Updated cmdlets to enable setting an optional parameter -TrafficSelectorPolicies
    - `New-AzVpnConnection`
    - `Update-AzVpnConnection`
* Bug fix for update vpnServerConfiguration.
* Add scenarioTest for p2s multi auth VWAN.
* Added multi auth feature support for VNG
	- `Get-AzVpnClientConfiguration`
	- `New-AzVirtualNetworkGateway`
	- `Set-AzVirtualNetworkGateway`

## Version 4.6.0
* Added new cmdlets to replace old product name `virtual router` with new name `route server` in the future.
    - `New-AzRouteServer`
    - `Get-AzRouteServer`
    - `Remove-AzRouteServer`
    - `Update-AzRouteServer`
    - `Get-AzRouteServerPeer`
    - `Add-AzRouteServerPeer`
    - `Update-AzRouteServerPeer`
    - `Remove-AzRouteServerPeer`
    - Added deprecation attribute warning to the old cmdlets.
* Bug fix in ExpressRouteLink MacSecConfig. Added new property `SciState` to `PSExpressRouteLinkMacSecConfig`
* Updated format list and format table views for Get-AzVirtualNetworkGatewayConnectionIkeSa
* Updated New-AzFirewall to no longer require data public IP for force tunneling firewall (with management IP and subnet)

## Version 4.5.0
* Added new cmdlets for CRUD of VpnGatewayNATRule.
    - `New-AzAzVpnGatewayNatRule`
    - `Update-AzAzVpnGatewayNatRule`
    - `Get-AzAzVpnGatewayNatRule`
    - `Remove-AzAzVpnGatewayNatRule`
* Updated cmdlets to set NATRule on VpnGateway resource and associate it with VpnSiteLinkConnection resource.
    - `New-AzVpnGateway`
    - `Update-AzVpnGateway`
    - `New-AzVpnSiteLinkConnection`
* Updated cmdlets to enable setting of ConnectionMode on Virtual Network Gateway Connections.
    - `New-AzVirtualNetworkGatewayConnection`
    - `Set-AzVirtualNetworkGatewayConnection`
* Updated `New-AzFirewallPolicyApplicationRule` cmdlet:
    - Added parameter TargetUrl
    - Added parameter TerminateTLS
* Added new cmdlets for Azure Firewall Premium Features
    - `New-AzFirewallPolicyIntrusionDetection`
    - `New-AzFirewallPolicyIntrusionDetectionBypassTraffic`
    - `New-AzFirewallPolicyIntrusionDetectionSignatureOverride`
* Updated New-AzFirewallPolicy cmdlet:
    - Added parameter -SkuTier
    - Added parameter -Identity
    - Added parameter -UserAssignedIdentityId
    - Added parameter -IntrusionDetection
    - Added parameter -TransportSecurityName
    - Added parameter -TransportSecurityKeyVaultSecretId
* Added new cmdlet to fetch IKE Security Associations for Virtual Network Gateway Connections.
    - `Get-AzVirtualNetworkGatewayConnectionIkeSa`
* Added multiple Authentication support for p2sVpnGateway
    - Updated New-AzVpnServerConfiguration and Update-AzVpnServerConfiguration to allow multiple authentication parameters to be set.
* Updated `New-AzVpnGateway` and `New-AzP2sVpnGateway` cmdlet:
    - Added parameter EnableRoutingPreferenceInternetFlag

## Version 4.4.0
* Fixed issue in remove peering and connection cmdlet for ExpressRouteCircuit scenario
    - `Remove-AzExpressRouteCircuitPeeringConfig` and `Remove-AzExpressRouteCircuitConnectionConfig`

## Version 4.3.0
* Updated below cmdlet
    - `New-AzLoadBalancerFrontendIpConfigCommand`, `Set-AzLoadBalancerFrontendIpConfigCommand`, `Add-AzLoadBalancerFrontendIpConfigCommand`:
        - Added PublicIpAddressPrefix property
        - Added PublicIpAddressPrefixId property
* Added new properties to the following cmdlets to allow for global load balancing
    - `New-AzLoadBalancer`:
        - Added Sku Tier property
    - `New-AzPuplicIpAddress`:
        - Added Sku Tier property
    - `New-AzPublicIpPrefix`:
        - Added Sku Tier property
    - `New-AzLoadBalancerBackendAddressConfig`:
        - Added LoadBalancerFrontendIPConfigurationId property
* Updated planning to deprecate warnings for the following cmdlets
    -`New-AzVirtualHubRoute`
    -`New-AzVirtualHubRouteTable`
    -`Add-AzVirtualHubRoute`
    -`Add-AzVirtualHubRouteTable`
    -`Get-AzVirtualHubRouteTable`
    -`Remove-AzVirtualHubRouteTable`
* Added planning to deprecate warnings on the argument `RouteTable` for the following cmdlets
    -`New-AzVirtualHub`
    -`Set-AzVirtualHub`
    -`Update-AzVirtualHub`
* Made arguments `-MinScaleUnits` and `-MaxScaleUnits` optional in `Set-AzExpressRouteGateway`
* Added new cmdlets to support Mutual Authentication and SSL Profiles on Application Gateway
    - `Get-AzApplicationGatewayClientAuthConfiguration`
    - `New-AzApplicationGatewayClientAuthConfiguration`
    - `Remove-AzApplicationGatewayClientAuthConfiguration`
    - `Set-AzApplicationGatewayClientAuthConfiguration`
    - `Add-AzApplicationGatewayTrustedClientCertificate`
    - `Get-AzApplicationGatewayTrustedClientCertificate`
    - `New-AzApplicationGatewayTrustedClientCertificate`
    - `Remove-AzApplicationGatewayTrustedClientCertificate`
    - `Set-AzApplicationGatewayTrustedClientCertificate`
    - `Add-AzApplicationGatewaySslProfile`
    - `Get-AzApplicationGatewaySslProfile`
    - `New-AzApplicationGatewaySslProfile`
    - `Remove-AzApplicationGatewaySslProfile`
    - `Set-AzApplicationGatewaySslProfile`
    - `Get-AzApplicationGatewaySslProfilePolicy`
    - `Remove-AzApplicationGatewaySslProfilePolicy`
    - `Set-AzApplicationGatewaySslProfilePolicy`
* Added new parameter 'Priority' to support Rule Priority in Application Gateway RequestRoutingRule for the below cmdlets
    - `Add-AzApplicationGatewayRequestRoutingRule`
    - `New-AzApplicationGatewayRequestRoutingRule`
    - `Set-AzApplicationGatewayRequestRoutingRule`

## Version 4.2.0
* Added warning messages for upcoming breaking change for Virtual Router Peer Routes
    - `Get-AzVirtualRouterPeerLearnedRoute`
    - `Get-AzVirtualRouterPeerAdvertisedRoute`
* Added new cmdlet for virtual router
    - `Update-AzVirtualRouter`: to allow branch to branch traffic
* Updated New-AzFirewallPolicyNatRule cmdlet:
    - Added parameter Translated FQDN

## Version 4.1.0
* [Breaking Change] Removed parameter `HostedSubnet` and added `Subnet` instead
* Added new cmdlets for Virtual Router Peer Routes
    - `Get-AzVirtualRouterPeerLearnedRoute`
    - `Get-AzVirtualRouterPeerAdvertisedRoute`
* Updated New-AzFirewall cmdlet:
    - Added parameter `-SkuTier`
    - Added parameter `-SkuName` and made Sku as Alias for this
    - Removed parameter `-Sku`
* [Breaking Change] Made `Connectionlink` argument mandatory in `Start-AzVpnConnectionPacketCapture` and `Stop-AzVpnConnectionPacketCapture`
* [Breaking Change] Updated `New-AzNetworkWatcherConnectionMonitorEndPointObject` to remove parameter `-Filter`
* [Breaking Change] Replaced `New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject` cmdlet with `New-AzNetworkWatcherConnectionMonitorEndpointScopeItemObject`
* Updated `New-AzNetworkWatcherConnectionMonitorEndPointObject` cmdlet:
	- Added parameter `-Type`
	- Added parameter `-CoverageLevel`
	- Added parameter `-Scope`
* Updated `New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject` cmdlet with new parameter `-DestinationPortBehavior`

## Version 3.5.0
* Added Office365 Policy to VPNSite Resource
    - `New-AzO365PolicyProperty`
* Added example to New-AzVirtualHubVnetConnection
    - `Example details how to create a new routing config and static routes and apply it to a connection`
* Added example to New-AzVHubRoute
    - `Example details how to set static route on HubVnet connection`

## Version 3.4.0
* [Breaking Change] Updated below cmdlets to align resource virtual router and virtual hub
    - `New-AzVirtualRouter`:
        - Added -HostedSubnet parameter to support IP configuration child resource
        - deleted -HostedGateway and -HostedGatewayId
    - `Get-AzVirtualRouter`:
        - Added subscription level parameter set
    - `Remove-AzVirtualRouter`
    - `Add-AzVirtualRouterPeer`
    - `Get-AzVirtualRouterPeer`
    - `Remove-AzVirtualRouterPeer`
* Added new cmdlet for Azure Express Route Port
    - `New-AzExpressRoutePortLOA`
* Added RemoteBgpCommunities property to the VirtualNetwork Peering Resource
* Modified the warning message for `New-AzLoadBalancerFrontendIpConfig`, `New-AzPublicIpAddress` and `New-AzPublicIpPrefix`.
* Added VpnGatewayIpConfigurations to `Get-AzVpnGateway` output
* Fixed bug for `Set-AzApplicationGatewaySslCertificate` [#9488]
* Added `AllowActiveFTP` parameter to `AzureFirewall`
* Updated below commands for feature: Enable internet security set/remove on VirtualWan P2SVpnGateway.
- Updated `New-AzP2sVpnGateway`: Added optional switch parameter `EnableInternetSecurityFlag` for customers to set true to enable internet security on P2SVpnGateway, which will be applied for Point to site clients.
- Updated `Update-AzP2sVpnGateway`: Added optional switch parameters `EnableInternetSecurityFlag` or `DisableInternetSecurityFlag` for customers to set true/false to enable/disable internet security on P2SVpnGateway, which will be applied for Point to site clients.
* Added new cmdlet `Reset-AzP2sVpnGateway` for customers to reset/reboot their VirtualWan P2SVpnGateway for troubleshooting.
* Added new cmdlet `Reset-AzVpnGateway` for customers to reset/reboot their VirtualWan VpnGateway for troubleshooting.
* Updated `Set-AzVirtualNetworkSubnetConfig`
    - Set NSG and Route Table properties of subnet to null if explicitly set in parameters [#1548][#9718]
* [Breaking Change] Deprecated a switch parameter in below cmdlets
    - `New-AzFirewall`:
        - Deprecated `-DnsProxyNotRequiredForNetworkRule` switch paramemter
    - `New-AzFirewallPolicyDnsSetting`:
        - Deprecated `-ProxyNotRequiredForNetworkRule` switch parameter

## Version 3.3.0
* Added support for AddressPrefixType parameter to `Remove-AzExpressRouteCircuitConnectionConfig`
* Added non-breaking changes: PeerAddressType functionality for Private Peering in `Remove-AzExpressRouteCircutPeeringConfig`.
* Code changed to ignore case for AddressPrefixType and PeerAddressType parameter.
* Modified the warning message for `New-AzLoadBalancerFrontendIpConfig`, `New-AzPublicIpAddress` and `New-AzPublicIpPrefix`.

## Version 3.2.0
* Fixed parameters swap in VWan HubVnet connection
* Added new cmdlets for Azure Network Virtual Appliance Sites
    - `Get-AzVirtualApplianceSite`
    - `New-AzVirtualApplianceSite`
    - `Remove-AzVirtualApplianceSite`
    - `Update-AzVirtualApplianceSite`
    - `New-AzOffice365PolicyProperty`
* Added new cmdlets for Azure Network Virtual Appliance
    - `Get-AzNetworkVirtualAppliance`
    - `New-AzNetworkVirtualAppliance`
    - `Remove-AzNetworkVirtualAppliance`
    - `Update-AzNetworkVirtualAppliance`
    - `Get-AzNetworkVirtualApplianceSku`
    - `New-AzVirtualApplianceSkuProperty`
* Added new cmdlets for VirtualWan
    - `Start-AzVpnGatewayPacketCapture`
    - `Stop-AzVpnGatewayPacketCapture`
    - `Start-AzVpnConnectionPacketCapture`
    - `Stop-AzVpnConnectionPacketCapture`
* Onboard Application Gateway to Private Link Common Cmdlets
* Onboard StorageSync to Private Link Common Cmdlets
* Onboarded SignalR to Private Link Common Cmdlets

## Version 3.1.0
* Added support for AddressPrefixType parameter to `Remove-AzExpressRouteCircuitConnectionConfig`
* Added new cmdlets for Azure FirewallPolicy
    - `New-AzFirewallPolicyDnsSetting`
    - Support for Destination FQDN in Network Rules for Firewall Policy
* Added support for backend address pool operations
    - `New-AzLoadBalancerBackendAddressConfig`
    - `New-AzLoadBalancerBackendAddressPool`
    - `Set-AzLoadBalancerBackendAddressPool`
    - `Remove-AzLoadBalancerBackendAddressPool`
    - `Get-AzLoadBalancerBackendAddressPool`
* Added name validation for `New-AzIpGroup`
* Added new cmdlets for Azure FirewallPolicy
    - `New-AzFirewallPolicyThreatIntelWhitelist`
* Updated below commands for feature: Custom dns servers set/remove on VirtualWan P2SVpnGateway.
    - Updated New-AzP2sVpnGateway: Added optional parameter `-CustomDnsServer` for customers to specify their dns servers to set on P2SVpnGateway, which can be used by Point to site clients.
    - Updated Update-AzP2sVpnGateway: Added optional parameter `-CustomDnsServer` for customers to specify their dns servers to set on P2SVpnGateway, which can be used by Point to site clients.
* Updated `Update-AzVpnGateway`
    - Added optional parameter `-BgpPeeringAddress` for customers to specify their custom bgps to set on VpnGateway.
* Added new cmdlet to support resetting the routing state of a VirtualHub resource:
    - `Reset-AzHubRouter`
* Updated below things based on recent swagger change for Firewall Policy
    - Changes names for RuleGroup, RuleCollectionGroup and RuleType
    - Added support for Firewall Policy NAT Rule Collections to support multiple NAT Rule Collection
* [Breaking Change] Added mandatory parameter `SourceIpGroup` for `New-AzFirewallPolicyApplicationRule` and `New-AzFirewallPolicyNetworkRule`.
* [Breaking Change] Fixed `New-AzFirewallPolicyApplicationRule`, parameter `SourceAddress` to be mandatory.
* [Breaking Change] Fixed `New-AzFirewallPolicyApplicationRule`, parameter `SourceAddress` to be mandatory.
* [Breaking Change] Removed mandatory parameters: `TranslatedAddress`, `TranslatedPort` for `New-AzFirewallPolicyNatRuleCollection`.
* Added new cmdlets to support PrivateLink On Application Gateway
    - `New-AzApplicationGatewayPrivateLinkConfiguration`
    - `Get-AzApplicationGatewayPrivateLinkConfiguration`
    - `New-AzApplicationGatewayPrivateLinkConfiguration`
    - `Set-AzApplicationGatewayPrivateLinkConfiguration`
    - `Remove-AzApplicationGatewayPrivateLinkConfiguration`
    - `New-AzApplicationGatewayPrivateLinkIpConfiguration`
* Added new cmdlets for HubRouteTables child resource of VirtualHub.
    - `New-AzVHubRoute`
    - `New-AzVHubRouteTable`
    - `Get-AzVHubRouteTable`
    - `Update-AzVHubRouteTable`
    - `Remove-AzVHubRouteTable`
* Updated existing cmdlets to support optional RoutingConfiguration input parameter for custom routing in VirtualWan.
    - `New-AzExpressRouteConnection`
    - `Set-AzExpressRouteConnection`
    - `New-AzVirtualHubVnetConnection`
    - `Update-AzVirtualHubVnetConnection`
    - `New-AzVpnConnection`
    - `Update-AzVpnConnection`
    - `New-AzP2sVpnGateway`
    - `Update-AzP2sVpnGateway`

## Version 3.0.0
* Added breaking change attribute to notify that Zone default behaviour will be changed
    - `New-AzPublicIpAddress`
    - `New-AzPublicIpPrefix`
    - `New-AzLoadBalancerFrontendIpConfig`
* Added support for a new top level resource SecurityPartnerProvider
    - New cmdlets added:
        - New-AzSecurityPartnerProvider
        - Remove-AzSecurityPartnerProvider
        - Get-AzSecurityPartnerProvider
        - Set-AzSecurityPartnerProvider
* Added `RequiredZoneNames` on `PSPrivateLinkResource` and `GroupId` on `PSPrivateEndpointConnection`
* Fixed incorrect type of SuccessThresholdRoundTripTimeMs parameter for New-AzNetworkWatcherConnectionMonitorTestConfigurationObject
* Updated VirtualWan cmdlets to set default value of AllowVnetToVnetTraffic argument to True.
    - `New-AzVirtualWan`
    - `Update-AzVirtualWan`
* Added new cmdlets to support DNS zone group for private endpoint
    - `New-AzPrivateDnsZoneConfig`
    - `Get-AzPrivateDnsZoneGroup`
    - `New-AzPrivateDnsZoneGroup`
    - `Set-AzPrivateDnsZoneGroup`
    - `Remove-AzPrivateDnsZoneGroup`
* Add `DNSEnableProxy`, 'DNSRequireProxyForNetworkRules' and 'DNSServers' parameters to `AzureFirewall`
* Add `EnableDnsProxy`, 'DnsProxyNotRequiredForNetworkRule' and 'DnsServer' parameters to `AzureFirewall`
    - Updated cmdlet:
        - New-AzFirewall
* Add deprecation warning for `HubVnetConnection` parameter in following cmdlets
    - NewAzureRmVirtualHubCommand
    - UpdateAzureRmVirtualHubCommand
* Use HubVnetConnection create/update APIs instead of VirtualHub create/update APIs for following cmdlets
    - NewAzureRmVirtualHubCommand
    - UpdateAzureRmVirtualHubCommand
    - NewHubVirtualNetworkConnectionCommand
    - UpdateAzureRmHubVirtualNetworkConnectionCommand
    - RemoveHubVirtualNetworkConnectionCommand
* Deprecate `EnableInternetSecurity` switch parameter and instead introduce `EnableInternetSecurityFlag` boolean in
    - NewHubVirtualNetworkConnectionCommand.
    The flag is also made true by default for newly created connections.

## Version 2.5.0
* Updated cmdlets to enable connection on private IP for Virtual Network Gateway.
    - `New-AzVirtualNetworkGateway`
    - `Set-AzVirtualNetworkGateway`
    - `New-AzVirtualNetworkGatewayConnection`
    - `Set-AzVirtualNetworkGatewayConnection`
* Updated cmdlets to enable FQDN based LocalNetworkGateways and VpnSites
    - `New-AzLocalNetworkGateway`
    - `New-AzVpnSiteLink`
* Added support for IPv6 address family in ExpressRouteCircuitConnectionConfig (Global Reach)
    - Added `Set-AzExpressRouteCircuitConnectionConfig`
        - allows setting of all the existing properties including the IPv6CircuitConnectionProperties
    - Updated `Add-AzExpressRouteCircuitConnectionConfig`
        - Added another optional parameter AddressPrefixType to specify the address family of address prefix
* Updated cmdlets to enable setting of DPD Timeout on Virtual Network Gateway Connections.
    - New-AzVirtualNetworkGatewayConnection
    - Set-AzVirtualNetworkGatewayConnection
* Added resource type IpAllocation
* Added properties to Subnet
    - Added property 'IpAllocations' as type of PSResourceId to PSIpAllocation
* Added properties to Virtual Network
    - Added property 'IpAllocations' as type of PSResourceId to PSIpAllocation
* Added support for IpAllocation resource
    - New cmdlet added:
        - Get-AzIpAllocation
        - New-AzIpAllocation
        - Remove-AzIpAllocation
        - Get-AzIpAllocation
    - Updated `New-AzVirtualNetwork`
        - Added another optional parameter IpAllocations to specify the IpAllocation
    - Updated `New-AzVirtualNetworkSubnetConfig`
        - Added another optional parameter IpAllocations to specify the IpAllocation
    - Updated `Set-AzVirtualNetworkSubnetConfig`
        - Added another optional parameter IpAllocations to specify the IpAllocation
    - Updated `Add-AzVirtualNetworkSubnetConfig`
        - Added another optional parameter IpAllocations to specify the IpAllocation

## Version 2.4.0
* Updated cmdlets to allow cross-tenant VirtualHubVnetConnections
    - `New-AzVirtualHubVnetConnection`
    - `Update-AzVirtualHubVnetConnection`
    - `New-AzVirtualHub`
    - `Update-AzVirtualHub`
* Removed Sql Management SDK dependency
* Added 'New-AzIpConfigurationBgpPeeringAddressObject'
* Updated 'Set-AzVirtualNetworkGateway' and 'New-AzVirtualNetworkGateway'

## Version 2.3.2
* Updated Sql Management SDK.
* Fixed a naming-difference issue in PrivateLinkServiceConnectionState class.
    - Mapping the field ActionsRequired to ActionRequired.
* Added PublicNetworkAccess to `New-AzSqlServer` and `Set-AzSqlServer`

## Version 2.3.1
* Added one extra parameter note for parameter `-EnableProxyProtocol` for `New-AzPrivateLinkService` cmdlet.
* Fixed FilterData example in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Added Packet Capture example for capture all inner and outer packets in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Supported Azure Firewall Policy on VNet Firewalls
    - No new cmdlets are added. Relaxing the restriction for firewall policy on VNet firewalls
* Added support to disconnect vpn connection in virtual network gateway and p2s vpn gateway
    - New cmdlets added:
        - Disconnect-AzVirtualNetworkGatewayVpnConnection
        - Disconnect-AzP2sVpnGatewayVpnConnection

## Version 2.3.0
* New example added to Set-AzNetworkWatcherConfigFlowLog.md to demonstrate Traffic Analytics disable scenario.
* Add support for assigning management IP configuration to Azure Firewall - a dedicated subnet and Public IP that the firewall will use for its management traffic
    - Updated New-AzFirewall cmdlet:
        - Added parameter -ManagementPublicIpAddress (not mandatory) which accepts a Public IP Address object
        - Added method SetManagementIpConfiguration on firewall object - requires a subnet and a Public IP address as input - subnet name must be "AzureFirewallManagementSubnet"
* Corrected Get-AzNetworkSecurityGroup examples to show examples for NSG's instead of network interfaces.
* Fixed typo in New-AzureRmVpnSite command that was preventing resource id completer from completing a parameter.
* Added support for Url Confiugration in Rewrite Rules Action Set in the Application Gateway
    - New cmdlets added:
        - New-AzApplicationGatewayRewriteRuleUrlConfiguration
    - Cmdlets updated with optional parameter - UrlConfiguration
        - New-AzApplicationGatewayRewriteRuleActionSet
* Add suppport for NetworkWatcher ConnectionMonitor version 2 resources

## Version 2.2.1
* Upgrade dependancy of Microsoft.Azure.Management.Sql from 1.36-preview to 1.37-preview

## Version 2.2.0
* Update references in .psd1 to use relative path
* Support for IpGroups in AzureFirewall Application,Nat & Network Rules.

## Version 2.1.0
* Change `Start-AzVirtualNetworkGatewayConnectionPacketCapture.md` and `Start-AzVirtualnetworkGatewayPacketCapture.md` FilterData option examples.
* Add `PrivateRange` parameter to `AzureFirewall`
    - Updated cmdlet:
        - New-AzFirewall

## Version 2.0.0
* Change all cmdlets for PrivateEndpointConnection to support generic service provider.
    - Updated cmdlet:
        - Approve-AzPrivateEndpointConnection
        - Deny-AzPrivateEndpointConnection
        - Get-AzPrivateEndpointConnection
        - Remove-AzPrivateEndpointConnection
        - Set-AzPrivateEndpointConnection
* Add new cmdlet for PrivateLinkResource and it also support generic service provider.
    - New cmdlet:
        - Get-AzPrivateLinkResource
* Add new fields and parameter for the feature Proxy Protocol V2.
    - Add property EnableProxyProtocol in PrivateLinkService
    - Add property LinkIdentifier in PrivateEndpointConnection
    - Updated New-AzPrivateLinkService to add a new optional parameter EnableProxyProtocol.
* Fix incorrect parameter description in `New-AzApplicationGatewaySku` reference documentation
* New cmdlets to support the azure firewall policy
* Add support for ThreatIntelWhitelist property for AzFirewall
    - New cmdlet added:
        - New-AzFirewallThreatIntelWhitelist
    - Cmdlets updated with optional parameters:
        - New-AzFirewall : added parameter ThreatIntelWhitelist
* Add support for child resource RouteTables of VirtualHub
    - New cmdlets added:
        - Add-AzVirtualHubRoute
        - Add-AzVirtualHubRouteTable
        - Get-AzVirtualHubRouteTable
        - Remove-AzVirtualHubRouteTable
        - Set-AzVirtualHub
* Add support for new properties Sku of VirtualHub and VirtualWANType of VirtualWan
    - Cmdlets updated with optional parameters:
        - New-AzVirtualHub : added parameter Sku
        - Update-AzVirtualHub : added parameter Sku
        - New-AzVirtualWan : added parameter VirtualWANType
        - Update-AzVirtualWan : added parameter VirtualWANType
* Add support for EnableInternetSecurity property for HubVnetConnection, VpnConnection and ExpressRouteConnection
    - New cmdlets added:
        - Update-AzureRmVirtualHubVnetConnection
    - Cmdlets updated with optional parameters:
        - New-AzureRmVirtualHubVnetConnection : added parameter EnableInternetSecurity
        - New-AzureRmVpnConnection : added parameter EnableInternetSecurity
        - Update-AzureRmVpnConnection : added parameter EnableInternetSecurity
        - New-AzureRmExpressRouteConnection : added parameter EnableInternetSecurity
        - Set-AzureRmExpressRouteConnection : added parameter EnableInternetSecurity
* Add support for Configuring TopLevel WebApplicationFirewall Policy
    - New cmdlets added:
        - New-AzApplicationGatewayFirewallPolicySetting
        - New-AzApplicationGatewayFirewallPolicyExclusion
        - New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride
        - New-AzApplicationGatewayFirewallPolicyManagedRuleOverride
        - New-AzApplicationGatewayFirewallPolicyManagedRule
        - New-AzApplicationGatewayFirewallPolicyManagedRuleSet
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayFirewallPolicy : added parameter PolicySetting, ManagedRule
* Added support for Geo-Match operator on CustomRule
    - Added GeoMatch to the operator on the FirewallCondition
* Added support for perListener and perSite Firewall policy
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayHttpListener : added parameter FirewallPolicy, FirewallPolicyId
        - New-AzApplicationGatewayPathRuleConfig : added parameter FirewallPolicy, FirewallPolicyId
* Added support for perListener HostNames
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayHttpListener : added parameter HostNames
        - Add-AzApplicationGatewayHttpListener : added parameter HostNames
* Fix required subnet with name AzureBastionSubnet in `PSBastion` can be case insensitive
* Support for Destination FQDNs in Network Rules and Translated FQDN in NAT Rules for Azure Firewall
* Add support for top level resource RouteTables of IpGroup
    - New cmdlets added:
        - New-AzIpGroup
        - Remove-AzIpGroup
        - Get-AzIpGroup
        - Set-AzIpGroup
* Virtual Wan Point to site feature release.
  - Introduce new command lets for managing point to site VpnServerConfiguration resource
    - Get-AzVpnServerConfiguration
    - New-AzVpnServerConfiguration
    - Remove-AzVpnServerConfiguration
    - Update-AzVpnServerConfiguration
  - Introduce new command lets for managing P2SVpnGateway resource that will be used for Point to site connectivity from Virtual wan perspective
    - Get-AzP2sVpnGateway
    - Get-AzP2sVpnGatewayConnectionHealth
    - Get-AzP2sVpnGatewayDetailedConnectionHealth
    - New-AzP2sVpnGateway
    - Remove-AzP2sVpnGateway
    - Update-AzP2sVpnGateway
  - Introduce new command lets for VirtualWan resource to get all associated VpnServerConfigurations and download Wan level Point to site client profile.
    - Get-AzVirtualWanVpnServerConfiguration
    - Get-AzVirtualWanVpnServerConfigurationVpnProfile

## Version 1.15.0
* Add new cmdlet Get-AzAvailableServiceAlias which can be called to get the aliases that can be used for Service Endpoint Policies.
* Added support for the adding traffic selectors to Virtual Network Gateway Connections
    - New cmdlets added:
        - New-AzureRmTrafficSelectorPolicy
    - Cmdlets updated with optional parameter -TrafficSelectorPolicies
        -New-AzureRmVirtualNetworkGatewayConnection
        -Set-AzureRmVirtualNetworkGatewayConnection
* Add support for ESP and AH protocols in network security rule configurations
    - Updated cmdlets:
        - Add-AzNetworkSecurityRuleConfig
        - New-AzNetworkSecurityRuleConfig
        - Set-AzNetworkSecurityRuleConfig
* Improve handling of exceptions in Cortex cmdlets
* New Generations and SKUs for VirtualNetworkGateways
  - Introduce new Generations for VirtualNetworkGateways.
  - Introduce new high throughput SKUs for VirtualNetworkGateways.

## Version 1.14.0
* Fix incorrect example in `New-AzApplicationGateway` reference documentation
* Add note in `Get-AzNetworkWatcherPacketCapture` reference documentation about retrieving all properties for a packet capture
* Fixed example in `Test-AzNetworkWatcherIPFlow` reference documentation to correctly enumerate NICs
* Improved cloud exception parsing to display additional details if they are present
* Improved cloud exception parsing to handle additional type of SDK exception
* Fixed incorrect mapping of Security Rule models
* Added properties to network interface for private ip feature
    - Added property 'PrivateEndpoint' as type of PSResourceId to PSNetworkInterface
    - Added property 'PrivateLinkConnectionProperties' as type of PSIpConfigurationConnectivityInformation to PSNetworkInterfaceIPConfiguration
    - Added new model class PSIpConfigurationConnectivityInformation
* Added new ApplicationRuleProtocolType "mssql" for Azure Firewall resource
* MultiLink support in Virtual WAN
    - New cmdlets
        - New-AzVpnSiteLink
        - New-AzVpnSiteLinkConnection
    - Updated cmdlet:
        - New-VpnSite
        - Update-VpnSite
        - New-VpnConnection
        - Update-VpnConnection
* Fixed documents for some PowerShell examples to use Az cmdlets instead of AzureRM cmdlets

## Version 1.13.0
* Updated New-AzPrivateLinkServiceIpConfig
    - Deprecated the parameter 'PublicIpAddress' since this is never used in the server side.
    - Added one optional parameter 'Primary' that indicate the current ip configuration is primary one or not.
* Improved handling of request error exception from SDK
    -Fixes the issue that previously SDK exceptions aren't handled correctly which results in key error details not being displayed
* Fixed miscellaneous typos across module
* Adjusted validation logic for Ipv6 IP Prefix to check for correct IPv6 prefix length.
* Updated Get-AzVirtualNetworkSubnetConfig: Added parameter set to get by subnet resource id.
* Updated description of Location parameter for AzNetworkServiceTag

## Version 1.12.0
* Add support for private endpoint and private link service
    - New cmdlets
        - Set-AzPrivateEndpoint
        - Set-AzPrivateLinkService
        - Approve-AzPrivateEndpointConnection
        - Deny-AzPrivateEndpointConnection
        - Get-AzPrivateEndpointConnection
        - Remove-AzPrivateEndpointConnection
        - Test-AzPrivateLinkServiceVisibility
        - Get-AzAutoApprovedPrivateLinkService
* Updated below commands for feature: PrivateEndpointNetworkPolicies/PrivateLinkServiceNetworkPolicies flag on Subnet in Virtualnetwork
    - Updated New-AzVirtualNetworkSubnetConfig/Set-AzVirtualNetworkSubnetConfig/Add-AzVirtualNetworkSubnetConfig
        - Added optional parameter -PrivateEndpointNetworkPoliciesFlag to indicate that enable or disable apply network policies on pivate endpoint in this subnet.
        - Added optional parameter -PrivateLinkServiceNetworkPoliciesFlag to indicate that enable or disable apply network policies on private link service in this subnet.
* AzPrivateLinkService's cmdlet parameter `ServiceName` was renamed to `Name` with an alias `ServiceName` for backward compatibility
* Enable ICMP protocol for network security rule configurations
    - Updated cmdlets
        - Add-AzNetworkSecurityRuleConfig
        - New-AzNetworkSecurityRuleConfig
        - Set-AzNetworkSecurityRuleConfig
* Add ConnectionProtocolType (Ikev1/Ikev2) as a configurable parameter for New-AzVirtualNetworkGatewayConnection
* Add PrivateIpAddressVersion in LoadBalancerFrontendIpConfiguration
    - Updated cmdlet:
        - New-AzLoadBalancerFrontendIpConfig
        - Add-AzLoadBalancerFrontendIpConfig
        - Set-AzLoadBalancerFrontendIpConfig
* Application Gateway New-AzApplicationGatewayProbeConfig command update for supporting custom port in Probe
    - Updated New-AzApplicationGatewayProbeConfig: Added optional parameter Port which is used for probing backend server. This parameter is applicable for Standard_V2 and WAF_V2 SKU.


## Version 1.11.0
* Added `RoutingPreference` to public ip tags
* Improve examples for `Get-AzNetworkServiceTag` reference documentation

## Version 1.10.0
* Add support for Virtual Network Gateway Resource
    - New cmdlets
        - Get-AzVirtualNetworkGatewayVpnClientConnectionHealth
* Add AvailablePrivateEndpointType
    - New cmdlets
        - Get-AzAvailablePrivateEndpointType
* Add PrivatePrivateLinkService
    - New cmdlets
        - Get-AzPrivateLinkService
        - New-AzPrivateLinkService
        - Remove-AzPrivateLinkService
        - New-AzPrivateLinkServiceIpConfig
        - Set-AzPrivateEndpointConnection
* Add PrivateEndpoint
    - New cmdlets
        - Get-AzPrivateEndpoint
        - New-AzPrivateEndpoint
        - Remove-AzPrivateEndpoint
        - New-AzPrivateLinkServiceConnection
* Updated below commands for feature: UseLocalAzureIpAddress flag on VpnConnection
    - Updated New-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
    - Updated Set-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
* Added readonly field PeeredConnections in ExpressRoute peering.
* Added readonly field GlobalReachEnabled in ExpressRoute.
* Added breaking change attribute to call out deprecation of AllowGlobalReach field in ExpressRouteCircuit model
* Fixed Issue 8756 Error using TargetListenerID with AzApplicationGatewayRedirectConfiguration cmdlets
* Fixed bug in New-AzApplicationGatewayPathRuleConfig that prevented the rewrite ruleset from being set.
* Fixed displaying of VirtualNetworkTaps in NetworkInterfaceIpConfiguration
* Fixed Cortex Get cmdlets for list all part
* Fixed VirtualHub reference creation for ExpressRouteGateways, VpnGateway
* Added support for Availability Zones in AzureFirewall and NatGateway
* Added cmdlet Get-AzNetworkServiceTag
* Add support for multiple public IP addresses for Azure Firewall
    - Updated New-AzFirewall cmdlet:
        - Added parameter -PublicIpAddress which accepts one or more Public IP Address objects
        - Added parameter -VirtualNetwork which accepts a Virtual Network object
        - Added methods AddPublicIpAddress and RemovePublicIpAddress on firewall object - these accept a Public IP Address object as input
        - Deprecated parameters -PublicIpName and -VirtualNetworkName
* Updated below commands for feature: Set VpnClient AAD authentication options to Virtual network gateway resource.
    - Updated New-AzVirtualNetworkGateway: Added optional parameters AadTenantUri,AadAudienceId,AadIssuerUri to set VpnClient AAD authentication options on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional parameter AadTenantUri,AadAudienceId,AadIssuerUri to set VpnClient AAD authentication options on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional switch parameter RemoveAadAuthentication to remove VpnClient AAD authentication options from Gateway.

## Version 1.9.0
* Update ResourceId and InputObject for Nat Gateway
    - Add alias for ResourceId and InputObject
* Removed WAF RuleSetVersion validation

## Version 1.8.1
* Add DisableBgpRoutePropagation flag to Effective Route Table output
    - Updated cmdlet:
        - Get-AzEffectiveRouteTable
* Fix double dash in New-AzApplicationGatewayTrustedRootCertificate documentation

## Version 1.8.0
* Add support for Nat Gateway Resource
    - New cmdlets
        - New-AzNatGateway
        - Get-AzNatGateway
        - Set-AzNatGateway
        - Remove-AzNatGateway
   - Updated cmdlets
        - New-AzureVirtualNetworkSubnetConfigCommand
        - Add-AzureVirtualNetworkSubnetConfigCommand
* Updated below commands for feature: Custom routes set/remove on Brooklyn Gateway.
    - Updated New-AzVirtualNetworkGateway: Added optional parameter -CustomRoute to set the address prefixes as custom routes to set on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional parameter -CustomRoute to set the address prefixes as custom routes to set on Gateway.

## Version 1.7.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

## Version 1.6.0
* Add Alert action type for Azure Firewall Network and Application Rule Collections

* Added support for conditions in RewriteRules in the Application Gateway
    - New cmdlets added:
        - New-AzApplicationGatewayRewriteRuleCondition
    - Cmdlets updated with optional parameter - RuleSequence and Condition
        - New-AzApplicationGatewayRewriteRule

## Version 1.5.0
* Add Threat Intelligence support for Azure Firewall
* Add Application Gateway Firewall Policy top level resource and Custom Rules


## Version 1.4.0
* Add ResourceId parameter to Get-AzNetworkInterface
* Improved error handling for Get-AzVpnClientRevokedCertificate, Get-AzVpnClientRootCertificate
* Improved Subnet, Primary, PrivateIpAddressVersion parameters processing in
    - Add-AzNetworkInterfaceIpConfig
    - Set-AzNetworkInterfaceIpConfig

## Version 1.3.0
* Add wildcard support to Network cmdlets

## Version 1.2.1
* Update help example for Add-AzApplicationGatewayCustomError

## Version 1.2.0
* Added Cmdlets for Identity on Application Gateway.
    - New cmdlets added:
        - Set-AzApplicationGatewayIdentity
        - Get-AzApplicationGatewayIdentity
        - New-AzApplicationGatewayIdentity
        - Remove-AzApplicationGatewayIdentity
    - New-AzApplicationGateway cmdlet updated with optional parameter -Identity

## Version 1.1.0
* Update incorrect online help URLs

## Version 1.0.0
* Added support for the configuring RewriteRuleSets in the Application Gateway
    - New cmdlets added:
        - Add-AzureRmApplicationGatewayRewriteRuleSet
        - Get-AzureRmApplicationGatewayRewriteRuleSet
        - New-AzureRmApplicationGatewayRewriteRuleSet
        - Remove-AzureRmApplicationGatewayRewriteRuleSet
        - Set-AzureRmApplicationGatewayRewriteRuleSet
        - New-AzureRmApplicationGatewayRewriteRule
        - New-AzureRmApplicationGatewayRewriteRuleActionSet
        - New-AzureRmApplicationGatewayRewriteRuleHeaderConfiguration
    - Cmdlets updated with optional parameter -RewriteRuleSet
        - New-AzureRmApplicationGateway
        - New-AzureRmApplicationGatewayRequestRoutingRule
        - Add-AzureRmApplicationGatewayRequestRoutingRule
        - New-AzureRmApplicationGatewayPathRuleConfig
        - Add-AzureRmApplicationGatewayUrlPathMapConfig
        - New-AzureRmApplicationGatewayUrlPathMapConfig
* Removed deprecated -ResourceId parameter from Get-AzServiceEndpointPolicyDefinition
* Removed deprecated EnableVmProtection property from PSVirtualNetwork
* Removed deprecated Set-AzVirtualNetworkGatewayVpnClientConfig cmdlet
* Added KeyVault Support to Application Gateway using Identity.
    - Cmdlets updated with optonal parameter -KeyVaultSecretId, -KeyVaultSecret
        - Add-AzApplicationGatewaySslCertificate
        - New-AzApplicationGatewaySslCertificate
        - Set-AzApplicationGatewaySslCertificate
    - New-AzApplicationGateway cmdlet updated with optional parameter -UserAssignedIdentityId, -UserAssignedIdentity
* Add MaxCapacity property in ApplicationGatewayAutoscaleConfiguration
