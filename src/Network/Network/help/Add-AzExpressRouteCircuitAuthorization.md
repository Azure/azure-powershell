---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 9994E2B2-20A1-4E95-9A9F-379B8B63F7F5
online version: https://docs.microsoft.com/powershell/module/az.network/add-azexpressroutecircuitauthorization
schema: 2.0.0
---

# Add-AzExpressRouteCircuitAuthorization

## SYNOPSIS
Adds an ExpressRoute circuit authorization.

## SYNTAX

```
Add-AzExpressRouteCircuitAuthorization -Name <String> -ExpressRouteCircuit <PSExpressRouteCircuit>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzExpressRouteCircuitAuthorization** cmdlet adds an authorization to an ExpressRoute
circuit. ExpressRoute circuits connect your on-premises network to the Microsoft cloud by using a
connectivity provider instead of the public Internet. The owner of an ExpressRoute circuit can
create as many as 10 authorizations for each circuit; these authorizations generate an
authorization key that can be used by a virtual network owner to connect his or her network to the
circuit (one authorization per virtual network). **Add-AzExpressRouteCircuitAuthorization**
adds a new authorization to a circuit and, at the same time, generates the corresponding
authorization key. These keys can be viewed at any time by running the
Get-AzExpressRouteCircuitAuthorization cmdlet and, as needed, can then be copied and forwarded
to the appropriate network owner.
Note that, after running **Add-AzExpressRouteCircuitAuthorization**, you must call the
Set-AzExpressRouteCircuit cmdlet to activate the key. If you do not call
**Set-AzExpressRouteCircuit** the authorization will be added to the circuit but will not be
enabled for use.

## EXAMPLES

### Example 1: Add an authorization to the specified ExpressRoute circuit
```
$Circuit = Get-AzExpressRouteCircuit -Name "ContosoCircuit" -ResourceGroupName "ContosoResourceGroup"
Add-AzExpressRouteCircuitAuthorization -Name "ContosoCircuitAuthorization" -Circuit $Circuit
Set-AzExpressRouteCircuit -ExpressRouteCircuit $Circuit
```

The commands in this example add a new authorization to an existing ExpressRoute circuit. The first
command uses **Get-AzExpressRouteCircuit** to create an object reference to a circuit named
ContosoCircuit. That object reference is stored in a variable named $Circuit.
In the second command, the **Add-AzExpressRouteCircuitAuthorization** cmdlet is used to add a
new authorization (ContosoCircuitAuthorization) to the ExpressRoute circuit. This command adds the
authorization but does not activate that authorization. Activating an authorization requires the
**Set-AzExpressRouteCircuit** shown in the final command in the example.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -ExpressRouteCircuit
Specifies the ExpressRoute circuit that this cmdlet adds the authorization to.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the circuit authorization to be added.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit

## NOTES

## RELATED LINKS

[Get-AzExpressRouteCircuit](./Get-AzExpressRouteCircuit.md)

[Get-AzExpressRouteCircuitAuthorization](./Get-AzExpressRouteCircuitAuthorization.md)

[New-AzExpressRouteCircuitAuthorization](./New-AzExpressRouteCircuitAuthorization.md)

[Remove-AzExpressRouteCircuitAuthorization](./Remove-AzExpressRouteCircuitAuthorization.md)

[Set-AzExpressRouteCircuit](./Set-AzExpressRouteCircuit.md)
