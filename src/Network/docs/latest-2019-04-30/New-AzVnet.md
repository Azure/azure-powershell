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

### CreateExpanded (Default)
```
New-AzVnet -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-AddressPrefix <String[]>]
 [-DdosProtectionPlanId <String>] [-DnsServer <String[]>] [-EnableDdosProtection] [-EnableVMProtection]
 [-Etag <String>] [-Id <String>] [-Location <String>] [-ProvisioningState <String>] [-ResourceGuid <String>]
 [-Subnet <ISubnet_Reference[]>] [-Tag <Hashtable>] [-VnetPeering <IVirtualNetworkPeering_Reference[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzVnet -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Vnet <IVirtualNetwork>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzVnet -InputObject <INetworkIdentity> [-AddressPrefix <String[]>] [-DdosProtectionPlanId <String>]
 [-DnsServer <String[]>] [-EnableDdosProtection] [-EnableVMProtection] [-Etag <String>] [-Id <String>]
 [-Location <String>] [-ProvisioningState <String>] [-ResourceGuid <String>] [-Subnet <ISubnet_Reference[]>]
 [-Tag <Hashtable>] [-VnetPeering <IVirtualNetworkPeering_Reference[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzVnet -InputObject <INetworkIdentity> -Vnet <IVirtualNetwork> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: CreateExpanded, Create
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
Parameter Sets: CreateExpanded, Create
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet_Reference[]
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
Parameter Sets: CreateExpanded, Create
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

### -Vnet
Virtual Network resource.
To construct, see NOTES section for VNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetwork
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -VnetPeering
A list of peerings in a Virtual Network.
To construct, see NOTES section for VNETPEERING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering_Reference[]
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

#### SUBNET <ISubnet_Reference[]>: A list of subnets in a Virtual Network.
  - `[AddressPrefix <String[]>]`: List of  address prefixes for the subnet.
  - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
    - `[Id <String>]`: Resource ID.
    - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
    - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[NatGatewayId <String>]`: Resource ID.
  - `[Nsg <INetworkSecurityGroup>]`: The reference of the NetworkSecurityGroup resource.
  - `[PropertiesAddressPrefix <String>]`: The address prefix for the subnet.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
  - `[RouteTable <IRouteTable>]`: The reference of the RouteTable resource.
  - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
  - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
  - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.

#### VNET <IVirtualNetwork>: Virtual Network resource.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[DdosProtectionPlanId <String>]`: Resource ID.
  - `[DnsServer <String[]>]`: The list of DNS servers IP addresses.
  - `[EnableDdosProtection <Boolean?>]`: Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource.
  - `[EnableVMProtection <Boolean?>]`: Indicates if VM protection is enabled for all the subnets in the virtual network.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[Peering <IVirtualNetworkPeering[]>]`: A list of peerings in a Virtual Network.
    - `[Id <String>]`: Resource ID.
    - `[AllowForwardedTraffic <Boolean?>]`: Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
    - `[AllowGatewayTransit <Boolean?>]`: If gateway links can be used in remote virtual networking to link to this virtual network.
    - `[AllowVnetAccess <Boolean?>]`: Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PeeringState <VirtualNetworkPeeringState?>]`: The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[RemoteAddressSpaceAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
    - `[RemoteVnetId <String>]`: Resource ID.
    - `[UseRemoteGateway <Boolean?>]`: If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.
  - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[ResourceGuid <String>]`: The resourceGuid property of the Virtual Network resource.
  - `[Subnet <ISubnet[]>]`: A list of subnets in a Virtual Network.
    - `[Id <String>]`: Resource ID.
    - `[AddressPrefix <String[]>]`: List of  address prefixes for the subnet.
    - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
      - `[Id <String>]`: Resource ID.
      - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
      - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[NatGatewayId <String>]`: Resource ID.
    - `[Nsg <INetworkSecurityGroup>]`: The reference of the NetworkSecurityGroup resource.
    - `[PropertiesAddressPrefix <String>]`: The address prefix for the subnet.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
      - `[Id <String>]`: Resource ID.
      - `[Link <String>]`: Link to the external resource
      - `[LinkedResourceType <String>]`: Resource type of the linked resource.
      - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[RouteTable <IRouteTable>]`: The reference of the RouteTable resource.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
      - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
      - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
      - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
        - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
        - `[Id <String>]`: Resource ID.
        - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
        - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
      - `[Id <String>]`: Resource ID.
      - `[Link <String>]`: Link to the external resource.
      - `[LinkedResourceType <String>]`: Resource type of the linked resource.
      - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
      - `[Location <String[]>]`: A list of locations.
      - `[ProvisioningState <String>]`: The provisioning state of the resource.
      - `[Service <String>]`: The type of the endpoint service.
    - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
      - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
        - `[Id <String>]`: Resource ID.
        - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Service <String>]`: Service endpoint name.
        - `[ServiceResource <String[]>]`: A list of service resources.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.

#### VNETPEERING <IVirtualNetworkPeering_Reference[]>: A list of peerings in a Virtual Network.
  - `[AllowForwardedTraffic <Boolean?>]`: Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
  - `[AllowGatewayTransit <Boolean?>]`: If gateway links can be used in remote virtual networking to link to this virtual network.
  - `[AllowVnetAccess <Boolean?>]`: Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PeeringState <VirtualNetworkPeeringState?>]`: The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[RemoteAddressSpaceAddressPrefix <String[]>]`: A list of address blocks reserved for this virtual network in CIDR notation.
  - `[RemoteVnetId <String>]`: Resource ID.
  - `[UseRemoteGateway <Boolean?>]`: If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.

## RELATED LINKS

