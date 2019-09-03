---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvpnconnection
schema: 2.0.0
---

# New-AzVpnConnection

## SYNOPSIS
Creates a vpn connection to a scalable vpn gateway if it doesn't exist else updates the existing connection.

## SYNTAX

### CreateExpanded (Default)
```
New-AzVpnConnection -GatewayName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ConnectionBandwidth <Int32>] [-EnableBgp] [-EnableInternetSecurity]
 [-EnableRateLimiting] [-Id <String>] [-IPsecPolicy <IIpsecPolicy[]>]
 [-ProtocolType <VirtualNetworkGatewayConnectionProtocol>] [-RemoteVpnSiteId <String>]
 [-ResourceName <String>] [-RoutingWeight <Int32>] [-SharedKey <String>] [-UseLocalAzureIPAddress]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzVpnConnection -GatewayName <String> -Name <String> -ResourceGroupName <String>
 -VpnConnection <IVpnConnection> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVpnConnection -InputObject <INetworkIdentity> -VpnConnection <IVpnConnection>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVpnConnection -InputObject <INetworkIdentity> [-ConnectionBandwidth <Int32>] [-EnableBgp]
 [-EnableInternetSecurity] [-EnableRateLimiting] [-Id <String>] [-IPsecPolicy <IIpsecPolicy[]>]
 [-ProtocolType <VirtualNetworkGatewayConnectionProtocol>] [-RemoteVpnSiteId <String>]
 [-ResourceName <String>] [-RoutingWeight <Int32>] [-SharedKey <String>] [-UseLocalAzureIPAddress]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a vpn connection to a scalable vpn gateway if it doesn't exist else updates the existing connection.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionBandwidth
Expected bandwidth in MBPS.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: ConnectionBandwidthInMbps

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableBgp
EnableBgp flag

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableInternetSecurity
Enable internet security

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableRateLimiting
EnableBgp flag

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GatewayName
The name of the gateway.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: ParentResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IPsecPolicy
The IPSec Policies to be considered by this connection.
To construct, see NOTES section for IPSECPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the connection.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: ConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProtocolType
Connection protocol used for this connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: VpnConnectionProtocolType

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RemoteVpnSiteId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: VpnSiteId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The resource group name of the VpnGateway.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoutingWeight
Routing weight for vpn connection.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SharedKey
SharedKey for the vpn connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UseLocalAzureIPAddress
Use local azure ip to initiate connection

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnConnection
VpnConnection Resource.
To construct, see NOTES section for VPNCONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <INetworkIdentity>: Identity Parameter
  - `[ApplicationGatewayName <String>]`: The name of the application gateway.
  - `[ApplicationSecurityGroupName <String>]`: The name of the application security group.
  - `[AuthorizationName <String>]`: The name of the authorization.
  - `[AzureFirewallName <String>]`: The name of the Azure Firewall.
  - `[BackendAddressPoolName <String>]`: The name of the backend address pool.
  - `[CircuitName <String>]`: The name of the express route circuit.
  - `[ConnectionMonitorName <String>]`: The name of the connection monitor.
  - `[ConnectionName <String>]`: The name of the vpn connection.
  - `[CrossConnectionName <String>]`: The name of the ExpressRouteCrossConnection (service key of the circuit).
  - `[DdosCustomPolicyName <String>]`: The name of the DDoS custom policy.
  - `[DdosProtectionPlanName <String>]`: The name of the DDoS protection plan.
  - `[DefaultSecurityRuleName <String>]`: The name of the default security rule.
  - `[DevicePath <String>]`: The path of the device.
  - `[ExpressRouteGatewayName <String>]`: The name of the ExpressRoute gateway.
  - `[ExpressRoutePortName <String>]`: The name of the ExpressRoutePort resource.
  - `[FrontendIPConfigurationName <String>]`: The name of the frontend IP configuration.
  - `[GatewayName <String>]`: The name of the gateway.
  - `[IPConfigurationName <String>]`: The name of the ip configuration name.
  - `[Id <String>]`: Resource identity path
  - `[InboundNatRuleName <String>]`: The name of the inbound nat rule.
  - `[InterfaceEndpointName <String>]`: The name of the interface endpoint.
  - `[LinkName <String>]`: The name of the ExpressRouteLink resource.
  - `[LoadBalancerName <String>]`: The name of the load balancer.
  - `[LoadBalancingRuleName <String>]`: The name of the load balancing rule.
  - `[LocalNetworkGatewayName <String>]`: The name of the local network gateway.
  - `[Location <String>]`: The location of the subnet.
  - `[LocationName <String>]`: Name of the requested ExpressRoutePort peering location.
  - `[NatGatewayName <String>]`: The name of the nat gateway.
  - `[NetworkInterfaceName <String>]`: The name of the network interface.
  - `[NetworkProfileName <String>]`: The name of the NetworkProfile.
  - `[NetworkWatcherName <String>]`: The name of the network watcher.
  - `[NsgName <String>]`: The name of the network security group.
  - `[OutboundRuleName <String>]`: The name of the outbound rule.
  - `[P2SVpnServerConfigurationName <String>]`: The name of the P2SVpnServerConfiguration.
  - `[PacketCaptureName <String>]`: The name of the packet capture session.
  - `[PeeringName <String>]`: The name of the peering.
  - `[PolicyName <String>]`: The name of the policy
  - `[PredefinedPolicyName <String>]`: Name of Ssl predefined policy.
  - `[ProbeName <String>]`: The name of the probe.
  - `[PublicIPAddressName <String>]`: The name of the subnet.
  - `[PublicIPPrefixName <String>]`: The name of the PublicIpPrefix.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RouteFilterName <String>]`: The name of the route filter.
  - `[RouteName <String>]`: The name of the route.
  - `[RouteTableName <String>]`: The name of the route table.
  - `[RuleName <String>]`: The name of the rule.
  - `[SecurityRuleName <String>]`: The name of the security rule.
  - `[ServiceEndpointPolicyDefinitionName <String>]`: The name of the service endpoint policy definition.
  - `[ServiceEndpointPolicyName <String>]`: The name of the service endpoint policy.
  - `[SubnetName <String>]`: The name of the subnet.
  - `[SubscriptionId <String>]`: The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[TapConfigurationName <String>]`: The name of the tap configuration.
  - `[TapName <String>]`: The name of the virtual network tap.
  - `[VirtualHubName <String>]`: The name of the VirtualHub.
  - `[VirtualMachineScaleSetName <String>]`: The name of the virtual machine scale set.
  - `[VirtualWanName <String>]`: The name of the VirtualWAN being retrieved.
  - `[VirtualWanName1 <String>]`: The name of the VirtualWAN for which configuration of all vpn-sites is needed.
  - `[VirtualWanName2 <String>]`: The name of the VirtualWan.
  - `[VirtualmachineIndex <String>]`: The virtual machine index.
  - `[VnetGatewayConnectionName <String>]`: The name of the virtual network gateway connection for which the configuration script is generated.
  - `[VnetGatewayName <String>]`: The name of the virtual network gateway.
  - `[VnetName <String>]`: The name of the virtual network.
  - `[VnetPeeringName <String>]`: The name of the virtual network peering.
  - `[VpnSiteName <String>]`: The name of the VpnSite being retrieved.

#### IPSECPOLICY <IIpsecPolicy[]>: The IPSec Policies to be considered by this connection.
  - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
  - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
  - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
  - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
  - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
  - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
  - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
  - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.

#### VPNCONNECTION <IVpnConnection>: VpnConnection Resource.
  - `[Id <String>]`: Resource ID.

## RELATED LINKS

