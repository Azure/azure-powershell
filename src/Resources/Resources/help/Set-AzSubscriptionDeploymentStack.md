---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/Set-AzSubscriptionDeploymentStack
schema: 2.0.0
---

# Set-AzSubscriptionDeploymentStack

## SYNOPSIS
Sets a new Subscription scoped Deployment Stack.

## SYNTAX

### ByTemplateFileWithNoParameters (Default)
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateFile <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterFile
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateFile <String> -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterUri
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateFile <String> -TemplateParameterUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateFileWithParameterObject
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateFile <String> -TemplateParameterObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterFile
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateUri <String> -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterUri
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateUri <String> -TemplateParameterUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithParameterObject
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateUri <String> -TemplateParameterObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateUriWithNoParameters
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateUri <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterFile
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateSpecId <String> -TemplateParameterFile <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterUri
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateSpecId <String> -TemplateParameterUri <String>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithParameterObject
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateSpecId <String> -TemplateParameterObject <Hashtable>
 [-SkipTemplateParameterPrompt] [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByTemplateSpecWithNoParameters
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateSpecId <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParameterFileWithNoTemplate
```
Set-AzSubscriptionDeploymentStack -Name <String> [-Description <String>] -Location <String>
 [-DeploymentResourceGroupName <String>] -ActionOnUnmanage <PSActionOnUnmanage>
 -DenySettingsMode <PSDenySettingsMode> [-DenySettingsExcludedPrincipal <String[]>]
 [-DenySettingsExcludedAction <String[]>] [-DenySettingsApplyToChildScopes] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-BypassStackOutOfSyncError] -TemplateParameterFile <String> [-SkipTemplateParameterPrompt]
 [-QueryString <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a subscription scoped deployment stack.

## EXAMPLES

### Example 1: Updates the subscription scoped deployment stack MySubStack at the current subscription
```powershell
Set-AzSubscriptionDeploymentStack -Name MySubStack -TemplateFile myTemplate.json -Location westus -DenySettingsMode DenyDelete
```

Update a subscription scoped deployment stack named 'MySubStack' in the default subscription, with deny settings being DenyDelete. 

### Example 2: Use a .bicepparam file to update a stack
```powershell
Set-AzSubscriptionDeploymentStack -Name MySubStack -Location westus -DenySettingsMode DenyDelete -TemplateParameterFile "./parameters.bicepparam"
```

This command updates a stack at the subscription scope by using a .bicepparam file on disk.

## PARAMETERS

### -ActionOnUnmanage
Action to take on resources that become unmanaged on deletion or update of the deployment stack. Possible values include: 'detachAll' (do not delete any unmanaged resources), 'deleteResources' (delete all unmanaged resources that are not RGs or MGs), and 'deleteAll' (delete every unmanaged resource).

```yaml
Type: Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks.PSActionOnUnmanage
Parameter Sets: (All)
Aliases:
Accepted values: DetachAll, DeleteResources, DeleteAll

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -BypassStackOutOfSyncError
Bypass errors for the stack being out of sync when running the operation. If the stack is out of sync and this parameter is not set, the operation will fail. Only include this parameter if instructed to do so on a failed stack operation.

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

### -DeploymentResourceGroupName
The ResourceGroup at which the deployment will be created. If none is specified, it will default to the subscription level scope of the deployment stack.

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
The name of the deploymentStack to create.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
