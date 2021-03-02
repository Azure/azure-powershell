---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/set-azroleassignment
schema: 2.0.0
---

# Set-AzRoleAssignment

## SYNOPSIS
Update an existing Role Assignment.

## SYNTAX

### RoleAssignmentParameterSet (Default)
```
Set-AzRoleAssignment -InputObject <PSRoleAssignment> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputFileParameterSet
```
Set-AzRoleAssignment -InputFile <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Use the New-AzRoleAssignment command to modify an existing assignment.  
Descriptions can be any valid string, use that to diferentiate from one another.  
if Condition is set Condition Version has to be set as well but if you're updating a Condition that is not necesary.
Condition Version can be upgraded from 1.0 to 2.0 but it can't not be downgraded back. Be cautious as 2.0 is not retrocompatible with 1.0.

## EXAMPLES

### Example 1
```powershell
$ConditionVersion = "2.0"
  $Description = "This is a new role assignment for John"
  $Condition = "@Resource[Microsoft.Storage/storageAccounts/blobServices/containers/blobs:Path] StringEqualsIgnoreCase 'foo_storage_container'"

  $roleAssignment = Get-AzRoleAssignment -Scope "/subscriptions/4e5329a6-39ce-4e13-b12e-11b30f015986/resourceGroups/contoso_rg" -PrincipalId "0c0f6cdc-90dd-4664-83c0-a0d986c4c604"
  $roleAssignment.Description = $Description
  $roleAssignment.Condition = $Condition
  $roleAssignment.ConditionVersion = $ConditionVersion

  Set-AzRoleAssignment -InputObject $roleAssignment -PassThru

  RoleAssignmentId   : /providers/Microsoft.Management/managementGroups/1273adef-00a3
                     -4086-a51a-dbcce1857d36/providers/Microsoft.Authorization/role
                     Assignments/926c2a76-be19-4281-94de-38777629b9dc
  Scope              : /subscriptions/4e5329a6-39ce-4e13-b12e-11b30f015986/resourceGroups/contoso_rg
  DisplayName        : John Doe
  SignInName         : John.Doe@Contoso.com
  RoleDefinitionName : Owner
  RoleDefinitionId   : 8e3af657-a8ff-443c-a75c-2fe8c4bcb635
  ObjectId           : 0c0f6cdc-90dd-4664-83c0-a0d986c4c604
  ObjectType         : User
  CanDelegate        : False
  Description        : This is a new role assignment for John
  ConditionVersion   : 2.0
  Condition          : @Resource[Microsoft.Storage/storageAccounts/blobServices/containers/blobs:Path] StringEqualsIgnoreCase 'foo_storage_container'
```

Update an existing role assignment by modifying an object

### Example 2
```powershell
Set-AzRoleAssignment -InputFile "C:\RoleAssignments\example.json" -PassThru

  RoleAssignmentId   : /providers/Microsoft.Management/managementGroups/1273adef-00a3
                     -4086-a51a-dbcce1857d36/providers/Microsoft.Authorization/role
                     Assignments/926c2a76-be19-4281-94de-38777629b9dc
  Scope              : /subscriptions/4e5329a6-39ce-4e13-b12e-11b30f015986/resourceGroups/contoso_rg
  DisplayName        : John Doe
  SignInName         : John.Doe@Contoso.com
  RoleDefinitionName : Owner
  RoleDefinitionId   : 8e3af657-a8ff-443c-a75c-2fe8c4bcb635
  ObjectId           : 0c0f6cdc-90dd-4664-83c0-a0d986c4c604
  ObjectType         : User
  CanDelegate        : False
  Description        : This is a new role assignment for John
  ConditionVersion   : 2.0
  Condition          : @Resource[Microsoft.Storage/storageAccounts/blobServices/containers/blobs:Path] StringEqualsIgnoreCase 'foo_storage_container'
```

Update an existing role assignment by using a file

## PARAMETERS

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

### -InputFile
File name containing a single role definition.

```yaml
Type: System.String
Parameter Sets: InputFileParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Role Assignment.

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment
Parameter Sets: RoleAssignmentParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
If specified, displays the updated role assignment

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment

## NOTES

## RELATED LINKS
