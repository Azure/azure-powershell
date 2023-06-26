---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/import-azcontainerregistryimage
schema: 2.0.0
---

# Import-AzContainerRegistryImage

## SYNOPSIS
Copies an image to this container registry from the specified container registry.

## SYNTAX

### ImportExpanded (Default)
```
Import-AzContainerRegistryImage -RegistryName <String> -ResourceGroupName <String> -SourceImage <String>
 [-SubscriptionId <String>] [-Mode <ImportMode>] [-Password <String>] [-SourceRegistryUri <String>]
 [-SourceResourceId <String>] [-TargetTag <String[]>] [-UntaggedTargetRepository <String[]>]
 [-Username <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Import
```
Import-AzContainerRegistryImage -RegistryName <String> -ResourceGroupName <String>
 -Parameter <IImportImageParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Copies an image to this container registry from the specified container registry.

## EXAMPLES

### Example 1: Import image from a public/azure registry to an azure container registry.
```powershell
Import-AzContainerRegistryImage -SourceImage library/busybox:latest -ResourceGroupName $resourceGroupName -RegistryName $RegistryName -SourceRegistryUri docker.io -TargetTag busybox:latest
```

Import busybox to ACR.
Note:
"library/" need to be add before source image.
"busybox:latest" =\> "library/busybox:latest"
Credential needed if source registry is not publicly available
SourceRegistryResourceId or SourceRegistryUri is required for this cmdlet

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

### -Mode
When Force, any existing target tags will be overwritten.
When NoForce, any existing target tags will fail the operation before any copying begins.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.ImportMode
Parameter Sets: ImportExpanded
Aliases:

Required: False
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

### -Parameter
.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IImportImageParameters
Parameter Sets: Import
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -Password
The password used to authenticate with the source registry.

```yaml
Type: System.String
Parameter Sets: ImportExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceImage
Repository name of the source image.Specify an image by repository ('hello-world').
This will use the 'latest' tag.Specify an image by tag ('hello-world:latest').Specify an image by sha256-based manifest digest ('hello-world@sha256:abc123').

```yaml
Type: System.String
Parameter Sets: ImportExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceRegistryUri
The address of the source registry (e.g.
'mcr.microsoft.com').

```yaml
Type: System.String
Parameter Sets: ImportExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
The resource identifier of the source Azure Container Registry.

```yaml
Type: System.String
Parameter Sets: ImportExpanded
Aliases: SourceRegistryResourceId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetTag
List of strings of the form repo[:tag].
When tag is omitted the source will be used (or 'latest' if source tag is also omitted).

```yaml
Type: System.String[]
Parameter Sets: ImportExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UntaggedTargetRepository
List of strings of repository names to do a manifest only copy.
No tag will be created.

```yaml
Type: System.String[]
Parameter Sets: ImportExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Username
The username to authenticate with the source registry.

```yaml
Type: System.String
Parameter Sets: ImportExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IImportImageParameters

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PARAMETER <IImportImageParameters>`: .
  - `SourceImage <String>`: Repository name of the source image.         Specify an image by repository ('hello-world'). This will use the 'latest' tag.         Specify an image by tag ('hello-world:latest').         Specify an image by sha256-based manifest digest ('hello-world@sha256:abc123').
  - `[CredentialsPassword <String>]`: The password used to authenticate with the source registry.
  - `[CredentialsUsername <String>]`: The username to authenticate with the source registry.
  - `[Mode <ImportMode?>]`: When Force, any existing target tags will be overwritten. When NoForce, any existing target tags will fail the operation before any copying begins.
  - `[SourceRegistryUri <String>]`: The address of the source registry (e.g. 'mcr.microsoft.com').
  - `[SourceResourceId <String>]`: The resource identifier of the source Azure Container Registry.
  - `[TargetTag <String[]>]`: List of strings of the form repo[:tag]. When tag is omitted the source will be used (or 'latest' if source tag is also omitted).
  - `[UntaggedTargetRepository <String[]>]`: List of strings of repository names to do a manifest only copy. No tag will be created.

## RELATED LINKS

