---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azroledefinition
schema: 2.0.0
---

# Get-AzRoleDefinition

## SYNOPSIS
Gets a role definition by ID.

## SYNTAX

### ListRoleDefinition (Default)
```
Get-AzRoleDefinition [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetRoleDefinition2
```
Get-AzRoleDefinition -Id <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetRoleDefinitionByCustom
```
Get-AzRoleDefinition -Scope <String> -Custom [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetRoleDefinitionByName
```
Get-AzRoleDefinition -Scope <String> -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListRoleDefinition1
```
Get-AzRoleDefinition -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a role definition by ID.

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

### -Custom
If set, signals that only custom created roles in the directory should be returned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetRoleDefinitionByCustom
Aliases:

Required: True
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

### -Filter
The filter to apply on the operation.
Use atScopeAndBelow filter to search below the given scope as well.

```yaml
Type: System.String
Parameter Sets: ListRoleDefinition1
Aliases: ODataQuery

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
Parameter Sets: GetRoleDefinition2
Aliases: RoleDefinitionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the role definition.

```yaml
Type: System.String
Parameter Sets: GetRoleDefinitionByName
Aliases:

Required: True
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
Parameter Sets: GetRoleDefinition2, GetRoleDefinitionByCustom, GetRoleDefinitionByName, ListRoleDefinition1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IRoleDefinition

## ALIASES

## NOTES

## RELATED LINKS

