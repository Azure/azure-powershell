---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azrolemanagementpolicyassignment
schema: 2.0.0
---

# Get-AzRoleManagementPolicyAssignment

## SYNOPSIS
Get the specified role management policy assignment for a resource scope

## SYNTAX

### List (Default)
```
Get-AzRoleManagementPolicyAssignment -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRoleManagementPolicyAssignment -Name <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRoleManagementPolicyAssignment -InputObject <IAuthorizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified role management policy assignment for a resource scope

## EXAMPLES

### Example 1: List all role management policy assignments under a resource scope
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
Get-AzRoleManagementPolicyAssignment -Scope $scope
```

```output
Name                                                                      Type                                                   Scope                                               RoleDefinitionId
----                                                                      ----                                                   -----                                               ----------------
588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
8dbbf139-4d46-4ad4-a56b-004156c117d2_056cd41c-7e88-42e1-933e-88ba6a50c9c3 Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
1c8bc687-402c-4e62-b38b-009d6fc244d3_b97fb8bc-a8b2-4522-a38b-dd33c7e65ead Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
5d582357-e60a-4322-a299-00ab23713a07_70bbe301-9835-447d-afdd-19eb3167307c Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
```

Returns all `roleManagementPolicyAssignment` for the `scope`

### Example 2: Get a role management policy assignment by Scope and Name
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$name = "588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd"
Get-AzRoleManagementPolicyAssignment -Scope $scope -Name $name
```

```output
Name                                                                      Type                                                   Scope                                               RoleDefinitionId
----                                                                      ----                                                   -----                                               ----------------
588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f…
```

Use the `Id` property to get `scope` and `name`

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IAuthorizationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of format {guid_guid} the role management policy assignment to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RoleManagementPolicyAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the role management policy.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.IAuthorizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicyAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAuthorizationIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[RoleAssignmentScheduleInstanceName <String>]`: The name (hash of schedule name + time) of the role assignment schedule to get.
  - `[RoleAssignmentScheduleName <String>]`: The name (guid) of the role assignment schedule to get.
  - `[RoleAssignmentScheduleRequestName <String>]`: The name of the role assignment to create. It can be any valid GUID.
  - `[RoleEligibilityScheduleInstanceName <String>]`: The name (hash of schedule name + time) of the role eligibility schedule to get.
  - `[RoleEligibilityScheduleName <String>]`: The name (guid) of the role eligibility schedule to get.
  - `[RoleEligibilityScheduleRequestName <String>]`: The name of the role eligibility to create. It can be any valid GUID.
  - `[RoleManagementPolicyAssignmentName <String>]`: The name of format {guid_guid} the role management policy assignment to get.
  - `[RoleManagementPolicyName <String>]`: The name (guid) of the role management policy to get.
  - `[Scope <String>]`: The scope of the role management policy.

## RELATED LINKS

