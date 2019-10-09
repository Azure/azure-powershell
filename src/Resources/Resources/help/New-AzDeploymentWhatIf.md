---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azdeploymentwhatif
schema: 2.0.0
---

# New-AzDeploymentWhatIf

## SYNOPSIS
Create a deployment what-if

## SYNTAX

### SubscriptionWithTemplateFileWithAndNoParameters (Default)
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -Location <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionWithTemplateObjectAndParameterObject
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -Location <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterObject <Hashtable>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionWithTemplateObjectAndParameterFile
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -Location <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterFile <String>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionWithTemplateFileAndParameterObject
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -Location <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterObject <Hashtable>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionWithTemplateFileAndParameterFile
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -Location <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterFile <String>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SubscriptionWithTemplateObjectAndNoParameters
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -Location <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndParameterObject
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterObject <Hashtable>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndParameterFile
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterFile <String>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileAndParameterObject
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterObject <Hashtable>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileAndParameterFile
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateParameterFile <String>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndNoParameters
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileWithAndNoParameters
```
New-AzDeploymentWhatIf [-Name <String>] -ScopeType <DeploymentWhatIfScopeType> -ResourceGroupName <String>
 [-Mode <DeploymentMode>] [-ResultFormat <WhatIfResultFormat>] [-AsJob] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDeploymentWhatIf** cmdlet creates a template deployment what-if operation at the specified scope. It returns a list of changes indicating what resources will be updated if the template deployment is applied without making any changes to real resources. The supported scopes are: resource group and subscription.

A template contains resources that can be deployed to Azure.

An Azure resource is a user-managed Azure entity. A resource can live in a resource group, like database server, database, website, virtual machine, or Storage account.
A resource can be a subscription level resource, like role definition, policy definition, resource group, etc.

To create a deployment what-if at a resource group, specify *ResourceGroup* for *ScopeType*, and a *ResourceGroupName* parameter. 
To create a deployment what-if at the current subscription scope, specify *Subscription* for *ScopeType*, and a *Location* parameter.

The location tells Azure Resource Manager where to store the deployment data. The template is a JSON string that contains individual resources to be deployed.
The template includes parameter placeholders for required resources and configurable property values, such as names and sizes.

To use a custom template for the deployment what-if, specify the *TemplateFile* parameter or *TemplateUri* parameter.
Each template has parameters for configurable properties.
To specify values for the template parameters, specify the *TemplateParameterFile* parameter or the *TemplateParameterObject* parameter.
Alternatively, you can use the template parameters that are dynamically added to the command when you specify a template.
To use dynamic parameters, type them at the command prompt, or type a minus sign (-) to indicate a parameter and use the Tab key to cycle through available parameters.
Template parameter values that you enter at the command prompt take precedence over values in a template parameter object or file.

To specify the format for the returning result, use the *ResultFormat* parameter.

## EXAMPLES

### Example 1: Run a deployment what-if at subscription scope with ResourceIdOnly
```powershell
PS C:\> New-AzDeploymentWhatIf `
    -ScopeType "Subscription" `
    -DeploymentName "deploy-01" `
    -Location "West US" `
    -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" `
    -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json" `
    -ResultFormat "ResourceIdOnly"
```

This command creates a deployment what-if operation at the current subscription scope by using a custom template and a template file on disk.
The command uses the *Location* parameter to specify where to store the deployment data.
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.
The command uses the *ResultFormat* parameter to specify the what-if result to only contain resource IDs.

### Example 2: Run a deployment what-if at subscription scope with FullResourcePayloads
```powershell
PS C:\> New-AzDeploymentWhatIf `
    -ScopeType "Subscription" `
    -DeploymentName "deploy-01" `
    -Location "West US" `
    -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" `
    -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json" `
    -ResultFormat "FullResourcePayloads"
```

This command creates a deployment what-if operation at the current subscription scope by using a custom template and a template file on disk.
The command uses the *Location* parameter to specify where to store the deployment data.
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.
The command uses the *ResultFormat* parameter to specify the what-if result to include full resource payloads.

### Example 3: Run a deployment what-if at a resource group with FullResourcePayloads
```powershell
PS C:\> New-AzDeploymentWhatIf `
    -ScopeType "ResourceGroup" `
    -DeploymentName "deploy-01" `
    -ResourceGroupName "servicerg" `
    -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" `
    -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command creates a deployment what-if operation at a resource group by using a custom template and a template file on disk.
This command uses the *ResourceGroupName* parameter to specify the resource group to deploy to. 
The command uses the *TemplateFile* parameter to specify the template and the *TemplateParameterFile* parameter to specify a file that contains parameters and parameter values.
The command uses the *ResultFormat* parameter to specify the what-if result to include full resource payloads.

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

### -Location
The location to store deployment data.

```yaml
Type: System.String
Parameter Sets: SubscriptionWithTemplateFileWithAndNoParameters, SubscriptionWithTemplateObjectAndParameterObject, SubscriptionWithTemplateObjectAndParameterFile, SubscriptionWithTemplateFileAndParameterObject, SubscriptionWithTemplateFileAndParameterFile, SubscriptionWithTemplateObjectAndNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Mode
The deployment mode.

```yaml
Type: Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode
Parameter Sets: (All)
Aliases:
Accepted values: Incremental, Complete

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
The resource group name.

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

### -ResultFormat
The result format.

```yaml
Type: Microsoft.Azure.Management.ResourceManager.Models.WhatIfResultFormat
Parameter Sets: (All)
Aliases:
Accepted values: ResourceIdOnly, FullResourcePayloads

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeType
The deployment scope type.

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments.DeploymentWhatIfScopeType
Parameter Sets: (All)
Aliases:
Accepted values: Subscription, ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipTemplateParameterPrompt
Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template.
This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and error out immediately if a parameter was found not to be bound in the template.
For non-interactive scripts, -SkipTemplateParameterPrompt can be provided to provide a better error message in the case where not all required parameters are satisfied.

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
Uri or local path to the template file.

```yaml
Type: System.String
Parameter Sets: SubscriptionWithTemplateFileWithAndNoParameters, SubscriptionWithTemplateFileAndParameterObject, SubscriptionWithTemplateFileAndParameterFile, ResourceGroupWithTemplateFileAndParameterObject, ResourceGroupWithTemplateFileAndParameterFile, ResourceGroupWithTemplateFileWithAndNoParameters
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
Parameter Sets: SubscriptionWithTemplateObjectAndParameterObject, SubscriptionWithTemplateObjectAndParameterFile, SubscriptionWithTemplateObjectAndNoParameters, ResourceGroupWithTemplateObjectAndParameterObject, ResourceGroupWithTemplateObjectAndParameterFile, ResourceGroupWithTemplateObjectAndNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateParameterFile
A Uri or local path to the file that has the template parameters.

```yaml
Type: System.String
Parameter Sets: SubscriptionWithTemplateObjectAndParameterFile, SubscriptionWithTemplateFileAndParameterFile, ResourceGroupWithTemplateObjectAndParameterFile, ResourceGroupWithTemplateFileAndParameterFile
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
Parameter Sets: SubscriptionWithTemplateObjectAndParameterObject, SubscriptionWithTemplateFileAndParameterObject, ResourceGroupWithTemplateObjectAndParameterObject, ResourceGroupWithTemplateFileAndParameterObject
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments.PSWhatIfOperationResult

## NOTES

## RELATED LINKS
