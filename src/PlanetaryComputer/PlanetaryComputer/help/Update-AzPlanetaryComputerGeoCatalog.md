---
external help file: Az.PlanetaryComputer-help.xml
Module Name: Az.PlanetaryComputer
online version: https://learn.microsoft.com/powershell/module/az.planetarycomputer/update-azplanetarycomputergeocatalog
schema: 2.0.0
---

# Update-AzPlanetaryComputerGeoCatalog

## SYNOPSIS
Update a GeoCatalog

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPlanetaryComputerGeoCatalog -CatalogName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnableSystemAssignedIdentity <Boolean>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPlanetaryComputerGeoCatalog -InputObject <IPlanetaryComputerIdentity>
 [-EnableSystemAssignedIdentity <Boolean>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a GeoCatalog

## EXAMPLES

### Example 1: Update tags on a GeoCatalog
```powershell
Update-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -Tag @{environment='production'; team='geospatial'}
```

```output
Name        Location    ResourceGroupName ProvisioningState
----        --------    ----------------- -----------------
mycatalog   centralus   myResourceGroup   Succeeded
```

Updates the tags on an existing GeoCatalog resource.

### Example 2: Assign a user-assigned managed identity to a GeoCatalog
```powershell
Update-AzPlanetaryComputerGeoCatalog -CatalogName 'mycatalog' -ResourceGroupName 'myResourceGroup' -UserAssignedIdentity @('/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity')
```

```output
Name        Location    ResourceGroupName ProvisioningState
----        --------    ----------------- -----------------
mycatalog   centralus   myResourceGroup   Succeeded
```

Assigns a user-assigned managed identity to the specified GeoCatalog.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CatalogName
The name of the catalog

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
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
