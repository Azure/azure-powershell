---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/New-AzResourceGroupDeploymentStack
schema: 2.0.0
---

# New-AzResourceGroupDeploymentStack

## SYNOPSIS
Creates a new Resource Group scoped Deployment Stack.

## SYNTAX

### ByTemplateFileWithNoParameters (Default)
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterFile
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateFile <String>
 -TemplateParameterFile <String> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterUri
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateFile <String>
 -TemplateParameterUri <String> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterObject
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateFile <String>
 -TemplateParameterObject <Hashtable> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterFile
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateUri <String>
 -TemplateParameterFile <String> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterUri
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateUri <String>
 -TemplateParameterUri <String> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterObject
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateUri <String>
 -TemplateParameterObject <Hashtable> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithNoParameters
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterFile
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateSpecId <String>
 -TemplateParameterFile <String> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterUri
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateSpecId <String>
 -TemplateParameterUri <String> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterObject
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateSpecId <String>
 -TemplateParameterObject <Hashtable> [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithNoParameters
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateSpecId <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParameterFileWithNoTemplate
```
New-AzResourceGroupDeploymentStack -Name <String> -ResourceGroupName <String> [-Description <String>]
 [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups] -DenySettingsMode <PSDenySettingsMode>
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force] [-AsJob] -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a resource group scoped deployment stack.

## EXAMPLES

### Example 1: Create the stack MyRGStack in the Resource Group MyResourceGroup
```powershell
New-AzResourceGroupDeploymentStack -Name MyRGStack -ResourceGroupName MyResourceGroup -TemplateFile myTemplate.json -DenySettingsMode DenyDelete
```

Create a new resource group scoped deployment stack named 'MyRGStack' in management group 'MyResoourceGroup,' with deny settings being DenyDelete. 

### Example 2: Use a .bicepparam file to create a stack
```powershell
New-AzResourceGroupDeploymentStack -Name MyRGStack -ResourceGroupName MyResourceGroup -DenySettingsMode DenyDelete -TemplateParameterFile "./parameters.bicepparam"
```

This command creates a new stack at the resource group scope by using a .bicepparam file on disk.

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -DeleteAll
Signal to delete both unmanaged Resources and ResourceGroups after updating stack.

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

### -DeleteResourceGroups
Signal to delete unmanaged stack ResourceGroups after updating stack.

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

### -DeleteResources
Signal to delete unmanaged stack Resources after updating stack.

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

### -DenySettingsApplyToChildScopes
Apply to child scopes.

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

### -DenySettingsExcludedAction
List of role-based management operations that are excluded from the denySettings. Up to 200 actions are permitted.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenySettingsExcludedPrincipal
List of AAD principal IDs excluded from the lock. Up to 5 principals are permitted.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenySettingsMode
Mode for DenySettings.
Possible values include: 'denyDelete', 'denyWriteAndDelete', and 'none'.

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDenySettingsMode
Parameter Sets: (All)
Aliases:
Accepted values: None, DenyDelete, DenyWriteAndDelete

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description for the stack.

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

### -Force
Do not ask for confirmation when overwriting an existing stack.

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

### -Name
The name of the DeploymentStack to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: StackName

Required: True
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

### -QueryString
The query string (for example, a SAS token) to be used with the TemplateUri parameter. Would be used in case of linked templates

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

### -ResourceGroupName
The name of the ResourceGroup to be used.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Tag
The tags to put on the deployment.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateFile
TemplateFile to be used to create the stack.

```yaml
Type: System.String
Parameter Sets: ByTemplateFileWithNoParameters, ByTemplateFileWithParameterFile, ByTemplateFileWithParameterUri, ByTemplateFileWithParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateParameterFile
Parameter file to use for the template.

```yaml
Type: System.String
Parameter Sets: ByTemplateFileWithParameterFile, ByTemplateUriWithParameterFile, ByTemplateSpecWithParameterFile, ByParameterFileWithNoTemplate
Aliases:

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
Parameter Sets: ByTemplateFileWithParameterObject, ByTemplateUriWithParameterObject, ByTemplateSpecWithParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateParameterUri
Location of the Parameter file to use for the template.

```yaml
Type: System.String
Parameter Sets: ByTemplateFileWithParameterUri, ByTemplateUriWithParameterUri, ByTemplateSpecWithParameterUri
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateSpecId
ResourceId of the TemplateSpec to be used to create the stack.

```yaml
Type: System.String
Parameter Sets: ByTemplateSpecWithParameterFile, ByTemplateSpecWithParameterUri, ByTemplateSpecWithParameterObject, ByTemplateSpecWithNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateUri
Location of the Template to be used to create the stack.

```yaml
Type: System.String
Parameter Sets: ByTemplateUriWithParameterFile, ByTemplateUriWithParameterUri, ByTemplateUriWithParameterObject, ByTemplateUriWithNoParameters
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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSDeploymentStack

## NOTES

## RELATED LINKS
