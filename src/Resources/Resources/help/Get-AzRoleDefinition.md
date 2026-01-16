---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 7740AC3B-F643-4F8D-8DC5-ACBF59323BD8
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azroledefinition
schema: 2.0.0
---

# Get-AzRoleDefinition

## SYNOPSIS
Lists all Azure RBAC roles that are available for assignment.

## SYNTAX

### RoleDefinitionNameParameterSet (Default)
```
Get-AzRoleDefinition [[-Name] <String>] [-Scope <String>] [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RoleDefinitionIdParameterSet
```
Get-AzRoleDefinition -Id <Guid> [-Scope <String>] [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RoleDefinitionCustomParameterSet
```
Get-AzRoleDefinition [-Scope <String>] [-Custom] [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Use the Get-AzRoleDefinition command with a particular role name to view its details.
To inspect individual operations that a role grants access to, review the Permissions property of the role.
Each permission entry contains Actions, NotActions, DataActions, NotDataActions, and optionally Condition and ConditionVersion properties.
Roles with Attribute-Based Access Control (ABAC) conditions will have the Condition and ConditionVersion set on the appropriate permission entry.

## EXAMPLES

### Example 1: Get a role definition by name
```powershell
Get-AzRoleDefinition -Name Reader
```

Retrieves the Reader role definition with all its permissions.

### Example 2: List all RBAC role definitions
```powershell
Get-AzRoleDefinition
```

Lists all Azure RBAC role definitions available in the current scope.

### Example 3: Access Actions from a role definition
```powershell
$roleDef = Get-AzRoleDefinition -Name "Virtual Machine Contributor"
$roleDef.Permissions[0].Actions
```

Retrieves the actions from the first permission entry of a role definition.

### Example 4: Get all permissions including conditions
```powershell
$roleDef = Get-AzRoleDefinition -Name "Storage Blob Data Reader"
foreach ($permission in $roleDef.Permissions) {
    Write-Host "Actions: $($permission.Actions -join ', ')"
    Write-Host "DataActions: $($permission.DataActions -join ', ')"
    if ($permission.Condition) {
        Write-Host "Condition: $($permission.Condition)"
        Write-Host "ConditionVersion: $($permission.ConditionVersion)"
    }
}
```

Iterates through all permission entries and displays actions and any ABAC conditions.

## PARAMETERS

### -Custom
If specified, only displays the custom created roles in the directory.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RoleDefinitionCustomParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Id
Role definition Id.

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

### -Name
Role definition name.
For e.g.
Reader, Contributor, Virtual Machine Contributor.

```yaml
Type: System.String
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Guid

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[New-AzRoleAssignment](./New-AzRoleAssignment.md)

[Get-AzRoleAssignment](./Get-AzRoleAssignment.md)

[New-AzRoleDefinition](./New-AzRoleDefinition.md)

[Remove-AzRoleDefinition](./Remove-AzRoleDefinition.md)
