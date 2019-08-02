---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworkprofile
schema: 2.0.0
---

# Set-AzNetworkProfile

## SYNOPSIS
Creates or updates a network profile.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzNetworkProfile -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-ContainerNetworkInterface <IContainerNetworkInterface[]>]
 [-ContainerNetworkInterfaceConfiguration <IContainerNetworkInterfaceConfiguration[]>] [-Etag <String>]
 [-Id <String>] [-Location <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzNetworkProfile -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -NetworkProfile <INetworkProfile> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a network profile.

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

### -ContainerNetworkInterface
List of child container network interfaces.
To construct, see NOTES section for CONTAINERNETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterface[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContainerNetworkInterfaceConfiguration
List of chid container network interface configurations.
To construct, see NOTES section for CONTAINERNETWORKINTERFACECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the network profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkProfile
Network profile resource.
To construct, see NOTES section for NETWORKPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AsJob

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CONTAINERNETWORKINTERFACE <IContainerNetworkInterface[]>: List of child container network interfaces.
  - `[Id <String>]`: Resource ID.
  - `[ConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[ConfigurationId <String>]`: Resource ID.
  - `[ConfigurationName <String>]`: The name of the resource. This name can be used to access the resource.
  - `[ConfigurationPropertiesIPConfiguration <IIPConfigurationProfile[]>]`: A list of ip configurations of the container network interface configuration.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
    - `[Subnet <ISubnet>]`: The reference of the subnet resource to create a container network interface ip configuration.
      - `[Id <String>]`: Resource ID.
      - `[AddressPrefix <String>]`: The address prefix for the subnet.
      - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
        - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
        - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
        - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
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
      - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
        - `[Id <String>]`: Resource ID.
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
        - `[Id <String>]`: Resource ID.
        - `[Link <String>]`: Link to the external resource
        - `[LinkedResourceType <String>]`: Resource type of the linked resource.
        - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
        - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
        - `[Id <String>]`: Resource ID.
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
  - `[ContainerId <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPConfiguration <IContainerNetworkInterfaceIPConfiguration[]>]`: Reference to the ip configuration on this container nic.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
  - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
  - `[PropertiesContainerNetworkInterfaceConfigurationPropertiesContainerNetworkInterfaces <ISubResource[]>]`: A list of container network interfaces created from this container network interface configuration.

#### CONTAINERNETWORKINTERFACECONFIGURATION <IContainerNetworkInterfaceConfiguration[]>: List of chid container network interface configurations.
  - `[Id <String>]`: Resource ID.
  - `[ContainerNetworkInterface <ISubResource[]>]`: A list of container network interfaces created from this container network interface configuration.
    - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPConfiguration <IIPConfigurationProfile[]>]`: A list of ip configurations of the container network interface configuration.
    - `[Id <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
    - `[Subnet <ISubnet>]`: The reference of the subnet resource to create a container network interface ip configuration.
      - `[Id <String>]`: Resource ID.
      - `[AddressPrefix <String>]`: The address prefix for the subnet.
      - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
        - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
        - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
        - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
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
      - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
        - `[Id <String>]`: Resource ID.
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
        - `[Id <String>]`: Resource ID.
        - `[Link <String>]`: Link to the external resource
        - `[LinkedResourceType <String>]`: Resource type of the linked resource.
        - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
        - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
        - `[Id <String>]`: Resource ID.
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
  - `[Name <String>]`: The name of the resource. This name can be used to access the resource.

#### NETWORKPROFILE <INetworkProfile>: Network profile resource.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ContainerNetworkInterface <IContainerNetworkInterface[]>]`: List of child container network interfaces.
    - `[Id <String>]`: Resource ID.
    - `[ConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[ConfigurationId <String>]`: Resource ID.
    - `[ConfigurationName <String>]`: The name of the resource. This name can be used to access the resource.
    - `[ConfigurationPropertiesIPConfiguration <IIPConfigurationProfile[]>]`: A list of ip configurations of the container network interface configuration.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
      - `[Subnet <ISubnet>]`: The reference of the subnet resource to create a container network interface ip configuration.
        - `[Id <String>]`: Resource ID.
        - `[AddressPrefix <String>]`: The address prefix for the subnet.
        - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
          - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
          - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
          - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
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
        - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
          - `[Id <String>]`: Resource ID.
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
          - `[Id <String>]`: Resource ID.
          - `[Link <String>]`: Link to the external resource
          - `[LinkedResourceType <String>]`: Resource type of the linked resource.
          - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
          - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
          - `[Id <String>]`: Resource ID.
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
    - `[ContainerId <String>]`: Resource ID.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[IPConfiguration <IContainerNetworkInterfaceIPConfiguration[]>]`: Reference to the ip configuration on this container nic.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
    - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
    - `[PropertiesContainerNetworkInterfaceConfigurationPropertiesContainerNetworkInterfaces <ISubResource[]>]`: A list of container network interfaces created from this container network interface configuration.
  - `[ContainerNetworkInterfaceConfiguration <IContainerNetworkInterfaceConfiguration[]>]`: List of chid container network interface configurations.
    - `[Id <String>]`: Resource ID.
    - `[ContainerNetworkInterface <ISubResource[]>]`: A list of container network interfaces created from this container network interface configuration.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[IPConfiguration <IIPConfigurationProfile[]>]`: A list of ip configurations of the container network interface configuration.
    - `[Name <String>]`: The name of the resource. This name can be used to access the resource.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.

## RELATED LINKS

