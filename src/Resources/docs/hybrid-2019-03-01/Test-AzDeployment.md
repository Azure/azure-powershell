---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeployment
schema: 2.0.0
---

# Test-AzDeployment

## SYNOPSIS
Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzDeployment -Name <String> -SubscriptionId <String> -Mode <DeploymentMode>
 [-DebugSettingDetailLevel <String>] [-DeploymentParameter <IDeploymentPropertiesParameters>]
 [-Location <String>] [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>]
 [-Template <IDeploymentPropertiesTemplate>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzDeployment -Name <String> -SubscriptionId <String> -Parameter <IDeployment>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate1
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Parameter <IDeployment>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded1
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Mode <DeploymentMode>
 [-DebugSettingDetailLevel <String>] [-DeploymentParameter <IDeploymentPropertiesParameters>]
 [-Location <String>] [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>]
 [-Template <IDeploymentPropertiesTemplate>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzDeployment -InputObject <IResourcesIdentity> -Parameter <IDeployment> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity1
```
Test-AzDeployment -InputObject <IResourcesIdentity> -Parameter <IDeployment> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDeployment -InputObject <IResourcesIdentity> -Mode <DeploymentMode> [-DebugSettingDetailLevel <String>]
 [-DeploymentParameter <IDeploymentPropertiesParameters>] [-Location <String>]
 [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>]
 [-Template <IDeploymentPropertiesTemplate>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded1
```
Test-AzDeployment -InputObject <IResourcesIdentity> -Mode <DeploymentMode> [-DebugSettingDetailLevel <String>]
 [-DeploymentParameter <IDeploymentPropertiesParameters>] [-Location <String>]
 [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>]
 [-Template <IDeploymentPropertiesTemplate>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..

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

### -DebugSettingDetailLevel
Specifies the type of information to log for debugging.
The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma.
The default is none.
When setting this value, carefully consider the type of information you are passing in during deployment.
By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
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

### -DeploymentParameter
Name and value pairs that define the deployment parameters for the template.
You use this element when you want to provide the parameter values directly in the request rather than link to an existing parameter file.
Use either the parametersLink property or the parameters property, but not both.
It can be a JObject or a well formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentPropertiesParameters
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
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
Parameter Sets: ValidateViaIdentity, ValidateViaIdentity1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
The location to store the deployment data.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Mode
The mode that is used to deploy resources.
This value can be either Incremental or Complete.
In Incremental mode, resources are deployed without deleting existing resources that are not included in the template.
In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted.
Be careful when using Complete mode as you may unintentionally delete resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.DeploymentMode
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the deployment.

```yaml
Type: System.String
Parameter Sets: Validate, Validate1, ValidateExpanded, ValidateExpanded1
Aliases: DeploymentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OnErrorDeploymentName
The deployment to be used on error case.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OnErrorDeploymentType
The deployment on error behavior type.
Possible values are LastSuccessful and SpecificDeployment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.OnErrorDeploymentType
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Deployment operation parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeployment
Parameter Sets: Validate, Validate1, ValidateViaIdentity, ValidateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ParameterLinkContentVersion
If included, must match the ContentVersion in the template.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParameterLinkUri
The URI of the parameters file.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group the template will be deployed to.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Validate1, ValidateExpanded1
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
Type: System.String
Parameter Sets: Validate, Validate1, ValidateExpanded, ValidateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Template
The template content.
You use this element when you want to pass the template syntax directly in the request rather than link to an existing template.
It can be a JObject or well-formed JSON string.
Use either the templateLink property or the template property, but not both.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentPropertiesTemplate
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateLinkContentVersion
If included, must match the ContentVersion in the template.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateLinkUri
The URI of the template to deploy.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateExpanded1, ValidateViaIdentityExpanded, ValidateViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeployment

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentValidateResult

## ALIASES

### Test-AzResourceGroupDeployment

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

#### PARAMETER <IDeployment>: Deployment operation parameters.
  - `Mode <DeploymentMode>`: The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources.
  - `ParameterLinkUri <String>`: The URI of the parameters file.
  - `TemplateLinkUri <String>`: The URI of the template to deploy.
  - `[DebugSettingDetailLevel <String>]`: Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.
  - `[Location <String>]`: The location to store the deployment data.
  - `[OnErrorDeploymentName <String>]`: The deployment to be used on error case.
  - `[OnErrorDeploymentType <OnErrorDeploymentType?>]`: The deployment on error behavior type. Possible values are LastSuccessful and SpecificDeployment.
  - `[Parameter <IDeploymentPropertiesParameters>]`: Name and value pairs that define the deployment parameters for the template. You use this element when you want to provide the parameter values directly in the request rather than link to an existing parameter file. Use either the parametersLink property or the parameters property, but not both. It can be a JObject or a well formed JSON string.
  - `[ParameterLinkContentVersion <String>]`: If included, must match the ContentVersion in the template.
  - `[Template <IDeploymentPropertiesTemplate>]`: The template content. You use this element when you want to pass the template syntax directly in the request rather than link to an existing template. It can be a JObject or well-formed JSON string. Use either the templateLink property or the template property, but not both.
  - `[TemplateLinkContentVersion <String>]`: If included, must match the ContentVersion in the template.

## RELATED LINKS

