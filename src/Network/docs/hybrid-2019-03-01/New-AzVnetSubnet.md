---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvnetsubnet
schema: 2.0.0
---

# New-AzVnetSubnet

## SYNOPSIS
Creates or updates a subnet in the specified virtual network.

## SYNTAX

### CreateExpanded1 (Default)
```
New-AzVnetSubnet -Name <String> -ResourceGroupName <String> -VnetName <String> [-SubscriptionId <String>]
 [-AdditionalAddressPrefix <String>] [-Etag <String>] [-Id <String>] [-Nsg <INetworkSecurityGroup_Reference>]
 [-ProvisioningState <String>] [-ResourceName <String>] [-ResourceNavigationLink <IResourceNavigationLink[]>]
 [-RouteTable <IRouteTable_Reference>] [-ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create1
```
New-AzVnetSubnet -Name <String> -ResourceGroupName <String> -VnetName <String> -Subnet <ISubnet>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzVnetSubnet -InputObject <INetworkIdentity> -Subnet <ISubnet> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzVnetSubnet -InputObject <INetworkIdentity> [-AdditionalAddressPrefix <String>] [-Etag <String>]
 [-Id <String>] [-Nsg <INetworkSecurityGroup_Reference>] [-ProvisioningState <String>]
 [-ResourceName <String>] [-ResourceNavigationLink <IResourceNavigationLink[]>]
 [-RouteTable <IRouteTable_Reference>] [-ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a subnet in the specified virtual network.

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

### -AdditionalAddressPrefix
The address prefix for the subnet.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateViaIdentity1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the subnet.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: SubnetName

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

### -Nsg
The reference of the NetworkSecurityGroup resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup_Reference
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroup

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
The provisioning state of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceNavigationLink
Gets an array of references to the external resources using subnet.
To construct, see NOTES section for RESOURCENAVIGATIONLINK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RouteTable
The reference of the RouteTable resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTable_Reference
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServiceEndpoint
An array of service endpoints.
To construct, see NOTES section for SERVICEENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Subnet
Subnet in a virtual network resource.
To construct, see NOTES section for SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet
Parameter Sets: Create1, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetName
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: VirtualNetworkName

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet

## ALIASES

### New-AzVirtualNetworkSubnet

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

#### RESOURCENAVIGATIONLINK <IResourceNavigationLink[]>: Gets an array of references to the external resources using subnet.
  - `[Id <String>]`: Resource ID.
  - `[Link <String>]`: Link to the external resource
  - `[LinkedResourceType <String>]`: Resource type of the linked resource.
  - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.

#### SERVICEENDPOINT <IServiceEndpointPropertiesFormat[]>: An array of service endpoints.
  - `[Location <String[]>]`: A list of locations.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[Service <String>]`: The type of the endpoint service.

#### SUBNET <ISubnet>: Subnet in a virtual network resource.
  - `[Id <String>]`: Resource ID.

## RELATED LINKS

