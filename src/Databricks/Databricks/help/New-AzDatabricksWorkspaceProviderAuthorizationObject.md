---
external help file: Az.Databricks-help.xml
Module Name: Az.Databricks
online version: https://learn.microsoft.com/powershell/module/Az.Databricks/new-AzDatabricksWorkspaceProviderAuthorizationObject
schema: 2.0.0
---

# New-AzDatabricksWorkspaceProviderAuthorizationObject

## SYNOPSIS
Create an in-memory object for WorkspaceProviderAuthorization.

## SYNTAX

```
New-AzDatabricksWorkspaceProviderAuthorizationObject -PrincipalId <String> -RoleDefinitionId <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WorkspaceProviderAuthorization.

## EXAMPLES

### Example 1: Create an in-memory object for WorkspaceProviderAuthorization.
```powershell
New-AzDatabricksWorkspaceProviderAuthorizationObject -PrincipalId 024d7367-0890-4ad3-8140-e37374722820 -RoleDefinitionId 2124844c-7e23-48cc-bc52-a3af25f7a4ae
```

```output
PrincipalId                          RoleDefinitionId
-----------                          ----------------
024d7367-0890-4ad3-8140-e37374722820 2124844c-7e23-48cc-bc52-a3af25f7a4ae
```

Create an in-memory object for WorkspaceProviderAuthorization.

## PARAMETERS

### -PrincipalId
The provider's principal identifier.
This is the identity that the provider will use to call ARM to manage the workspace resources.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionId
The provider's role definition identifier.
This role will define all the permissions that the provider must have on the workspace's container resource group.
This role definition cannot have permission to delete the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20240501.WorkspaceProviderAuthorization

## NOTES

## RELATED LINKS
