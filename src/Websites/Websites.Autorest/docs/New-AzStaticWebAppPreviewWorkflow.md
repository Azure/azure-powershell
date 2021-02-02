---
external help file:
Module Name: Az.Websites
online version: https://docs.microsoft.com/en-us/powershell/module/az.websites/new-azstaticwebapppreviewworkflow
schema: 2.0.0
---

# New-AzStaticWebAppPreviewWorkflow

## SYNOPSIS
Description for Generates a preview workflow file for the static site

## SYNTAX

### PreviewExpanded (Default)
```
New-AzStaticWebAppPreviewWorkflow -Location <String> [-SubscriptionId <String>] [-Branch <String>]
 [-BuildPropertyApiLocation <String>] [-BuildPropertyAppArtifactLocation <String>]
 [-BuildPropertyAppLocation <String>] [-Kind <String>] [-RepositoryUrl <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Preview
```
New-AzStaticWebAppPreviewWorkflow -Location <String>
 -StaticSitesWorkflowPreviewRequest <IStaticSitesWorkflowPreviewRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PreviewViaIdentity
```
New-AzStaticWebAppPreviewWorkflow -InputObject <IWebsitesIdentity>
 -StaticSitesWorkflowPreviewRequest <IStaticSitesWorkflowPreviewRequest> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PreviewViaIdentityExpanded
```
New-AzStaticWebAppPreviewWorkflow -InputObject <IWebsitesIdentity> [-Branch <String>]
 [-BuildPropertyApiLocation <String>] [-BuildPropertyAppArtifactLocation <String>]
 [-BuildPropertyAppLocation <String>] [-Kind <String>] [-RepositoryUrl <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Description for Generates a preview workflow file for the static site

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Branch
The target branch in the repository.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildPropertyApiLocation
The path to the api code within the repository.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildPropertyAppArtifactLocation
The path of the app artifacts after building.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildPropertyAppLocation
The path to the app code within the repository.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
Parameter Sets: PreviewViaIdentity, PreviewViaIdentityExpanded
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
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location where you plan to create the static site.

```yaml
Type: System.String
Parameter Sets: Preview, PreviewExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RepositoryUrl
URL for the repository of the static site.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticSitesWorkflowPreviewRequest
Request entity for previewing the Static Site workflow
To construct, see NOTES section for STATICSITESWORKFLOWPREVIEWREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20200601.IStaticSitesWorkflowPreviewRequest
Parameter Sets: Preview, PreviewViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Preview, PreviewExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20200601.IStaticSitesWorkflowPreviewRequest

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20200601.IStaticSitesWorkflowPreview

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IWebsitesIdentity>: Identity Parameter
  - `[Authprovider <String>]`: The auth provider for the users.
  - `[DomainName <String>]`: The custom domain to create.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Location where you plan to create the static site.
  - `[Name <String>]`: Name of the static site.
  - `[PrId <String>]`: The stage site identifier.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Userid <String>]`: The user id of the user.

STATICSITESWORKFLOWPREVIEWREQUEST <IStaticSitesWorkflowPreviewRequest>: Request entity for previewing the Static Site workflow
  - `[Kind <String>]`: Kind of resource.
  - `[Branch <String>]`: The target branch in the repository.
  - `[BuildPropertyApiLocation <String>]`: The path to the api code within the repository.
  - `[BuildPropertyAppArtifactLocation <String>]`: The path of the app artifacts after building.
  - `[BuildPropertyAppLocation <String>]`: The path to the app code within the repository.
  - `[RepositoryUrl <String>]`: URL for the repository of the static site.

## RELATED LINKS

