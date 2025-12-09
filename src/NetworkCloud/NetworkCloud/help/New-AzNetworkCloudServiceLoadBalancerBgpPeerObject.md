---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudserviceloadbalancerbgppeerobject
schema: 2.0.0
---

# New-AzNetworkCloudServiceLoadBalancerBgpPeerObject

## SYNOPSIS
Create an in-memory object for ServiceLoadBalancerBgpPeer.

## SYNTAX

```
New-AzNetworkCloudServiceLoadBalancerBgpPeerObject [-BfdEnabled <String>] [-BgpMultiHop <String>]
 [-HoldTime <String>] [-KeepAliveTime <String>] [-MyAsn <Int64>] [-Name <String>] [-Password <String>]
 [-PeerAddress <String>] [-PeerAsn <Int64>] [-PeerPort <Int64>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceLoadBalancerBgpPeer.

## EXAMPLES

### Example 1: Create service load balancer BGP peer with basic configuration
```powershell
New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name "peer1" -PeerAddress "192.168.1.1" -PeerAsn 65000 -MyAsn 65001 -BfdEnabled "True"
```

```output
BfdEnabled      : True
BgpMultiHop     : 
HoldTime        : 
KeepAliveTime   : 
MyAsn           : 65001
Name            : peer1
Password        : 
PeerAddress     : 192.168.1.1
PeerAsn         : 65000
PeerPort        : 
```

This example creates a BGP peer configuration for service load balancer with BFD enabled.

### Example 2: Create service load balancer BGP peer with multi-hop support
```powershell
New-AzNetworkCloudServiceLoadBalancerBgpPeerObject -Name "peer2" -PeerAddress "10.0.0.5" -PeerAsn 64512 -MyAsn 65001 -BgpMultiHop "True" -PeerPort 179
```

```output
BfdEnabled      : 
BgpMultiHop     : True
HoldTime        : 
KeepAliveTime   : 
MyAsn           : 65001
Name            : peer2
Password        : 
PeerAddress     : 10.0.0.5
PeerAsn         : 64512
PeerPort        : 179
```

This example creates a BGP peer with multi-hop support enabled and custom peer port.

## PARAMETERS

### -BfdEnabled
The indicator of BFD enablement for this BgpPeer.

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

### -BgpMultiHop
The indicator to enable multi-hop peering support.

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

Required: False
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

Required: False
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

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ServiceLoadBalancerBgpPeer

## NOTES

## RELATED LINKS
