---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: B6E55944-1B78-463F-9FC9-98097FEEC278
online version: https://docs.microsoft.com/powershell/module/az.network/new-azexpressroutecircuitauthorization
schema: 2.0.0
---

# New-AzExpressRouteCircuitAuthorization

## SYNOPSIS
Creates an ExpressRoute circuit authorization.

## SYNTAX

```
New-AzExpressRouteCircuitAuthorization -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzExpressRouteCircuitAuthorization** cmdlet creates a circuit authorization that can
be added to an ExpressRoute circuit. ExpressRoute circuits connect your on-premises network to the
Microsoft cloud by using a connectivity provider instead of the public Internet. The owner of an
ExpressRoute circuit can create as many as 10 authorizations for each circuit; these authorizations
generate an authorization key that can be used by a virtual network owner to connect a network to
the circuit. There can only one authorization per virtual network.
After you create an ExpressRoute circuit you can use
**Add-AzExpressRouteCircuitAuthorization** to add an authorization to that circuit.
Alternatively, you can use **New-AzExpressRouteCircuitAuthorization** to create an
authorization that can be added to a new circuit at the same time the circuit is created.

## EXAMPLES

### Example 1: Create a new circuit authorization
```
$Authorization = New-AzExpressRouteCircuitAuthorization -Name "ContosoCircuitAuthorization"
```

This command creates a new circuit authorization named ContosoCircuitAuthorization and then stores
that object in a variable named $Authorization. Saving the object to a variable is important:
although **New-AzExpressRouteCircuitAuthorization** can create a circuit authorization it
cannot add that authorization to a circuit route. Instead, the variable $Authorization is used
New-AzExpressRouteCircuit when creating a brand-new ExpressRoute circuit.
For more information, see the documentation for the New-AzExpressRouteCircuit cmdlet.

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

### -Name
Specifies a unique name for the new ExpressRoute circuit authorization.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuitAuthorization

## NOTES

## RELATED LINKS

[Add-AzExpressRouteCircuitAuthorization](./Add-AzExpressRouteCircuitAuthorization.md)

[Get-AzExpressRouteCircuitAuthorization](./Get-AzExpressRouteCircuitAuthorization.md)

[Remove-AzExpressRouteCircuitAuthorization](./Remove-AzExpressRouteCircuitAuthorization.md)

