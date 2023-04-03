---
external help file:
Module Name: Az.Blueprint
online version: https://learn.microsoft.com/powershell/module/az.blueprint/remove-azblueprintassignment
schema: 2.0.0
---

# Remove-AzBlueprintAssignment

## SYNOPSIS
Delete a blueprint assignment.

## SYNTAX

### Delete (Default)
```
Remove-AzBlueprintAssignment -Name <String> -ResourceScope <String>
 [-DeleteBehavior <AssignmentDeleteBehavior>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzBlueprintAssignment -InputObject <IBlueprintIdentity> [-DeleteBehavior <AssignmentDeleteBehavior>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Delete a blueprint assignment.

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

### -DeleteBehavior
When deleteBehavior=all, the resources that were created by the blueprint assignment will be deleted.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Support.AssignmentDeleteBehavior
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Models.IBlueprintIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the blueprint assignment.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: AssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceScope
The scope of the resource.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}').

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Models.IBlueprintIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Models.Api20181101Preview.IAssignment

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

