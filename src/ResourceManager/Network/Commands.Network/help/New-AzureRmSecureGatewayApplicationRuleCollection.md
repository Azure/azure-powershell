---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version:
schema: 2.0.0
---

# New-AzureRmSecureGatewayApplicationRuleCollection

## SYNOPSIS
Creates a collection of Secure Gateway rules.

## SYNTAX

```
New-AzureRmSecureGatewayApplicationRuleCollection -Name <String> -Priority <Integer>
 -Rule <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRule]>
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSecureGatewayApplicationRuleCollection** cmdlet creates a collection of Secure Gateway Application Rules.

## EXAMPLES

### 1:  Create a collection of two rules
```
$rule1 = New-AzureRmSecureGatewayApplicationRule -Name "Deny abc" -Priority 100 -Protocol "https" -TargetFqdn "*.abc" -ActionType "deny"
$rule2 = New-AzureRmSecureGatewayApplicationRule -Name "AllowAll" -Priority 1000 -Protocol "https" -TargetFqdn "*" -ActionType "allow"
New-AzureRmSecureGatewayApplicationRuleCollection -Name "MyCollection" -Priority 1000 -Rule $rule1,$rule2
```

This example creates a collection with 2 rules.
The first rule (which has a bigger priority - smaller number) will deny all traffic to *.abc domains.
The second rule (which only applies if traffic was not filtered by the first rule) will allow all HTTPS traffic.
