---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version:
schema: 2.0.0
---

# Get-AzureRmSecureGateway

## SYNOPSIS
Get a Secure Gateway in a resource group

## SYNTAX

```
Get-AzureRmSecureGateway [-ResourceGroupName <String>] [-Name <String>]
```

## DESCRIPTION
The **Get-AzureRmSecureGateway** cmdlet gets one or more Secure Gateways in a resource group.

## EXAMPLES

### 1:  Retrieve all Secure Gateways in a resource group
```
Get-AzureRmSecureGateway -ResourceGroupName "rgName"
```

This example retrieves all Secure Gateways in resource group "rgName".

### 2:  Retrieve a Secure Gateway by name
```
Get-AzureRmSecureGateway -ResourceGroupName "rgName" -Name "secGw"
```

This example retrieves Secure Gateway named "secGw" in resource group "rgName".