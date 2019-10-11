---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdeployment
schema: 2.0.0
---

# Get-AzDeployment

## SYNOPSIS
Get deployment

## SYNTAX

### SubscriptionWithDeploymentName (Default)
```
Get-AzDeployment -ScopeType <DeploymentScopeType> [[-Name] <String>] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithDeploymentName
```
Get-AzDeployment -ScopeType <DeploymentScopeType> [-ResourceGroupName] <String> [[-Name] <String>]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupWithDeploymentName
```
Get-AzDeployment -ScopeType <DeploymentScopeType> [-ManagementGroupId] <String> [[-Name] <String>]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### TenantWithDeploymentName
```
Get-AzDeployment -ScopeType <DeploymentScopeType> [[-Name] <String>] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByDeploymentId
```
Get-AzDeployment -Id <String> [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDeployment** cmdlet gets the deployments at a resource group, subscription, management group, or tenant scope.
Specify the *ScopeType* parameter for the scope to get deployments. Specify the *Name* or *Id* parameter to filter the results.
By default, **Get-AzDeployment** gets all deployments at the current subscription scope.

## EXAMPLES

### Example 1: Get all deployments at subscription scope
```
PS C:\>Get-AzDeployment -ScopeType Subscription
```

This command gets all deployments at the current subscription scope.

### Example 2: Get a deployment by name
```
PS C:\>Get-AzDeployment -ScopeType Subscription -Name "DeployRoles01"
```

This command gets the DeployRoles01 deployment at the current subscription scope.
You can assign a name to a deployment when you create it by using the **New-AzDeployment** cmdlets.
If you do not assign a name, the cmdlets provide a default name based on the template that is used to create the deployment.

### Example 3: Get a deployment by deployment ID
```
PS C:\>Get-AzDeployment -Id "/subscriptions/sub-01/providers/Microsoft.Resources/deployments/DeployRole01"
```

This command gets the DeployRole01 deployment from subscription sub-01.
You can assign a name to a deployment when you create it by using the **New-AzDeployment** cmdlets.
If you do not assign a name, the cmdlets provide a default name based on the template that is used to create the deployment.

### Example 4: Get a deployment at a resource group
```
PS C:\>Get-AzDeployment -ScopeType ResourceGroup -Name "DeployRoles01" -ResourceGroupName "rg-01"
```

This command gets the DeployRole01 deployment from resource group rg-01.

### Example 5: Get a deployment at a management group
```
PS C:\>Get-AzDeployment -ScopeType ManagementGroup -Name "DeployRoles01" -ManagementGroupId "mg-01"
```

This command gets the DeployRole01 deployment from management group mg-01.

### Example 6: Get a deployment at the tenant scope
```
PS C:\>Get-AzDeployment -ScopeType Tenant -Name "DeployRoles01" -Tenant
```

This command gets the DeployRole01 deployment from the tenant scope.

## PARAMETERS

### -ApiVersion
When set, indicates the version of the resource provider API to use.
If not specified, the API version is automatically determined as the latest available.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Id
The fully qualified resource Id of the deployment.
example: /subscriptions/{subId}/providers/Microsoft.Resources/deployments/{deploymentName}

```yaml
Type: System.String
Parameter Sets: GetByDeploymentId
Aliases: DeploymentId, ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupId
The management group ID.

```yaml
Type: System.String
Parameter Sets: ManagementGroupWithDeploymentName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of deployment.

```yaml
Type: System.String
Parameter Sets: SubscriptionWithDeploymentName, ResourceGroupWithDeploymentName, ManagementGroupWithDeploymentName, TenantWithDeploymentName
Aliases: DeploymentName

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

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

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithDeploymentName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeType
The scope type of the deployment.
- Subscription: Get deployment at subscription scope. 
- ResourceGroup: Get deployment in a resource group.
- ManagementGroup: Get deployment at management group scope.
- Tenant: Get deployment at tenant scope.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments.DeploymentScopeType]
Parameter Sets: SubscriptionWithDeploymentName, ResourceGroupWithDeploymentName, ManagementGroupWithDeploymentName, TenantWithDeploymentName
Aliases:

Required: True
Position: Named
Default value: Subscription
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeployment

## NOTES

## RELATED LINKS
