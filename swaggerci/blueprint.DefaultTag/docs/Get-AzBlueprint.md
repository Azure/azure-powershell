---
external help file:
Module Name: Az.Blueprint
online version: https://learn.microsoft.com/powershell/module/az.blueprint/get-azblueprint
schema: 2.0.0
---

# Get-AzBlueprint

## SYNOPSIS
Get a blueprint definition.

## SYNTAX

### List (Default)
```
Get-AzBlueprint -ResourceScope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzBlueprint -Name <String> -ResourceScope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBlueprint -InputObject <IBlueprintIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a blueprint definition.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Models.IBlueprintIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the blueprint definition.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BlueprintName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceScope
The scope of the resource.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}').

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Models.IBlueprintIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Models.Api20181101Preview.IBlueprint

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IBlueprintIdentity>`: Identity Parameter
  - `[ArtifactName <String>]`: Name of the blueprint artifact.
  - `[AssignmentName <String>]`: Name of the blueprint assignment.
  - `[AssignmentOperationName <String>]`: Name of the blueprint assignment operation.
  - `[BlueprintName <String>]`: Name of the blueprint definition.
  - `[Id <String>]`: Resource identity path
  - `[ResourceScope <String>]`: The scope of the resource. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}').
  - `[VersionId <String>]`: Version of the published blueprint definition.

## RELATED LINKS

