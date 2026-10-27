---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressrouteportauthorizationkey
schema: 2.0.0
---

# Get-AzExpressRoutePortAuthorizationKey

## SYNOPSIS
Gets the authorization key for an ExpressRoute port authorization.

## SYNTAX

### ByName (Default)
```
Get-AzExpressRoutePortAuthorizationKey -ResourceGroupName <String> -ExpressRoutePortName <String>
 -Name <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObject
```
Get-AzExpressRoutePortAuthorizationKey -ExpressRoutePortObject <PSExpressRoutePort> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRoutePortAuthorizationKey** cmdlet retrieves the authorization key for an
authorization on an ExpressRoute port.

The authorization key is a secret and is masked by **Get-AzExpressRoutePortAuthorization**.
This cmdlet performs a live `listKeys` action against the service to return the current
authorization key so that an ExpressRoute circuit owner can consume it.

## EXAMPLES

### Example 1: Get the authorization key by name
```powershell
Get-AzExpressRoutePortAuthorizationKey -ResourceGroupName "ContosoResourceGroup" -ExpressRoutePortName "ContosoPort" -Name "ContosoPortAuthorization"
```

```output
AuthorizationKey
----------------
10d01cd7-0b67-4c44-88ca-51e7effa452d
```

This command returns the authorization key for the authorization named ContosoPortAuthorization
on the ExpressRoute port ContosoPort.

### Example 2: Get the authorization key from a port object
```powershell
$ERPort = Get-AzExpressRoutePort -Name "ContosoPort" -ResourceGroupName "ContosoResourceGroup"
$ERPort | Get-AzExpressRoutePortAuthorizationKey -Name "ContosoPortAuthorization"
```

```output
AuthorizationKey
----------------
10d01cd7-0b67-4c44-88ca-51e7effa452d
```

The first command gets the ExpressRoute port ContosoPort and stores it in the variable $ERPort.
The second command pipes that port to **Get-AzExpressRoutePortAuthorizationKey** to retrieve the
authorization key.

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

### -ExpressRoutePortName
The name of the ExpressRoute port.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: PortName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRoutePortObject
The ExpressRoute port object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePort

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteAuthorizationKey

## NOTES

## RELATED LINKS

[Get-AzExpressRoutePortAuthorization](./Get-AzExpressRoutePortAuthorization.md)

[Add-AzExpressRoutePortAuthorization](./Add-AzExpressRoutePortAuthorization.md)

[Remove-AzExpressRoutePortAuthorization](./Remove-AzExpressRoutePortAuthorization.md)
