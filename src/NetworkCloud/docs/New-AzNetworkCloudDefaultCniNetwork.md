---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkclouddefaultcninetwork
schema: 2.0.0
---

# New-AzNetworkCloudDefaultCniNetwork

## SYNOPSIS
Create a new default CNI network or update the properties of the existing default CNI network.

## SYNTAX

```
New-AzNetworkCloudDefaultCniNetwork -Name <String> -ResourceGroupName <String> -ExtendedLocationName <String>
 -ExtendedLocationType <String> -L3IsolationDomainId <String> -Location <String> -Vlan <Int64>
 [-SubscriptionId <String>] [-CniBgpConfigurationBgpPeer <IBgpPeer[]>]
 [-CniBgpConfigurationCommunityAdvertisement <ICommunityAdvertisement[]>]
 [-CniBgpConfigurationNodeMeshPassword <String>] [-CniBgpConfigurationServiceExternalPrefix <String[]>]
 [-CniBgpConfigurationServiceLoadBalancerPrefix <String[]>] [-IPAllocationType <IPAllocationType>]
 [-Ipv4ConnectedPrefix <String>] [-Ipv6ConnectedPrefix <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new default CNI network or update the properties of the existing default CNI network.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
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
```

### -CniBgpConfigurationBgpPeer
The list of BgpPeer entities that the Hybrid AKS cluster will peer with in addition to peering that occurs automatically with the switch fabric.
To construct, see NOTES section for CNIBGPCONFIGURATIONBGPPEER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api202212Preview.IBgpPeer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CniBgpConfigurationCommunityAdvertisement
The list of prefix community advertisement properties.
Each prefix community specifies a prefix, and thecommunities that should be associated with that prefix when it is announced.
To construct, see NOTES section for CNIBGPCONFIGURATIONCOMMUNITYADVERTISEMENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api202212Preview.ICommunityAdvertisement[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CniBgpConfigurationNodeMeshPassword
The password of the Calico node mesh.
It defaults to a randomly-generated string when not provided.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CniBgpConfigurationServiceExternalPrefix
The subnet blocks in CIDR format for Kubernetes service external IPs to be advertised over BGP.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CniBgpConfigurationServiceLoadBalancerPrefix
The subnet blocks in CIDR format for Kubernetes load balancers.
Load balancer IPs will only be advertised if theyare within one of these blocks.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAllocationType
The type of the IP address allocation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.IPAllocationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv4ConnectedPrefix
The IPV4 prefix (CIDR) assigned to this default CNI network.
It is required when the IP allocation typeis IPV4 or DualStack.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6ConnectedPrefix
The IPV6 prefix (CIDR) assigned to this default CNI network.
It is required when the IP allocation typeis IPV6 or DualStack.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -L3IsolationDomainId
The resource ID of the Network Fabric l3IsolationDomain.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the default CNI network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DefaultCniNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vlan
The VLAN from the l3IsolationDomain that is used for this network.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api202212Preview.IDefaultCniNetwork

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CNIBGPCONFIGURATIONBGPPEER <IBgpPeer[]>`: The list of BgpPeer entities that the Hybrid AKS cluster will peer with in addition to peering that occurs automatically with the switch fabric.
  - `AsNumber <Int64>`: The ASN (Autonomous System Number) of the BGP peer.
  - `PeerIP <String>`: The IPv4 or IPv6 address to peer with the associated CNI Network. The IP version type will drive a peering with the same version type from the Default CNI Network. For example, IPv4 to IPv4 or IPv6 to IPv6.
  - `[Password <String>]`: The password for this peering neighbor. It defaults to no password if not specified.

`CNIBGPCONFIGURATIONCOMMUNITYADVERTISEMENT <ICommunityAdvertisement[]>`: The list of prefix community advertisement properties. Each prefix community specifies a prefix, and thecommunities that should be associated with that prefix when it is announced.
  - `Community <String[]>`: The list of community strings to announce with this prefix.
  - `SubnetPrefix <String>`: The subnet in CIDR format for which properties should be advertised.

## RELATED LINKS

