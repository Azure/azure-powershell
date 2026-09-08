---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azexpressroutelagidentity
schema: 2.0.0
---

# Get-AzExpressRouteLagIdentity

## SYNOPSIS
Get identity assigned to an ExpressRouteLag.

## SYNTAX

```
Get-AzExpressRouteLagIdentity -ExpressRouteLag <PSExpressRouteLag>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRouteLagIdentity** cmdlet gets identity assigned to a local Azure ExpressRouteLag object.

## EXAMPLES

### Example 1
```powershell
$rgName = "MyResourceGroup"
$exrLagName = "MyExpressRouteLag"
$exrLag = Get-AzExpressRouteLag -Name $exrLagName -ResourceGroupName $rgName
$identity = Get-AzExpressRouteLagIdentity -ExpressRouteLag $exrLag
```

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

### -ExpressRouteLag
The ExpressRoute LAG

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteLag

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSManagedServiceIdentity

## NOTES

## RELATED LINKS

[Set-AzExpressRouteLagIdentity](./Set-AzExpressRouteLagIdentity.md)

[New-AzExpressRouteLagIdentity](./New-AzExpressRouteLagIdentity.md)

[Remove-AzExpressRouteLagIdentity](./Remove-AzExpressRouteLagIdentity.md)
