---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 7740AC3B-F643-4F8D-8DC5-ACBF59323BD8
online version: 
schema: 2.0.0
---

# Get-AzureRmRoleDefinition

## SYNOPSIS
Lists all Azure RBAC roles that are available for assignment.

## SYNTAX

### RoleDefinitionNameParameterSet
```
Get-AzureRmRoleDefinition [[-Name] <String>] [-Scope <String>] [-AtScopeAndBelow] [<CommonParameters>]
```

### RoleDefinitionIdParameterSet
```
Get-AzureRmRoleDefinition -Id <Guid> [-Scope <String>] [<CommonParameters>]
```

### RoleDefinitionCustomParameterSet
```
Get-AzureRmRoleDefinition [-Scope <String>] [-Custom] [-AtScopeAndBelow] [<CommonParameters>]
```

## DESCRIPTION
Use the Get-AzureRmRoleDefinition command with a particular role name to view its details.
To inspect individual operations that a role grants access to, review the Actions and NotActions properties of the role.

## EXAMPLES

### --------------------------  Example 1  --------------------------
```
PS C:\> Get-AzureRmRoleDefinition -Name Reader
```

Get the Reader role definition

### --------------------------  Example 2  --------------------------
```
PS C:\> Get-AzureRmRoleDefinition
```

Lists all RBAC role definitions

## PARAMETERS

### -AtScopeAndBelow
If specified, displays all role definitions.

```yaml
Type: SwitchParameter
Parameter Sets: RoleDefinitionNameParameterSet, RoleDefinitionCustomParameterSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Custom
If specified, only displays the custom created roles in the directory.

```yaml
Type: SwitchParameter
Parameter Sets: RoleDefinitionCustomParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
Role definition Id.

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
Role definition name.
For e.g.
Reader, Contributor, Virtual Machine Contributor.

```yaml
Type: String
Parameter Sets: RoleDefinitionNameParameterSet
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[New-AzureRmRoleAssignment]()

[Get-AzureRmRoleAssignment]()

[New-AzureRmRoleDefinition]()

[Remove-AzureRmRoleDefinition]()

