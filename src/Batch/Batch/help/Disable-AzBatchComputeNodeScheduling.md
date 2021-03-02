---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
ms.assetid: 2DF5FB4D-A5CB-439C-AC6F-DF2130AF33EC
online version: https://docs.microsoft.com/powershell/module/az.batch/disable-azbatchcomputenodescheduling
schema: 2.0.0
---

# Disable-AzBatchComputeNodeScheduling

## SYNOPSIS
Disables task scheduling on the specified compute node.

## SYNTAX

### Id (Default)
```
Disable-AzBatchComputeNodeScheduling [-PoolId] <String> [-Id] <String>
 [-DisableSchedulingOption <DisableComputeNodeSchedulingOption>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObject
```
Disable-AzBatchComputeNodeScheduling [[-ComputeNode] <PSComputeNode>]
 [-DisableSchedulingOption <DisableComputeNodeSchedulingOption>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Disable-AzBatchComputeNodeScheduling** cmdlet disables task scheduling on the specified compute node.
A compute node is an Azure virtual machine dedicated to a specific application workload.
When you disable task scheduling on a compute node you will also have the option of determining what to do about jobs currently in the node's task queue.
**Disable-AzBatchComputeNodeScheduling** lets you do the following: 
- Terminate the tasks and put them back in the job queue.
This enables those tasks to be rescheduled on another compute node. 
- Terminate the tasks and remove them from the job queue.
Tasks stopped in this manner will not be rescheduled. 
- Wait for all the tasks currently being executed to complete and then disable task scheduling on the compute node. 
- Wait for all the running tasks to complete and all the data retention periods to expire, and then disable task scheduling on the compute node.

## EXAMPLES

### Example 1: Disable task scheduling on a compute node
```
PS C:\>$Context = Get-AzBatchAccountKey -AccountName "contosobatchaccount"
PS C:\> Disable-AzBatchComputeNodeScheduling -PoolId "myPool" -Id "tvm-1783593343_34-20151117t222514z" -BatchContext $Context
```

These commands disable task schedule on the compute node tvm-1783593343_34-20151117t222514z.
To do this, the first command in the example creates an object reference to the account keys for the batch account contosobatchaccount.
This object reference is stored in a variable named $context.
The second command then uses this object reference and the **Disable-AzBatchComputeNodeScheduling** cmdlet to connect to the pool myPool and disable task scheduling on node tvm-1783593343_34-20151117t222514z.
Because the *DisableComputeNodeSchedulingOptions* parameter was not included any tasks currently running on the compute node will be requeued.

### Example 2: Disable task scheduling on all compute nodes in a pool
```
PS C:\>$Context = Get-AzBatchAccountKey -AccountName "contosobatchaccount"
PS C:\> Get-AzBatchComputeNode -PoolId "Pool06"  -BatchContext $Context | Disable-AzBatchComputeNodeScheduling -BatchContext $Context
```

These commands disable task scheduling on all the computer nodes in the batch pool Pool06.
To perform this task, the first command in the example creates an object reference to the account keys for the batch account contosobatchaccount.
This object reference is stored in a variable named $context.
The second command in the example then uses this object reference and **Get-AzBatchComputeNode** to return a collection of all the compute nodes found in Pool06.
That collection is then piped to then **Disable-AzBatchComputeNodeScheduling** cmdlet to disable task scheduling on each compute node in the collection.
Because the *DisableComputeNodeSchedulingOptions* parameter was not included any tasks currently running on the compute nodes will be requeued.

## PARAMETERS

### -BatchContext
Specifies the **BatchAccountContext** instance that this cmdlet uses to interact with the Batch service.
If you use the Get-AzBatchAccount cmdlet to get your BatchAccountContext, then Azure Active Directory authentication will be used when interacting with the Batch service. To use shared key authentication instead, use the Get-AzBatchAccountKey cmdlet to get a BatchAccountContext object with its access keys populated. When using shared key authentication, the primary access key is used by default. To change the key to use, set the BatchAccountContext.KeyInUse property.

```yaml
Type: Microsoft.Azure.Commands.Batch.BatchAccountContext
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ComputeNode
Specifies an object reference to the compute node where task scheduling is disabled.
This object reference is created by using the Get-AzBatchComputeNode cmdlet and storing the returned compute node object in a variable.

```yaml
Type: Microsoft.Azure.Commands.Batch.Models.PSComputeNode
Parameter Sets: InputObject
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableSchedulingOption
Specifies how this cmdlet deals with any tasks currently running on the computer node where scheduling is being disabled.
The acceptable values for this parameter are:
- Requeue.
Tasks are stopped immediately and returned to the job queue.
This enables the tasks to be rescheduled on another compute node.
This is the default value. 
- Terminate.
Tasks are stopped immediately and removed from the job queue.
These tasks will not be rescheduled. 
- TaskCompletion.
Currently running tasks will be able to complete before task scheduling is disabled on the compute node.
No new tasks will be scheduled on this node. 
- RetainedData.
Currently running tasks will be able to complete and data retention periods will be able to expire before task scheduling is disabled on the compute node.
No new tasks will be scheduled on this node.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Batch.Common.DisableComputeNodeSchedulingOption]
Parameter Sets: (All)
Aliases:
Accepted values: Requeue, Terminate, TaskCompletion

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the ID of the compute node where task scheduling is disabled.

```yaml
Type: System.String
Parameter Sets: Id
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolId
Specifies the ID of the batch pool that contains the compute node where task scheduling is disabled.
If you use the *PoolId* parameter, do not use the *ComputeNode* parameter in that same command.

```yaml
Type: System.String
Parameter Sets: Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Batch.Models.PSComputeNode

### Microsoft.Azure.Commands.Batch.BatchAccountContext

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Get-AzBatchAccountKey](./Get-AzBatchAccountKey.md)

[Enable-AzBatchComputeNodeScheduling](./Enable-AzBatchComputeNodeScheduling.md)


