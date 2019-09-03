---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvnettap
schema: 2.0.0
---

# Set-AzVnetTap

## SYNOPSIS
Creates or updates a Virtual Network Tap.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzVnetTap -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdditionalVnetTap <IVirtualNetworkTap_Reference[]>]
 [-ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-ApplicationSecurityGroup <IApplicationSecurityGroup_Reference[]>] [-DestinationLoadBalancerEtag <String>]
 [-DestinationLoadBalancerId <String>] [-DestinationLoadBalancerName <String>]
 [-DestinationLoadBalancerPrivateIPAddress <String>]
 [-DestinationLoadBalancerPrivateIPAllocationMethod <IPAllocationMethod>]
 [-DestinationLoadBalancerProvisioningState <String>]
 [-DestinationLoadBalancerPublicIPAddress <IPublicIPAddress_Reference>]
 [-DestinationLoadBalancerSubnet <ISubnet_Reference>] [-DestinationLoadBalancerZone <String[]>]
 [-DestinationNetworkInterfaceEtag <String>] [-DestinationNetworkInterfaceId <String>]
 [-DestinationNetworkInterfaceName <String>] [-DestinationNetworkInterfacePrivateIPAddress <String>]
 [-DestinationNetworkInterfacePrivateIPAllocationMethod <IPAllocationMethod>]
 [-DestinationNetworkInterfaceProvisioningState <String>]
 [-DestinationNetworkInterfacePublicIPAddress <IPublicIPAddress_Reference>]
 [-DestinationNetworkInterfaceSubnet <ISubnet_Reference>] [-DestinationPort <Int32>] [-Etag <String>]
 [-Id <String>] [-LoadBalancerBackendAddressPool <IBackendAddressPool[]>]
 [-LoadBalancerInboundNatRule <IInboundNatRule_Reference[]>] [-Location <String>] [-Primary]
 [-PrivateIPAddressVersion <IPVersion>] [-PublicIPPrefixId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzVnetTap -Name <String> -ResourceGroupName <String> -VnetTap <IVirtualNetworkTap>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Virtual Network Tap.

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

### -AdditionalVnetTap
The reference to Virtual Network Taps.

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

### -DestinationLoadBalancerEtag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DestinationLoadBalancerFrontEndIPConfigurationEtag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationLoadBalancerId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DestinationLoadBalancerFrontEndIPConfigurationId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationLoadBalancerName
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DestinationLoadBalancerFrontEndIPConfigurationName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationLoadBalancerPrivateIPAddress
The private IP address of the IP configuration.

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

### -DestinationLoadBalancerPrivateIPAllocationMethod
The Private IP allocation method.

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

### -DestinationLoadBalancerProvisioningState
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

### -DestinationLoadBalancerPublicIPAddress
The reference of the Public IP resource.

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

### -DestinationLoadBalancerSubnet
The reference of the subnet resource.

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

### -DestinationLoadBalancerZone
A list of availability zones denoting the IP allocated for the resource needs to come from.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases: DestinationLoadBalancerFrontEndIPConfigurationZone

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationNetworkInterfaceEtag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DestinationNetworkInterfaceIPConfigurationEtag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationNetworkInterfaceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DestinationNetworkInterfaceIPConfigurationId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationNetworkInterfaceName
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DestinationNetworkInterfaceIPConfigurationName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationNetworkInterfacePrivateIPAddress
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

### -DestinationNetworkInterfacePrivateIPAllocationMethod
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

### -DestinationNetworkInterfaceProvisioningState
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

### -DestinationNetworkInterfacePublicIPAddress
Public IP address bound to the IP configuration.

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

### -DestinationNetworkInterfaceSubnet
Subnet bound to the IP configuration.

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

### -DestinationPort
The VXLAN destination port that will receive the tapped traffic.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

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
The name of the virtual network tap.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TapName

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

### -Primary
Gets whether this is a primary customer address on the network interface.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -PublicIPPrefixId
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

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### -VnetTap
Virtual Network Tap resource
To construct, see NOTES section for VNETTAP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap
Parameter Sets: Update
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap

## ALIASES

### Set-AzVirtualNetworkTap

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
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[Id <String>]`: Resource ID.
    - `[VnetTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### LOADBALANCERBACKENDADDRESSPOOL <IBackendAddressPool[]>: The reference of LoadBalancerBackendAddressPool resource.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[OutboundRuleId <String>]`: Resource ID.
  - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### VNETTAP <IVirtualNetworkTap>: Virtual Network Tap resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

