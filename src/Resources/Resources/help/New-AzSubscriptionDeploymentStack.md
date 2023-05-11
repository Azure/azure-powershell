---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/update-azrolemanagementpolicy
schema: 2.0.0
---

# New-AzSubscriptionDeploymentStack

## SYNOPSIS
Creates a new Subscription scoped Deployment Stack.

## SYNTAX

### ByTemplateFileWithNoParameters (Default)
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateFile <String> [-Description <String>]
 -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterFile
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateFile <String> -TemplateParameterFile <String>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterUri
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateFile <String> -TemplateParameterUri <String>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterObject
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateFile <String> -TemplateParameterObject <Hashtable>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterFile
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateUri <String> -TemplateParameterFile <String>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterUri
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateUri <String> -TemplateParameterUri <String>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterObject
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateUri <String> -TemplateParameterObject <Hashtable>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithNoParameters
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateUri <String> [-Description <String>]
 -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterFile
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateSpecId <String> -TemplateParameterFile <String>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterUri
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateSpecId <String> -TemplateParameterUri <String>
 [-Description <String>] -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterObject
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateSpecId <String>
 -TemplateParameterObject <Hashtable> [-Description <String>] -Location <String> [-DeleteAll]
 [-DeleteResources] [-DeleteResourceGroups] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipals <String[]>] [-DenySettingsExcludedActions <String[]>]
 [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>] [-Force] [-AsJob] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithNoParameters
```
New-AzSubscriptionDeploymentStack [-Name] <String> -TemplateSpecId <String> [-Description <String>]
 -Location <String> [-DeleteAll] [-DeleteResources] [-DeleteResourceGroups]
 [-DenySettingsMode <PSDenySettingsMode>] [-DenySettingsExcludedPrincipals <String[]>]
 [-DenySettingsExcludedActions <String[]>] [-DenySettingsApplyToChildScopes] [-ResourceGroupName <String>]
 [-Force] [-AsJob] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
Signal to delete both resources and resource groups after updating stack.

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
Signal to delete unmanaged stack resource groups after updating stack.

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
Signal to delete unmanaged stack resources after upating stack.

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

### -DenySettingsExcludedActions
List of role-based management operations that are excluded from the denySettings.
Up to 200 actions are permitted.

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

### -DenySettingsExcludedPrincipals
List of AAD principal IDs excluded from the lock.
Up to 5 principals are permitted.

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

Required: False
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

### -Location
Location of the stack.

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

### -Name
The name of the deploymentStack to create

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: StackName

Required: True
Position: 0
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
The ResourceGroup at which the deployment will be created.
If none is specified, it will default to the subscription level scope of the deployment stack.

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
Parameter Sets: ByTemplateFileWithParameterFile, ByTemplateUriWithParameterFile, ByTemplateSpecWithParameterFile
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
