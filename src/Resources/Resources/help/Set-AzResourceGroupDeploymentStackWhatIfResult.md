---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Set-AzResourceGroupDeploymentStackWhatIfResultschema: 2.0.0
---

# Set-AzResourceGroupDeploymentStackWhatIfResult

## SYNOPSIS
Updates a resource group scoped deployment stack WhatIf result.

## SYNTAX

### ByTemplateFileWithNoParameters (Default)
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateFile <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByTemplateFileWithParameterFile
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateFile <String> -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterUri
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateFile <String> -TemplateParameterUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterObject
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateFile <String> -TemplateParameterObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterFile
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateUri <String> -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterUri
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateUri <String> -TemplateParameterUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterObject
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateUri <String> -TemplateParameterObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithNoParameters
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateUri <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByTemplateSpecWithParameterFile
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateSpecId <String> -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterUri
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateSpecId <String> -TemplateParameterUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterObject
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateSpecId <String> -TemplateParameterObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithNoParameters
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateSpecId <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParameterFileWithNoTemplate
```
Set-AzResourceGroupDeploymentStackWhatIfResult -Name <String> -StackResourceId <String>
 -RetentionInterval <String> -ResourceGroupName <String> [-Description <String>]
 [-ActionOnUnmanage <PSActionOnUnmanage>] [-DenySettingsMode <PSDenySettingsMode>]
 [-DenySettingsExcludedPrincipal <String[]>] [-DenySettingsExcludedAction <String[]>]
 [-DenySettingsApplyToChildScopes] [-ValidationLevel <String>] [-DebugSettingDetailLevel <String>]
 [-BypassStackOutOfSyncError] [-Force] [-AsJob] -TemplateParameterFile <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a resource group scoped deployment stack WhatIf result resource. This cmdlet works with persisted deployment stack WhatIf result resources.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ActionOnUnmanage
Action to take on resources that become unmanaged.
Possible values include: 'detachAll', 'deleteResources', and 'deleteAll'.

```yaml
Type: PSActionOnUnmanage
Parameter Sets: (All)
Aliases:
Accepted values: DetachAll, DeleteResources, DeleteAll

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BypassStackOutOfSyncError
Flag to bypass stack out-of-sync error.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DebugSettingDetailLevel
Debug setting detail level (e.g.
RequestContent, ResponseContent).

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenySettingsApplyToChildScopes
Apply to child scopes.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenySettingsExcludedAction
List of role-based management operations excluded from the denySettings.
Up to 200 actions are permitted.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenySettingsExcludedPrincipal
List of AAD principal IDs excluded from the lock.
Up to 5 principals are permitted.

```yaml
Type: String[]
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
Type: PSDenySettingsMode
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
Description for the WhatIf result.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation when an existing WhatIf result will be overwritten.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the WhatIf result resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryString
The query string (for example, a SAS token) to be used with the TemplateUri parameter.
Would be used in case of linked templates

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the ResourceGroup.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionInterval
The interval to persist the WhatIf result in ISO 8601 format (e.g.
P1D for 1 day).

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipTemplateParameterPrompt
Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template.
This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and error out immediately if a parameter was found not to be bound in the template.
For non-interactive scripts, -SkipTemplateParameterPrompt can be provided to provide a better error message in the case where not all required parameters are satisfied.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StackResourceId
The fully-qualified resource ID of the deployment stack to use as the basis for comparison.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateFile
TemplateFile to be used to create the stack.

```yaml
Type: String
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
Type: String
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
Type: Hashtable
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
Type: String
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
Type: String
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
Type: String
Parameter Sets: ByTemplateUriWithParameterFile, ByTemplateUriWithParameterUri, ByTemplateUriWithParameterObject, ByTemplateUriWithNoParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ValidationLevel
Validation level.
Possible values: Template, Provider, ProviderNoRbac.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf.PSDeploymentStackWhatIfResult

## NOTES

## RELATED LINKS

