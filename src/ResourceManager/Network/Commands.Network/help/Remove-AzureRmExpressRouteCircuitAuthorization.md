---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: 38D57CE4-6994-4BDA-A50E-28680EF4E568
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermexpressroutecircuitauthorization
schema: 2.0.0
---

# Remove-AzureRmExpressRouteCircuitAuthorization

## SYNOPSIS
Removes an existing ExpressRoute configuration authorization.

## SYNTAX

```
Remove-AzureRmExpressRouteCircuitAuthorization [-Name <String>] -ExpressRouteCircuit <PSExpressRouteCircuit>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmExpressRouteCircuitAuthorization** cmdlet removes an authorization assigned to
an ExpressRoute circuit. ExpressRoute circuits connect your on-premises network to Azure by using a
connectivity provider instead of the public Internet. The owner of an ExpressRoute circuit can
create as many as 10 authorizations for each circuit; these authorizations generate an
authorization key that can be used by a virtual network owner to connect his or her network to the
circuit. There can only be one authorization per virtual network. At any time, however, the circuit
owner can use **Remove-AzureRmExpressRouteCircuitAuthorization** to remove the authorization
assigned to a virtual network. When that happens the corresponding virtual network is no longer
able to use the ExpressRoute circuit to connect to Azure.

## EXAMPLES

### Example 1: Remove a circuit authorization from an ExpressRoute circuit
```
$Circuit = Get-AzureRmExpressRouteCircuit -Name "ContosoCircuit" -ResourceGroupName "ContosoResourceGroup"
Remove-AzureRmExpressRouteCircuitAuthorization -Name "ContosoCircuitAuthorization" -Circuit $Circuit
Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $Circuit
```

This example removes a circuit authorization from an ExpressRoute circuit. The first command uses
the **Get-AzureRmExpressRouteCircuit** cmdlet to create an object reference to an ExpressRoute
circuit named ContosoCircuit and stores the result in the variable named $Circuit.

The second command marks the circuit authorization ContosoCircuitAuthorization for removal.

The third command uses the Set-AzureRmExpressRouteCircuit cmdlet to confirm the removal of the
ExpressRoute circuit stored in the $Circuit variable.

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
Specifies the ExpressRouteCircuit object that this cmdlet removes.

```yaml
Type: PSExpressRouteCircuit
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the circuit authorization that this cmdlet removes.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSExpressRouteCircuit
This cmdlet accepts pipelined instances of the
**Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit** object.

## OUTPUTS

### PSExpressRouteCircuit
This cmdlet modifies existing instances of the
**Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit** object.

## NOTES

## RELATED LINKS

[Add-AzureRmExpressRouteCircuitAuthorization](./Add-AzureRmExpressRouteCircuitAuthorization.md)

[Get-AzureRmExpressRouteCircuit](./Get-AzureRmExpressRouteCircuit.md)

[Get-AzureRmExpressRouteCircuitAuthorization](./Get-AzureRmExpressRouteCircuitAuthorization.md)

[New-AzureRmExpressRouteCircuitAuthorization](./New-AzureRmExpressRouteCircuitAuthorization.md)

[Set-AzureRmExpressRouteCircuit](./Set-AzureRmExpressRouteCircuit.md)
