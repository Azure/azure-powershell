---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvnetsubnet
schema: 2.0.0
---

# Set-AzVnetSubnet

## SYNOPSIS
Creates or updates a subnet in the specified virtual network.

## SYNTAX

### UpdateExpanded1 (Default)
```
Set-AzVnetSubnet -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -VnetName <String>
 [-AdditionalAddressPrefix <String>] [-Etag <String>] [-Id <String>] [-Nsg <INetworkSecurityGroup_Reference>]
 [-ProvisioningState <String>] [-ResourceName <String>] [-ResourceNavigationLink <IResourceNavigationLink[]>]
 [-RouteTable <IRouteTable_Reference>] [-ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzVnetSubnet -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -VnetName <String>
 -Subnet <ISubnet> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: UpdateExpanded1
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
Parameter Sets: UpdateExpanded1
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
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the subnet.

```yaml
Type: System.String
Parameter Sets: (All)
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Nsg
The reference of the NetworkSecurityGroup resource.
To construct, see NOTES section for NSG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup_Reference
Parameter Sets: UpdateExpanded1
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
Parameter Sets: UpdateExpanded1
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded1
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
Parameter Sets: UpdateExpanded1
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
To construct, see NOTES section for ROUTETABLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTable_Reference
Parameter Sets: UpdateExpanded1
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
Parameter Sets: UpdateExpanded1
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
Parameter Sets: Update1
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetName
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet

## ALIASES

### Set-AzVirtualNetworkSubnet

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### NSG <INetworkSecurityGroup_Reference>: The reference of the NetworkSecurityGroup resource.
  - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
    - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied. Possible values are: 'Allow' and 'Deny'.
    - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. Possible values are: 'Inbound' and 'Outbound'.
    - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', and '*'.
    - `[Id <String>]`: Resource ID.
    - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
    - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
    - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
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
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
  - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.

#### RESOURCENAVIGATIONLINK <IResourceNavigationLink[]>: Gets an array of references to the external resources using subnet.
  - `[Id <String>]`: Resource ID.
  - `[Link <String>]`: Link to the external resource
  - `[LinkedResourceType <String>]`: Resource type of the linked resource.
  - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.

#### ROUTETABLE <IRouteTable_Reference>: The reference of the RouteTable resource.
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

#### SERVICEENDPOINT <IServiceEndpointPropertiesFormat[]>: An array of service endpoints.
  - `[Location <String[]>]`: A list of locations.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[Service <String>]`: The type of the endpoint service.

#### SUBNET <ISubnet>: Subnet in a virtual network resource.
  - `[Id <String>]`: Resource ID.
  - `[AddressPrefix <String>]`: The address prefix for the subnet.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Nsg <INetworkSecurityGroup>]`: The reference of the NetworkSecurityGroup resource.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
    - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
      - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied. Possible values are: 'Allow' and 'Deny'.
      - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. Possible values are: 'Inbound' and 'Outbound'.
      - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', and '*'.
      - `[Id <String>]`: Resource ID.
      - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
      - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
      - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
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
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
    - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
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
  - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
    - `[Location <String[]>]`: A list of locations.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[Service <String>]`: The type of the endpoint service.

## RELATED LINKS

