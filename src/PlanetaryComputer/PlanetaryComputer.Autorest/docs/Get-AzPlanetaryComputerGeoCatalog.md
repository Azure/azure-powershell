---
external help file:
Module Name: Az.PlanetaryComputer
online version: https://learn.microsoft.com/powershell/module/az.planetarycomputer/get-azplanetarycomputergeocatalog
schema: 2.0.0
---

# Get-AzPlanetaryComputerGeoCatalog

## SYNOPSIS
Get a GeoCatalog

## SYNTAX

### List (Default)
```
Get-AzPlanetaryComputerGeoCatalog [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPlanetaryComputerGeoCatalog -CatalogName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPlanetaryComputerGeoCatalog -InputObject <IPlanetaryComputerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzPlanetaryComputerGeoCatalog -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a GeoCatalog

## EXAMPLES

### Example 1: List all GeoCatalogs in the subscription
```powershell
Get-AzPlanetaryComputerGeoCatalog
```

```output
Name         Location    ResourceGroupName ProvisioningState
----         --------    ----------------- -----------------
mycatalog1   centralus   myResourceGroup   Succeeded
mycatalog2   eastus      testRG            Succeeded
```

Lists all GeoCatalog resources in the current subscription.

### Example 2: Get a specific GeoCatalog by name
```powershell
Get-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog1' -ResourceGroupName 'myResourceGroup'
```

```output
Name         Location    ResourceGroupName ProvisioningState
----         --------    ----------------- -----------------
mycatalog1   centralus   myResourceGroup   Succeeded
```

Gets a specific GeoCatalog resource by catalog name and resource group.

## PARAMETERS

### -CatalogName
The name of the catalog

```yaml
Type: System.String
Parameter Sets: Get
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.IPlanetaryComputerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.IPlanetaryComputerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.IGeoCatalog

## NOTES

## RELATED LINKS

