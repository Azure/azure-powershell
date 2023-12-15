---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azroleassignmentschedulerequest
schema: 2.0.0
---

# Get-AzRoleAssignmentScheduleRequest

## SYNOPSIS
Get the specified role assignment schedule request.

## SYNTAX

### List (Default)
```
Get-AzRoleAssignmentScheduleRequest -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzRoleAssignmentScheduleRequest -Name <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRoleAssignmentScheduleRequest -InputObject <IAuthorizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified role assignment schedule request.

## EXAMPLES

### Example 1: List all role assignment schedule requests for a resource
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleAssignmentScheduleRequest -Scope $scope 
```

```output
Name                                 Type                                                   Scope
----                                 ----                                                   -----
01b86d0b-2d7d-4ee2-bedb-68417ca9cc6a Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
06425dd7-102c-42c2-90c4-b5c630447356 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
0988b71a-f813-467b-abc0-cef007eddbb5 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
0cbb19d3-3804-404a-b74a-2f577f8aecbc Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
```

Returns all `roleAssignmentScheduleRequests` for the `scope`.

### Example 2: List all My role assignment schedule requests for a resource
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleAssignmentScheduleRequest -Scope $scope -Filter "asTarget()"
```

```output
Name                                 Type                                                   Scope                                                                       RoleDefinitionId
----                                 ----                                                   -----                                                                       ----------------
2cc018c2-27f8-4730-a0bc-b6a8fcee3e70 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
31910719-4f82-443c-9e7a-6bfe4b918e0c Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
4cd7e26b-8eca-425c-969d-ec708c88bf18 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…

```

Returns all `roleAssignmentScheduleRequests` for the `scope` which are assigned to the calling user.

### Example 3: List all role assignment schedule requests for a resource where calling user is an approver
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleAssignmentScheduleRequest -Scope $scope -Filter "asApprover()"
```

```output
Name                                 Type                                                   Scope                                                                       RoleDefinitionId
----                                 ----                                                   -----                                                                       ----------------
2cc018c2-27f8-4730-a0bc-b6a8fcee3e70 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
31910719-4f82-443c-9e7a-6bfe4b918e0c Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
4cd7e26b-8eca-425c-969d-ec708c88bf18 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…

```

Returns all `roleAssignmentScheduleRequests` for the `scope` on which the calling user is an approver.

### Example 4: Get a role assignment schedule request by scope and name
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleAssignmentScheduleRequest -Scope $scope -Name "2cc018c2-27f8-4730-a0bc-b6a8fcee3e70"
```

```output
Name                                 Type                                                   Scope                                               RoleDefinitionId
----                                 ----                                                   -----                                               ----------------
2cc018c2-27f8-4730-a0bc-b6a8fcee3e70 Microsoft.Authorization/roleAssignmentScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/providers/Microsoft.Authoriz… 
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

### -Filter
The filter to apply on the operation.
Use $filter=atScope() to return all role assignment schedule requests at or above the scope.
Use $filter=principalId eq {id} to return all role assignment schedule requests at, above or below the scope for the specified principal.
Use $filter=asRequestor() to return all role assignment schedule requests requested by the current user.
Use $filter=asTarget() to return all role assignment schedule requests created for the current user.
Use $filter=asApprover() to return all role assignment schedule requests where the current user is an approver.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
The name (guid) of the role assignment schedule request to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RoleAssignmentScheduleRequestName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the role assignment schedule request.

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleAssignmentScheduleRequest

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

