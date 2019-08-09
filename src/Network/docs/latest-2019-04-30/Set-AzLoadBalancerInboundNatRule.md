---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azloadbalancerinboundnatrule
schema: 2.0.0
---

# Set-AzLoadBalancerInboundNatRule

## SYNOPSIS
Creates or updates a load balancer inbound nat rule.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzLoadBalancerInboundNatRule -LoadBalancerName <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-ApplicationSecurityGroup <IApplicationSecurityGroup_Reference[]>] [-BackendIPConfigurationEtag <String>]
 [-BackendIPConfigurationId <String>] [-BackendIPConfigurationName <String>]
 [-BackendIPConfigurationProvisioningState <String>] [-BackendPort <Int32>] [-EnableFloatingIP]
 [-EnableTcpReset] [-Etag <String>] [-FrontendIPConfigurationId <String>] [-FrontendPort <Int32>]
 [-Id <String>] [-IdleTimeoutInMinutes <Int32>] [-LoadBalancerBackendAddressPool <IBackendAddressPool[]>]
 [-LoadBalancerInboundNatRule <IInboundNatRule_Reference[]>] [-Primary] [-PrivateIPAddress <String>]
 [-PrivateIPAddressVersion <IPVersion>] [-PrivateIPAllocationMethod <IPAllocationMethod>]
 [-Protocol <TransportProtocol>] [-ProvisioningState <String>] [-PublicIPAddress <IPublicIPAddress_Reference>]
 [-ResourceName <String>] [-Subnet <ISubnet_Reference>] [-VnetTap <IVirtualNetworkTap_Reference[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzLoadBalancerInboundNatRule -LoadBalancerName <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> -InboundNatRule <IInboundNatRule> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a load balancer inbound nat rule.

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

### -ApplicationGatewayBackendAddressPool
The reference of ApplicationGatewayBackendAddressPool resource.
To construct, see NOTES section for APPLICATIONGATEWAYBACKENDADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApplicationSecurityGroup
Application security groups in which the IP configuration is included.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup_Reference[]
Parameter Sets: UpdateExpanded
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

### -BackendIPConfigurationEtag
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

### -BackendIPConfigurationId
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

### -BackendIPConfigurationName
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

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

### -BackendIPConfigurationProvisioningState
The provisioning state of the network interface IP configuration.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

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

### -BackendPort
The port used for the internal endpoint.
Acceptable values range from 1 to 65535.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -EnableFloatingIP
Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group.
This setting is required when using the SQL AlwaysOn Availability Groups in SQL server.
This setting can't be changed after you create the endpoint.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableTcpReset
Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
This element is only used when the protocol is set to TCP.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
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

### -FrontendIPConfigurationId
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

### -FrontendPort
The port for the external endpoint.
Port numbers for each rule must be unique within the Load Balancer.
Acceptable values range from 1 to 65534.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -IdleTimeoutInMinutes
The timeout for the TCP idle connection.
The value can be set between 4 and 30 minutes.
The default value is 4 minutes.
This element is only used when the protocol is set to TCP.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InboundNatRule
Inbound NAT rule of the load balancer.
To construct, see NOTES section for INBOUNDNATRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerBackendAddressPool
The reference of LoadBalancerBackendAddressPool resource.
To construct, see NOTES section for LOADBALANCERBACKENDADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerInboundNatRule
A list of references of LoadBalancerInboundNatRules.
To construct, see NOTES section for LOADBALANCERINBOUNDNATRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule_Reference[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerName
The name of the load balancer.

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

### -Name
The name of the inbound nat rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: InboundNatRuleName

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

### -Primary
Gets whether this is a primary customer address on the network interface.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrivateIPAddress
Private IP address of the IP configuration.

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

### -PrivateIPAddressVersion
Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6.
Default is taken as IPv4.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrivateIPAllocationMethod
The private IP address allocation method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
The reference to the transport protocol used by the load balancing rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Gets the provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

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

### -PublicIPAddress
Public IP address bound to the IP configuration.
To construct, see NOTES section for PUBLICIPADDRESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress_Reference
Parameter Sets: UpdateExpanded
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
Gets name of the resource that is unique within a resource group.
This name can be used to access the resource.

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

### -Subnet
Subnet bound to the IP configuration.
To construct, see NOTES section for SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet_Reference
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetTap
The reference to Virtual Network Taps.
To construct, see NOTES section for VNETTAP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap_Reference[]
Parameter Sets: UpdateExpanded
Aliases: VirtualNetworkTap

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### APPLICATIONGATEWAYBACKENDADDRESSPOOL <IApplicationGatewayBackendAddressPool[]>: The reference of ApplicationGatewayBackendAddressPool resource.
  - `[Id <String>]`: Resource ID.
  - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
    - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
    - `[IPAddress <String>]`: IP address
  - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
    - `[Id <String>]`: Resource ID.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[OutboundRuleId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[BackendIPConfigurationId <String>]`: Resource ID.
      - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
      - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
      - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[FrontendIPConfigurationId <String>]`: Resource ID.
      - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
      - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
      - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
        - `[AllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
        - `[DdosCustomPolicyId <String>]`: Resource ID.
        - `[DdosProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPAddressVersion <IPVersion?>]`: The public IP address version.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationFormat <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
          - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
          - `[Subnet <ISubnet>]`: The reference of the subnet resource.
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
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
          - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
          - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
        - `[IdleTimeoutInMinutes <Int32?>]`: The idle timeout of the public IP address.
        - `[PrefixId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
    - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### INBOUNDNATRULE <IInboundNatRule>: Inbound NAT rule of the load balancer.
  - `[Id <String>]`: Resource ID.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[Id <String>]`: Resource ID.
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
          - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[Id <String>]`: Resource ID.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[OutboundRuleId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
        - `[AllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
        - `[DdosCustomPolicyId <String>]`: Resource ID.
        - `[DdosProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPAddressVersion <IPVersion?>]`: The public IP address version.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationFormat <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
          - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
          - `[Subnet <ISubnet>]`: The reference of the subnet resource.
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
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
          - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
          - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
        - `[IdleTimeoutInMinutes <Int32?>]`: The idle timeout of the public IP address.
        - `[PrefixId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[BackendIPConfigurationId <String>]`: Resource ID.
  - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
  - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
  - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.

#### LOADBALANCERBACKENDADDRESSPOOL <IBackendAddressPool[]>: The reference of LoadBalancerBackendAddressPool resource.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[OutboundRuleId <String>]`: Resource ID.
  - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### LOADBALANCERINBOUNDNATRULE <IInboundNatRule_Reference[]>: A list of references of LoadBalancerInboundNatRules.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[Id <String>]`: Resource ID.
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
          - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[Id <String>]`: Resource ID.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[OutboundRuleId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
        - `[Id <String>]`: Resource ID.
        - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
        - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[BackendIPConfigurationId <String>]`: Resource ID.
        - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
        - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[FrontendIPConfigurationId <String>]`: Resource ID.
        - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
        - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
        - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
        - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
        - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
        - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
        - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
          - `[Id <String>]`: Resource ID.
          - `[Location <String>]`: Resource location.
          - `[Tag <IResourceTags>]`: Resource tags.
          - `[AllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
          - `[DdosCustomPolicyId <String>]`: Resource ID.
          - `[DdosProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
          - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
          - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
          - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
          - `[IPAddressVersion <IPVersion?>]`: The public IP address version.
          - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPConfigurationFormat <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
            - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
            - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
            - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
            - `[Subnet <ISubnet>]`: The reference of the subnet resource.
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
          - `[IPConfigurationId <String>]`: Resource ID.
          - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
            - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
            - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
          - `[IdleTimeoutInMinutes <Int32?>]`: The idle timeout of the public IP address.
          - `[PrefixId <String>]`: Resource ID.
          - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
          - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
          - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
        - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
        - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[BackendIPConfigurationId <String>]`: Resource ID.
  - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
  - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
  - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.

#### PUBLICIPADDRESS <IPublicIPAddress_Reference>: Public IP address bound to the IP configuration.
  - `[AllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
  - `[DdosCustomPolicyId <String>]`: Resource ID.
  - `[DdosProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
  - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
  - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
  - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
  - `[IPAddressVersion <IPVersion?>]`: The public IP address version.
  - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPConfigurationFormat <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
    - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[AllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
      - `[DdosCustomPolicyId <String>]`: Resource ID.
      - `[DdosProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
      - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
      - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
      - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
      - `[IPAddressVersion <IPVersion?>]`: The public IP address version.
      - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[IPConfigurationFormat <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
      - `[IPConfigurationId <String>]`: Resource ID.
      - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
        - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
        - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
      - `[IdleTimeoutInMinutes <Int32?>]`: The idle timeout of the public IP address.
      - `[PrefixId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
      - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
      - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
    - `[Subnet <ISubnet>]`: The reference of the subnet resource.
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
  - `[IPConfigurationId <String>]`: Resource ID.
  - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
  - `[IdleTimeoutInMinutes <Int32?>]`: The idle timeout of the public IP address.
  - `[PrefixId <String>]`: Resource ID.
  - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
  - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
  - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.

#### SUBNET <ISubnet_Reference>: Subnet bound to the IP configuration.
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

#### VNETTAP <IVirtualNetworkTap_Reference[]>: The reference to Virtual Network Taps.
  - `[AdditionalVnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[AdditionalVnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[Id <String>]`: Resource ID.
      - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
        - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
        - `[IPAddress <String>]`: IP address
      - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
        - `[Id <String>]`: Resource ID.
        - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
        - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
          - `[Id <String>]`: Resource ID.
          - `[Location <String>]`: Resource location.
          - `[Tag <IResourceTags>]`: Resource tags.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
          - `[Id <String>]`: Resource ID.
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[OutboundRuleId <String>]`: Resource ID.
          - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
          - `[Id <String>]`: Resource ID.
          - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
          - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
          - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[BackendIPConfigurationId <String>]`: Resource ID.
          - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
          - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
          - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[FrontendIPConfigurationId <String>]`: Resource ID.
          - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
          - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
          - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
          - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
          - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
          - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
          - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
            - `[Id <String>]`: Resource ID.
            - `[Location <String>]`: Resource location.
            - `[Tag <IResourceTags>]`: Resource tags.
            - `[AllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
            - `[DdosCustomPolicyId <String>]`: Resource ID.
            - `[DdosProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
            - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
            - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
            - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
            - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
            - `[IPAddressVersion <IPVersion?>]`: The public IP address version.
            - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[IPConfigurationFormat <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
              - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
              - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
              - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
              - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
              - `[Subnet <ISubnet>]`: The reference of the subnet resource.
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
            - `[IPConfigurationId <String>]`: Resource ID.
            - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
              - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
              - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
            - `[IdleTimeoutInMinutes <Int32?>]`: The idle timeout of the public IP address.
            - `[PrefixId <String>]`: Resource ID.
            - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
            - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
            - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
          - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
          - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
        - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
        - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
        - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
        - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
      - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[Type <String>]`: Type of the resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
    - `[DestinationLoadBalancerEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[DestinationLoadBalancerId <String>]`: Resource ID.
    - `[DestinationLoadBalancerName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[DestinationLoadBalancerPrivateIPAddress <String>]`: The private IP address of the IP configuration.
    - `[DestinationLoadBalancerPrivateIPAllocationMethod <IPAllocationMethod?>]`: The Private IP allocation method.
    - `[DestinationLoadBalancerProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[DestinationLoadBalancerPublicIPAddress <IPublicIPAddress>]`: The reference of the Public IP resource.
    - `[DestinationLoadBalancerSubnet <ISubnet>]`: The reference of the subnet resource.
    - `[DestinationLoadBalancerZone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
    - `[DestinationNetworkInterfaceEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[DestinationNetworkInterfaceId <String>]`: Resource ID.
    - `[DestinationNetworkInterfaceName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[DestinationNetworkInterfacePrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[DestinationNetworkInterfacePrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[DestinationNetworkInterfaceProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[DestinationNetworkInterfacePublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
    - `[DestinationNetworkInterfaceSubnet <ISubnet>]`: Subnet bound to the IP configuration.
    - `[DestinationPort <Int32?>]`: The VXLAN destination port that will receive the tapped traffic.
    - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
    - `[PublicIPPrefixId <String>]`: Resource ID.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[DestinationLoadBalancerEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[DestinationLoadBalancerId <String>]`: Resource ID.
  - `[DestinationLoadBalancerName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[DestinationLoadBalancerPrivateIPAddress <String>]`: The private IP address of the IP configuration.
  - `[DestinationLoadBalancerPrivateIPAllocationMethod <IPAllocationMethod?>]`: The Private IP allocation method.
  - `[DestinationLoadBalancerProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[DestinationLoadBalancerPublicIPAddress <IPublicIPAddress>]`: The reference of the Public IP resource.
  - `[DestinationLoadBalancerSubnet <ISubnet>]`: The reference of the subnet resource.
  - `[DestinationLoadBalancerZone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
  - `[DestinationNetworkInterfaceEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[DestinationNetworkInterfaceId <String>]`: Resource ID.
  - `[DestinationNetworkInterfaceName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[DestinationNetworkInterfacePrivateIPAddress <String>]`: Private IP address of the IP configuration.
  - `[DestinationNetworkInterfacePrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[DestinationNetworkInterfaceProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[DestinationNetworkInterfacePublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[DestinationNetworkInterfaceSubnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[DestinationPort <Int32?>]`: The VXLAN destination port that will receive the tapped traffic.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
  - `[PublicIPPrefixId <String>]`: Resource ID.

## RELATED LINKS

