---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 3D80F94B-AF9D-40C2-BE7E-2F32E5E926D2
online version: https://docs.microsoft.com/powershell/module/az.network/get-azexpressroutecircuitauthorization
schema: 2.0.0
---

# Get-AzExpressRouteCircuitAuthorization

## SYNOPSIS
Gets information about ExpressRoute circuit authorizations.

## SYNTAX

```
Get-AzExpressRouteCircuitAuthorization [-Name <String>] -ExpressRouteCircuit <PSExpressRouteCircuit>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteCircuitAuthorization** cmdlet gets information about the
authorizations assigned to an ExpressRoute circuit. ExpressRoute circuits connect your on-premises
network to the Microsoft cloud by using a connectivity provider instead of the public Internet. The
owner of an ExpressRoute circuit can create as many as 10 authorizations for each circuit; these
authorizations generate an authorization key that can be used by a virtual network owner to connect
his or her network to the circuit (one authorization per virtual network). Authorization keys, as
well as other information about the authorization, can be viewed at any time by running
**Get-AzExpressRouteCircuitAuthorization**.

## EXAMPLES

### Example 1: Get all ExpressRoute authorizations
```
$Circuit = Get-AzExpressRouteCircuit -Name "ContosoCircuit" -ResourceGroupName "ContosoResourceGroup"
Get-AzExpressRouteCircuitAuthorization -Circuit $Circuit
```

These commands return information about all the ExpressRoute authorizations associated with an
ExpressRoute circuit. The first command uses the **Get-AzExpressRouteCircuit** cmdlet to
create an object reference a circuit named ContosoCircuit; that object reference is stored in the
variable $Circuit. The second command then uses that object reference and the
**Get-AzExpressRouteCircuitAuthorization** cmdlet to return information about the
authorizations associated with ContosoCircuit.

### Example 2: Get all ExpressRoute authorizations using the Where-Object cmdlet
```
$Circuit = Get-AzExpressRouteCircuit -Name "ContosoCircuit" -ResourceGroupName "ContosoResourceGroup"
 Get-AzExpressRouteCircuitAuthorization -Circuit $Circuit | Where-Object {$_.AuthorizationUseStatus -eq "Available"}
```

These commands represent a variation on the commands used in Example 1. In this case, however,
information is returned only for those authorizations that are available for use (that is, for
authorizations that have not been assigned to a virtual network). To do this, the circuit
authorization information is returned in command 2 and is piped to the **Where-Object** cmdlet.
**Where-Object** then picks out only those authorizations where the *AuthorizationUseStatus*
property is set to Available. To list only those authorizations that are not available, use this
syntax for the Where clause:
`{$_.AuthorizationUseStatus -ne "Available"}`

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
Specifies the ExpressRoute circuit authorization.

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
Specifies the name of the ExpressRoute circuit authorization that this cmdlet gets.
-Name "ContosoCircuitAuthorization"

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuitAuthorization

## NOTES

## RELATED LINKS

[Add-AzExpressRouteCircuitAuthorization](./Add-AzExpressRouteCircuitAuthorization.md)

[Get-AzExpressRouteCircuit](./Get-AzExpressRouteCircuit.md)

[New-AzExpressRouteCircuitAuthorization](./New-AzExpressRouteCircuitAuthorization.md)

[Remove-AzExpressRouteCircuitAuthorization](./Remove-AzExpressRouteCircuitAuthorization.md)
