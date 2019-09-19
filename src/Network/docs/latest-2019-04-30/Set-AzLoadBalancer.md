---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azloadbalancer
schema: 2.0.0
---

# Set-AzLoadBalancer

## SYNOPSIS
Creates or updates a load balancer.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzLoadBalancer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BackendAddressPool <IBackendAddressPool[]>] [-Etag <String>]
 [-FrontendIPConfiguration <IFrontendIPConfiguration[]>] [-Id <String>] [-InboundNatPool <IInboundNatPool[]>]
 [-InboundNatRule <IInboundNatRule_Reference[]>] [-LoadBalancingRule <ILoadBalancingRule[]>]
 [-Location <String>] [-OutboundRule <IOutboundRule[]>] [-Probe <IProbe[]>] [-ProvisioningState <String>]
 [-ResourceGuid <String>] [-SkuName <LoadBalancerSkuName>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzLoadBalancer -Name <String> -ResourceGroupName <String> -LoadBalancer <ILoadBalancer>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a load balancer.

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

### -BackendAddressPool
Collection of backend address pools used by a load balancer
To construct, see NOTES section for BACKENDADDRESSPOOL properties and create a hash table.

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

### -FrontendIPConfiguration
Object representing the frontend IPs to be used for the load balancer
To construct, see NOTES section for FRONTENDIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[]
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

### -InboundNatPool
Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer.
Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules.
Inbound NAT pools are referenced from virtual machine scale sets.
NICs that are associated with individual virtual machines cannot reference an inbound NAT pool.
They have to reference individual inbound NAT rules.
To construct, see NOTES section for INBOUNDNATPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InboundNatRule
Collection of inbound NAT Rules used by a load balancer.
Defining inbound NAT rules on your load balancer is mutually exclusive with defining an inbound NAT pool.
Inbound NAT pools are referenced from virtual machine scale sets.
NICs that are associated with individual virtual machines cannot reference an Inbound NAT pool.
They have to reference individual inbound NAT rules.

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

### -LoadBalancer
LoadBalancer resource
To construct, see NOTES section for LOADBALANCER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancer
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancingRule
Object collection representing the load balancing rules Gets the provisioning 
To construct, see NOTES section for LOADBALANCINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[]
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
The name of the load balancer.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LoadBalancerName

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

### -OutboundRule
The outbound rules.
To construct, see NOTES section for OUTBOUNDRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Probe
Collection of probe objects used in the load balancer
To construct, see NOTES section for PROBE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[]
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
Gets the provisioning state of the PublicIP resource.
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

### -ResourceGuid
The resource GUID property of the load balancer resource.

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

### -SkuName
Name of a load balancer SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancer

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancer

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### BACKENDADDRESSPOOL <IBackendAddressPool[]>: Collection of backend address pools used by a load balancer
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[OutboundRuleId <String>]`: Resource ID.
  - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### FRONTENDIPCONFIGURATION <IFrontendIPConfiguration[]>: Object representing the frontend IPs to be used for the load balancer
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The Private IP allocation method.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the Public IP resource.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[PublicIPPrefixId <String>]`: Resource ID.
  - `[Subnet <ISubnet>]`: The reference of the subnet resource.
    - `[Id <String>]`: Resource ID.
  - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.

#### INBOUNDNATPOOL <IInboundNatPool[]>: Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range. Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an inbound NAT pool. They have to reference individual inbound NAT rules.
  - `BackendPort <Int32>`: The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535.
  - `FrontendPortRangeEnd <Int32>`: The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65535.
  - `FrontendPortRangeStart <Int32>`: The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65534.
  - `Protocol <TransportProtocol>`: The reference to the transport protocol used by the inbound NAT pool.
  - `[Id <String>]`: Resource ID.
  - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### LOADBALANCER <ILoadBalancer>: LoadBalancer resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

#### LOADBALANCINGRULE <ILoadBalancingRule[]>: Object collection representing the load balancing rules Gets the provisioning 
  - `FrontendPort <Int32>`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values are between 0 and 65534. Note that value 0 enables "Any Port"
  - `Protocol <TransportProtocol>`: The reference to the transport protocol used by the load balancing rule.
  - `[Id <String>]`: Resource ID.
  - `[BackendAddressPoolId <String>]`: Resource ID.
  - `[BackendPort <Int32?>]`: The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables "Any Port"
  - `[DisableOutboundSnat <Boolean?>]`: Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing rule.
  - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
  - `[LoadDistribution <LoadDistribution?>]`: The load distribution policy for this rule. Possible values are 'Default', 'SourceIP', and 'SourceIPProtocol'.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[ProbeId <String>]`: Resource ID.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### OUTBOUNDRULE <IOutboundRule[]>: The outbound rules.
  - `FrontendIPConfiguration <ISubResource[]>`: The Frontend IP addresses of the load balancer.
    - `[Id <String>]`: Resource ID.
  - `Protocol <LoadBalancerOutboundRuleProtocol>`: The protocol for the outbound rule in load balancer. Possible values are: 'Tcp', 'Udp', and 'All'.
  - `[Id <String>]`: Resource ID.
  - `[AllocatedOutboundPort <Int32?>]`: The number of outbound ports to be used for NAT.
  - `[BackendAddressPoolId <String>]`: Resource ID.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IdleTimeoutInMinutes <Int32?>]`: The timeout for the TCP idle connection
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### PROBE <IProbe[]>: Collection of probe objects used in the load balancer
  - `Port <Int32>`: The port for communicating the probe. Possible values range from 1 to 65535, inclusive.
  - `Protocol <ProbeProtocol>`: The protocol of the end point. Possible values are: 'Http', 'Tcp', or 'Https'. If 'Tcp' is specified, a received ACK is required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is required for the probe to be successful.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IntervalInSeconds <Int32?>]`: The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of rotation. The default value is 15, the minimum value is 5.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[NumberOfProbe <Int32?>]`: The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint. This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[RequestPath <String>]`: The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is not allowed. There is no default value.

## RELATED LINKS

