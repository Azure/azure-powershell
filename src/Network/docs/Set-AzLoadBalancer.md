---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azloadbalancer
schema: 2.0.0
---

# Set-AzLoadBalancer

## SYNOPSIS
Creates or updates a load balancer.

## SYNTAX

### Update (Default)
```
Set-AzLoadBalancer -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <ILoadBalancer>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzLoadBalancer -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-BackendAddressPool <IBackendAddressPool[]>] [-Etag <String>]
 [-FrontendIPConfiguration <IFrontendIPConfiguration[]>] [-Id <String>] [-InboundNatPool <IInboundNatPool[]>]
 [-InboundNatRule <IInboundNatRule[]>] [-LoadBalancingRule <ILoadBalancingRule[]>] [-Location <String>]
 [-OutboundRule <IOutboundRule[]>] [-Probe <IProbe[]>] [-ProvisioningState <String>] [-ResourceGuid <String>]
 [-SkuName <LoadBalancerSkuName>] [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzLoadBalancer -InputObject <INetworkIdentity> [-BackendAddressPool <IBackendAddressPool[]>]
 [-Etag <String>] [-FrontendIPConfiguration <IFrontendIPConfiguration[]>] [-Id <String>]
 [-InboundNatPool <IInboundNatPool[]>] [-InboundNatRule <IInboundNatRule[]>]
 [-LoadBalancingRule <ILoadBalancingRule[]>] [-Location <String>] [-OutboundRule <IOutboundRule[]>]
 [-Probe <IProbe[]>] [-ProvisioningState <String>] [-ResourceGuid <String>] [-SkuName <LoadBalancerSkuName>]
 [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzLoadBalancer -InputObject <INetworkIdentity> [-Parameter <ILoadBalancer>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a load balancer.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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
```

### -BackendAddressPool
Collection of backend address pools used by a load balancer

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendIPConfiguration
Object representing the frontend IPs to be used for the load balancer

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InboundNatPool
Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer.
Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range.
Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules.
Inbound NAT pools are referenced from virtual machine scale sets.
NICs that are associated with individual virtual machines cannot reference an inbound NAT pool.
They have to reference individual inbound NAT rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InboundNatRule
Collection of inbound NAT Rules used by a load balancer.
Defining inbound NAT rules on your load balancer is mutually exclusive with defining an inbound NAT pool.
Inbound NAT pools are referenced from virtual machine scale sets.
NICs that are associated with individual virtual machines cannot reference an Inbound NAT pool.
They have to reference individual inbound NAT rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LoadBalancingRule
Object collection representing the load balancing rules Gets the provisioning

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the load balancer.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: LoadBalancerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutboundRule
The outbound rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
LoadBalancer resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancer
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Probe
Collection of probe objects used in the load balancer

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Gets the provisioning state of the PublicIP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuid
The resource GUID property of the load balancer resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of a load balancer SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadBalancerSkuName
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancer
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/set-azloadbalancer](https://docs.microsoft.com/en-us/powershell/module/az.network/set-azloadbalancer)

