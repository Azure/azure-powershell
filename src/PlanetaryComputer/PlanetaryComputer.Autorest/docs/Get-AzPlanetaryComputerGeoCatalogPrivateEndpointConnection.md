---
external help file:
Module Name: Az.PlanetaryComputer
online version: https://learn.microsoft.com/powershell/module/az.planetarycomputer/get-azplanetarycomputergeocatalogprivateendpointconnection
schema: 2.0.0
---

# Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection

## SYNOPSIS
Get a specific private connection

## SYNTAX

### List (Default)
```
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -CatalogName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -CatalogName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -InputObject <IPlanetaryComputerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityGeoCatalog
```
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -GeoCatalogInputObject <IPlanetaryComputerIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a specific private connection

## EXAMPLES

### Example 1: List a GeoCatalog's private-endpoint connections
```powershell
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog"
```

Lists the private-endpoint connections associated with the GeoCatalog.

### Example 2: Get one private-endpoint connection
```powershell
Get-AzPlanetaryComputerGeoCatalogPrivateEndpointConnection -ResourceGroupName "myResourceGroup" -CatalogName "myGeoCatalog" -Name "myConnection"
```

Gets the named connection and its approval state.

## PARAMETERS

### -CatalogName
The name of the catalog

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -GeoCatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.IPlanetaryComputerIdentity
Parameter Sets: GetViaIdentityGeoCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
The name of the private endpoint connection associated with the Azure resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityGeoCatalog
Aliases: PrivateEndpointConnectionName

Required: True
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.PlanetaryComputer.Models.IPrivateEndpointConnection

## NOTES

## RELATED LINKS
