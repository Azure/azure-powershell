---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version:
schema: 2.0.0
---

# New-AzureRmVirtualNetwork

## SYNOPSIS
Creates a Secure Gateway Application Rule.

## SYNTAX

```
New-AzureRmSecureGatewayApplicationRule -Name <String> -Priority <Integer> [-Description <String>]
 -Protocol <System.Collections.Generic.List`1[System.String]>
 -TargetFqdn <System.Collections.Generic.List`1[System.String]>
 -ActionType <String> [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSecureGatewayApplicationRule** cmdlet creates an application rule for Azure Secure Gateway.

## EXAMPLES

### 1:  Create a rule to allow all HTTPS traffic
```
New-AzureRmSecureGatewayApplicationRule -Name "AllowHTTPS" -Priority 100 -Protocol "https" -TargetFqdn "*" -ActionType "allow"
```

This example creates a rule which will allow all HTTPS traffic.
The default rule is to deny all traffic, so, if this is the only existing rule of a Secure Gateway, all other traffic will be blocked.

### 2:  Allow *.msn.com, but deny *.site.msn.com for HTTP traffic
```
New-AzureRmSecureGatewayApplicationRule -Name "AllowMsnHttp" -Priority 100 -Protocol "http" -TargetFqdn "*.msn.com" -ActionType "allow"
New-AzureRmSecureGatewayApplicationRule -Name "BlockMsnSiteHttp" -Priority 90 -Protocol "http" -TargetFqdn "*.site.msn.com" -ActionType "deny"
```

This example evidentiates the importance of priority for a rule.
If first rule would have a bigger priority (smaller number), all MSN traffic will match it, including the traffic for *.site.msn.com.
By giving the subdomain rule a bigger priority, we are sure traffic will match it first and thus deny it.
