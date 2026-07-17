---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azallvirtualnetworkgatewayradiusserversecret
schema: 2.0.0
---

# Get-AzAllVirtualNetworkGatewayRadiusServerSecret

## SYNOPSIS
Lists the Radius servers and corresponding radius secrets set on VirtualNetworkGateway PointToSite VpnClientConfiguration.

## SYNTAX

```
Get-AzAllVirtualNetworkGatewayRadiusServerSecret -Name <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Fetches the Radius servers and corresponding radius secrets list set on VirtualNetworkGateway PointToSite VpnClientConfiguration.

## EXAMPLES

### Example 1
```powershell
Get-AzAllVirtualNetworkGatewayRadiusServerSecret -ResourceGroupName resourceGroup -Name gatewayName
```

```output
RadiusServerAddress : 1.1.1.1
RadiusServerSecret  : ****

RadiusServerAddress : 2.2.2.2
RadiusServerSecret  : ****
```

For the Azure virtual network gateway named gatewayname in resource group resourceGroup, retrieves the list of Radius servers and corresponding radius secrets set on VpnClientConfiguration.
The Azure virtual network gateway in this case has two radius servers set(1.1.1.1,2.2.2.2), and it returns set corresponding radius secrets as well.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRadiusAuthServer

## NOTES

## RELATED LINKS
