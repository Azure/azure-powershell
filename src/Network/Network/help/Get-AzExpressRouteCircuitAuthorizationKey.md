---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutecircuitauthorizationkey
schema: 2.0.0
---

# Get-AzExpressRouteCircuitAuthorizationKey

## SYNOPSIS
Gets the authorization key for an ExpressRoute circuit authorization.

## SYNTAX

### ByName (Default)
```
Get-AzExpressRouteCircuitAuthorizationKey -ResourceGroupName <String> -CircuitName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObject
```
Get-AzExpressRouteCircuitAuthorizationKey -ExpressRouteCircuit <PSExpressRouteCircuit> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteCircuitAuthorizationKey** cmdlet retrieves the authorization key for an
authorization on an ExpressRoute circuit.

The authorization key is a secret and is masked by **Get-AzExpressRouteCircuitAuthorization**.
This cmdlet performs a live `listKeys` action against the service to return the current
authorization key so that an ExpressRoute connection owner can consume it.

## EXAMPLES

### Example 1: Get the authorization key by name
```powershell
Get-AzExpressRouteCircuitAuthorizationKey -ResourceGroupName "ContosoResourceGroup" -CircuitName "ContosoCircuit" -Name "ContosoCircuitAuthorization"
```

```output
AuthorizationKey
----------------
10d01cd7-0b67-4c44-88ca-51e7effa452d
```

This command returns the authorization key for the authorization named ContosoCircuitAuthorization
on the ExpressRoute circuit ContosoCircuit.

### Example 2: Get the authorization key from a circuit object
```powershell
$circuit = Get-AzExpressRouteCircuit -Name "ContosoCircuit" -ResourceGroupName "ContosoResourceGroup"
$circuit | Get-AzExpressRouteCircuitAuthorizationKey -Name "ContosoCircuitAuthorization"
```

```output
AuthorizationKey
----------------
10d01cd7-0b67-4c44-88ca-51e7effa452d
```

The first command gets the ExpressRoute circuit ContosoCircuit and stores it in the variable
$circuit. The second command pipes that circuit to
**Get-AzExpressRouteCircuitAuthorizationKey** to retrieve the authorization key.

## PARAMETERS

### -CircuitName
The name of the ExpressRoute circuit.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ExpressRouteCircuitName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ExpressRouteCircuit
The ExpressRoute circuit object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteCircuit
Parameter Sets: ByParentObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the authorization.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AuthorizationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteAuthorizationKey

## NOTES

## RELATED LINKS

[Get-AzExpressRouteCircuitAuthorization](./Get-AzExpressRouteCircuitAuthorization.md)

[Add-AzExpressRouteCircuitAuthorization](./Add-AzExpressRouteCircuitAuthorization.md)

[Remove-AzExpressRouteCircuitAuthorization](./Remove-AzExpressRouteCircuitAuthorization.md)
