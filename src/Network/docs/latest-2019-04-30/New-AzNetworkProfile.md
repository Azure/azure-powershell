---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-aznetworkprofile
schema: 2.0.0
---

# New-AzNetworkProfile

## SYNOPSIS
Creates or updates a network profile.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkProfile -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-ContainerNetworkInterface <IContainerNetworkInterface[]>]
 [-ContainerNetworkInterfaceConfiguration <IContainerNetworkInterfaceConfiguration[]>] [-Etag <String>]
 [-Id <String>] [-Location <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzNetworkProfile -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -NetworkProfile <INetworkProfile> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkProfile -InputObject <INetworkIdentity>
 [-ContainerNetworkInterface <IContainerNetworkInterface[]>]
 [-ContainerNetworkInterfaceConfiguration <IContainerNetworkInterfaceConfiguration[]>] [-Etag <String>]
 [-Id <String>] [-Location <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzNetworkProfile -InputObject <INetworkIdentity> -NetworkProfile <INetworkProfile>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
The name of the network profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
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
Parameter Sets: Create, CreateViaIdentity
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
Parameter Sets: CreateExpanded, Create
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

