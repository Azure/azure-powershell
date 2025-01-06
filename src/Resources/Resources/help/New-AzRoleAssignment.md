---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: E460D108-2BF9-4F57-AF3D-13868DC73EA0
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azroleassignment
schema: 2.0.0
---

# New-AzRoleAssignment

## SYNOPSIS
Assigns the specified RBAC role to the specified principal, at the specified scope.

The cmdlet may call below Microsoft Graph API according to input parameters:

- GET /users/{id}
- GET /servicePrincipals/{id}
- GET /groups/{id}
- GET /directoryObjects/{id}

Please notice that this cmdlet will mark `ObjectType` as `Unknown` in output if the object of role assignment is not found or current account has insufficient privileges to get object type.

## SYNTAX

### EmptyParameterSet (Default)
```
New-AzRoleAssignment -ObjectId <String> [-Scope <String>] -RoleDefinitionName <String> [-Description <String>]
 [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>] [-AllowDelegation]
 [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceGroupWithObjectIdParameterSet
```
New-AzRoleAssignment -ObjectId <String> -ResourceGroupName <String> -RoleDefinitionName <String>
 [-Description <String>] [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>]
 [-AllowDelegation] [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceWithObjectIdParameterSet
```
New-AzRoleAssignment -ObjectId <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceType <String> [-ParentResource <String>] -RoleDefinitionName <String> [-Description <String>]
 [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>] [-AllowDelegation]
 [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### RoleIdWithScopeAndObjectIdParameterSet
```
New-AzRoleAssignment -ObjectId <String> -Scope <String> [-Description <String>] [-Condition <String>]
 [-ConditionVersion <String>] [-ObjectType <String>] -RoleDefinitionId <Guid> [-AllowDelegation]
 [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceGroupWithSignInNameParameterSet
```
New-AzRoleAssignment -SignInName <String> -ResourceGroupName <String> -RoleDefinitionName <String>
 [-Description <String>] [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>]
 [-AllowDelegation] [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceWithSignInNameParameterSet
```
New-AzRoleAssignment -SignInName <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceType <String> [-ParentResource <String>] -RoleDefinitionName <String> [-Description <String>]
 [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>] [-AllowDelegation]
 [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ScopeWithSignInNameParameterSet
```
New-AzRoleAssignment -SignInName <String> [-Scope <String>] -RoleDefinitionName <String>
 [-Description <String>] [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>]
 [-AllowDelegation] [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceGroupWithSPNParameterSet
```
New-AzRoleAssignment -ApplicationId <String> -ResourceGroupName <String> -RoleDefinitionName <String>
 [-Description <String>] [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>]
 [-AllowDelegation] [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceWithSPNParameterSet
```
New-AzRoleAssignment -ApplicationId <String> -ResourceGroupName <String> -ResourceName <String>
 -ResourceType <String> [-ParentResource <String>] -RoleDefinitionName <String> [-Description <String>]
 [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>] [-AllowDelegation]
 [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ScopeWithSPNParameterSet
```
New-AzRoleAssignment -ApplicationId <String> [-Scope <String>] -RoleDefinitionName <String>
 [-Description <String>] [-Condition <String>] [-ConditionVersion <String>] [-ObjectType <String>]
 [-AllowDelegation] [-SkipClientSideScopeValidation] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### InputFileParameterSet
```
New-AzRoleAssignment -InputFile <String> [-AllowDelegation] [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Use the New-AzRoleAssignment command to grant access.
Access is granted by assigning the appropriate RBAC role to them at the right scope.
To grant access to the entire subscription, assign a role at the subscription scope.
To grant access to a specific resource group within a subscription, assign a role at the resource group scope.
The subject of the assignment must be specified.
To specify a user, use SignInName or Microsoft Entra ObjectId parameters.
To specify a security group, use Microsoft Entra ObjectId parameter.
And to specify a Microsoft Entra application, use ApplicationId or ObjectId parameters.
The role that is being assigned must be specified using the RoleDefinitionName parameter.
The scope at which access is being granted may be specified.
It defaults to the selected subscription. 
The scope of the assignment can be specified using one of the following parameter combinations
        a.
Scope - This is the fully qualified scope starting with /subscriptions/\<subscriptionId\>
        b.
ResourceGroupName - to grant access to the specified resource group.
        c.
ResourceName, ResourceType, ResourceGroupName and (optionally) ParentResource - to specify a particular resource within a resource group to grant access to.

## EXAMPLES

### Example 1
```powershell
New-AzRoleAssignment -ResourceGroupName rg1 -SignInName allen.young@live.com -RoleDefinitionName Reader -AllowDelegation
```

Grant Reader role access to a user at a resource group scope with the Role Assignment being available for delegation

### Example 2
<!-- Skip: Output cannot be splitted from code -->


```powershell
Get-AzADGroup -SearchString "Christine Koch Team"

          DisplayName                    Type                           Id
          -----------                    ----                           --------
          Christine Koch Team                                           2f9d4375-cbf1-48e8-83c9-2a0be4cb33fb

New-AzRoleAssignment -ObjectId 2f9d4375-cbf1-48e8-83c9-2a0be4cb33fb -RoleDefinitionName Contributor  -ResourceGroupName rg1
```

Grant access to a security group

### Example 3
```powershell
New-AzRoleAssignment -SignInName john.doe@contoso.com -RoleDefinitionName Owner -Scope "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/rg1/providers/Microsoft.Web/sites/site1"
```

Grant access to a user at a resource (website)

### Example 4
```powershell
New-AzRoleAssignment -ObjectId 00001111-aaaa-2222-bbbb-3333cccc4444 -RoleDefinitionName "Virtual Machine Contributor" -ResourceName Devices-Engineering-ProjectRND -ResourceType Microsoft.Network/virtualNetworks/subnets -ParentResource virtualNetworks/VNET-EASTUS-01 -ResourceGroupName Network
```

Grant access to a group at a nested resource (subnet)

### Example 5
```powershell
$servicePrincipal = New-AzADServicePrincipal -DisplayName "testServiceprincipal"
New-AzRoleAssignment -RoleDefinitionName "Reader" -ApplicationId $servicePrincipal.ApplicationId
```

Grant reader access to a service principal

### Example 6
```powershell
$Condition = '(
 (
  !(ActionMatches{''Microsoft.Authorization/roleAssignments/write''})
 )
 OR 
 (
  @Request[Microsoft.Authorization/roleAssignments:PrincipalType] StringEqualsIgnoreCase ''ServicePrincipal''
 )
)
AND
(
 (
  !(ActionMatches{''Microsoft.Authorization/roleAssignments/delete''})
 )
 OR 
 (
  @Resource[Microsoft.Authorization/roleAssignments:PrincipalType] StringEqualsIgnoreCase ''ServicePrincipal''
 )
)'

$DelegationParams = @{
    AllowDelegation = $true
    Condition = $Condition 
    Scope = "/subscriptions/11112222-bbbb-3333-cccc-4444dddd5555" 
    RoleDefinitionName = 'User Access Administrator' 
    ObjectId = "00001111-aaaa-2222-bbbb-3333cccc4444"
}

New-AzRoleAssignment @DelegationParams
```

Grant User Access Administrator over an azure subscription with constrained delegation.<br>
The constrained delegation will only allow that the delegated user/service principal/group may only create/delete/update new role assignments for a service principal and any roles.

### Example 7
```powershell
$Condition = '(
 (
  !(ActionMatches{''Microsoft.Authorization/roleAssignments/write''})
 )
 OR 
 (
  @Request[Microsoft.Authorization/roleAssignments:PrincipalType] StringEqualsIgnoreCase ''ServicePrincipal''
  AND
  NOT @Request[Microsoft.Authorization/roleAssignments:RoleDefinitionId] ForAnyOfAnyValues:GuidEquals {8e3af657-a8ff-443c-a75c-2fe8c4bcb635,18d7d88d-d35e-4fb5-a5c3-7773c20a72d9}
 )
)
AND
(
 (
  !(ActionMatches{''Microsoft.Authorization/roleAssignments/delete''})
 )
 OR 
 (
  @Resource[Microsoft.Authorization/roleAssignments:PrincipalType] StringEqualsIgnoreCase ''ServicePrincipal''
  AND
  NOT @Resource[Microsoft.Authorization/roleAssignments:RoleDefinitionId] ForAnyOfAnyValues:GuidEquals {8e3af657-a8ff-443c-a75c-2fe8c4bcb635,18d7d88d-d35e-4fb5-a5c3-7773c20a72d9}
 )
)'

$DelegationParams = @{
    AllowDelegation = $true
    Condition = $Condition 
    Scope = "/subscriptions/11112222-bbbb-3333-cccc-4444dddd5555" 
    RoleDefinitionName = 'User Access Administrator' 
    ObjectId = "00001111-aaaa-2222-bbbb-3333cccc4444"
}

New-AzRoleAssignment @DelegationParams
```

Grant User Access Administrator over an azure subscription with constrained delegation.<br>
The constrained delegation will only allow that the delegated user/service principal/group may only create/delete/update new role assignments for a service principal, excluding the [Owner](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles/privileged#owner) and [User Access Administrator](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles/privileged#user-access-administrator) role.

## PARAMETERS

### -AllowDelegation
The delegation flag while creating a Role assignment.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationId
The Application ID of the ServicePrincipal

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet
Aliases: SPN, ServicePrincipalName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Condition
Condition to be applied to the RoleAssignment.

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, RoleIdWithScopeAndObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ConditionVersion
Version of the condition.

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, RoleIdWithScopeAndObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -Description
Brief description of the role assignment.

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, RoleIdWithScopeAndObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputFile
Path to role assignment json

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

### -ObjectId
Microsoft Entra Objectid of the user, group or service principal.

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, RoleIdWithScopeAndObjectIdParameterSet
Aliases: Id, PrincipalId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ObjectType
To be used with ObjectId. Specifies the type of the asignee object

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, RoleIdWithScopeAndObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet
Aliases: PrincipalType

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentResource
The parent resource in the hierarchy(of the resource specified using ResourceName parameter).
Should only be  used in conjunction with ResourceGroupName, ResourceType and ResourceName parameters to construct a hierarchical scope in the form of a relative URI that identifies a resource.

```yaml
Type: System.String
Parameter Sets: ResourceWithObjectIdParameterSet, ResourceWithSignInNameParameterSet, ResourceWithSPNParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.
Creates an assignment that is effective at the specified resource group.
When used in conjunction with ResourceName, ResourceType and (optionally)ParentResource parameters, the command constructs a hierarchical scope in the form of a relative URI that identifies a resource.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceName
The resource name.
For e.g.
storageaccountprod.
Should only be used in conjunction with ResourceGroupName, ResourceType and (optionally)ParentResource parameters to construct a hierarchical scope in the form of a  relative URI that identifies a resource.

```yaml
Type: System.String
Parameter Sets: ResourceWithObjectIdParameterSet, ResourceWithSignInNameParameterSet, ResourceWithSPNParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceType
The resource type.
For e.g.
Microsoft.Network/virtualNetworks.
Should only be used in conjunction with ResourceGroupName, ResourceName and (optionally)ParentResource parameters to construct a hierarchical scope in  the form of a relative URI that identifies a resource.

```yaml
Type: System.String
Parameter Sets: ResourceWithObjectIdParameterSet, ResourceWithSignInNameParameterSet, ResourceWithSPNParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoleDefinitionId
Id of the RBAC role that needs to be assigned to the principal.

```yaml
Type: System.Guid
Parameter Sets: RoleIdWithScopeAndObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoleDefinitionName
Name of the RBAC role that needs to be assigned to the principal i.e.
Reader, Contributor, Virtual Network Administrator, etc.

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The Scope of the role assignment.
In the format of relative URI.
For e.g.
"/subscriptions/9004a9fd-d58e-48dc-aeb2-4a4aec58606f/resourceGroups/TestRG".
If not specified, will create the role assignment at subscription level.
If specified, it should start with "/subscriptions/{id}".

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet, ScopeWithSignInNameParameterSet, ScopeWithSPNParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: RoleIdWithScopeAndObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SignInName
The email address or the user principal name of the user.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet
Aliases: Email, UserPrincipalName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipClientSideScopeValidation
If specified, skip client side scope validation.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Guid

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment

## NOTES
Learn more about role assignment delegation - https://learn.microsoft.com/en-us/azure/role-based-access-control/delegate-role-assignments-portal?tabs=template 
<br>Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[Get-AzRoleAssignment](./Get-AzRoleAssignment.md)

[Remove-AzRoleAssignment](./Remove-AzRoleAssignment.md)

[Get-AzRoleDefinition](./Get-AzRoleDefinition.md)
