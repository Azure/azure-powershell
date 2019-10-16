---
external help file:
Module Name: Az.ContainerService
online version: https://docs.microsoft.com/en-us/powershell/module/az.containerservice/set-azagentpool
schema: 2.0.0
---

# Set-AzAgentPool

## SYNOPSIS
Creates or updates an agent pool in the specified managed cluster.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzAgentPool -Name <String> -ResourceGroupName <String> -ResourceName <String> -SubscriptionId <String>
 [-AvailabilityZone <String[]>] [-Count <Int32>] [-EnableAutoScaling] [-EnableNodePublicIP]
 [-MaxCount <Int32>] [-MaxPod <Int32>] [-MinCount <Int32>] [-NodeTaint <String[]>]
 [-OrchestratorVersion <String>] [-OSDiskSizeGb <Int32>] [-OSType <OSType>]
 [-ScaleSetEvictionPolicy <ScaleSetEvictionPolicy>] [-ScaleSetPriority <ScaleSetPriority>]
 [-Type <AgentPoolType>] [-VMSize <ContainerServiceVMSizeTypes>] [-VnetSubnetId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzAgentPool -Name <String> -ResourceGroupName <String> -ResourceName <String> -SubscriptionId <String>
 -Parameter <IAgentPool> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an agent pool in the specified managed cluster.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.containerservice/set-azagentpool
```



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
Dynamic: False
```

### -AvailabilityZone
(PREVIEW) Availability zones for nodes.
Must use VirtualMachineScaleSets AgentPoolType.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Count
Number of agents (VMs) to host docker containers.
Allowed values must be in the range of 1 to 100 (inclusive).
The default value is 1.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -EnableAutoScaling
Whether to enable auto-scaler

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableNodePublicIP
Enable public IP for nodes

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxCount
Maximum number of nodes for auto-scaling

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxPod
Maximum number of pods that can run on a node.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MinCount
Minimum number of nodes for auto-scaling

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the agent pool.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AgentPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NodeTaint
Taints added to new nodes during node pool create and scale.
For example, key=value:NoSchedule.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -OrchestratorVersion
Version of orchestrator specified when creating the managed cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskSizeGb
OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool.
If you specify 0, it will apply the default osDisk size according to the vmSize specified.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSType
OsType to be used to specify os type.
Choose from Linux and Windows.
Default to Linux.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.OSType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Agent Pool.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190801.IAgentPool
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScaleSetEvictionPolicy
ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set.
Default to Delete.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ScaleSetEvictionPolicy
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScaleSetPriority
ScaleSetPriority to be used to specify virtual machine scale set priority.
Default to regular.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ScaleSetPriority
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
AgentPoolType represents types of an agent pool

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.AgentPoolType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMSize
Size of agent VMs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ContainerServiceVMSizeTypes
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetSubnetId
VNet SubnetID specifies the VNet's subnet identifier.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190801.IAgentPool

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190801.IAgentPool

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IAgentPool>: Agent Pool.
  - `Count <Int32>`: Number of agents (VMs) to host docker containers. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. 
  - `VMSize <ContainerServiceVMSizeTypes>`: Size of agent VMs.
  - `[AvailabilityZone <String[]>]`: (PREVIEW) Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.
  - `[EnableAutoScaling <Boolean?>]`: Whether to enable auto-scaler
  - `[EnableNodePublicIP <Boolean?>]`: Enable public IP for nodes
  - `[MaxCount <Int32?>]`: Maximum number of nodes for auto-scaling
  - `[MaxPod <Int32?>]`: Maximum number of pods that can run on a node.
  - `[MinCount <Int32?>]`: Minimum number of nodes for auto-scaling
  - `[NodeTaint <String[]>]`: Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
  - `[OSDiskSizeGb <Int32?>]`: OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.
  - `[OSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
  - `[OrchestratorVersion <String>]`: Version of orchestrator specified when creating the managed cluster.
  - `[ScaleSetEvictionPolicy <ScaleSetEvictionPolicy?>]`: ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set. Default to Delete.
  - `[ScaleSetPriority <ScaleSetPriority?>]`: ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
  - `[Type <AgentPoolType?>]`: AgentPoolType represents types of an agent pool
  - `[VnetSubnetId <String>]`: VNet SubnetID specifies the VNet's subnet identifier.

## RELATED LINKS

