---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azroleassignment
schema: 2.0.0
---

# New-AzRoleAssignment

## SYNOPSIS
Creates a role assignment.

## SYNTAX

### CreateExpanded3 (Default)
```
New-AzRoleAssignment -RoleId <String> -PrincipalId <String> -RoleDefinitionId <String> [-CanDelegate]
 [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create2
```
New-AzRoleAssignment -Name <String> -Scope <String> -Parameter <IRoleAssignmentCreateParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create3
```
New-AzRoleAssignment -RoleId <String> -Parameter <IRoleAssignmentCreateParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded2
```
New-AzRoleAssignment -Name <String> -Scope <String> -PrincipalId <String> -RoleDefinitionId <String>
 [-CanDelegate] [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity2
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> -Parameter <IRoleAssignmentCreateParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity3
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> -Parameter <IRoleAssignmentCreateParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded2
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> -PrincipalId <String> -RoleDefinitionId <String>
 [-CanDelegate] [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded3
```
New-AzRoleAssignment -InputObject <IResourcesIdentity> -PrincipalId <String> -RoleDefinitionId <String>
 [-CanDelegate] [-PrincipalType <PrincipalType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a role assignment.

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

### -CanDelegate
The delegation flag used for creating a role assignment

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded3
Aliases: AllowDelegation

Required: False
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: CreateViaIdentity2, CreateViaIdentity3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the role assignment to create.
It can be any valid GUID.

```yaml
Type: System.String
Parameter Sets: Create2, CreateExpanded2
Aliases: RoleAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Role assignment create parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignmentCreateParameters
Parameter Sets: Create2, Create3, CreateViaIdentity2, CreateViaIdentity3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PrincipalId
The principal ID assigned to the role.
This maps to the ID inside the Active Directory.
It can point to a user, service principal, or security group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrincipalType
The principal type of the assigned principal ID.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PrincipalType
Parameter Sets: CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded3
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoleDefinitionId
The role definition ID used in the role assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded2, CreateExpanded3, CreateViaIdentityExpanded2, CreateViaIdentityExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoleId
The ID of the role assignment to create.

```yaml
Type: System.String
Parameter Sets: Create3, CreateExpanded3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Scope
The scope of the role assignment to create.
The scope can be any REST resource instance.
For example, use '/subscriptions/{subscription-id}/' for a subscription, '/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}' for a resource group, and '/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}' for a resource.

```yaml
Type: System.String
Parameter Sets: Create2, CreateExpanded2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignmentCreateParameters

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignment

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IResourcesIdentity>: Identity Parameter
  - `[ApplianceDefinitionId <String>]`: The fully qualified ID of the appliance definition, including the appliance name and the appliance definition resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applianceDefinitions/{applianceDefinition-name}
  - `[ApplianceDefinitionName <String>]`: The name of the appliance definition.
  - `[ApplianceId <String>]`: The fully qualified ID of the appliance, including the appliance name and the appliance resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/appliances/{appliance-name}
  - `[ApplianceName <String>]`: The name of the appliance.
  - `[ApplicationDefinitionId <String>]`: The fully qualified ID of the managed application definition, including the managed application name and the managed application definition resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applicationDefinitions/{applicationDefinition-name}
  - `[ApplicationDefinitionName <String>]`: The name of the managed application definition.
  - `[ApplicationId <String>]`: The application ID.
  - `[ApplicationId1 <String>]`: The fully qualified ID of the managed application, including the managed application name and the managed application resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}
  - `[ApplicationName <String>]`: The name of the managed application.
  - `[ApplicationObjectId <String>]`: Application object ID.
  - `[DenyAssignmentId <String>]`: The ID of the deny assignment to get.
  - `[DeploymentName <String>]`: The name of the deployment.
  - `[DomainName <String>]`: name of the domain.
  - `[FeatureName <String>]`: The name of the feature to get.
  - `[GroupId <String>]`: Management Group ID.
  - `[GroupObjectId <String>]`: The object ID of the group from which to remove the member.
  - `[Id <String>]`: Resource identity path
  - `[LinkId <String>]`: The fully qualified ID of the resource link. Use the format, /subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/{provider-namespace}/{resource-type}/{resource-name}/Microsoft.Resources/links/{link-name}. For example, /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup/Microsoft.Web/sites/mySite/Microsoft.Resources/links/myLink
  - `[LockName <String>]`: The name of lock.
  - `[ManagementGroupId <String>]`: The ID of the management group.
  - `[MemberObjectId <String>]`: Member object id
  - `[ObjectId <String>]`: Application object ID.
  - `[OperationId <String>]`: The ID of the operation to get.
  - `[OwnerObjectId <String>]`: Owner object id
  - `[ParentResourcePath <String>]`: The parent resource identity.
  - `[PolicyAssignmentId <String>]`: The ID of the policy assignment to delete. Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.
  - `[PolicyAssignmentName <String>]`: The name of the policy assignment to delete.
  - `[PolicyDefinitionName <String>]`: The name of the policy definition to create.
  - `[PolicySetDefinitionName <String>]`: The name of the policy set definition to create.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource to delete. The name is case insensitive.
  - `[ResourceId <String>]`: The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}
  - `[ResourceName <String>]`: The name of the resource to delete.
  - `[ResourceProviderNamespace <String>]`: The namespace of the resource provider.
  - `[ResourceType <String>]`: The resource type.
  - `[RoleAssignmentId <String>]`: The ID of the role assignment to delete.
  - `[RoleAssignmentName <String>]`: The name of the role assignment to delete.
  - `[RoleDefinitionId <String>]`: The ID of the role definition to delete.
  - `[RoleId <String>]`: The ID of the role assignment to delete.
  - `[Scope <String>]`: The scope for the lock. 
  - `[SourceResourceGroupName <String>]`: The name of the resource group containing the resources to move.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[TagName <String>]`: The name of the tag.
  - `[TagValue <String>]`: The value of the tag to delete.
  - `[TenantId <String>]`: The tenant ID.
  - `[UpnOrObjectId <String>]`: The object ID or principal name of the user for which to get information.

#### PARAMETER <IRoleAssignmentCreateParameters>: Role assignment create parameters.
  - `PrincipalId <String>`: The principal ID assigned to the role. This maps to the ID inside the Active Directory. It can point to a user, service principal, or security group.
  - `RoleDefinitionId <String>`: The role definition ID used in the role assignment.
  - `[CanDelegate <Boolean?>]`: The delegation flag used for creating a role assignment
  - `[PrincipalType <PrincipalType?>]`: The principal type of the assigned principal ID.

## RELATED LINKS

