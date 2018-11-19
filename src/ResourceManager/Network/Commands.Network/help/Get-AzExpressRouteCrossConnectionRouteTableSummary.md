﻿---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 2C603E0E-A19F-4EA6-B918-945007BE22FF
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermexpressroutecrossconnectionroutetablesummary
schema: 2.0.0
---

# Get-AzureRmExpressRouteCrossConnectionRouteTableSummary

## SYNOPSIS
Gets a route table summary of an ExpressRoute cross connection.

## SYNTAX

```
Get-AzureRmExpressRouteCrossConnectionRouteTableSummary -ResourceGroupName <String> -ExpressRouteCrossConnectionName <String>
 [-PeeringType <String>] -DevicePath <DevicePathEnum> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmExpressRouteCrossConnectionRouteTableSummary** cmdlet retrieves a summary of BGP neighbor
information for a particular routing context. This information is useful to determine for how long
a routing context has been established and the number of route prefixes advertised by the peering
router.

## EXAMPLES

### Example 1: Display the route summary for the primary path
```
Get-AzureRmExpressRouteCrossConnectionRouteTableSummary -ResourceGroupName $RG -ExpressRouteCrossConnectionName $CrossConnectionName -DevicePath 'Primary'
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevicePath
The acceptable values for this parameter are: `Primary` or `Secondary`

```yaml
Type: DevicePathEnum
Parameter Sets: (All)
Aliases: 
Accepted values: Primary, Secondary

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCrossConnectionName
The name of the ExpressRoute cross connection being examined.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name, ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PeeringType
The acceptable values for this parameter are: `AzurePrivatePeering`, `AzurePublicPeering`, and
`MicrosoftPeering`

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: AzurePrivatePeering, AzurePublicPeering, MicrosoftPeering

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group containing the ExpressRoute cross connection.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCrossConnectionRoutesTableSummary

## NOTES

## RELATED LINKS

[Get-AzureRmExpressRouteCrossConnectionARPTable](Get-AzureRmExpressRouteCrossConnectionARPTable.md)

[Get-AzureRmExpressRouteCrossConnectionRouteTable](Get-AzureRmExpressRouteCrossConnectionRouteTable.md)