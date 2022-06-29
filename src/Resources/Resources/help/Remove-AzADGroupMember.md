---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/remove-azadgroupmember
schema: 2.0.0
---

# Remove-AzADGroupMember

## SYNOPSIS
Deletes member from group
Users, contacts, and groups that are members of this group.
HTTP Methods: GET (supported for all groups), POST (supported for security groups and mail-enabled security groups), DELETE (supported only for security groups) Read-only.
Nullable.
Supports $expand.

## SYNTAX

### ExplicitParameterSet  (Default)
```
Remove-AzADGroupMember [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MemberObjectIdWithGroupObjectId
```
Remove-AzADGroupMember -GroupObjectId <String> -MemberObjectId <String[]> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MemberUPNWithGroupObjectIdParameterSet
```
Remove-AzADGroupMember -GroupObjectId <String> -MemberUserPrincipalName <String[]> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MemberUPNWithGroupObjectParameterSet
```
Remove-AzADGroupMember -MemberUserPrincipalName <String[]> -GroupObject <MicrosoftGraphGroup>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MemberUPNWithGroupDisplayNameParameterSet
```
Remove-AzADGroupMember -MemberUserPrincipalName <String[]> -GroupDisplayName <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MemberObjectIdWithGroupObject
```
Remove-AzADGroupMember -MemberObjectId <String[]> -GroupObject <MicrosoftGraphGroup>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MemberObjectIdWithGroupDisplayName
```
Remove-AzADGroupMember -MemberObjectId <String[]> -GroupDisplayName <String> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes member from group
Users, contacts, and groups that are members of this group.
HTTP Methods: GET (supported for all groups), POST (supported for security groups and mail-enabled security groups), DELETE (supported only for security groups) Read-only.
Nullable.
Supports $expand.

## EXAMPLES

### Example 1: Remove members from group
```powershell
$members = @()
$members += (Get-AzADUser -DisplayName $uname).Id
$members += (Get-AzADServicePrincipal -ApplicationId $appid).Id
Get-AzADGroupMember -GroupDisplayName $gname | Remove-AzADGroupMember -MemberObjectId $member
```

Remove members from group

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupDisplayName
The display name of target group.

```yaml
Type: System.String
Parameter Sets: MemberUPNWithGroupDisplayNameParameterSet, MemberObjectIdWithGroupDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupObject
The target group object, could be used as pipeline input.
To construct, see NOTES section for GROUPOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphGroup
Parameter Sets: MemberUPNWithGroupObjectParameterSet, MemberObjectIdWithGroupObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GroupObjectId
The object Id of target group.

```yaml
Type: System.String
Parameter Sets: MemberObjectIdWithGroupObjectId, MemberUPNWithGroupObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberObjectId
The object Id of member to be removed from target group.

```yaml
Type: System.String[]
Parameter Sets: MemberObjectIdWithGroupObjectId, MemberObjectIdWithGroupObject, MemberObjectIdWithGroupDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberUserPrincipalName
The user principal name of member to be removed from target group.

```yaml
Type: System.String[]
Parameter Sets: MemberUPNWithGroupObjectIdParameterSet, MemberUPNWithGroupObjectParameterSet, MemberUPNWithGroupDisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphGroup

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


GROUPOBJECT `<MicrosoftGraphGroup>`: The target group object, could be used as pipeline input.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[AppRoleAssignment <IMicrosoftGraphAppRoleAssignmentAutoGenerated[]>]`: Represents the app roles a group has been granted for an application. Supports $expand.
    - `[DeletedDateTime <DateTime?>]`: 
    - `[DisplayName <String>]`: The name displayed in directory
    - `[AppRoleId <String>]`: The identifier (id) for the app role which is assigned to the principal. This app role must be exposed in the appRoles property on the resource application's service principal (resourceId). If the resource application has not declared any app roles, a default app role ID of 00000000-0000-0000-0000-000000000000 can be specified to signal that the principal is assigned to the resource app without any specific app roles. Required on create.
    - `[CreatedDateTime <DateTime?>]`: The time when the app role assignment was created.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.
    - `[PrincipalDisplayName <String>]`: The display name of the user, group, or service principal that was granted the app role assignment. Read-only. Supports $filter (eq and startswith).
    - `[PrincipalId <String>]`: The unique identifier (id) for the user, group or service principal being granted the app role. Required on create.
    - `[PrincipalType <String>]`: The type of the assigned principal. This can either be User, Group or ServicePrincipal. Read-only.
    - `[ResourceDisplayName <String>]`: The display name of the resource app's service principal to which the assignment is made.
    - `[ResourceId <String>]`: The unique identifier (id) for the resource service principal for which the assignment is made. Required on create. Supports $filter (eq only).
  - `[Classification <String>]`: Describes a classification for the group (such as low, medium or high business impact). Valid values for this property are defined by creating a ClassificationList setting value, based on the template definition.Returned by default. Supports $filter (eq, ne, NOT, ge, le, startsWith).
  - `[CreatedOnBehalfOf <IMicrosoftGraphDirectoryObject>]`: Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity types.
    - `[DeletedDateTime <DateTime?>]`: 
    - `[DisplayName <String>]`: The name displayed in directory
  - `[Description <String>]`: An optional description for the group. Returned by default. Supports $filter (eq, ne, NOT, ge, le, startsWith) and $search.
  - `[GroupType <String[]>]`: Specifies the group type and its membership.  If the collection contains Unified, the group is a Microsoft 365 group; otherwise, it's either a security group or distribution group. For details, see groups overview.If the collection includes DynamicMembership, the group has dynamic membership; otherwise, membership is static.  Returned by default. Supports $filter (eq, NOT).
  - `[HasMembersWithLicenseError <Boolean?>]`: Indicates whether there are members in this group that have license errors from its group-based license assignment. This property is never returned on a GET operation. You can use it as a $filter argument to get groups that have members with license errors (that is, filter for this property being true).  Supports $filter (eq).
  - `[IsArchived <Boolean?>]`: 
  - `[IsAssignableToRole <Boolean?>]`: Indicates whether this group can be assigned to an Azure Active Directory role.This property can only be set while creating the group and is immutable. If set to true, the securityEnabled property must also be set to true and the group cannot be a dynamic group (that is, groupTypes cannot contain DynamicMembership). Only callers in Global administrator and Privileged role administrator roles can set this property. The caller must also be assigned the Directory.AccessAsUser.All permission to set this property. For more, see Using a group to manage Azure AD role assignmentsReturned by default. Supports $filter (eq, ne, NOT).
  - `[MailEnabled <Boolean?>]`: Specifies whether the group is mail-enabled. Returned by default. Supports $filter (eq, ne, NOT).
  - `[MailNickname <String>]`: The mail alias for the group, unique in the organization. This property must be specified when a group is created. These characters cannot be used in the mailNickName: @()/[]';:.<>,SPACE. Returned by default. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[MembershipRule <String>]`: The rule that determines members for this group if the group is a dynamic group (groupTypes contains DynamicMembership). For more information about the syntax of the membership rule, see Membership Rules syntax. Returned by default. Supports $filter (eq, ne, NOT, ge, le, startsWith).
  - `[MembershipRuleProcessingState <String>]`: Indicates whether the dynamic membership processing is on or paused. Possible values are On or Paused. Returned by default. Supports $filter (eq, ne, NOT, in).
  - `[PermissionGrant <IMicrosoftGraphResourceSpecificPermissionGrant[]>]`: The permissions that have been granted for a group to a specific application. Supports $expand.
    - `[DeletedDateTime <DateTime?>]`: 
    - `[DisplayName <String>]`: The name displayed in directory
    - `[ClientAppId <String>]`: ID of the service principal of the Azure AD app that has been granted access. Read-only.
    - `[ClientId <String>]`: ID of the Azure AD app that has been granted access. Read-only.
    - `[Permission <String>]`: The name of the resource-specific permission. Read-only.
    - `[PermissionType <String>]`: The type of permission. Possible values are: Application, Delegated. Read-only.
    - `[ResourceAppId <String>]`: ID of the Azure AD app that is hosting the resource. Read-only.
  - `[PreferredDataLocation <String>]`: The preferred data location for the group. For more information, see  OneDrive Online Multi-Geo. Returned by default.
  - `[PreferredLanguage <String>]`: The preferred language for a Microsoft 365 group. Should follow ISO 639-1 Code; for example 'en-US'. Returned by default. Supports $filter (eq, ne, NOT, ge, le, in, startsWith).
  - `[SecurityEnabled <Boolean?>]`: Specifies whether the group is a security group. Returned by default. Supports $filter (eq, ne, NOT, in).
  - `[SecurityIdentifier <String>]`: Security identifier of the group, used in Windows scenarios. Returned by default.
  - `[Theme <String>]`: Specifies a Microsoft 365 group's color theme. Possible values are Teal, Purple, Green, Blue, Pink, Orange or Red. Returned by default.
  - `[Visibility <String>]`: Specifies the group join policy and group content visibility for groups. Possible values are: Private, Public, or Hiddenmembership. Hiddenmembership can be set only for Microsoft 365 groups, when the groups are created. It can't be updated later. Other values of visibility can be updated after group creation. If visibility value is not specified during group creation on Microsoft Graph, a security group is created as Private by default and Microsoft 365 group is Public. See group visibility options to learn more. Returned by default.
  - `[DeletedDateTime <DateTime?>]`: 
  - `[DisplayName <String>]`: The name displayed in directory

## RELATED LINKS
