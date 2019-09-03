---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/remove-azdeployment
schema: 2.0.0
---

# Remove-AzDeployment

## SYNOPSIS
Removes a deployment and any associated operations

## SYNTAX

### SubscriptionWithDeploymentName (Default)
```
Remove-AzDeployment -ScopeType <DeploymentScopeType> [-Name] <String> [-AsJob] [-PassThru]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceGroupWithDeploymentName
```
Remove-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Name] <String> [-AsJob]
 [-PassThru] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ManagementGroupWithDeploymentName
```
Remove-AzDeployment -ScopeType <DeploymentScopeType> -ManagementGroupId <String> [-Name] <String> [-AsJob]
 [-PassThru] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### TenantWithDeploymentName
```
Remove-AzDeployment -ScopeType <DeploymentScopeType> [-Name] <String> [-AsJob] [-PassThru]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RemoveByDeploymentId
```
Remove-AzDeployment -Id <String> [-AsJob] [-PassThru] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByInputObject
```
Remove-AzDeployment -InputObject <PSDeployment> [-AsJob] [-PassThru] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzDeployment** cmdlet removes an Azure deployment and its associated operations at subscription, resource group, management group, or tenant scope.

## EXAMPLES

### Example 1: Remove a deployment at subscription scope
```
PS C:\>Remove-AzDeployment -ScopeType "Subscription" -Name "RolesDeployment"
```

This command removes the deployment "RolesDeployment" at the current subscription scope.

### Example 2: Remove a deployment at resource group
```
PS C:\>Remove-AzDeployment -ScopeType "ResourceGroup" -ResourceGroupName "testrg" -Name "RolesDeployment"
```

This command removes the deployment "RolesDeployment" at resource group "testrg".

### Example 3: Remove a deployment at management group
```
PS C:\>Remove-AzDeployment -ScopeType "ManagementGroup" -ManagementGroupId "testmg" -Name "RolesDeployment"
```

This command removes the deployment "RolesDeployment" at management group "testmg".

### Example 4: Remove a deployment at tenant scope
```
PS C:\>Remove-AzDeployment -ScopeType "Tenant" -Name "RolesDeployment"
```

This command removes the deployment "RolesDeployment" at the current tenant scope.

### Example 5: Get a deployment and remove it
```
PS C:\>Get-AzDeployment -ScopeType "Subscription" -Name "RolesDeployment" | Remove-AzDeployment
```

This command gets the deployment "RolesDeployment" at the current subscription scope and removes it.

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

### -AsJob
Run cmdlet in the background

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
Parameter Sets: RemoveByDeploymentId
Aliases: DeploymentId, ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The deployment object.

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeployment
Parameter Sets: RemoveByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
The management group id.```yaml
Type: System.String
Parameter Sets: ManagementGroupWithDeploymentName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the deployment.

```yaml
Type: System.String
Parameter Sets: SubscriptionWithDeploymentName, ResourceGroupWithDeploymentName, ManagementGroupWithDeploymentName, TenantWithDeploymentName
Aliases: DeploymentName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
{{Fill PassThru Description}}

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
The resource group name.```yaml
Type: System.String
Parameter Sets: ResourceGroupWithDeploymentName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeType
The scope type of the deployment.```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments.DeploymentScopeType]
Parameter Sets: SubscriptionWithDeploymentName, ResourceGroupWithDeploymentName, ManagementGroupWithDeploymentName, TenantWithDeploymentName
Aliases:

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeployment

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
