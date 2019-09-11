---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azmanagedapplicationdefinition
schema: 2.0.0
---

# New-AzManagedApplicationDefinition

## SYNOPSIS
Creates a new managed application definition.

## SYNTAX

### Create1 (Default)
```
New-AzManagedApplicationDefinition -Id <String> -Parameter <IApplicationDefinition>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzManagedApplicationDefinition -Name <String> -ResourceGroupName <String>
 -Parameter <IApplicationDefinition> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzManagedApplicationDefinition -Name <String> -ResourceGroupName <String>
 -Authorization <IApplicationProviderAuthorization[]> -LockLevel <ApplicationLockLevel>
 [-SubscriptionId <String>] [-Artifact <IApplicationArtifact[]>]
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-IsEnabled <String>] [-Location <String>]
 [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>] [-ManagedBy <String>]
 [-PackageFileUri <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzManagedApplicationDefinition -Id <String> -Authorization <IApplicationProviderAuthorization[]>
 -LockLevel <ApplicationLockLevel> [-Artifact <IApplicationArtifact[]>]
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-IsEnabled <String>] [-Location <String>]
 [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>] [-ManagedBy <String>]
 [-PackageFileUri <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzManagedApplicationDefinition -InputObject <IResourcesIdentity> -Parameter <IApplicationDefinition>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzManagedApplicationDefinition -InputObject <IResourcesIdentity> -Parameter <IApplicationDefinition>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzManagedApplicationDefinition -InputObject <IResourcesIdentity>
 -Authorization <IApplicationProviderAuthorization[]> -LockLevel <ApplicationLockLevel>
 [-Artifact <IApplicationArtifact[]>]
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-IsEnabled <String>] [-Location <String>]
 [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>] [-ManagedBy <String>]
 [-PackageFileUri <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzManagedApplicationDefinition -InputObject <IResourcesIdentity>
 -Authorization <IApplicationProviderAuthorization[]> -LockLevel <ApplicationLockLevel>
 [-Artifact <IApplicationArtifact[]>]
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-IsEnabled <String>] [-Location <String>]
 [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>] [-ManagedBy <String>]
 [-PackageFileUri <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new managed application definition.

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

### -Artifact
The collection of managed application artifacts.
The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
To construct, see NOTES section for ARTIFACT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationArtifact[]
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Authorization
The managed application provider authorizations.
To construct, see NOTES section for AUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationProviderAuthorization[]
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreateUiDefinition
The createUiDefinition json for the backing template with Microsoft.Solutions/applications resource.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinitionPropertiesCreateUiDefinition
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

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

### -Description
The managed application definition description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayName
The managed application definition display name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
The fully qualified ID of the managed application definition, including the managed application name and the managed application definition resource type.
Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applicationDefinitions/{applicationDefinition-name}

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: ApplicationDefinitionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

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
Parameter Sets: CreateViaIdentity, CreateViaIdentity1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IsEnabled
A value indicating whether the package is enabled or not.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LockLevel
The managed application lock level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ApplicationLockLevel
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MainTemplate
The inline main template json which has resources to be provisioned.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinitionPropertiesMainTemplate
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedBy
ID of the resource that manages this resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed application definition.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: ApplicationDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PackageFileUri
The managed application definition package file Uri.
Use this element

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Information about managed application definition.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition
Parameter Sets: Create, Create1, CreateViaIdentity, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
The SKU capacity.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuFamily
The SKU family.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuModel
The SKU model.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The SKU name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuSize
The SKU size.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
The SKU tier.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded, CreateViaIdentityExpanded1
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ARTIFACT <IApplicationArtifact[]>: The collection of managed application artifacts. The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
  - `[Name <String>]`: The managed application artifact name.
  - `[Type <ApplicationArtifactType?>]`: The managed application artifact type.
  - `[Uri <String>]`: The managed application artifact blob uri.

#### AUTHORIZATION <IApplicationProviderAuthorization[]>: The managed application provider authorizations.
  - `PrincipalId <String>`: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the managed application resources.
  - `RoleDefinitionId <String>`: The provider's role definition identifier. This role will define all the permissions that the provider must have on the managed application's container resource group. This role definition cannot have permission to delete the resource group.

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

#### PARAMETER <IApplicationDefinition>: Information about managed application definition.
  - `SkuName <String>`: The SKU name.
  - `Authorization <IApplicationProviderAuthorization[]>`: The managed application provider authorizations.
    - `PrincipalId <String>`: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the managed application resources.
    - `RoleDefinitionId <String>`: The provider's role definition identifier. This role will define all the permissions that the provider must have on the managed application's container resource group. This role definition cannot have permission to delete the resource group.
  - `LockLevel <ApplicationLockLevel>`: The managed application lock level.
  - `[IdentityType <ResourceIdentityType?>]`: The identity type.
  - `[ManagedBy <String>]`: ID of the resource that manages this resource.
  - `[SkuCapacity <Int32?>]`: The SKU capacity.
  - `[SkuFamily <String>]`: The SKU family.
  - `[SkuModel <String>]`: The SKU model.
  - `[SkuSize <String>]`: The SKU size.
  - `[SkuTier <String>]`: The SKU tier.
  - `[Location <String>]`: Resource location
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Artifact <IApplicationArtifact[]>]`: The collection of managed application artifacts. The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
    - `[Name <String>]`: The managed application artifact name.
    - `[Type <ApplicationArtifactType?>]`: The managed application artifact type.
    - `[Uri <String>]`: The managed application artifact blob uri.
  - `[CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>]`: The createUiDefinition json for the backing template with Microsoft.Solutions/applications resource. It can be a JObject or well-formed JSON string.
  - `[Description <String>]`: The managed application definition description.
  - `[DisplayName <String>]`: The managed application definition display name.
  - `[IsEnabled <String>]`: A value indicating whether the package is enabled or not.
  - `[MainTemplate <IApplicationDefinitionPropertiesMainTemplate>]`: The inline main template json which has resources to be provisioned. It can be a JObject or well-formed JSON string.
  - `[PackageFileUri <String>]`: The managed application definition package file Uri. Use this element

## RELATED LINKS

