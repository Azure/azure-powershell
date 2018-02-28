---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version:
schema: 2.0.0
---

# New-AzureRmSecureGateway

## SYNOPSIS
Creates a Secure Gateway

## SYNTAX

```
New-AzureRmSecureGateway -Name <String> -ResourceGroupName <String> -Location <String>
 [-VirtualNetworkName <String>]
 [-ApplicationRuleCollection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRuleCollection]>]
 [-WorkspaceId <String> -WorkspacePrimaryKey <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSecureGateway** cmdlet creates an Azure Secure Gateway.

## EXAMPLES

### 1:  Create a Secure Gateway attached to a virtual network
```
New-AzureRmSecureGateway -Name "SecGw" -ResourceGroupName "rg" -Location centralus -VirtualNetworkName "vnet"
```

This example creates a secure gateway attached to virtual network "vnet" in the same resource group as the gateway.
Since no rules were specified, gateway will block all traffic (default behavior).
