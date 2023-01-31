---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/new-azcontainerregistryagentpool
schema: 2.0.0
---

# New-AzContainerRegistryAgentPool

## SYNOPSIS
Creates an agent pool for a container registry with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzContainerRegistryAgentPool -Name <String> -RegistryName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-Count <Int32>] [-OS <OS>] [-Tag <Hashtable>] [-Tier <String>]
 [-VirtualNetworkSubnetResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzContainerRegistryAgentPool -Name <String> -RegistryName <String> -ResourceGroupName <String>
 -AgentPool <IAgentPool> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzContainerRegistryAgentPool -InputObject <IContainerRegistryIdentity> -AgentPool <IAgentPool>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzContainerRegistryAgentPool -InputObject <IContainerRegistryIdentity> -Location <String> [-Count <Int32>]
 [-OS <OS>] [-Tag <Hashtable>] [-Tier <String>] [-VirtualNetworkSubnetResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates an agent pool for a container registry with the specified parameters.

## EXAMPLES

### Example 1: Creates an agent pool for a container registry with the specified parameters.
```powershell
New-AzContainerRegistryAgentPool -name agent  -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Location 'eastus' -Count 1 -Tier S1 -os 'Linux'
```

```
Name  Location OS    Count ProvisioningState
----  -------- --    ----- -----------------
agent eastus   Linux 1     Succeeded

```

Creates an agent pool for a container registry with the specified parameters.

## PARAMETERS

### -AgentPool
The agentpool that has the ARM resource and properties.

The agentpool will have all information to create an agent pool.
To construct, see NOTES section for AGENTPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.IAgentPool
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Count
The count of agent machine

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the resource.
This cannot be changed after the resource is created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the agent pool.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: AgentPoolName

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

### -OS
The OS of agent machine

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.OS
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: Create, CreateExpanded
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
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tier
The Tier of agent machine

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkSubnetResourceId
The Virtual Network Subnet Resource Id of the agent machine

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.IAgentPool

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.IAgentPool

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`AGENTPOOL <IAgentPool>`: The agentpool that has the ARM resource and properties.         The agentpool will have all information to create an agent pool.
  - `Location <String>`: The location of the resource. This cannot be changed after the resource is created.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource modification (UTC).
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <LastModifiedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <IResourceTags>]`: The tags of the resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Count <Int32?>]`: The count of agent machine
  - `[OS <OS?>]`: The OS of agent machine
  - `[Tier <String>]`: The Tier of agent machine
  - `[VirtualNetworkSubnetResourceId <String>]`: The Virtual Network Subnet Resource Id of the agent machine

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

