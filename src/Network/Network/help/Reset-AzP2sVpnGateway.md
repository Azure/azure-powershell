---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 443F6492-EFA7-4417-943A-3A8D47F8C83C
online version: https://docs.microsoft.com/powershell/module/az.network/reset-azp2svpngateway
schema: 2.0.0
---

# Reset-AzP2sVpnGateway

## SYNOPSIS
Resets the scalable P2S VPN gateway.

## SYNTAX

### ByP2SVpnGatewayName (Default)
```
Reset-AzP2sVpnGateway -ResourceGroupName <String> -Name <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnGatewayObject
```
Reset-AzP2sVpnGateway -InputObject <PSP2SVpnGateway> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnGatewayResourceId
```
Reset-AzP2sVpnGateway -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resets the P2SVpnGateway

## EXAMPLES

### Example 1:
```powershell
$Gateway = Get-AzP2sVpnGateway -Name "ContosoVirtualGateway" -ResourceGroupName "RGName"
Reset-AzP2sVpnGateway -P2SVpnGateway $Gateway
```

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnGateway

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSP2SVpnGateway

## NOTES

## RELATED LINKS

[Get-AzP2sVpnGateway](./Get-AzP2sVpnGateway.md)

[New-AzP2sVpnGateway](./New-AzP2sVpnGateway.md)

[Remove-AzP2sVpnGateway](./Remove-AzP2sVpnGateway.md)

[Update-AzP2sVpnGateway](./Update-AzP2sVpnGateway.md)
