---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azrolemanagementpolicy
schema: 2.0.0
---

# Get-AzRoleManagementPolicy

## SYNOPSIS
Get the specified role management policy for a resource scope

## SYNTAX

### List (Default)
```
Get-AzRoleManagementPolicy -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRoleManagementPolicy -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRoleManagementPolicy -InputObject <IAuthorizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified role management policy for a resource scope

## EXAMPLES

### Example 1: List all role management policies under a resource scope
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
Get-AzRoleManagementPolicy -Scope $scope
```

```output
Name                                 Type                                           Scope
----                                 ----                                           -----
588b80cc-f50c-4616-acc9-0003872624db Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
8dbbf139-4d46-4ad4-a56b-004156c117d2 Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
1c8bc687-402c-4e62-b38b-009d6fc244d3 Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
```

Returns all `roleManagementPolicies` for the `scope`

### Example 2: Get a role management policy by Scope and Name
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$name = "33b520ea-3544-4abc-8565-3588deb8e68e"
Get-AzRoleManagementPolicy -Scope $scope -Name $name
```

```output
Name                                 Type                                           Scope
----                                 ----                                           -----
33b520ea-3544-4abc-8565-3588deb8e68e Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
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
The name (guid) of the role management policy to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RoleManagementPolicyName

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicy

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

