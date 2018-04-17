---
external help file: Azs.Network.Admin-help.xml
Module Name: Azs.Network.Admin
online version: 
schema: 2.0.0
---

# Set-AzsNetworkQuota

## SYNOPSIS
Create or update a quota.

## SYNTAX

### Quotas (Default)
```
Set-AzsNetworkQuota -Name <String> [-MaxNicsPerSubscription <Int64>] [-MaxPublicIpsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewayConnectionsPerSubscription <Int64>] [-MaxVnetsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewaysPerSubscription <Int64>] [-MaxSecurityGroupsPerSubscription <Int64>]
 [-MaxLoadBalancersPerSubscription <Int64>] [-Location <String>] [<CommonParameters>]
```

### ResourceId
```
Set-AzsNetworkQuota [-MaxNicsPerSubscription <Int64>] [-MaxPublicIpsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewayConnectionsPerSubscription <Int64>] [-MaxVnetsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewaysPerSubscription <Int64>] [-MaxSecurityGroupsPerSubscription <Int64>]
 [-MaxLoadBalancersPerSubscription <Int64>] -ResourceId <String> [<CommonParameters>]
```

### InputObject
```
Set-AzsNetworkQuota [-MaxNicsPerSubscription <Int64>] [-MaxPublicIpsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewayConnectionsPerSubscription <Int64>] [-MaxVnetsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewaysPerSubscription <Int64>] [-MaxSecurityGroupsPerSubscription <Int64>]
 [-MaxLoadBalancersPerSubscription <Int64>] -InputObject <Quota> [<CommonParameters>]
```

## DESCRIPTION
Create or update a quota.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsNetworkQuota -Name NetworkQuota1 -MaxVnetsPerSubscription 20
```

MaxPublicIpsPerSubscription                        : 150
MaxVnetsPerSubscription                            : 20
MaxVirtualNetworkGatewaysPerSubscription           : 1
MaxVirtualNetworkGatewayConnectionsPerSubscription : 2
MaxLoadBalancersPerSubscription                    : 50
MaxNicsPerSubscription                             : 50
MaxSecurityGroupsPerSubscription                   : 50
MigrationPhase                                     : None
Id                                                 : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/providers/Microsoft.Network.Admin/locations/local/quotas/Networ
                                                     kQuota1
Name                                               : NetworkQuota1
Type                                               : Microsoft.Network.Admin/quotas
Location                                           :
Tags                                               :

Update a network quota by name.

### -------------------------- EXAMPLE 2 --------------------------
```
Set-AzsNetworkQuota -Name NetworkQuota1 -MaxPublicIpsPerSubscription 75 -MaxNicsPerSubscription 100
```

MaxPublicIpsPerSubscription                        : 75
MaxVnetsPerSubscription                            : 20
MaxVirtualNetworkGatewaysPerSubscription           : 1
MaxVirtualNetworkGatewayConnectionsPerSubscription : 2
MaxLoadBalancersPerSubscription                    : 50
MaxNicsPerSubscription                             : 100
MaxSecurityGroupsPerSubscription                   : 50
MigrationPhase                                     : None
Id                                                 : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/providers/Microsoft.Network.Admin/locations/local/quotas/Networ
                                                     kQuota1
Name                                               : NetworkQuota1
Type                                               : Microsoft.Network.Admin/quotas
Location                                           :
Tags                                               :

Update a network quota by name.

## PARAMETERS

### -InputObject
The input object of type Microsoft.AzureStack.Management.Network.Admin.Models.Quota.

```yaml
Type: Quota
Parameter Sets: InputObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: Quotas
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxLoadBalancersPerSubscription
The maximum number of load balancers allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxNicsPerSubscription
The maximum NICs allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPublicIpsPerSubscription
The maximum public IP addresses allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxSecurityGroupsPerSubscription
The maximum number of security groups allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxVirtualNetworkGatewayConnectionsPerSubscription
The maximum number of virtual network gateway connections allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxVirtualNetworkGatewaysPerSubscription
The maximum number of virtual network gateways allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxVnetsPerSubscription
The maxium number of virtual networks allowed per subscription.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource.

```yaml
Type: String
Parameter Sets: Quotas
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Network.Admin.Models.Quota

## NOTES

## RELATED LINKS

