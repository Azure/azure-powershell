---
external help file:
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

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

