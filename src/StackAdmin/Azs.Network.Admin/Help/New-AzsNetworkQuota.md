---
external help file: Azs.Network.Admin-help.xml
Module Name: Azs.Network.Admin
online version: 
schema: 2.0.0
---

# New-AzsNetworkQuota

## SYNOPSIS
Create or update a quota.

## SYNTAX

```
New-AzsNetworkQuota -Name <String> [-MaxNicsPerSubscription <Int64>] [-MaxPublicIpsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewayConnectionsPerSubscription <Int64>] [-MaxVnetsPerSubscription <Int64>]
 [-MaxVirtualNetworkGatewaysPerSubscription <Int64>] [-MaxSecurityGroupsPerSubscription <Int64>]
 [-MaxLoadBalancersPerSubscription <Int64>] [-Location <String>] [-MigrationPhase <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create or update a quota.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
New-AzsNetworkQuota -Name NetworkQuota1 -MaxNicsPerSubscription 150 -MaxPublicIpsPerSubscription 150
```

MaxPublicIpsPerSubscription                        : 150
MaxVnetsPerSubscription                            : 150
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

Create a new network quota.

## PARAMETERS

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: (All)
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
Default value: 50
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
Default value: 100
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
Default value: 50
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
Default value: 50
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
Default value: 2
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
Default value: 1
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
Default value: 50
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationPhase
{{Fill MigrationPhase Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: Prepare
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Network.Admin.Models.Quota

## NOTES

## RELATED LINKS

