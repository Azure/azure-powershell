---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 59692f1f-9f1e-4a3c-8200-312c3806a9b7
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermexpressroutecircuitconnectionconfig
schema: 2.0.0
---

# Get-AzureRmExpressRouteCircuitConnectionConfig

## SYNOPSIS
Gets an ExpressRoute circuit connection configuration associated with Private Peering of ExpressRouteCircuit.

## SYNTAX

```
Get-AzureRmExpressRouteCircuitConnectionConfig [-Name] <String> [-ExpressRouteCircuit] <PSExpressRouteCircuit>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmExpressRouteCircuitConnectionConfig** cmdlet retrieves the configuration of a circuit connection
associated with Private Peering for an ExpressRoute circuit.

## EXAMPLES

### Example 1: Display the circuit connection configuration for an ExpressRoute circuit
```
$circuit_init = Get-AzureRmExpressRouteCircuit -Name $initiatingCircuitName -ResourceGroupName $rg
Get-AzureRmExpressRouteCircuitConnectionConfig -Name $circuitConnectionName -ExpressRouteCircuit $circuit_init
```

### Example 2: Get circuit connection resource associated with an ExpressRoute Circuit using piping
```
Get-AzureRmExpressRouteCircuit -Name $initiatingCircuitName -ResourceGroupName $rg|Get-AzureRmExpressRouteCircuitConnectionConfig -Name $circuitConnectionName
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

### -ExpressRouteCircuit
The ExpressRoute circuit object containing the circuit connection configuration.

```yaml
Type: PSExpressRouteCircuit
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the circuit connection configuration to be retrieved.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSExpressRouteCircuit
Parameter 'ExpressRouteCircuit' accepts value of type 'PSExpressRouteCircuit' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuitConnection

## NOTES

## RELATED LINKS

[Get-AzureRmExpressRouteCircuit](Get-AzureRmExpressRouteCircuit.md)

[Add-AzureRmExpressRouteCircuitConnectionConfig](Add-AzureRmExpressRouteCircuitConnectionConfig.md)

[Remove-AzureRmExpressRouteCircuitConnectionConfig](Remove-AzureRmExpressRouteCircuitConnectionConfig.md)

[Set-AzureRmExpressRouteCircuitConnectionConfig](Set-AzureRmExpressRouteCircuitConnectionConfig.md)

[New-AzureRmExpressRouteCircuitConnectionConfig](New-AzureRmExpressRouteCircuitConnectionConfig.md)