---
external help file: Azs.Network.Admin-help.xml
Module Name: Azs.Network.Admin
online version: 
schema: 2.0.0
---

# Get-AzsNetworkQuota

## SYNOPSIS
List all quotas.

## SYNTAX

### List (Default)
```
Get-AzsNetworkQuota [-Location <String>] [-Filter <String>] [<CommonParameters>]
```

### Get
```
Get-AzsNetworkQuota [-Name] <String> [-Location <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsNetworkQuota -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
List all quotas.
Limit the list by passing a name or filter.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsNetworkQuota -Name NetworkQuota1
```

MaxPublicIpsPerSubscription                        : 50
MaxVnetsPerSubscription                            : 50
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

Get the specified network quota.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

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

