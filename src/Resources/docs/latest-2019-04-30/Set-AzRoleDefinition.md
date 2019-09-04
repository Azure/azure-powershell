---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azroledefinition
schema: 2.0.0
---

# Set-AzRoleDefinition

## SYNOPSIS
Creates or updates a role definition.

## SYNTAX

### UpdateExpanded1 (Default)
```
Set-AzRoleDefinition -Id <String> -Scope <String> [-AssignableScope <String[]>] [-Description <String>]
 [-Permission <IPermission[]>] [-RoleName <String>] [-RoleType <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzRoleDefinition -Id <String> -Scope <String> -RoleDefinition <IRoleDefinition>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a role definition.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AssignableScope
Role definition assignable scopes.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Description
The role definition description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
The ID of the role definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RoleDefinitionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Permission
Role definition permissions.
To construct, see NOTES section for PERMISSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IPermission[]
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoleDefinition
Role definition.
To construct, see NOTES section for ROLEDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IRoleDefinition
Parameter Sets: Update1
Aliases: Role

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -RoleName
The role name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoleType
The role type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope of the role definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IRoleDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IRoleDefinition

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PERMISSION <IPermission[]>: Role definition permissions.
  - `[Action <String[]>]`: Allowed actions.
  - `[NotAction <String[]>]`: Denied actions.
  - `[DataAction <String[]>]`: Allowed Data actions.
  - `[NotDataAction <String[]>]`: Denied Data actions.

#### ROLEDEFINITION <IRoleDefinition>: Role definition.
  - `[AssignableScope <String[]>]`: Role definition assignable scopes.
  - `[Description <String>]`: The role definition description.
  - `[Permission <IPermission[]>]`: Role definition permissions.
    - `[Action <String[]>]`: Allowed actions.
    - `[NotAction <String[]>]`: Denied actions.
    - `[DataAction <String[]>]`: Allowed Data actions.
    - `[NotDataAction <String[]>]`: Denied Data actions.
  - `[RoleName <String>]`: The role name.
  - `[RoleType <String>]`: The role type.

## RELATED LINKS

