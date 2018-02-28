---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version:
schema: 2.0.0
---

# Remove-AzureRmSecureGateway

## SYNOPSIS
Remove a Secure Gateway

## SYNTAX

```
Remove-AzureRmSecureGateway -ResourceGroupName <String> -Name <String>
```

## DESCRIPTION
The **Remove-AzureRmSecureGateway** cmdlet removes an Azure Secure Gateway.

## EXAMPLES

### 1: Create and delete a secure gateway
```
New-AzureRmSecureGateway -Name "secGw" -ResourceGroupName "rgName" -Location centralus

Remove-AzureRmSecureGateway -Name "secGw" -ResourceGroupName "rgName"
```

This example creates a secure gateway in a resource group and then immediately deletes it. To suppress the prompt when deleting the secure gateway, use the -Force flag.
