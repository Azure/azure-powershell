---
external help file:
Module Name: Azs.Network.Admin
online version: https://docs.microsoft.com/en-us/powershell/module/azs.network.admin/set-azsnetworkquota
schema: 2.0.0
---

# Set-AzsNetworkQuota

## SYNOPSIS
Create or update a quota.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzsNetworkQuota -Name <String> [-Location <String>] [-SubscriptionId <String>]
 [-MaxLoadBalancersPerSubscription <Int64>] [-MaxNicsPerSubscription <Int64>]
 [-MaxPublicIpsPerSubscription <Int64>] [-MaxSecurityGroupsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewayConnectionsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewaysPerSubscription <Int64>] [-MaxVnetsPerSubscription <Int64>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzsNetworkQuota -Name <String> -Quota <IQuota> [-Location <String>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a quota.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsNetworkQuota -Name NetworkQuota1 -MaxVnetsPerSubscription 20
```

Update a network quota by name.

### -------------------------- EXAMPLE 2 --------------------------
```
Set-AzsNetworkQuota -Name NetworkQuota1 -MaxPublicIpsPerSubscription 75 -MaxNicsPerSubscription 100
```

Update a network quota by name.

## PARAMETERS

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

### -Location
Location of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzLocation)[0].Name
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxLoadBalancersPerSubscription
Maximum number of load balancers a tenant subscription can provision.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxNicsPerSubscription
Maximum number of NICs a tenant subscription can provision.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxPublicIpsPerSubscription
Maximum number of public IP addresses a tenant subscription can provision.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxSecurityGroupsPerSubscription
Maximum number of security groups a tenant subscription can provision.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxVirtualNetworkGatewayConnectionsPerSubscription
Maximum number of virtual network gateway Connections a tenant subscription can provision.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxVirtualNetworkGatewaysPerSubscription
Maximum number of virtual network gateways a tenant subscription can provision.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxVnetsPerSubscription
Maximum number of virtual networks a tenant subscription can provision.

```yaml
Type: System.Int64
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
Name of the resource.

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

### -Quota
Network quota resource.
To construct, see NOTES section for QUOTA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAdmin.Models.Api20150615.IQuota
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
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
List of key value pairs.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAdmin.Models.Api20150615.IQuota

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAdmin.Models.Api20150615.IQuota

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### QUOTA <IQuota>: Network quota resource.
  - `[Tag <IResourceTags>]`: List of key value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[MaxLoadBalancersPerSubscription <Int64?>]`: Maximum number of load balancers a tenant subscription can provision.
  - `[MaxNicsPerSubscription <Int64?>]`: Maximum number of NICs a tenant subscription can provision.
  - `[MaxPublicIpsPerSubscription <Int64?>]`: Maximum number of public IP addresses a tenant subscription can provision.
  - `[MaxSecurityGroupsPerSubscription <Int64?>]`: Maximum number of security groups a tenant subscription can provision.
  - `[MaxVirtualNetworkGatewayConnectionsPerSubscription <Int64?>]`: Maximum number of virtual network gateway Connections a tenant subscription can provision.
  - `[MaxVirtualNetworkGatewaysPerSubscription <Int64?>]`: Maximum number of virtual network gateways a tenant subscription can provision.
  - `[MaxVnetsPerSubscription <Int64?>]`: Maximum number of virtual networks a tenant subscription can provision.

## RELATED LINKS

