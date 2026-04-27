---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azdenyassignment
schema: 2.0.0
---

# Remove-AzDenyAssignment

## SYNOPSIS
Removes a user-assigned deny assignment at the specified scope.

## SYNTAX

### DenyAssignmentIdParameterSet (Default)
```
Remove-AzDenyAssignment -Id <String> [-Scope <String>] [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DenyAssignmentNameAndScopeParameterSet
```
Remove-AzDenyAssignment -DenyAssignmentName <String> -Scope <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzDenyAssignment [-InputObject] <PSDenyAssignment> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Use the Remove-AzDenyAssignment command to remove a user-assigned deny assignment.
The deny assignment can be identified by its ID, by display name and scope, or by piping a PSDenyAssignment object from Get-AzDenyAssignment.

## EXAMPLES

### Example 1: Remove a deny assignment by ID
```powershell
Remove-AzDenyAssignment -Id "/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.Authorization/denyAssignments/11111111-1111-1111-1111-111111111111" -Force
```

Removes the deny assignment with the specified fully qualified ID.

### Example 2: Remove a deny assignment by name and scope
```powershell
Remove-AzDenyAssignment -DenyAssignmentName "Block deletes" `
    -Scope "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG" -Force
```

Removes the deny assignment named "Block deletes" at the specified resource group scope.

### Example 3: Remove a deny assignment using pipeline
```powershell
Get-AzDenyAssignment -DenyAssignmentName "Block writes" -Scope "/subscriptions/00000000-0000-0000-0000-000000000000" | Remove-AzDenyAssignment -Force -PassThru
```

Gets and removes the specified deny assignment using the pipeline.

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

### -DenyAssignmentName
The display name of the deny assignment to remove.

```yaml
Type: System.String
Parameter Sets: DenyAssignmentNameAndScopeParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Fully qualified deny assignment ID including scope, or just the GUID. When provided as a GUID, the current subscription scope is used.

```yaml
Type: System.String
Parameter Sets: DenyAssignmentIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Deny assignment object from Get-AzDenyAssignment.

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.Authorization.PSDenyAssignment
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
If specified, returns the deleted deny assignment.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope of the deny assignment. In the format of relative URI.

```yaml
Type: System.String
Parameter Sets: DenyAssignmentIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DenyAssignmentNameAndScopeParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSDenyAssignment

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSDenyAssignment
When the -PassThru parameter is specified, returns the deleted deny assignment object. Otherwise, this cmdlet does not generate any output.

## NOTES

## RELATED LINKS

[Get-AzDenyAssignment](./Get-AzDenyAssignment.md)

[New-AzDenyAssignment](./New-AzDenyAssignment.md)
