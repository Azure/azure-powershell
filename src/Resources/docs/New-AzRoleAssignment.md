---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azroleassignment
schema: 2.0.0
---

# New-AzRoleAssignment

## SYNOPSIS
Creates a role assignment by ID.

## SYNTAX

### Create1 (Default)
```
New-AzRoleAssignment -Id <String> [-Parameter <IRoleAssignmentCreateParameters>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzRoleAssignment -Id <String> [-CanDelegate <Boolean>] -PrincipalId <String> -RoleDefinitionId <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded2
```
New-AzRoleAssignment -Name <String> -Scope <String> [-CanDelegate <Boolean>] -PrincipalId <String>
 -RoleDefinitionId <String> [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Create2
```
New-AzRoleAssignment -Name <String> -Scope <String> [-Parameter <IRoleAssignmentCreateParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded3
```
New-AzRoleAssignment -RoleId <String> [-CanDelegate <Boolean>] -PrincipalId <String> -RoleDefinitionId <String>
 [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create3
```
New-AzRoleAssignment -RoleId <String> [-Parameter <IRoleAssignmentCreateParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded3
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> [-CanDelegate <Boolean>] -PrincipalId <String>
 -RoleDefinitionId <String> [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded2
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> [-CanDelegate <Boolean>] -PrincipalId <String>
 -RoleDefinitionId <String> [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> [-CanDelegate <Boolean>] -PrincipalId <String>
 -RoleDefinitionId <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity3
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> [-Parameter <IRoleAssignmentCreateParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity2
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> [-Parameter <IRoleAssignmentCreateParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> [-Parameter <IRoleAssignmentCreateParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a role assignment by ID.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -CanDelegate
The delegation flag used for creating a role assignment

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded1, CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -Id
The ID of the role assignment to create.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: RoleAssignmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: CreateViaIdentityExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded1, CreateViaIdentity3, CreateViaIdentity2, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the role assignment to create.
It can be any valid GUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded2, Create2
Aliases: RoleAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Role assignment create parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20171001Preview.IRoleAssignmentCreateParameters
Parameter Sets: Create1, Create2, Create3, CreateViaIdentity3, CreateViaIdentity2, CreateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrincipalId
The principal ID assigned to the role.
This maps to the ID inside the Active Directory.
It can point to a user, service principal, or security group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
The principal type of the assigned principal ID.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PrincipalType
Parameter Sets: CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleDefinitionId
The role definition ID used in the role assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoleId
The ID of the role assignment to create.

```yaml
Type: System.String
Parameter Sets: CreateExpanded3, Create3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the role assignment to create.
The scope can be any REST resource instance.
For example, use '/subscriptions/{subscription-id}/' for a subscription, '/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}' for a resource group, and '/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}' for a resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded2, Create2
Aliases:

Required: True
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20171001Preview.IRoleAssignment
### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignment
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azroleassignment](https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azroleassignment)

