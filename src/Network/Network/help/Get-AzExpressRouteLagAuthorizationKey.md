---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutelagauthorizationkey
schema: 2.0.0
---

# Get-AzExpressRouteLagAuthorizationKey

## SYNOPSIS
Gets the key for an ExpressRoute link aggregation group authorization.

## SYNTAX

### ByName (Default)
```
Get-AzExpressRouteLagAuthorizationKey -ResourceGroupName <String> -ExpressRouteLagName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObject
```
Get-AzExpressRouteLagAuthorizationKey -ExpressRouteLagObject <PSExpressRouteLag> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteLagAuthorizationKey** cmdlet gets the key for an authorization on an ExpressRoute link aggregation group (LAG).
The authorization key is a secret and is retrieved through the service's `listKeys` operation.

## EXAMPLES

### Example 1
```powershell
$key = Get-AzExpressRouteLagAuthorizationKey -ResourceGroupName "TestResourceGroup" -ExpressRouteLagName "TestLag" -Name "TestAuthorization"
```

This example gets the key for the authorization named `TestAuthorization` on the ExpressRoute LAG named `TestLag`.

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

### -ExpressRouteLagName
The name of the ExpressRoute LAG.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: LagName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteLagObject
The ExpressRoute LAG object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteAuthorizationKey

## NOTES

## RELATED LINKS
