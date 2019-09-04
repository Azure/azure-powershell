---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azp2svpnserverconfiguration
schema: 2.0.0
---

# New-AzP2SVpnServerConfiguration

## SYNOPSIS
Creates a P2SVpnServerConfiguration to associate with a VirtualWan if it doesn't exist else updates the existing P2SVpnServerConfiguration.

## SYNTAX

### CreateExpanded (Default)
```
New-AzP2SVpnServerConfiguration -Name <String> -ResourceGroupName <String> -VirtualWanName <String>
 [-SubscriptionId <String>] [-Etag <String>] [-Id <String>]
 [-RadiusClientRootCertificate <IP2SVpnServerConfigRadiusClientRootCertificate[]>]
 [-RadiusServerAddress <String>]
 [-RadiusServerRootCertificate <IP2SVpnServerConfigRadiusServerRootCertificate[]>]
 [-RadiusServerSecret <String>] [-ResourceName <String>] [-ResourceName2 <String>]
 [-VpnClientIPsecPolicy <IIpsecPolicy[]>]
 [-VpnClientRevokedCertificate <IP2SVpnServerConfigVpnClientRevokedCertificate[]>]
 [-VpnClientRootCertificate <IP2SVpnServerConfigVpnClientRootCertificate[]>]
 [-VpnProtocol <VpnGatewayTunnelingProtocol[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzP2SVpnServerConfiguration -Name <String> -ResourceGroupName <String> -VirtualWanName <String>
 -P2SVpnServerConfiguration <IP2SVpnServerConfiguration> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzP2SVpnServerConfiguration -InputObject <INetworkIdentity>
 -P2SVpnServerConfiguration <IP2SVpnServerConfiguration> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzP2SVpnServerConfiguration -InputObject <INetworkIdentity> [-Etag <String>] [-Id <String>]
 [-RadiusClientRootCertificate <IP2SVpnServerConfigRadiusClientRootCertificate[]>]
 [-RadiusServerAddress <String>]
 [-RadiusServerRootCertificate <IP2SVpnServerConfigRadiusServerRootCertificate[]>]
 [-RadiusServerSecret <String>] [-ResourceName <String>] [-ResourceName2 <String>]
 [-VpnClientIPsecPolicy <IIpsecPolicy[]>]
 [-VpnClientRevokedCertificate <IP2SVpnServerConfigVpnClientRevokedCertificate[]>]
 [-VpnClientRootCertificate <IP2SVpnServerConfigVpnClientRootCertificate[]>]
 [-VpnProtocol <VpnGatewayTunnelingProtocol[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a P2SVpnServerConfiguration to associate with a VirtualWan if it doesn't exist else updates the existing P2SVpnServerConfiguration.

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

### -Etag
A unique read-only string that changes whenever the resource is updated.

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

### -Name
The name of the P2SVpnServerConfiguration.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: P2SVpnServerConfigurationName

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

### -P2SVpnServerConfiguration
P2SVpnServerConfiguration Resource.
To construct, see NOTES section for P2SVPNSERVERCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -RadiusClientRootCertificate
Radius client root certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for RADIUSCLIENTROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusClientRootCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerAddress
The radius server address property of the P2SVpnServerConfiguration resource for point to site client connection.

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

### -RadiusServerRootCertificate
Radius Server root certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for RADIUSSERVERROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigRadiusServerRootCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RadiusServerSecret
The radius secret property of the P2SVpnServerConfiguration resource for point to site client connection.

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

### -ResourceGroupName
The resource group name of the VirtualWan.

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

### -ResourceName2
The name of the P2SVpnServerConfiguration that is unique within a VirtualWan in a resource group.
This name can be used to access the resource along with Paren VirtualWan resource name.

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

### -VirtualWanName
The name of the VirtualWan.

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

### -VpnClientIPsecPolicy
VpnClientIpsecPolicies for P2SVpnServerConfiguration.
To construct, see NOTES section for VPNCLIENTIPSECPOLICY properties and create a hash table.

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

### -VpnClientRevokedCertificate
VPN client revoked certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for VPNCLIENTREVOKEDCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRevokedCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnClientRootCertificate
VPN client root certificate of P2SVpnServerConfiguration.
To construct, see NOTES section for VPNCLIENTROOTCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfigVpnClientRootCertificate[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnProtocol
VPN protocols for the P2SVpnServerConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnGatewayTunnelingProtocol[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnServerConfiguration

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

#### P2SVPNSERVERCONFIGURATION <IP2SVpnServerConfiguration>: P2SVpnServerConfiguration Resource.
  - `[Id <String>]`: Resource ID.

#### RADIUSCLIENTROOTCERTIFICATE <IP2SVpnServerConfigRadiusClientRootCertificate[]>: Radius client root certificate of P2SVpnServerConfiguration.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Thumbprint <String>]`: The Radius client root certificate thumbprint.

#### RADIUSSERVERROOTCERTIFICATE <IP2SVpnServerConfigRadiusServerRootCertificate[]>: Radius Server root certificate of P2SVpnServerConfiguration.
  - `PublicCertData <String>`: The certificate public data.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

#### VPNCLIENTIPSECPOLICY <IIpsecPolicy[]>: VpnClientIpsecPolicies for P2SVpnServerConfiguration.
  - `DhGroup <DhGroup>`: The DH Group used in IKE Phase 1 for initial SA.
  - `IkeEncryption <IkeEncryption>`: The IKE encryption algorithm (IKE phase 2).
  - `IkeIntegrity <IkeIntegrity>`: The IKE integrity algorithm (IKE phase 2).
  - `IpsecEncryption <IpsecEncryption>`: The IPSec encryption algorithm (IKE phase 1).
  - `IpsecIntegrity <IpsecIntegrity>`: The IPSec integrity algorithm (IKE phase 1).
  - `PfsGroup <PfsGroup>`: The Pfs Group used in IKE Phase 2 for new child SA.
  - `SaDataSizeKilobyte <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) payload size in KB for a site to site VPN tunnel.
  - `SaLifeTimeSecond <Int32>`: The IPSec Security Association (also called Quick Mode or Phase 2 SA) lifetime in seconds for a site to site VPN tunnel.

#### VPNCLIENTREVOKEDCERTIFICATE <IP2SVpnServerConfigVpnClientRevokedCertificate[]>: VPN client revoked certificate of P2SVpnServerConfiguration.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Thumbprint <String>]`: The revoked VPN client certificate thumbprint.

#### VPNCLIENTROOTCERTIFICATE <IP2SVpnServerConfigVpnClientRootCertificate[]>: VPN client root certificate of P2SVpnServerConfiguration.
  - `PublicCertData <String>`: The certificate public data.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

## RELATED LINKS

