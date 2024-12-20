---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudServiceLoadBalancerBgpPeerObject
schema: 2.0.0
---

# New-AzNetworkCloudServiceLoadBalancerBgpPeerObject

## SYNOPSIS
Create an in-memory object for ServiceLoadBalancerBgpPeer.

## SYNTAX

```
New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name <String> -PeerAddress <String> -PeerAsn <Int64>
 [-BfdEnabled <BfdEnabled>] [-BgpMultiHop <BgpMultiHop>] [-HoldTime <String>] [-KeepAliveTime <String>]
 [-MyAsn <Int64>] [-Password <String>] [-PeerPort <Int64>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceLoadBalancerBgpPeer.

## EXAMPLES

### Example 1: Create an in-memory object for ServiceLoadBalancerBgpPeer.
```powershell
New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name name -PeerAddress "203.0.113.254" -PeerAsn "64497" -BfdEnabled False -BgpMultiHop False -HoldTime "P300s" -KeepAliveTime "P300s" -MyAsn 64512 -Password passsword -PeerPort 1234
```

```output
BfdEnabled BgpMultiHop HoldTime KeepAliveTime MyAsn Name Password  PeerAddress   PeerAsn PeerPort
---------- ----------- -------- ------------- ----- ---- --------  -----------   ------- --------
False      False       P300s    P300s         64512 name passsword 203.0.113.254 64497   1234
```

Create an in-memory object for ServiceLoadBalancerBgpPeer.

## PARAMETERS

### -BfdEnabled
The indicator of BFD enablement for this BgpPeer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.BfdEnabled
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpMultiHop
The indicator to enable multi-hop peering support.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.BgpMultiHop
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HoldTime
Field Deprecated.
The field was previously optional, now it will have no defined behavior and will be ignored.
The requested BGP hold time value.
This field uses ISO 8601 duration format, for example P1H.

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

### -KeepAliveTime
Field Deprecated.
The field was previously optional, now it will have no defined behavior and will be ignored.
The requested BGP keepalive time value.
This field uses ISO 8601 duration format, for example P1H.

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

### -MyAsn
The autonomous system number used for the local end of the BGP session.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name used to identify this BGP peer for association with a BGP advertisement.

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

### -Password
The authentication password for routers enforcing TCP MD5 authenticated sessions.

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

### -PeerAddress
The IPv4 or IPv6 address used to connect this BGP session.

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

### -PeerAsn
The autonomous system number expected from the remote end of the BGP session.

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

### -PeerPort
The port used to connect this BGP session.

```yaml
Type: System.Int64
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ServiceLoadBalancerBgpPeer

## NOTES

## RELATED LINKS
