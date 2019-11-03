---
external help file:
Module Name: Az.Aks
online version: https://docs.microsoft.com/en-us/powershell/module/az.aks/new-azaksagentpool
schema: 2.0.0
---

# New-AzAksAgentPool

## SYNOPSIS
Creates or updates an agent pool in the specified managed cluster.

## SYNTAX

```
New-AzAksAgentPool -AksName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AvailabilityZone <String[]>] [-Count <Int32>] [-EnableAutoScaling] [-EnableNodePublicIP]
 [-MaxCount <Int32>] [-MaxPod <Int32>] [-MinCount <Int32>] [-NodeTaint <String[]>]
 [-OrchestratorVersion <String>] [-OSDiskSizeGb <Int32>] [-OSType <OSType>]
 [-ScaleSetEvictionPolicy <ScaleSetEvictionPolicy>] [-ScaleSetPriority <ScaleSetPriority>]
 [-Type <AgentPoolType>] [-VMSize <ContainerServiceVMSizeTypes>] [-VnetSubnetId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an agent pool in the specified managed cluster.

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

### -AksName
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -ScaleSetEvictionPolicy
ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set.
Default to Delete.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority
Parameter Sets: (All)
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

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
AgentPoolType represents types of an agent pool

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IAgentPool

## ALIASES

## NOTES

## RELATED LINKS

