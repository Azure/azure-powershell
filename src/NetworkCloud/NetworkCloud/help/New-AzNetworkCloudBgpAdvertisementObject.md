---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudbgpadvertisementobject
schema: 2.0.0
---

# New-AzNetworkCloudBgpAdvertisementObject

## SYNOPSIS
Create an in-memory object for BgpAdvertisement.

## SYNTAX

```
New-AzNetworkCloudBgpAdvertisementObject [-AdvertiseToFabric <String>] [-Community <String[]>]
 [-IPAddressPool <String[]>] [-Peer <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BgpAdvertisement.

## EXAMPLES

### Example 1: Create BGP advertisement with specific pools and communities
```powershell
New-AzNetworkCloudBgpAdvertisementObject -AdvertiseToFabric "True" -IPAddressPool @("pool1", "pool2") -Community @("65001:100", "65001:200")
```

```output
AdvertiseToFabric : True
Community         : {65001:100, 65001:200}
IPAddressPool     : {pool1, pool2}
Peer              : {}
```

This example creates a BGP advertisement object that advertises specific IP address pools to the fabric with associated BGP communities.

### Example 2: Create BGP advertisement for specific peers
```powershell
New-AzNetworkCloudBgpAdvertisementObject -AdvertiseToFabric "False" -IPAddressPool @("external-pool") -Peer @("peer1", "peer2")
```

```output
AdvertiseToFabric : False
Community         : {}
IPAddressPool     : {external-pool}
Peer              : {peer1, peer2}
```

This example creates a BGP advertisement object that advertises to specific BGP peers without fabric peering.

## PARAMETERS

### -AdvertiseToFabric
The indicator of if this advertisement is also made to the network fabric associated with the Network Cloud Cluster.
This field is ignored if fabricPeeringEnabled is set to False.

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

### -Community
The names of the BGP communities to be associated with the announcement, utilizing a BGP community string in 1234:1234 format.

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

### -IPAddressPool
The names of the IP address pools associated with this announcement.

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

### -Peer
The names of the BGP peers to limit this advertisement to.
If no values are specified, all BGP peers will receive this advertisement.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BgpAdvertisement

## NOTES

## RELATED LINKS
