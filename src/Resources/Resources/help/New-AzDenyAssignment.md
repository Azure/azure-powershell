---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azdenyassignment
schema: 2.0.0
---

# New-AzDenyAssignment

## SYNOPSIS
Creates a user-assigned deny assignment at the specified scope.
By default, the deny assignment targets Everyone and requires at least one excluded principal.
Alternatively, use -PrincipalId and -PrincipalType to target a specific user or service principal.

## SYNTAX

### EveryoneParameterSet (Default)
```
New-AzDenyAssignment -DenyAssignmentName <String> -Scope <String> -ExcludePrincipalId <String[]>
 [-Description <String>] [-Action <String[]>] [-NotAction <String[]>] [-DataAction <String[]>]
 [-NotDataAction <String[]>] [-ExcludePrincipalType <String[]>] [-DoNotApplyToChildScope]
 [-DenyAssignmentId <Guid>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PerPrincipalParameterSet
```
New-AzDenyAssignment -DenyAssignmentName <String> -Scope <String> -PrincipalId <String>
 -PrincipalType <String> [-Description <String>] [-Action <String[]>] [-NotAction <String[]>]
 [-DataAction <String[]>] [-NotDataAction <String[]>] [-ExcludePrincipalId <String[]>]
 [-ExcludePrincipalType <String[]>] [-DoNotApplyToChildScope] [-DenyAssignmentId <Guid>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputFileParameterSet
```
New-AzDenyAssignment -Scope <String> -InputFile <String> [-DenyAssignmentId <Guid>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Use the New-AzDenyAssignment command to create a new user-assigned deny assignment at the specified scope.

By default, the deny assignment targets all principals (Everyone) and requires at least one excluded principal via the ExcludePrincipalId parameter.

Alternatively, use -PrincipalId and -PrincipalType to target a specific user or service principal. In this mode, -ExcludePrincipalId is optional. Group type principals are not supported for user-assigned deny assignments.

Only write, delete, and action operations can be denied. Read actions and data actions are not supported.

## EXAMPLES

### Example 1: Create a deny assignment that blocks delete actions for everyone
```powershell
New-AzDenyAssignment -DenyAssignmentName "Block deletes" `
    -Scope "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG" `
    -Action "*/delete" `
    -ExcludePrincipalId "11111111-1111-1111-1111-111111111111" `
    -ExcludePrincipalType "User"
```

Creates a deny assignment named "Block deletes" at the resource group scope that denies all delete actions for everyone. The specified user is excluded from the deny assignment.

### Example 2: Block a specific user from performing write operations
```powershell
New-AzDenyAssignment -DenyAssignmentName "Block user writes" `
    -Scope "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG" `
    -Action "*/write" `
    -PrincipalId "11111111-1111-1111-1111-111111111111" `
    -PrincipalType "User"
```

Creates a deny assignment that blocks write operations for a specific user. No excluded principals are required in per-principal mode.

### Example 3: Block a specific service principal from deleting resources
```powershell
New-AzDenyAssignment -DenyAssignmentName "Block SP deletes" `
    -Scope "/subscriptions/00000000-0000-0000-0000-000000000000" `
    -Action "*/delete" `
    -PrincipalId "22222222-2222-2222-2222-222222222222" `
    -PrincipalType "ServicePrincipal"
```

Creates a deny assignment that blocks delete operations for a specific service principal at subscription scope.

### Example 4: Create a deny assignment from a JSON input file
```powershell
New-AzDenyAssignment -Scope "/subscriptions/00000000-0000-0000-0000-000000000000" `
    -InputFile "C:\DenyAssignment.json"
```

Creates a deny assignment using the definition in the specified JSON file. The input file must include DenyAssignmentName, Actions, and either ExcludePrincipalIds (Everyone mode) or PrincipalIds + PrincipalTypes (per-principal mode).

### Example 5: Create a deny assignment with multiple exclude principals
```powershell
New-AzDenyAssignment -DenyAssignmentName "Block writes" `
    -Scope "/subscriptions/00000000-0000-0000-0000-000000000000" `
    -Action "*/write" `
    -ExcludePrincipalId "11111111-1111-1111-1111-111111111111", "22222222-2222-2222-2222-222222222222" `
    -ExcludePrincipalType "User", "ServicePrincipal"
```

Creates a deny assignment that denies write actions for everyone, excluding a user and a service principal.

## PARAMETERS

### -Action
Actions to deny. Wildcards supported (e.g., */delete, Microsoft.Storage/storageAccounts/*).

```yaml
Type: System.String[]
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DataAction
Data actions to deny. Note: Data actions are not supported for user-assigned deny assignments and will be rejected by the service.

```yaml
Type: System.String[]
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -DenyAssignmentId
The GUID for the deny assignment. If not specified, a new GUID will be generated.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenyAssignmentName
The display name for the deny assignment.

```yaml
Type: System.String
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Description
A description of the deny assignment.

```yaml
Type: System.String
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DoNotApplyToChildScope
If set, the deny assignment does not apply to child scopes. Note: This property is not supported for user-assigned deny assignments and will be rejected by the service.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExcludePrincipalId
Object IDs of principals to exclude from the deny assignment. Required when targeting Everyone. Optional when using -PrincipalId.

```yaml
Type: System.String[]
Parameter Sets: EveryoneParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String[]
Parameter Sets: PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExcludePrincipalType
Type(s) of the exclude principals (User, Group, ServicePrincipal). One per ExcludePrincipalId, or a single value applied to all. Defaults to User.

```yaml
Type: System.String[]
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:
Accepted values: User, Group, ServicePrincipal

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputFile
Path to a JSON file containing the deny assignment definition.

```yaml
Type: System.String
Parameter Sets: InputFileParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NotAction
Actions to exclude from the deny assignment.

```yaml
Type: System.String[]
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NotDataAction
Data actions to exclude from the deny assignment. Note: Data actions are not supported for user-assigned deny assignments.

```yaml
Type: System.String[]
Parameter Sets: EveryoneParameterSet, PerPrincipalParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrincipalId
Object ID of the user or service principal to deny. When specified, the deny assignment targets this specific principal instead of Everyone.

```yaml
Type: System.String
Parameter Sets: PerPrincipalParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrincipalType
Type of the principal specified by -PrincipalId. Accepted values are User and ServicePrincipal. Group type is not supported for user-assigned deny assignments.

```yaml
Type: System.String
Parameter Sets: PerPrincipalParameterSet
Aliases:
Accepted values: User, ServicePrincipal

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
Scope of the deny assignment. In the format of relative URI. For example, /subscriptions/{id}/resourceGroups/{rgName}.

```yaml
Type: System.String
Parameter Sets: (All)
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

### System.String[]

### System.Guid

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSDenyAssignment

## NOTES

## RELATED LINKS

[Get-AzDenyAssignment](./Get-AzDenyAssignment.md)

[Remove-AzDenyAssignment](./Remove-AzDenyAssignment.md)
