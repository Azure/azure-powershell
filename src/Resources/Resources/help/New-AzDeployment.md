---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azdeployment
schema: 2.0.0
---

# New-AzDeployment

## SYNOPSIS
Create a deployment

## SYNTAX

### SubscriptionAndTenantWithTemplateFileWithAndNoParameters (Default)
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob]
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateObjectAndParameterObject
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob]
 -TemplateParameterObject <Hashtable> -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateObjectAndParameterFile
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob]
 -TemplateParameterFile <String> -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateFileAndParameterObject
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob]
 -TemplateParameterObject <Hashtable> -TemplateFile <String> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateFileAndParameterFile
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob]
 -TemplateParameterFile <String> -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>]
 [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateObjectAndNoParameters
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob]
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagementGroupWithTemplateObjectAndParameterObject
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String>
 -ManagementGroupId <String> [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterObject <Hashtable>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagementGroupWithTemplateObjectAndParameterFile
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String>
 -ManagementGroupId <String> [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterFile <String>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagementGroupWithTemplateFileAndParameterObject
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String>
 -ManagementGroupId <String> [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterObject <Hashtable>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagementGroupWithTemplateFileAndParameterFile
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String>
 -ManagementGroupId <String> [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterFile <String>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagementGroupWithTemplateObjectAndNoParameters
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String>
 -ManagementGroupId <String> [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob] -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManagementGroupWithTemplateFileWithAndNoParameters
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -Location <String>
 -ManagementGroupId <String> [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] [-AsJob] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndParameterObject
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment]
 [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterObject <Hashtable> -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndParameterFile
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment]
 [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterFile <String> -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileAndParameterObject
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment]
 [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterObject <Hashtable> -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileAndParameterFile
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment]
 [-RollBackDeploymentName <String>] [-AsJob] -TemplateParameterFile <String> -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndNoParameters
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment]
 [-RollBackDeploymentName <String>] [-AsJob] -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceGroupWithTemplateFileWithAndNoParameters
```
New-AzDeployment [-Name <String>] -ScopeType <DeploymentScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-DeploymentDebugLogLevel <String>] [-RollbackToLastDeployment]
 [-RollBackDeploymentName <String>] [-AsJob] -TemplateFile <String> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDeployment** cmdlet creates a template deployment at the specified scope. The supported scopes are: resource group, subscription, management group and tenant. 

A template contains resources that can be deployed to Azure.

An Azure resource is a user-managed Azure entity. A resource can live in a resource group, like database server, database, website, virtual machine, or Storage account.
A resource can be a subscription level resource, like role definition, policy definition, resource group, etc.
A resource can also be at management group scope, like role assignment, policy assignment, etc.
Or, a resource can be a tenant level resource, like management group, role assignment, etc.

To create a deployment at a resource group, specify *ResourceGroup* for *ScopeType*, and a *ResourceGroupName* parameter. 
To create a deployment at the current subscription scope, specify *Subscription* for *ScopeType*, and a *Location* parameter.
To create a deployment at a management group, specify *ManagementGroup* for *ScopeType*, and specify the *ManagementGroupId* and *Location* parameter.
To create a deployment at the tenant scope, specify *Tenant* for *ScopeType* and a *Location* parameter.

The location tells Azure Resource Manager where to store the deployment data. The template is a JSON string that contains individual resources to be deployed.
The template includes parameter placeholders for required resources and configurable property values, such as names and sizes.

To use a custom template for the deployment, specify the *TemplateFile* parameter or *TemplateUri* parameter.
Each template has parameters for configurable properties.
To specify values for the template parameters, specify the *TemplateParameterFile* parameter or the *TemplateParameterObject* parameter.
Alternatively, you can use the template parameters that are dynamically added to the command when you specify a template.
To use dynamic parameters, type them at the command prompt, or type a minus sign (-) to indicate a parameter and use the Tab key to cycle through available parameters.
Template parameter values that you enter at the command prompt take precedence over values in a template parameter object or file.

## EXAMPLES

### Example 1: Create a deployment at subscription scope with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "Subscription" -DeploymentName "deploy-01" -Location "West US" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command creates a new deployment at the current subscription scope by using a custom template and a template file on disk.
The command uses the *Location* parameter to specify where to store the deployment data.
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.

### Example 2: Create a deployment at a resource group with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "ResourceGroup" -DeploymentName "deploy-01" -ResourceGroupName "servicerg" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command creates a new deployment at a resource group by using a custom template and a template file on disk.
This command uses the *ResourceGroupName* parameter to specify the resource group to deploy to. 
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.

### Example 3: Create a deployment at a management group with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "ManagementGroup" -DeploymentName "deploy-01" -ManagementGroupId "mg01" -Location "West US" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command creates a new deployment at a management group by using a custom template and a template file on disk.
This command uses the *ManagementGroupId* parameter to specify the management group to deploy to. It uses *Location* parameter to specify where to store the deployment data.
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.

### Example 4: Create a deployment at tenant scope with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "Tenant" -DeploymentName "deploy-01" -Tenant -Location "West US" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command creates a new deployment at tenant scope by using a custom template and a template file on disk.
This command uses the *Tenant* parameter to incidcate it's a tenant level deployment. It uses *Location* parameter to specify where to store the deployment data.
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.

### Example 5: Use a custom template object and parameter file to create a deployment
```
PS C:\> $TemplateFileText = [System.IO.File]::ReadAllText("D:\Azure\Templates\ServiceTemplate.json")
PS C:\> $TemplateObject = ConvertFrom-Json $TemplateFileText -AsHashtable
PS C:\> New-AzDeployment -ScopeType "Subscription" -Location "West US" -TemplateObject $TemplateObject -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command creates a new deployment at the current subscription scope by using a template file on disk that has been converted to an in-memory hashtable.
The first two commands read the text for the template file on disk and convert it to an in-memory hashtable.
The last command uses the *TemplateObject* parameter to specify this hashtable and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.

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

### -DeploymentDebugLogLevel
The deployment debug log level.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The location to store deployment data.

```yaml
Type: System.String
Parameter Sets: SubscriptionAndTenantWithTemplateFileWithAndNoParameters, SubscriptionAndTenantWithTemplateObjectAndParameterObject, SubscriptionAndTenantWithTemplateObjectAndParameterFile, SubscriptionAndTenantWithTemplateFileAndParameterObject, SubscriptionAndTenantWithTemplateFileAndParameterFile, SubscriptionAndTenantWithTemplateObjectAndNoParameters, ManagementGroupWithTemplateObjectAndParameterObject, ManagementGroupWithTemplateObjectAndParameterFile, ManagementGroupWithTemplateFileAndParameterObject, ManagementGroupWithTemplateFileAndParameterFile, ManagementGroupWithTemplateObjectAndNoParameters, ManagementGroupWithTemplateFileWithAndNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagementGroupId
Specifies the management group ID to deploy to.

```yaml
Type: System.String
Parameter Sets: ManagementGroupWithTemplateObjectAndParameterObject, ManagementGroupWithTemplateObjectAndParameterFile, ManagementGroupWithTemplateFileAndParameterObject, ManagementGroupWithTemplateFileAndParameterFile, ManagementGroupWithTemplateObjectAndNoParameters, ManagementGroupWithTemplateFileWithAndNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Mode
The deployment mode.```yaml
Type: Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the deployment it's going to create.
Only valid when a template is used.
When a template is used, if the user doesn't specify a deployment name, use the current time, like "20131223140835".

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeploymentName

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
Specifies the resource group name to deploy to.

```yaml
Type: System.String
Parameter Sets: ResourceGroupWithTemplateObjectAndParameterObject, ResourceGroupWithTemplateObjectAndParameterFile, ResourceGroupWithTemplateFileAndParameterObject, ResourceGroupWithTemplateFileAndParameterFile, ResourceGroupWithTemplateObjectAndNoParameters, ResourceGroupWithTemplateFileWithAndNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RollBackDeploymentName
Rollback to the successful deployment with the given name in the resource group, should not be used if -RollbackToLastDeployment is used.```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RollbackToLastDeployment
Rollback to the last successful deployment in the resource group, should not be present if -RollBackDeploymentName is used.```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeType
The scope type of the deployment.
- Subscription: Creates deployment at subscription scope. 
- ResourceGroup: Creates deployment in a resource group.
- ManagementGroup: Creates deployment at management group scope.
- Tenant: Creates deployment at tenant scope.

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments.DeploymentScopeType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: Subscription
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipTemplateParameterPrompt
Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template. This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and error out immediately if a parameter was found not to be bound in the template. For non-interactive scripts, -SkipTemplateParameterPrompt can be provided to provide a better error message in the case where not all required parameters are satisfied.

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

### -TemplateFile
A Uri or local path to the template file.

```yaml
Type: System.String
Parameter Sets: SubscriptionAndTenantWithTemplateFileWithAndNoParameters, SubscriptionAndTenantWithTemplateFileAndParameterObject, SubscriptionAndTenantWithTemplateFileAndParameterFile, ManagementGroupWithTemplateFileAndParameterObject, ManagementGroupWithTemplateFileAndParameterFile, ManagementGroupWithTemplateFileWithAndNoParameters, ResourceGroupWithTemplateFileAndParameterObject, ResourceGroupWithTemplateFileAndParameterFile, ResourceGroupWithTemplateFileWithAndNoParameters
Aliases: TemplateUri

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateObject
A hash table which represents the template.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: SubscriptionAndTenantWithTemplateObjectAndParameterObject, SubscriptionAndTenantWithTemplateObjectAndParameterFile, SubscriptionAndTenantWithTemplateObjectAndNoParameters, ManagementGroupWithTemplateObjectAndParameterObject, ManagementGroupWithTemplateObjectAndParameterFile, ManagementGroupWithTemplateObjectAndNoParameters, ResourceGroupWithTemplateObjectAndParameterObject, ResourceGroupWithTemplateObjectAndParameterFile, ResourceGroupWithTemplateObjectAndNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateParameterFile
A Uri or local path to the template parameters file.

```yaml
Type: System.String
Parameter Sets: SubscriptionAndTenantWithTemplateObjectAndParameterFile, SubscriptionAndTenantWithTemplateFileAndParameterFile, ManagementGroupWithTemplateObjectAndParameterFile, ManagementGroupWithTemplateFileAndParameterFile, ResourceGroupWithTemplateObjectAndParameterFile, ResourceGroupWithTemplateFileAndParameterFile
Aliases: TemplateParameterUri

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateParameterObject
A hash table which represents the parameters.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: SubscriptionAndTenantWithTemplateObjectAndParameterObject, SubscriptionAndTenantWithTemplateFileAndParameterObject, ManagementGroupWithTemplateObjectAndParameterObject, ManagementGroupWithTemplateFileAndParameterObject, ResourceGroupWithTemplateObjectAndParameterObject, ResourceGroupWithTemplateFileAndParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.Collections.Hashtable

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeployment

## NOTES

## RELATED LINKS
