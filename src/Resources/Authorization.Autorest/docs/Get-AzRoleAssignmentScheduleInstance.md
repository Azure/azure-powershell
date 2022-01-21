---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azroleassignmentscheduleinstance
schema: 2.0.0
---

# Get-AzRoleAssignmentScheduleInstance

## SYNOPSIS
Gets the specified role assignment schedule instance.

## SYNTAX

### List (Default)
```
Get-AzRoleAssignmentScheduleInstance -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzRoleAssignmentScheduleInstance -Name <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRoleAssignmentScheduleInstance -InputObject <IAuthorizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified role assignment schedule instance.

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
```

### -Filter
The filter to apply on the operation.
Use $filter=atScope() to return all role assignment schedules at or above the scope.
Use $filter=principalId eq {id} to return all role assignment schedules at, above or below the scope for the specified principal.
Use $filter=assignedTo('{userId}') to return all role assignment schedule instances for the user.
Use $filter=asTarget() to return all role assignment schedule instances created for the current user.

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
The name (hash of schedule name + time) of the role assignment schedule to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RoleAssignmentScheduleInstanceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the role assignments schedules.

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleAssignmentScheduleInstance

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAuthorizationIdentity>: Identity Parameter
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

