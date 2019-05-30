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

### Get1 (Default)
```
Get-AzRoleDefinition -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get2
```
Get-AzRoleDefinition -Id <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzRoleDefinition -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity2
```
Get-AzRoleDefinition -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzRoleDefinition -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
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
Parameter Sets: List1
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
Parameter Sets: Get1, Get2
Aliases: RoleDefinitionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity2, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope of the role definition.

```yaml
Type: System.String
Parameter Sets: Get2, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20150701.IRoleDefinition1

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IRoleDefinition

## ALIASES

## RELATED LINKS

