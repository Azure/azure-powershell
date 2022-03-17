---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azexpressrouteportauthorization
schema: 2.0.0
---

# Get-AzExpressRoutePortAuthorization

## SYNOPSIS
Gets information about ExpressRoutePort authorizations.

## SYNTAX

```
Get-AzExpressRoutePortAuthorization [-Name <String>] -ExpressRoutePort <PSExpressRoutePort>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRoutePortAuthorization** cmdlet gets information about the
authorizations assigned to an ExpressRoutePort.  The owner of an ExpressRoutePort
can create these authorizations which generate an authorization key that can be 
used by a ExpressRoute circuit owner to create the circuit on the ExpressRoutePort 
(with a different owner). Only one circuit can be created with one ExpressRoutePort
authorization. Authorization keys, as well as other information about 
the authorization, can be viewed at any time by running
**Get-AzExpressRoutePortAuthorization**.

## EXAMPLES

### Example 1
```powershell
$ERPort = Get-AzExpressRoutePort -Name "ContosoPort" -ResourceGroupName "ContosoResourceGroup"
Get-AzExpressRoutePortAuthorization -ExpressRoutePort $ERPort
```

These commands return information about all the ExpressRoute authorizations associated with an
ExpressRoutePort. The first command uses the **Get-AzExpressRoutePort** cmdlet to
create an object reference a ExpressRoutePort named ContosoPort; that object reference is stored in the
variable $ERPort. The second command then uses that object reference and the
**Get-AzExpressRoutePortAuthorization** cmdlet to return information about the
authorizations associated with ContosoPort. You can also specify the name of the authorization
with this command to a specific authorization associated with ContosoPort.

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

### -ExpressRoutePort
Specifies the ExpressRoutePort object that this cmdlet gets the authorization from.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the ExpressRoutePort authorization that this cmdlet gets.

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

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePortAuthorization

## NOTES

## RELATED LINKS

[Add-AzExpressRoutePortAuthorization](./Add-AzExpressRoutePortAuthorization.md)

[Remove-AzExpressRoutePortAuthorization](./Remove-AzExpressRoutePortAuthorization.md)
