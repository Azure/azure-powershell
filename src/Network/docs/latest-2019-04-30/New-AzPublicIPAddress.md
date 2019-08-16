---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azpublicipaddress
schema: 2.0.0
---

# New-AzPublicIPAddress

## SYNOPSIS
Creates or updates a static or dynamic public IP address.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPublicIPAddress -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AllocationMethod <IPAllocationMethod>] [-DdosCustomPolicyId <String>]
 [-DdosProtectionCoverage <DdosSettingsProtectionCoverage>] [-DomainNameLabel <String>] [-Etag <String>]
 [-Fqdn <String>] [-IPAddress <String>] [-IPAddressVersion <IPVersion>] [-IPConfigurationEtag <String>]
 [-IPConfigurationFormat <IIPConfigurationPropertiesFormat>] [-IPConfigurationId <String>]
 [-IPConfigurationName <String>] [-IPTag <IIPTag[]>] [-Id <String>] [-IdleTimeoutInMinutes <Int32>]
 [-Location <String>] [-PrefixId <String>] [-ProvisioningState <String>] [-ResourceGuid <String>]
 [-ReverseFqdn <String>] [-SkuName <PublicIPAddressSkuName>] [-Tag <Hashtable>] [-Zone <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzPublicIPAddress -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -PublicIPAddress <IPublicIPAddress> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzPublicIPAddress -InputObject <INetworkIdentity> [-AllocationMethod <IPAllocationMethod>]
 [-DdosCustomPolicyId <String>] [-DdosProtectionCoverage <DdosSettingsProtectionCoverage>]
 [-DomainNameLabel <String>] [-Etag <String>] [-Fqdn <String>] [-IPAddress <String>]
 [-IPAddressVersion <IPVersion>] [-IPConfigurationEtag <String>]
 [-IPConfigurationFormat <IIPConfigurationPropertiesFormat>] [-IPConfigurationId <String>]
 [-IPConfigurationName <String>] [-IPTag <IIPTag[]>] [-Id <String>] [-IdleTimeoutInMinutes <Int32>]
 [-Location <String>] [-PrefixId <String>] [-ProvisioningState <String>] [-ResourceGuid <String>]
 [-ReverseFqdn <String>] [-SkuName <PublicIPAddressSkuName>] [-Tag <Hashtable>] [-Zone <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzPublicIPAddress -InputObject <INetworkIdentity> -PublicIPAddress <IPublicIPAddress>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a static or dynamic public IP address.

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

### -AllocationMethod
The public IP address allocation method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod
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

### -DdosCustomPolicyId
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

### -DdosProtectionCoverage
The DDoS protection policy customizability of the public IP.
Only standard coverage will have the ability to be customized.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage
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

### -DomainNameLabel
Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address.
If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.

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

### -Fqdn
Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP.
This is the concatenation of the domainNameLabel and the regionalized DNS zone.

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

### -IdleTimeoutInMinutes
The idle timeout of the public IP address.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -IPAddress
The IP address associated with the public IP address resource.

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

### -IPAddressVersion
The public IP address version.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPConfigurationEtag
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

### -IPConfigurationFormat
Properties of the IP configuration
To construct, see NOTES section for IPCONFIGURATIONFORMAT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationPropertiesFormat
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPConfigurationId
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

### -IPConfigurationName
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

### -IPTag
The list of tags associated with the public IP address.
To construct, see NOTES section for IPTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
The name of the public IP address.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
Aliases: PublicIPAddressName

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

### -PrefixId
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

### -PublicIPAddress
Public IP address resource.
To construct, see NOTES section for PUBLICIPADDRESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress
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
Aliases: PublicIpPrefix

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGuid
The resource GUID property of the public IP resource.

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

### -ReverseFqdn
Gets or Sets the Reverse FQDN.
A user-visible, fully qualified domain name that resolves to this public IP address.
If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN.

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

### -SkuName
Name of a public IP address SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: Sku

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

### -Zone
A list of availability zones denoting the IP allocated for the resource needs to come from.

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### IPCONFIGURATIONFORMAT <IIPConfigurationPropertiesFormat>: Properties of the IP configuration
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

#### IPTAG <IIPTag[]>: The list of tags associated with the public IP address.
  - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
  - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.

#### PUBLICIPADDRESS <IPublicIPAddress>: Public IP address resource.
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

## RELATED LINKS

