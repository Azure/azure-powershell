---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 2D882B33-2B62-4785-AF8F-5F4644E9504D
online version: 
schema: 2.0.0
---

# Remove-AzureRmRoleDefinition

## SYNOPSIS
Deletes a custom role in Azure RBAC.
The role to be deleted is specified using the Id property of the role.
Delete will fail if there are existing role assignments made to the custom role.

## SYNTAX

### RoleDefinitionIdParameterSet (Default)
```
Remove-AzureRmRoleDefinition -Id <Guid> [-Scope <String>] [-Force] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RoleDefinitionNameParameterSet
```
Remove-AzureRmRoleDefinition [-Name] <String> [-Scope <String>] [-Force] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzureRmRoleDefinition cmdlet deletes a custom role in Azure Role-Based Access Control.
        Provide the Id parameter of an existing custom role to delete that custom role.
By default, Remove-AzureRmRoleDefinition prompts you for confirmation.
To suppress the prompt, use the Force parameter.
If there are existing role assignments made to the custom role to be deleted, the delete will fail.

## EXAMPLES

### --------------------------  Example 1  --------------------------
```
Get-AzureRmRoleDefinition -Name "Virtual Machine Operator" | Remove-AzureRmRoleDefinition
```

### --------------------------  Example 2  --------------------------
```
Remove-AzureRmRoleDefinition -Id "52a6cc13-ff92-47a8-a39b-2a8205c3087e"
```

## PARAMETERS

### -Force
If set, does not prompt for a confirmation before deleting the custom role

```yaml
Type: SwitchParameter
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
Type: Guid
Parameter Sets: RoleDefinitionIdParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of the Role definition to be deleted.

```yaml
Type: String
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
Type: SwitchParameter
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
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[New-AzureRmRoleDefinition]()

[Get-AzureRmRoleDefinition]()

[Set-AzureRmRoleDefinition]()

