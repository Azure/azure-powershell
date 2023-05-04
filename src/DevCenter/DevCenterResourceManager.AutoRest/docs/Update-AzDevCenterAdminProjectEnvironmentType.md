---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradminprojectenvironmenttype
schema: 2.0.0
---

# Update-AzDevCenterAdminProjectEnvironmentType

## SYNOPSIS
Partially updates a project environment type.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-CreatorRoleAssignmentRole <Hashtable>]
 [-DeploymentTargetId <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-Status <EnvironmentTypeEnableStatus>] [-Tag <Hashtable>]
 [-UserRoleAssignment <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzDevCenterAdminProjectEnvironmentType -EnvironmentTypeName <String> -ProjectName <String>
 -ResourceGroupName <String> -Body <IProjectEnvironmentTypeUpdate> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzDevCenterAdminProjectEnvironmentType -InputObject <IDevCenterIdentity>
 -Body <IProjectEnvironmentTypeUpdate> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminProjectEnvironmentType -InputObject <IDevCenterIdentity>
 [-CreatorRoleAssignmentRole <Hashtable>] [-DeploymentTargetId <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-Status <EnvironmentTypeEnableStatus>] [-Tag <Hashtable>] [-UserRoleAssignment <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially updates a project environment type.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
The project environment type for partial update.
Properties not provided in the update request will not be changed.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IProjectEnvironmentTypeUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CreatorRoleAssignmentRole
A map of roles to assign to the environment creator.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DeploymentTargetId
Id of a subscription that the environment type will be mapped to.
The environment's resources will be deployed into this subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentTypeName
The name of the environment type.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.ManagedServiceIdentityType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The name of the project.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Defines whether this Environment Type can be used in this Project.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.EnvironmentTypeEnableStatus
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserRoleAssignment
Role Assignments created on environment backing resources.
This is a mapping from a user object ID to an object of role definition IDs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IProjectEnvironmentTypeUpdate

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IProjectEnvironmentType

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BODY <IProjectEnvironmentTypeUpdate>`: The project environment type for partial update. Properties not provided in the update request will not be changed.
  - `[CreatorRoleAssignmentRole <IProjectEnvironmentTypeUpdatePropertiesCreatorRoleAssignmentRoles>]`: A map of roles to assign to the environment creator.
    - `[(Any) <IEnvironmentRole>]`: This indicates any property can be added to this object.
  - `[DeploymentTargetId <String>]`: Id of a subscription that the environment type will be mapped to. The environment's resources will be deployed into this subscription.
  - `[IdentityType <ManagedServiceIdentityType?>]`: Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).
  - `[IdentityUserAssignedIdentity <IUserAssignedIdentities>]`: The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests.
    - `[(Any) <IUserAssignedIdentity>]`: This indicates any property can be added to this object.
  - `[Status <EnvironmentTypeEnableStatus?>]`: Defines whether this Environment Type can be used in this Project.
  - `[Tag <ITags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[UserRoleAssignment <IProjectEnvironmentTypeUpdatePropertiesUserRoleAssignments>]`: Role Assignments created on environment backing resources. This is a mapping from a user object ID to an object of role definition IDs.
    - `[(Any) <IUserRoleAssignmentValue>]`: This indicates any property can be added to this object.

`INPUTOBJECT <IDevCenterIdentity>`: Identity Parameter
  - `[AttachedNetworkConnectionName <String>]`: The name of the attached NetworkConnection.
  - `[CatalogName <String>]`: The name of the Catalog.
  - `[DevBoxDefinitionName <String>]`: The name of the Dev Box definition.
  - `[DevCenterName <String>]`: The name of the devcenter.
  - `[EnvironmentTypeName <String>]`: The name of the environment type.
  - `[GalleryName <String>]`: The name of the gallery.
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The name of the image.
  - `[Location <String>]`: The Azure region
  - `[NetworkConnectionName <String>]`: Name of the Network Connection that can be applied to a Pool.
  - `[OperationId <String>]`: The ID of an ongoing async operation
  - `[PoolName <String>]`: Name of the pool.
  - `[ProjectName <String>]`: The name of the project.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScheduleName <String>]`: The name of the schedule that uniquely identifies it.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VersionName <String>]`: The version of the image.

## RELATED LINKS

