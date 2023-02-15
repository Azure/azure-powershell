---
external help file:
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/update-azstaticwebapp
schema: 2.0.0
---

# Update-AzStaticWebApp

## SYNOPSIS
Description for Creates a new static site in an existing resource group, or updates an existing static site.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStaticWebApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AllowConfigFileUpdate] [-ApiBuildCommand <String>] [-ApiLocation <String>] [-AppArtifactLocation <String>]
 [-AppBuildCommand <String>] [-AppLocation <String>] [-Branch <String>] [-ForkRepositoryDescription <String>]
 [-ForkRepositoryIsPrivate] [-ForkRepositoryName <String>] [-ForkRepositoryOwner <String>]
 [-GithubActionSecretNameOverride <String>] [-Kind <String>] [-OutputLocation <String>]
 [-RepositoryToken <String>] [-RepositoryUrl <String>] [-SkipGithubActionWorkflowGeneration]
 [-StagingEnvironmentPolicy <StagingEnvironmentPolicy>] [-TemplateRepositoryUrl <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStaticWebApp -InputObject <IWebsitesIdentity> [-AllowConfigFileUpdate] [-ApiBuildCommand <String>]
 [-ApiLocation <String>] [-AppArtifactLocation <String>] [-AppBuildCommand <String>] [-AppLocation <String>]
 [-Branch <String>] [-ForkRepositoryDescription <String>] [-ForkRepositoryIsPrivate]
 [-ForkRepositoryName <String>] [-ForkRepositoryOwner <String>] [-GithubActionSecretNameOverride <String>]
 [-Kind <String>] [-OutputLocation <String>] [-RepositoryToken <String>] [-RepositoryUrl <String>]
 [-SkipGithubActionWorkflowGeneration] [-StagingEnvironmentPolicy <StagingEnvironmentPolicy>]
 [-TemplateRepositoryUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Description for Creates a new static site in an existing resource group, or updates an existing static site.

## EXAMPLES

### Example 1: Update a static site
```powershell
Update-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00'
```

```output
Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
```

This command updates a static site.

### Example 2: Update a static site by pipeline
```powershell
Get-AzStaticWebApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' | Update-AzStaticWebApp
```

```output
Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb00 Microsoft.Web/staticSites
```

This command updates a static site by pipeline.

## PARAMETERS

### -AllowConfigFileUpdate
\<code\>false\</code\> if config file is locked for this static web app; otherwise, \<code\>true\</code\>.

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

### -ApiBuildCommand
A custom command to run during deployment of the Azure Functions API application.

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

### -ApiLocation
The path to the api code within the repository.

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

### -AppArtifactLocation
Deprecated: The path of the app artifacts after building (deprecated in favor of OutputLocation)

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

### -AppBuildCommand
A custom command to run during deployment of the static content application.

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

### -AppLocation
The path to the app code within the repository.

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
The target branch in the repository.

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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForkRepositoryDescription
Description of the newly generated repository.

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

### -ForkRepositoryIsPrivate
Whether or not the newly generated repository is a private repository.
Defaults to false (i.e.
public).

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

### -ForkRepositoryName
Name of the newly generated repository.

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

### -ForkRepositoryOwner
Owner of the newly generated repository.

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

### -GithubActionSecretNameOverride
Github Action secret name override.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of resource.

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

### -Name
Name of the static site to create or update.

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

### -OutputLocation
The output path of the app after building.

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

### -RepositoryToken
A user's github repository token.
This is used to setup the Github Actions workflow file and API secrets.

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

### -RepositoryUrl
URL for the repository of the static site.

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
Name of the resource group to which the resource belongs.

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

### -SkipGithubActionWorkflowGeneration
Skip Github Action workflow generation.

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

### -StagingEnvironmentPolicy
State indicating whether staging environments are allowed or not allowed for a static web app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Support.StagingEnvironmentPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

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

### -TemplateRepositoryUrl
URL of the template repository.
The newly generated repository will be based on this one.

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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteArmResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IWebsitesIdentity>: Identity Parameter
  - `[Authprovider <String>]`: The auth provider for the users.
  - `[DomainName <String>]`: The custom domain name.
  - `[EnvironmentName <String>]`: The stage site identifier.
  - `[FunctionAppName <String>]`: Name of the function app registered with the static site build.
  - `[Id <String>]`: Resource identity path
  - `[JobHistoryId <String>]`: History ID.
  - `[Location <String>]`: Location where you plan to create the static site.
  - `[Name <String>]`: Name of the static site.
  - `[PrivateEndpointConnectionName <String>]`: Name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[Slot <String>]`: Name of the deployment slot. If a slot is not specified, the API deletes a deployment for the production slot.
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Userid <String>]`: The user id of the user.
  - `[WebJobName <String>]`: Name of Web Job.

## RELATED LINKS

