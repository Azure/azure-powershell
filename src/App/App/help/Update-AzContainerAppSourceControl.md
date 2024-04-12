---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/update-azcontainerappsourcecontrol
schema: 2.0.0
---

# Update-AzContainerAppSourceControl

## SYNOPSIS
Create the SourceControl for a Container App.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerAppSourceControl -ContainerAppName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AzureClientId <String>] [-AzureClientSecret <SecureString>] [-AzureKind <String>]
 [-AzureSubscriptionId <String>] [-AzureTenantId <String>] [-Branch <String>]
 [-GithubAccessToken <SecureString>] [-GithubConfigurationImage <String>] [-GithubContextPath <String>]
 [-GithubOS <String>] [-GithubPublishType <String>] [-GithubRuntimeStack <String>]
 [-GithubRuntimeVersion <String>] [-RegistryPassword <SecureString>] [-RegistryUrl <String>]
 [-RegistryUserName <String>] [-RepoUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityContainerAppExpanded
```
Update-AzContainerAppSourceControl -Name <String> -ContainerAppInputObject <IAppIdentity>
 [-AzureClientId <String>] [-AzureClientSecret <SecureString>] [-AzureKind <String>]
 [-AzureSubscriptionId <String>] [-AzureTenantId <String>] [-Branch <String>]
 [-GithubAccessToken <SecureString>] [-GithubConfigurationImage <String>] [-GithubContextPath <String>]
 [-GithubOS <String>] [-GithubPublishType <String>] [-GithubRuntimeStack <String>]
 [-GithubRuntimeVersion <String>] [-RegistryPassword <SecureString>] [-RegistryUrl <String>]
 [-RegistryUserName <String>] [-RepoUrl <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerAppSourceControl -InputObject <IAppIdentity> [-AzureClientId <String>]
 [-AzureClientSecret <SecureString>] [-AzureKind <String>] [-AzureSubscriptionId <String>]
 [-AzureTenantId <String>] [-Branch <String>] [-GithubAccessToken <SecureString>]
 [-GithubConfigurationImage <String>] [-GithubContextPath <String>] [-GithubOS <String>]
 [-GithubPublishType <String>] [-GithubRuntimeStack <String>] [-GithubRuntimeVersion <String>]
 [-RegistryPassword <SecureString>] [-RegistryUrl <String>] [-RegistryUserName <String>] [-RepoUrl <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create the SourceControl for a Container App.

## EXAMPLES

### Example 1: Update source control for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$RegistryPassword = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$GithubAccessToken = ConvertTo-SecureString -String "1234" -Force -AsPlainText

Update-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Update source control for a Container App.

### Example 2: Update source control for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$RegistryPassword = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$GithubAccessToken = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$sourcecontrol = Get-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current

Update-AzContainerAppSourceControl -InputObject $sourcecontrol -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Update source control for a Container App.

### Example 3: Update source control for a Container App.
```powershell
$AzureClientSecret = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$RegistryPassword = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$GithubAccessToken = ConvertTo-SecureString -String "1234" -Force -AsPlainText
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1

Update-AzContainerAppSourceControl -ContainerAppInputObject $containerapp -Name current -AzureClientId "UserObjectId" -AzureClientSecret $AzureClientSecret -AzureKind "feaderated" -AzureTenantId "UserDirectoryID" -Branch "main" -GithubContextPath "./" -GithubAccessToken $GithubAccessToken -GithubConfigurationImage "azps-containerapp-1" -RegistryPassword $RegistryPassword -RegistryUrl "azpscontainerregistry.azurecr.io" -RegistryUserName "azpscontainerregistry" -RepoUrl "https://github.com/lijinpei2008/ghatest"
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Update source control for a Container App.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -AzureClientId
Client Id.

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

### -AzureClientSecret
Client Secret.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureKind
Kind of auth github does for deploying the template

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

### -AzureSubscriptionId
Subscription Id.

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

### -AzureTenantId
Tenant Id.

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

### -Branch
The branch which will trigger the auto deployment

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

### -ContainerAppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityContainerAppExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ContainerAppName
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GithubAccessToken
One time Github PAT to configure github environment

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GithubConfigurationImage
Image name

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

### -GithubContextPath
Context path

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

### -GithubOS
Operation system

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

### -GithubPublishType
Code or Image

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

### -GithubRuntimeStack
Runtime stack

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

### -GithubRuntimeVersion
Runtime version

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Container App SourceControl.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityContainerAppExpanded
Aliases: SourceControlName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -RegistryPassword
registry secret.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryUrl
registry server Url.

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

### -RegistryUserName
registry username.

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

### -RepoUrl
The repo url which will be integrated to ContainerApp.

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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ISourceControl

## NOTES

## RELATED LINKS
