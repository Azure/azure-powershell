---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/update-azcontainerregistryscopemap
schema: 2.0.0
---

# Update-AzContainerRegistryScopeMap

## SYNOPSIS
Updates a scope map with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerRegistryScopeMap -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Action <String[]>] [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzContainerRegistryScopeMap -Name <String> -RegistryName <String> -ResourceGroupName <String>
 -ScopeMapUpdateParameter <IScopeMapUpdateParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzContainerRegistryScopeMap -InputObject <IContainerRegistryIdentity>
 -ScopeMapUpdateParameter <IScopeMapUpdateParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerRegistryScopeMap -InputObject <IContainerRegistryIdentity> [-Action <String[]>]
 [-Description <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a scope map with the specified parameters.

## EXAMPLES

### Example 1: Update action for a scope map
```powershell
Update-AzContainerRegistryScopeMap -Name newmap -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Action "repositories/busybox/content/read"

```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                     tModifiedBy
----  ------------------- -------------------       ----------------------- ------------------------ -------------
newmap 01/20/2023 05:49:36 user@microsoft.com       User                    01/20/2023 05:49:36      user@microsoft.com  
```

Update action for a scope map

## PARAMETERS

### -Action
The list of scope permissions for registry artifacts.E.g.
repositories/repository-name/pull, repositories/repository-name/delete

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Description
The user friendly description of the scope map.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the scope map.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ScopeMapName

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

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the container registry belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeMapUpdateParameter
The properties for updating the scope map.
To construct, see NOTES section for SCOPEMAPUPDATEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IScopeMapUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IScopeMapUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IScopeMap

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerRegistryIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[ConnectedRegistryName <String>]`: The name of the connected registry.
  - `[ExportPipelineName <String>]`: The name of the export pipeline.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[ImportPipelineName <String>]`: The name of the import pipeline.
  - `[PipelineRunName <String>]`: The name of the pipeline run.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[RegistryName <String>]`: The name of the container registry.
  - `[ReplicationName <String>]`: The name of the replication.
  - `[ResourceGroupName <String>]`: The name of the resource group to which the container registry belongs.
  - `[RunId <String>]`: The run ID.
  - `[ScopeMapName <String>]`: The name of the scope map.
  - `[SubscriptionId <String>]`: The Microsoft Azure subscription ID.
  - `[TaskName <String>]`: The name of the container registry task.
  - `[TaskRunName <String>]`: The name of the task run.
  - `[TokenName <String>]`: The name of the token.
  - `[WebhookName <String>]`: The name of the webhook.

`SCOPEMAPUPDATEPARAMETER <IScopeMapUpdateParameters>`: The properties for updating the scope map.
  - `[Action <String[]>]`: The list of scope permissions for registry artifacts.         E.g. repositories/repository-name/pull,         repositories/repository-name/delete
  - `[Description <String>]`: The user friendly description of the scope map.

## RELATED LINKS

