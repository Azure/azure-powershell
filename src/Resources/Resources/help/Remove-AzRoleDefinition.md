---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 2D882B33-2B62-4785-AF8F-5F4644E9504D
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azroledefinition
schema: 2.0.0
---

# Remove-AzRoleDefinition

## SYNOPSIS
Deletes a custom role in Azure RBAC.
The role to be deleted is specified using the Id property of the role.
Delete will fail if there are existing role assignments made to the custom role.

## SYNTAX

### RoleDefinitionIdParameterSet (Default)
```
Remove-AzRoleDefinition -Id <Guid> [-Scope <String>] [-SkipClientSideScopeValidation] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RoleDefinitionNameParameterSet
```
Remove-AzRoleDefinition [-Name] <String> [-Scope <String>] [-SkipClientSideScopeValidation] [-Force]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzRoleDefinition -InputObject <PSRoleDefinition> [-SkipClientSideScopeValidation] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzRoleDefinition cmdlet deletes a custom role in Azure Role-Based Access Control.
Provide the Id parameter of an existing custom role to delete that custom role.
By default, Remove-AzRoleDefinition prompts you for confirmation.
To suppress the prompt, use the Force parameter.
If there are existing role assignments made to the custom role to be deleted, the delete will fail.

When using the -PassThru parameter, the cmdlet returns the deleted PSRoleDefinition object.
The returned object contains a Permissions collection with Actions, NotActions, DataActions, NotDataActions, and any Attribute-Based Access Control (ABAC) conditions (Condition and ConditionVersion) for each permission entry.

## EXAMPLES

### Example 1: Remove a custom role by piping from Get-AzRoleDefinition
```powershell
Get-AzRoleDefinition -Name "Virtual Machine Operator" | Remove-AzRoleDefinition
```

Retrieves the "Virtual Machine Operator" custom role and pipes it to Remove-AzRoleDefinition for deletion.
You will be prompted for confirmation before the role is deleted.

### Example 2: Remove a custom role by Id
```powershell
Remove-AzRoleDefinition -Id "00001111-aaaa-2222-bbbb-3333cccc4444"
```

Deletes the custom role with the specified Id. You will be prompted for confirmation.

### Example 3: Remove a custom role without confirmation
```powershell
Remove-AzRoleDefinition -Name "Custom Reader Role" -Force
```

Deletes the custom role named "Custom Reader Role" without prompting for confirmation.

### Example 4: Remove and return the deleted role definition
```powershell
$deletedRole = Remove-AzRoleDefinition -Name "Custom Writer Role" -Force -PassThru
$deletedRole.Permissions[0].Actions
```

Deletes the role and returns the PSRoleDefinition object, then displays the actions from the first permission entry.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -Force
If set, does not prompt for a confirmation before deleting the custom role

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

### -Id
Id of the Role definition to be deleted

```yaml
Type: System.Guid
Parameter Sets: RoleDefinitionIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The object representing the role definition to be removed.

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Role definition to be deleted.

```yaml
Type: System.String
Parameter Sets: RoleDefinitionNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
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

### -Scope
Role definition scope.

```yaml
Type: System.String
Parameter Sets: RoleDefinitionIdParameterSet, RoleDefinitionNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipClientSideScopeValidation
If specified, skip client side scope validation.

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

### System.Guid

### System.String

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition

## OUTPUTS

### System.Boolean

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[New-AzRoleDefinition](./New-AzRoleDefinition.md)

[Get-AzRoleDefinition](./Get-AzRoleDefinition.md)

[Set-AzRoleDefinition](./Set-AzRoleDefinition.md)
