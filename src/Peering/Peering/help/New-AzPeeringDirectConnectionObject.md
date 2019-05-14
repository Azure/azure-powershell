---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.dll-Help.xml
Module Name: Az.Peering
online version: https://docs.microsoft.com/en-us/powershell/module/az.peering/new-azpeeringdirectconnectionobject
schema: 2.0.0
---

# New-AzPeeringDirectConnectionObject

## SYNOPSIS
Creates a in memory PSObject to be used for creating or modifying a Peering.

## SYNTAX

### IPv4Prefix (Default)
```
New-AzPeeringDirectConnectionObject [-PeeringDBFacilityId] <Int32> [-SessionPrefixV4] <String>
 [-BandwidthInMbps] <Int32> [-MaxPrefixesAdvertisedIPv4 <Int32>] [-MD5AuthenticationKey <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IPv6Prefix
```
New-AzPeeringDirectConnectionObject [-PeeringDBFacilityId] <Int32> [-SessionPrefixV6] <String>
 [-BandwidthInMbps] <Int32> [-MaxPrefixesAdvertisedIPv6 <Int32>] [-MD5AuthenticationKey <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IPv4PrefixIPv6Prefix
```
New-AzPeeringDirectConnectionObject [-PeeringDBFacilityId] <Int32> [-SessionPrefixV4] <String>
 [-SessionPrefixV6] <String> [-BandwidthInMbps] <Int32> [-MaxPrefixesAdvertisedIPv4 <Int32>]
 [-MaxPrefixesAdvertisedIPv6 <Int32>] [-MD5AuthenticationKey <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates an in memory PSObject 

## EXAMPLES

### Example 1
```powershell
PS C:> $connection = New-AzPeeringDirectConnectionObject -PeeringDBFacilityId 99999 -BandwidthInMbps 30000 -SessionPrefixV4 192.168.1.0/31 -SessionPrefixV6 fe01::0/127 -MaxPrefixesAdvertisedIPv4 20000 -MaxPrefixesAdvertisedIPv6 2000 -MD5AuthenticationKey 25234523452123411fd234qdwfas3234

PeeringDBFacilityId  : 99999
SessionPrefixv4      : 192.168.1.0/31
SessionPrefixv6      : fe01::0/127
BandwidthInMbps      : 30000
Md5AuthenticationKey : 25234523452123411fd234qdwfas3234
```

New local connection

## PARAMETERS

### -BandwidthInMbps
The Bandwidth offered at this location in Mbps.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrefixesAdvertisedIPv4
The maximum advertised IPv4

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: IPv4Prefix, IPv4PrefixIPv6Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrefixesAdvertisedIPv6
The maximum advertised IPv6

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: IPv6Prefix, IPv4PrefixIPv6Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MD5AuthenticationKey
The MD5 authentication key for session.

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

### -PeeringDBFacilityId
The peering facility Id found on https://peeringdb.com

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionPrefixV4
The peer session IPv4 address

```yaml
Type: System.String
Parameter Sets: IPv4Prefix, IPv4PrefixIPv6Prefix
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionPrefixV6
The peer session IPv6 address

```yaml
Type: System.String
Parameter Sets: IPv6Prefix, IPv4PrefixIPv6Prefix
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSDirectConnection

## NOTES

## RELATED LINKS
