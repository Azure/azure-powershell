---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
Module Name: AzureRM.Resources
online version:
schema: 2.0.0
---

# Get-AzureRmDenyAssignment

## SYNOPSIS
Lists Azure RBAC deny assignments at the specified scope.
By default it lists all deny assignments in the selected Azure subscription.
Use respective parameters to list deny assignments to a specific user, or to list deny assignments on a specific resource group or resource.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzureRmDenyAssignment [-Scope <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DenyAssignmentIdParameterSet
```
Get-AzureRmDenyAssignment -Id <Guid> [-Scope <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DenyAssignmentNameParameterSet
```
Get-AzureRmDenyAssignment -DenyAssignmentName <String> [-Scope <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzureRmDenyAssignment -ObjectId <Guid> [-ExpandPrincipalGroups] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithObjectIdParameterSet
```
Get-AzureRmDenyAssignment -ObjectId <Guid> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceWithObjectIdParameterSet
```
Get-AzureRmDenyAssignment -ObjectId <Guid> -ResourceGroupName <String> -ResourceName <String> -ResourceType <String> [-ParentResource <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ScopeWithObjectIdParameterSet
```
Get-AzureRmDenyAssignment -ObjectId <Guid> -Scope <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithSignInNameParameterSet
```
Get-AzureRmDenyAssignment -SignInName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceWithSignInNameParameterSet
```
Get-AzureRmDenyAssignment -SignInName <String> -ResourceGroupName <String> -ResourceName <String> -ResourceType <String> [-ParentResource <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ScopeWithSignInNameParameterSet
```
Get-AzureRmDenyAssignment -SignInName <String> -Scope <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SignInNameParameterSet
```
Get-AzureRmDenyAssignment -SignInName <String> [-ExpandPrincipalGroups] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithSPNParameterSet
```
Get-AzureRmDenyAssignment -ServicePrincipalName <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceWithSPNParameterSet
```
Get-AzureRmDenyAssignment -ServicePrincipalName <String> -ResourceGroupName <String> -ResourceName <String> -ResourceType <String> [-ParentResource <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ScopeWithSPNParameterSet
```
Get-AzureRmDenyAssignment -ServicePrincipalName <String> -Scope <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SPNParameterSet
```
Get-AzureRmDenyAssignment -ServicePrincipalName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupParameterSet
```
Get-AzureRmDenyAssignment -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceParameterSet
```
Get-AzureRmDenyAssignment -ResourceGroupName <String> -ResourceName <String> -ResourceType <String> [-ParentResource <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ScopeParameterSet
```
Get-AzureRmDenyAssignment -Scope <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Use the Get-AzureRmDenyAssignment command to list all deny assignments that are effective on a scope.
Without any parameters, this command returns all the deny assignments made under the subscription.
This list can  be filtered using filtering parameters for principal, deny assignment name and scope.
To specify a user, use SignInName or Azure AD ObjectId parameters.
To specify a security group, use Azure AD ObjectId parameter.
And to specify an Azure AD application, use ServicePrincipalName or ObjectId parameters.
The scope at which access is being denied may be specified.
It defaults to the selected subscription. 
The scope of the deny assignment can be specified using one of the following parameter combinations
        a.
Scope - This is the fully qualified scope starting with /subscriptions/\<subscriptionId\>.
This will filter deny assignments that are at, above and below that particular scope.
        b.
ResourceGroupName - Name of any resource group under the subscription.
This will filter deny assignments at, above and below the specified resource group
        c.
ResourceName, ResourceType, ResourceGroupName and (optionally) ParentResource - Identifies a particular resource under the subscription and will filter deny assignments effective at that resource scope.
To determine what access is denied for a particular user in the subscription, use the ExpandPrincipalGroups switch.
This will list all deny assignments assigned to the user, and to the groups that the user is member of.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmDenyAssignment
```

List all deny assignments in the subscription

### Example 2
```
PS C:\> Get-AzureRmDenyAssignment -ResourceGroupName testRG -SignInName john.doe@contoso.com
```

Gets all deny assignments made to user john.doe@contoso.com, and the groups of which he is member, at above and below the testRG scope.

### Example 3
```
PS C:\> Get-AzureRmDenyAssignment -ServicePrincipalName "http://testapp1.com"
```

Gets all deny assignments of the specified service principal

### Example 4
```
PS C:\> Get-AzureRmDenyAssignment -Scope "/subscriptions/96231a05-34ce-4eb4-aa6a-70759cbb5e83/resourcegroups/rg1/providers/Microsoft.Web/sites/site1"
```

Gets deny assignments at the 'site1' website scope.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpandPrincipalGroups
If specified, returns deny assignments directly assigned to the user and to the groups of which the user is a member (transitively).
Supported only for a user principal.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ObjectIdParameterSet, SignInNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
The Azure AD ObjectId of the User, Group or Service Principal.
Filters all deny assignments that are made to the specified principal.

```yaml
Type: System.Guid
Parameter Sets: ObjectIdParameterSet, ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, ScopeWithObjectIdParameterSet
Aliases: Id, PrincipalId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.Guid
Parameter Sets: RoleIdWithScopeAndObjectIdParameterSet
Aliases: Id, PrincipalId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentResource
The parent resource in the hierarchy of the resource specified using ResourceName parameter.
Must be used in conjunction with ResourceGroupName, ResourceType, and ResourceName parameters.

```yaml
Type: System.String
Parameter Sets: ResourceWithObjectIdParameterSet, ResourceWithSignInNameParameterSet, ResourceWithSPNParameterSet, ResourceParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.
Lists deny assignments that are effective at the specified resource group.
When used in conjunction with ResourceName, ResourceType, and ParentResource parameters, the command lists deny assignments effective at resources within the resource group.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithObjectIdParameterSet, ResourceWithObjectIdParameterSet, ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ResourceGroupParameterSet, ResourceParameterSet
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
Must be used in conjunction with ResourceGroupName, ResourceType, and (optionally)ParentResource parameters.

```yaml
Type: System.String
Parameter Sets: ResourceWithObjectIdParameterSet, ResourceWithSignInNameParameterSet, ResourceWithSPNParameterSet, ResourceParameterSet
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
Must be used in conjunction with ResourceGroupName, ResourceName, and (optionally)ParentResource parameters.

```yaml
Type: System.String
Parameter Sets: ResourceWithObjectIdParameterSet, ResourceWithSignInNameParameterSet, ResourceWithSPNParameterSet, ResourceParameterSet
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
/subscriptions/9004a9fd-d58e-48dc-aeb2-4a4aec58606f/resourceGroups/TestRG.
It must start with "/subscriptions/{id}".
The command filters all deny assignments that are effective at that scope.

```yaml
Type: System.String
Parameter Sets: ScopeWithObjectIdParameterSet, ScopeWithSignInNameParameterSet, ScopeWithSPNParameterSet, ScopeParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: RoleIdWithScopeAndObjectIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServicePrincipalName
The ServicePrincipalName of the service principal.
Filters all deny assignments that are made to the specified Azure AD application.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithSPNParameterSet, ResourceWithSPNParameterSet, ScopeWithSPNParameterSet, SPNParameterSet
Aliases: SPN

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SignInName
The email address or the user principal name of the user.
Filters all deny assignments that are made to the specified user.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithSignInNameParameterSet, ResourceWithSignInNameParameterSet, ScopeWithSignInNameParameterSet, SignInNameParameterSet
Aliases: Email, UserPrincipalName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Guid

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSDenyAssignment

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment