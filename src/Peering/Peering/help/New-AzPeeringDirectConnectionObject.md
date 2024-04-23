---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/Az.Peering/new-AzPeeringDirectConnectionObject
schema: 2.0.0
---

# New-AzPeeringDirectConnectionObject

## SYNOPSIS
Create an in-memory object for DirectConnection.

## SYNTAX

```
New-AzPeeringDirectConnectionObject [-BandwidthInMbps <Int32>] [-BgpSessionMaxPrefixesAdvertisedV4 <Int32>]
 [-BgpSessionMaxPrefixesAdvertisedV6 <Int32>] [-BgpSessionMd5AuthenticationKey <String>]
 [-BgpSessionMicrosoftSessionIPv4Address <String>] [-BgpSessionMicrosoftSessionIPv6Address <String>]
 [-BgpSessionPeerSessionIPv4Address <String>] [-BgpSessionPeerSessionIPv6Address <String>]
 [-BgpSessionPrefixV4 <String>] [-BgpSessionPrefixV6 <String>] [-ConnectionIdentifier <String>]
 [-PeeringDbFacilityId <Int32>] [-SessionAddressProvider <SessionAddressProvider>]
 [-UseForPeeringService <Boolean>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DirectConnection.

## EXAMPLES

### Example 1: Create a direct connection object
```powershell
$md5Key = "******"

New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 1.1.1.1 -BgpSessionPeerSessionIPv4Address 1.1.1.0 -BgpSessionPrefixV4 1.1.1.1/31 -PeeringDbFacilityId 82 -SessionAddressProvider Peer -ConnectionIdentifier c111111111111
```

```output
BandwidthInMbps ConnectionIdentifier ConnectionState ErrorMessage MicrosoftTrackingId PeeringDbFacilityId ProvisionedBandwidthInMbps
--------------- -------------------- --------------- ------------ ------------------- ------------------- --------------------------
10000           c111111111111        PendingApproval                                  82
```

Creates an in-memory direct connection object

## PARAMETERS

### -BandwidthInMbps
The bandwidth of the connection.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpSessionMaxPrefixesAdvertisedV4
The maximum number of prefixes advertised over the IPv4 session.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpSessionMaxPrefixesAdvertisedV6
The maximum number of prefixes advertised over the IPv6 session.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpSessionMd5AuthenticationKey
The MD5 authentication key of the session.

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

### -BgpSessionMicrosoftSessionIPv4Address
The IPv4 session address on Microsoft's end.

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

### -BgpSessionMicrosoftSessionIPv6Address
The IPv6 session address on Microsoft's end.

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

### -BgpSessionPeerSessionIPv4Address
The IPv4 session address on peer's end.

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

### -BgpSessionPeerSessionIPv6Address
The IPv6 session address on peer's end.

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

### -BgpSessionPrefixV4
The IPv4 prefix that contains both ends' IPv4 addresses.

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

### -BgpSessionPrefixV6
The IPv6 prefix that contains both ends' IPv6 addresses.

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

### -ConnectionIdentifier
The unique identifier (GUID) for the connection.

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

### -PeeringDbFacilityId
The PeeringDB.com ID of the facility at which the connection has to be set up.

```yaml
Type: System.Int32
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

### -SessionAddressProvider
The field indicating if Microsoft provides session ip addresses.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.SessionAddressProvider
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseForPeeringService
The flag that indicates whether or not the connection is used for peering service.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.DirectConnection

## NOTES

## RELATED LINKS
