---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/update-azmanagedapplication
schema: 2.0.0
---

# Update-AzManagedApplication

## SYNOPSIS
Updates an existing managed application.
The only value that can be updated via PATCH currently is the tags.

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzManagedApplication -Id <String> -Kind <String> -ManagedResourceGroupId <String>
 [-ApplicationDefinitionId <String>] [-ApplicationParameter <IApplicationPropertiesParameters>]
 [-IdentityType <ResourceIdentityType>] [-Location <String>] [-ManagedBy <String>] [-PlanName <String>]
 [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>] [-SkuName <String>] [-SkuSize <String>]
 [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzManagedApplication -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Parameter <IApplication> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Update-AzManagedApplication -Id <String> -Parameter <IApplication> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzManagedApplication -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Kind <String>
 -ManagedResourceGroupId <String> [-ApplicationDefinitionId <String>]
 [-ApplicationParameter <IApplicationPropertiesParameters>] [-IdentityType <ResourceIdentityType>]
 [-Location <String>] [-ManagedBy <String>] [-PlanName <String>] [-PlanProduct <String>]
 [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>] [-SkuCapacity <Int32>]
 [-SkuFamily <String>] [-SkuModel <String>] [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzManagedApplication -InputObject <IResourcesIdentity> -Parameter <IApplication>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity1
```
Update-AzManagedApplication -InputObject <IResourcesIdentity> -Parameter <IApplication>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzManagedApplication -InputObject <IResourcesIdentity> -Kind <String> -ManagedResourceGroupId <String>
 [-ApplicationDefinitionId <String>] [-ApplicationParameter <IApplicationPropertiesParameters>]
 [-IdentityType <ResourceIdentityType>] [-Location <String>] [-ManagedBy <String>] [-PlanName <String>]
 [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>] [-SkuName <String>] [-SkuSize <String>]
 [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzManagedApplication -InputObject <IResourcesIdentity> -Kind <String> -ManagedResourceGroupId <String>
 [-ApplicationDefinitionId <String>] [-ApplicationParameter <IApplicationPropertiesParameters>]
 [-IdentityType <ResourceIdentityType>] [-Location <String>] [-ManagedBy <String>] [-PlanName <String>]
 [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>] [-SkuName <String>] [-SkuSize <String>]
 [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing managed application.
The only value that can be updated via PATCH currently is the tags.

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

### -ApplicationDefinitionId
The fully qualified path of managed application definition Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases: ManagedApplicationDefinitionId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApplicationParameter
Name and value pairs that define the managed application parameters.
It can be a JObject or a well formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationPropertiesParameters
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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

### -Id
The fully qualified ID of the managed application, including the managed application name and the managed application resource type.
Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases: ApplicationId

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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentity1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
The kind of the managed application.
Allowed values are MarketPlace and ServiceCatalog.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedResourceGroupId
The managed resource group Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed application.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ApplicationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Information about managed application.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180601.IApplication
Parameter Sets: Update, Update1, UpdateViaIdentity, UpdateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PlanName
The plan name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanProduct
The product code.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPublisher
The publisher ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanVersion
The plan's version.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -SkuCapacity
The SKU capacity.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180601.IApplication

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180601.IApplication

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

#### PARAMETER <IApplication>: Information about managed application.
  - `SkuName <String>`: The SKU name.
  - `Kind <String>`: The kind of the managed application. Allowed values are MarketPlace and ServiceCatalog.
  - `ManagedResourceGroupId <String>`: The managed resource group Id.
  - `PlanName <String>`: The plan name.
  - `PlanProduct <String>`: The product code.
  - `PlanPublisher <String>`: The publisher ID.
  - `PlanVersion <String>`: The plan's version.
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
  - `[DefinitionId <String>]`: The fully qualified path of managed application definition Id.
  - `[Parameter <IApplicationPropertiesParameters>]`: Name and value pairs that define the managed application parameters. It can be a JObject or a well formed JSON string.
  - `[PlanPromotionCode <String>]`: The promotion code.

## RELATED LINKS

