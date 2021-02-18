---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.dll-Help.xml
Module Name: Az.Peering
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.peering/new-azpeeringdirectconnectionobject
=======
online version: https://docs.microsoft.com/powershell/module/az.peering/new-azpeeringdirectconnectionobject
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# New-AzPeeringDirectConnectionObject

## SYNOPSIS
Creates a in memory PSObject to be used for creating or modifying a Peering.

## SYNTAX

<<<<<<< HEAD
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
=======
### IPv4PrefixIPv6Prefix (Default)
```
New-AzPeeringDirectConnectionObject [-PeeringDBFacilityId] <Int32> [-SessionPrefixV4 <String>]
 [-SessionPrefixV6 <String>] -BandwidthInMbps <Int32> [-UseForPeeringService]
 [-MaxPrefixesAdvertisedIPv4 <Int32>] [-MaxPrefixesAdvertisedIPv6 <Int32>] [-MD5AuthenticationKey <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ParameterSetNameMicrosoftProvidedIPAddress
```
New-AzPeeringDirectConnectionObject [-PeeringDBFacilityId] <Int32> [-MicrosoftProvidedIPAddress]
 -BandwidthInMbps <Int32> [-UseForPeeringService] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

## DESCRIPTION
Creates an in memory PSObject 

## EXAMPLES

### Example 1
```powershell
<<<<<<< HEAD
PS C:> $connection = New-AzPeeringDirectConnectionObject -PeeringDBFacilityId 99999 -BandwidthInMbps 30000 -SessionPrefixV4 192.168.1.0/31 -SessionPrefixV6 fe01::0/127 -MaxPrefixesAdvertisedIPv4 20000 -MaxPrefixesAdvertisedIPv6 2000 -MD5AuthenticationKey 25234523452123411fd234qdwfas3234

PeeringDBFacilityId  : 99999
SessionPrefixv4      : 192.168.1.0/31
SessionPrefixv6      : fe01::0/127
BandwidthInMbps      : 30000
Md5AuthenticationKey : 25234523452123411fd234qdwfas3234
=======
PS C:>New-AzPeeringDirectConnectionObject -PeeringDBFacilityId 99999 -BandwidthInMbps 30000 -SessionPrefixV4 192.168.1.0/31 -SessionPrefixV6 fe01::0/127 -MaxPrefixesAdvertisedIPv4 20000 -MaxPrefixesAdvertisedIPv6 2000 -MD5AuthenticationKey 25234523452123411fd234qdwfas3234

PeeringDBFacilityId    : 99999
UseForPeeringService   : False
SessionAddressProvider : Peer
SessionPrefixV4        : 192.168.1.0/31
ConnectionIdentifier   : 6d771cef-7169-4b0a-b028-c7270054bd31
SessionPrefixV6        : fe01::0/127
BandwidthInMbps        : 30000
Md5AuthenticationKey   : 25234523452123411fd234qdwfas3234
SessionStateV4         :
SessionStateV6         :
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

New local connection

<<<<<<< HEAD
=======
### Example 2
```powershell
PS C:>New-AzPeeringDirectConnectionObject -PeeringDBFacilityId 99999 -MicrosoftProvidedIPAddress -BandwidthInMbps 30000 -UseForPeeringService

PeeringDBFacilityId    : 99999
UseForPeeringService   : True
SessionAddressProvider : Microsoft
ConnectionIdentifier   : 1de364bf-74ea-4088-ad17-bb79c16cfa81
BandwidthInMbps        : 30000
```

Create direct peering connection with use for peering service enabled and Microsoft provided IP addresses

### Example 3
```powershell
PS C:>New-AzPeeringDirectConnectionObject -PeeringDBFacilityId 99999 -BandwidthInMbps 30000 -SessionPrefixV4 192.168.1.0/31 -SessionPrefixV6 fe01::0/127 -UseForPeeringService

PeeringDBFacilityId    : 99999
UseForPeeringService   : True
SessionAddressProvider : Peer
SessionPrefixV4        : 192.168.1.0/31
ConnectionIdentifier   : 74ea6eab-5625-4170-a642-822e85d97566
SessionPrefixV6        : fe01::0/127
BandwidthInMbps        : 30000
SessionStateV4         :
SessionStateV6         :
```

Create direct peering connection with use for peering service enabled and peer provided IP Addresses

### Example 4
```powershell
PS C:>New-AzPeeringDirectConnectionObject -PeeringDBFacilityId 99999 -BandwidthInMbps 30000

PeeringDBFacilityId    : 99999
UseForPeeringService   : False
SessionAddressProvider : Peer
ConnectionIdentifier   : 920f128a-c9d8-4514-a2e0-c533ab1a550c
BandwidthInMbps        : 30000
```

Create direct peering connection without bgp session IP addresses. The peer will have to set the IP addresses before the bgp session can be configured.

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
## PARAMETERS

### -BandwidthInMbps
The Bandwidth offered at this location in Mbps.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: True
<<<<<<< HEAD
Position: 2
=======
Position: Named
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
Parameter Sets: IPv4Prefix, IPv4PrefixIPv6Prefix
=======
Parameter Sets: IPv4PrefixIPv6Prefix
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
Parameter Sets: IPv6Prefix, IPv4PrefixIPv6Prefix
=======
Parameter Sets: IPv4PrefixIPv6Prefix
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: IPv4PrefixIPv6Prefix
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
=======
### -MicrosoftProvidedIPAddress
Enable flag that tells Microsoft to provide the BGP session addresses.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ParameterSetNameMicrosoftProvidedIPAddress
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
Parameter Sets: IPv4Prefix, IPv4PrefixIPv6Prefix
Aliases:

Required: True
Position: 1
=======
Parameter Sets: IPv4PrefixIPv6Prefix
Aliases:

Required: False
Position: Named
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionPrefixV6
The peer session IPv6 address

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: IPv6Prefix, IPv4PrefixIPv6Prefix
Aliases:

Required: True
Position: 1
=======
Parameter Sets: IPv4PrefixIPv6Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseForPeeringService
Enable for use with Microsoft Peering Service (MPS).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSDirectConnection

## NOTES

## RELATED LINKS
