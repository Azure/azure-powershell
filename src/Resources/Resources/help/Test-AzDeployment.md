---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeployment
schema: 2.0.0
---

# Test-AzDeployment

## SYNOPSIS
Validates a deployment.

## SYNTAX

### SubscriptionAndTenantWithTemplateFileWithAndNoParameters (Default)
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateObjectAndParameterObject
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterObject <Hashtable>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateObjectAndParameterFile
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterFile <String>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateFileAndParameterObject
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterObject <Hashtable>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateFileAndParameterFile
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterFile <String>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SubscriptionAndTenantWithTemplateObjectAndNoParameters
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ManagementGroupWithTemplateObjectAndParameterObject
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> -ManagementGroupId <String>
 [-Mode <DeploymentMode>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>]
 -TemplateParameterObject <Hashtable> -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupWithTemplateObjectAndParameterFile
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> -ManagementGroupId <String>
 [-Mode <DeploymentMode>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>]
 -TemplateParameterFile <String> -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupWithTemplateFileAndParameterObject
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> -ManagementGroupId <String>
 [-Mode <DeploymentMode>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>]
 -TemplateParameterObject <Hashtable> -TemplateFile <String> [-SkipTemplateParameterPrompt]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupWithTemplateFileAndParameterFile
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> -ManagementGroupId <String>
 [-Mode <DeploymentMode>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>]
 -TemplateParameterFile <String> -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>]
 [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupWithTemplateObjectAndNoParameters
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> -ManagementGroupId <String>
 [-Mode <DeploymentMode>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>]
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ManagementGroupWithTemplateFileWithAndNoParameters
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -Location <String> -ManagementGroupId <String>
 [-Mode <DeploymentMode>] [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndParameterObject
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterObject <Hashtable>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndParameterFile
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterFile <String>
 -TemplateObject <Hashtable> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileAndParameterObject
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterObject <Hashtable>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithTemplateFileAndParameterFile
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateParameterFile <String>
 -TemplateFile <String> [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupWithTemplateObjectAndNoParameters
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceGroupWithTemplateFileWithAndNoParameters
```
Test-AzDeployment -ScopeType <DeploymentScopeType> -ResourceGroupName <String> [-Mode <DeploymentMode>]
 [-RollbackToLastDeployment] [-RollBackDeploymentName <String>] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Test-AzDeployment** cmdlet determines whether a deployment template and its parameter values are valid.

## EXAMPLES

### Example 1: Test deployment at subscription scope with a custom template and parameter file
```
PS C:\> Test-AzDeployment -ScopeType "Subscription" -Location "West US" -TemplateFile "D:\Azure\Templates\EngineeringSite.json" -TemplateParameterFile "D:\Azure\Templates\EngSiteParms.json"
```

This command tests a deployment at the current subscription scope using the given template file and parameters file.

### Example 2: Test deployment at a resource group with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "ResourceGroup" -ResourceGroupName "servicerg" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command tests a deployment at a resource group using the given template file and parameters file.

### Example 3: Test deployment at a management group with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "ManagementGroup" -ManagementGroupId "mg01" -Location "West US" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command tests a deployment at a management group using the given template file and parameters file.

### Example 4: Test a deployment at tenant scope with a custom template and parameter file
```
PS C:\> New-AzDeployment -ScopeType "Tenant" -Location "West US" -TemplateFile "D:\Azure\Templates\ServiceTemplate.json" -TemplateParameterFile "D:\Azure\Templates\ServiceParameters.json"
```

This command tests a deployment at the tenant scope using the given template file and parameters file.

### Example 5: Test deployment with a custom template object and parameter file
```
PS C:\> $TemplateFileText = [System.IO.File]::ReadAllText("D:\Azure\Templates\EngineeringSite.json")
PS C:\> $TemplateObject = ConvertFrom-Json $TemplateFileText -AsHashtable
PS C:\> Test-AzDeployment -ScopeType "Subscription" -Location "West US" -TemplateObject $TemplateObject -TemplateParameterFile "D:\Azure\Templates\EngSiteParams.json"
```

This command tests a deployment at the current subscription scope using the an in-memory hashtable created from the given template file and a parameter file.

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
The management group id.```yaml
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
The deployment scope type.```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments.DeploymentScopeType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
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
Local path to the template file.

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
A file that has the template parameters.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Collections.Hashtable

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceManagerError

## NOTES

## RELATED LINKS
