---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvnet
schema: 2.0.0
---

# New-AzVnet

## SYNOPSIS
Creates or updates a virtual network in the specified resource group.

## SYNTAX

### Create (Default)
```
New-AzVnet -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Parameter <IVirtualNetwork>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzVnet -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-AddressPrefix <String[]>]
 [-DdosProtectionPlanId <String>] [-DnsServer <String[]>] [-EnableDdosProtection] [-EnableVMProtection]
 [-Etag <String>] [-Id <String>] [-Location <String>] [-ProvisioningState <String>] [-ResourceGuid <String>]
 [-Subnet <ISubnet[]>] [-Tag <Hashtable>] [-VnetPeering <IVirtualNetworkPeering[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVnet -InputObject <INetworkIdentity> [-AddressPrefix <String[]>] [-DdosProtectionPlanId <String>]
 [-DnsServer <String[]>] [-EnableDdosProtection] [-EnableVMProtection] [-Etag <String>] [-Id <String>]
 [-Location <String>] [-ProvisioningState <String>] [-ResourceGuid <String>] [-Subnet <ISubnet[]>]
 [-Tag <Hashtable>] [-VnetPeering <IVirtualNetworkPeering[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVnet -InputObject <INetworkIdentity> [-Parameter <IVirtualNetwork>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a virtual network in the specified resource group.

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

### -AddressPrefix
A list of address blocks reserved for this virtual network in CIDR notation.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DdosProtectionPlanId
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

### -DnsServer
The list of DNS servers IP addresses.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableDdosProtection
Indicates if DDoS protection is enabled for all the protected resources in the virtual network.
It requires a DDoS protection plan associated with the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableVMProtection
Indicates if VM protection is enabled for all the subnets in the virtual network.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

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

### -Name
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: VirtualNetworkName

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Virtual Network resource.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetwork
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
The provisioning state of the PublicIP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

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
The name of the resource group.

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

### -ResourceGuid
The resourceGuid property of the Virtual Network resource.

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

### -Subnet
A list of subnets in a Virtual Network.
To construct, see NOTES section for SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[]
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetPeering
A list of peerings in a Virtual Network.
To construct, see NOTES section for VNETPEERING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: VirtualNetworkPeering

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetwork

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetwork

## ALIASES

### New-AzVirtualNetwork

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IVirtualNetwork>: Virtual Network resource.
  - `[AddressSpaceAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[DdosProtectionPlanId <String>]`: Resource ID.
  - `[DhcpOptionDnsServer <String[]>]`: The list of DNS servers IP addresses.
  - `[EnableDdosProtection <Boolean?>]`: Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource.
  - `[EnableVMProtection <Boolean?>]`: Indicates if VM protection is enabled for all the subnets in the virtual network.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[Peering <IVirtualNetworkPeering[]>]`: A list of peerings in a Virtual Network.
    - `[AllowForwardedTraffic <Boolean?>]`: Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
    - `[AllowGatewayTransit <Boolean?>]`: If gateway links can be used in remote virtual networking to link to this virtual network.
    - `[AllowVirtualNetworkAccess <Boolean?>]`: Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PeeringState <VirtualNetworkPeeringState?>]`: The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[RemoteAddressSpaceAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
    - `[RemoteVirtualNetworkId <String>]`: Resource ID.
    - `[UseRemoteGateway <Boolean?>]`: If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.
  - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[ResourceGuid <String>]`: The resourceGuid property of the Virtual Network resource.
  - `[Subnet <ISubnet[]>]`: A list of subnets in a Virtual Network.
    - `[AddressPrefix <String>]`: The address prefix for the subnet.
    - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
      - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
      - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
      - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
      - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
      - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
      - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
      - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
      - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
      - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
      - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
      - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
      - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
      - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
      - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
    - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
      - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
      - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
    - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[NatGatewayId <String>]`: Resource ID.
    - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[NetworkSecurityGroupId <String>]`: Resource ID.
    - `[NetworkSecurityGroupLocation <String>]`: Resource location.
    - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
    - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
    - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
      - `[Link <String>]`: Link to the external resource
      - `[LinkedResourceType <String>]`: Resource type of the linked resource.
      - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
      - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
      - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
      - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RouteTableEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
    - `[RouteTableId <String>]`: Resource ID.
    - `[RouteTableLocation <String>]`: Resource location.
    - `[RouteTablePropertiesProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RouteTableTag <IResourceTags>]`: Resource tags.
    - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
    - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
      - `[Link <String>]`: Link to the external resource.
      - `[LinkedResourceType <String>]`: Resource type of the linked resource.
      - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
      - `[Location <String[]>]`: A list of locations.
      - `[ProvisioningState <String>]`: The provisioning state of the resource.
      - `[Service <String>]`: The type of the endpoint service.
    - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
      - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
        - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Service <String>]`: Service endpoint name.
        - `[ServiceResource <String[]>]`: A list of service resources.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.

#### SUBNET <ISubnet[]>: A list of subnets in a Virtual Network.
  - `[AddressPrefix <String>]`: The address prefix for the subnet.
  - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
    - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
    - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
    - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
    - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
    - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
    - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
    - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
    - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
    - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
    - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
    - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
    - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
    - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
    - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
  - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
    - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
    - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
  - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[NatGatewayId <String>]`: Resource ID.
  - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[NetworkSecurityGroupId <String>]`: Resource ID.
  - `[NetworkSecurityGroupLocation <String>]`: Resource location.
  - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
  - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
  - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
    - `[Link <String>]`: Link to the external resource
    - `[LinkedResourceType <String>]`: Resource type of the linked resource.
    - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
    - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
    - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
    - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RouteTableEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[RouteTableId <String>]`: Resource ID.
  - `[RouteTableLocation <String>]`: Resource location.
  - `[RouteTablePropertiesProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RouteTableTag <IResourceTags>]`: Resource tags.
  - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
  - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
    - `[Link <String>]`: Link to the external resource.
    - `[LinkedResourceType <String>]`: Resource type of the linked resource.
    - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
    - `[Location <String[]>]`: A list of locations.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[Service <String>]`: The type of the endpoint service.
  - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
    - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
      - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Service <String>]`: Service endpoint name.
      - `[ServiceResource <String[]>]`: A list of service resources.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.

#### VNETPEERING <IVirtualNetworkPeering[]>: A list of peerings in a Virtual Network.
  - `[AllowForwardedTraffic <Boolean?>]`: Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
  - `[AllowGatewayTransit <Boolean?>]`: If gateway links can be used in remote virtual networking to link to this virtual network.
  - `[AllowVirtualNetworkAccess <Boolean?>]`: Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PeeringState <VirtualNetworkPeeringState?>]`: The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[RemoteAddressSpaceAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[RemoteVirtualNetworkId <String>]`: Resource ID.
  - `[UseRemoteGateway <Boolean?>]`: If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.

## RELATED LINKS

