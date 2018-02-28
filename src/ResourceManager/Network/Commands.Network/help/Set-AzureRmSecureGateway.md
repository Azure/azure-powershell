---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version:
schema: 2.0.0
---

# Set-AzureRmSecureGateway

## SYNOPSIS
Updates a Secure Gateway

## SYNTAX

```
Set-AzureRmSecureGateway -SecureGateway <Microsoft.Azure.Commands.Network.Models.PSSecureGateway>
```

## DESCRIPTION
The **Set-AzureRmSecureGateway** cmdlet updates an Azure Secure Gateway.

## EXAMPLES

### 1:  Update a Secure Gateway rule priority
```
$secGw = Get-AzureRmSecureGateway -Name "SecGw" -ResourceGroupName "rg"
$ruleCollection = $secGw.GetApplicationRuleCollectionByName("ruleCollectionName")
$rule = $ruleCollection.GetRuleByName("ruleName")
$rule.Priority = 101
Set-AzureRmSecureGateway -SecureGateway $secGw
```

This example updates the priority of an existing rule of a secure gateway.
Assuming Secure Gateway "SecGw" in resource group "rg" contains an application rule named "ruleName" inside
an application rule collection named "ruleCollectionName", commands above will change the priority of that rule
and update the Secure Gateway afterwards.
Without the Set-AzureRmSecureGateway command, all operations performed on the local $secGw object are not reflected
on the server.
