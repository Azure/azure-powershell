---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistry
schema: 2.0.0
---

# Get-AzContainerRegistry

## SYNOPSIS
Gets the properties of the specified container registry.

## SYNTAX

### List (Default)
```
Get-AzContainerRegistry [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerRegistry -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistry -InputObject <IContainerRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzContainerRegistry -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified container registry.

## EXAMPLES

### Example 1: Get a specified container registry
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```

```output
Name  SkuName LoginServer      CreationDate          ProvisioningState AdminUserEnabled
----  ------- -----------      ------------          ----------------- ----------------
testc Premium testc.azurecr.io 16/01/2023 8:45:50 pm Succeeded         True
```

This command gets the specified container registry.

### Example 2: Get all the container registries in a resource group
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup"
```

```output
Name   SkuName LoginServer       CreationDate          ProvisioningState AdminUserEnabled
----   ------- -----------       ------------          ----------------- ----------------
testc2 Premium testc2.azurecr.io 17/01/2023 3:47:50 pm Succeeded         True
testc  Premium testc.azurecr.io  16/01/2023 8:45:50 pm Succeeded         True
```

This command gets all the container registries in a resource group.

### Example 3:  Get all the container registries in the subscription
```powershell
Get-AzContainerRegistry
```

```output
Name   SkuName LoginServer       CreationDate          ProvisioningState AdminUserEnabled
----   ------- -----------       ------------          ----------------- ----------------
testc2 Premium testc2.azurecr.io 17/01/2023 3:47:50 pm Succeeded         True
testc  Premium testc.azurecr.io  16/01/2023 8:45:50 pm Succeeded         True
```

This command gets all the container registries in the subscription.

## PARAMETERS

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
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RegistryName

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
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20220201Preview.IRegistry

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

## RELATED LINKS

