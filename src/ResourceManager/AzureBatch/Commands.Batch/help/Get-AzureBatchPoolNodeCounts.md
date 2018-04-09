---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.batch/get-azurebatchpoolnodecounts
schema: 2.0.0
---

# Get-AzureBatchPoolNodeCounts

## SYNOPSIS
Gets Batch node counts per node state grouped by pool id. 

## SYNTAX

### Id
```
Get-AzureBatchPoolNodeCounts [-PoolId] <String> -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>]
```

### ParentObject
```
Get-AzureBatchPoolNodeCounts [[-Pool] <PSCloudPool>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION

The **Get-AzureBatchPoolNodeCounts** cmdlet allows customers to get back node counts per node state grouped by pool. Possible node states are creating, idle, leavingPool, offline, preempted, rebooting, reimaging, running, starting, startTaskFailed, unknown, unusable and waitingForStartTask. The cmdlet takes **PoolId** or **Pool** parameter to filter only pool with pool id specified. 

## EXAMPLES

To list node counts per node state for pools under current batch account context.

PS C:\> $batchContext = Get-AzureRmBatchAccountKeys -AccountName batchtestaccount
PS C:\> Get-AzureBatchPoolNodeCounts -BatchContext $batchContext

Dedicated                                          LowPriority                                        PoolId
---------                                          -----------                                        ------
Microsoft.Azure.Commands.Batch.Models.PSNodeCounts Microsoft.Azure.Commands.Batch.Models.PSNodeCounts Pool1
Microsoft.Azure.Commands.Batch.Models.PSNodeCounts Microsoft.Azure.Commands.Batch.Models.PSNodeCounts Pool2

To show node counts per node state for a pool given pool id:

PS C:\> Get-AzureBatchPoolNodeCounts -BatchContext $account -PoolId Pool1

Dedicated                                          LowPriority                                        PoolId
---------                                          -----------                                        ------
Microsoft.Azure.Commands.Batch.Models.PSNodeCounts Microsoft.Azure.Commands.Batch.Models.PSNodeCounts Pool1

A PSNodeCounts object looks like this:

PS C:\> $poolnodecounts = Get-AzureBatchPoolNodeCounts -BatchContext $account -PoolId Pool1
PS C:\> $poolnodecounts.Dedicated

Creating            : 1
Idle                : 1
LeavingPool         : 0
Offline             : 0
Preempted           : 0
Rebooting           : 1
Reimaging           : 0
Running             : 5
Starting            : 0
StartTaskFailed     : 0
Total               : 8
Unknown             : 0
Unusable            : 0
WaitingForStartTask : 0

## PARAMETERS

### -BatchContext
The BatchAccountContext instance to use when interacting with the Batch service.
If you use the Get-AzureRmBatchAccount cmdlet to get your BatchAccountContext, then Azure Active Directory authentication will be used when interacting with the Batch service.
To use shared key authentication instead, use the Get-AzureRmBatchAccountKeys cmdlet to get a BatchAccountContext object with its access keys populated.
When using shared key authentication, the primary access key is used by default.
To change the key to use, set the BatchAccountContext.KeyInUse property.

```yaml
Type: BatchAccountContext
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pool
Specifies pool that contains tasks that this cmdlet gets.
To obtain a **PSCloudPool** object, use the Get-AzureBatchPool cmdlet.

```yaml
Type: PSCloudPool
Parameter Sets: ParentObject
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PoolId
The id of the Pool for which to get node counts per node state.

```yaml
Type: String
Parameter Sets: Id
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String
Microsoft.Azure.Commands.Batch.Models.PSCloudPool
Microsoft.Azure.Commands.Batch.BatchAccountContext


## OUTPUTS

### Microsoft.Azure.Commands.Batch.Models.PSPoolNodeCounts


## NOTES

## RELATED LINKS

[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[Get-AzureBatchPool](./Get-AzureBatchPool.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)
