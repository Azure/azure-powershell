---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdeploymentoperation
schema: 2.0.0
---

# Get-AzDeploymentOperation

## SYNOPSIS
Gets a deployments operation.

## SYNTAX

### List (Default)
```
Get-AzDeploymentOperation -DeploymentName <String> -SubscriptionId <String[]> [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeploymentOperation -DeploymentName <String> -OperationId <String> -SubscriptionId <String[]>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzDeploymentOperation -DeploymentName <String> -OperationId <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDeploymentObject
```
Get-AzDeploymentOperation -DeploymentObject <IDeploymentExtended> -SubscriptionId <String[]> [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeploymentOperation -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzDeploymentOperation -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDeploymentOperation -DeploymentName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a deployments operation.

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
Dynamic: False
```

### -DeploymentName
The name of the deployment.

```yaml
Type: System.String
Parameter Sets: Get, Get1, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DeploymentObject
The object representation of the deployment.
To construct, see NOTES section for DEPLOYMENTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentExtended
Parameter Sets: GetByDeploymentObject
Aliases:

Required: True
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
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -OperationId
The ID of the operation to get.

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases:

Required: True
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
Parameter Sets: Get1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, Get1, GetByDeploymentObject, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Top
The number of results to return.

```yaml
Type: System.Int32
Parameter Sets: GetByDeploymentObject, List, List1
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentOperation

## ALIASES

### Get-AzResourceGroupDeploymentOperation

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DEPLOYMENTOBJECT <IDeploymentExtended>: The object representation of the deployment.
  - `ParameterLinkUri <String>`: The URI of the parameters file.
  - `TemplateLinkUri <String>`: The URI of the template to deploy.
  - `[DebugSettingDetailLevel <String>]`: Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.
  - `[Dependency <IDependency[]>]`: The list of deployment dependencies.
    - `[DependsOn <IBasicDependency[]>]`: The list of dependencies.
      - `[Id <String>]`: The ID of the dependency.
      - `[ResourceName <String>]`: The dependency resource name.
      - `[ResourceType <String>]`: The dependency resource type.
    - `[Id <String>]`: The ID of the dependency.
    - `[ResourceName <String>]`: The dependency resource name.
    - `[ResourceType <String>]`: The dependency resource type.
  - `[Location <String>]`: the location of the deployment.
  - `[Mode <DeploymentMode?>]`: The deployment mode. Possible values are Incremental and Complete.
  - `[OnErrorDeploymentName <String>]`: The deployment to be used on error case.
  - `[OnErrorDeploymentType <OnErrorDeploymentType?>]`: The deployment on error behavior type. Possible values are LastSuccessful and SpecificDeployment.
  - `[Output <IDeploymentPropertiesExtendedOutputs>]`: Key/value pairs that represent deployment output.
  - `[Parameter <IDeploymentPropertiesExtendedParameters>]`: Deployment parameters. Use only one of Parameters or ParametersLink.
  - `[ParameterLinkContentVersion <String>]`: If included, must match the ContentVersion in the template.
  - `[Provider <IProvider[]>]`: The list of resource providers needed for the deployment.
    - `[Namespace <String>]`: The namespace of the resource provider.
  - `[Template <IDeploymentPropertiesExtendedTemplate>]`: The template content. Use only one of Template or TemplateLink.
  - `[TemplateLinkContentVersion <String>]`: If included, must match the ContentVersion in the template.

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

## RELATED LINKS

