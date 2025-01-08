---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudBgpAdvertisementObject
schema: 2.0.0
---

# New-AzNetworkCloudBgpAdvertisementObject

## SYNOPSIS
Create an in-memory object for BgpAdvertisement.

## SYNTAX

```
New-AzNetworkCloudBgpAdvertisementObject -IPAddressPool <String[]> [-AdvertiseToFabric <AdvertiseToFabric>]
 [-Community <String[]>] [-Peer <String[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BgpAdvertisement.

## EXAMPLES

### Example 1: Create an in-memory object for BgpAdvertisement.
```powershell
New-AzNetworkCloudBgpAdvertisementObject -IPAddressPool  @("pool1","pool2") -AdvertiseToFabric "True" -Community  @("communityString") -Peer @("peer1")
```

```output
AdvertiseToFabric Community         IPAddressPool  Peer
----------------- ---------         -------------  ----
True              {communityString} {pool1, pool2} {peer1}
```

Create an in-memory object for BgpAdvertisement.

## PARAMETERS

### -AdvertiseToFabric
The indicator of if this advertisement is also made to the network fabric associated with the Network Cloud Cluster.
This field is ignored if fabricPeeringEnabled is set to False.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.AdvertiseToFabric
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

Required: True
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.BgpAdvertisement

## NOTES

## RELATED LINKS
