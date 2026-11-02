---
external help file:
Module Name: Az.PlanetaryComputer
online version: https://learn.microsoft.com/powershell/module/az.planetarycomputer/get-azplanetarycomputergeocatalogprivatelink
schema: 2.0.0
---

# Get-AzPlanetaryComputerGeoCatalogPrivateLink

## SYNOPSIS
List private links on the given resource

## SYNTAX

```
Get-AzPlanetaryComputerGeoCatalogPrivateLink -CatalogName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List private links on the given resource

## EXAMPLES

### Example 1: List the private-link resources supported by a GeoCatalog
```powershell
Get-AzPlanetaryComputerGeoCatalogPrivateLink -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog"
```

Lists the supported private-link group, required members, and private DNS zones.

## PARAMETERS

### -CatalogName
The name of the catalog

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.IPrivateLinkResource

## NOTES

## RELATED LINKS
