---
external help file: Az.ContainerRegistry-help.xml
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistryimportpipeline
schema: 2.0.0
---

# Get-AzContainerRegistryImportPipeline

## SYNOPSIS
Gets the properties of the import pipeline.

## SYNTAX

### List (Default)
```
Get-AzContainerRegistryImportPipeline -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzContainerRegistryImportPipeline -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistryImportPipeline -InputObject <IContainerRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the import pipeline.

## EXAMPLES

### Example 1: Lists all import pipelines for the specified container registry.
```powershell
Get-AzContainerRegistryImportPipeline -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
Name    SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----    -------------------   -------------------       ----------------------- ------------------------ ------------------------
Example 30/01/2023 9:09:31 am user@microsoft.com        User                    30/01/2023 9:09:31 am    user@microsoft.com
```

Lists all import pipelines for the specified container registry.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the import pipeline.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ImportPipelineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IImportPipeline

## NOTES

## RELATED LINKS
