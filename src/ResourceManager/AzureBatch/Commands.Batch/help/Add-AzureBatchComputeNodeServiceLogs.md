---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
Module Name: AzureRM.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.batch/add-azurebatchcomputenodeservicelogs
schema: 2.0.0
---

# Add-AzureBatchComputeNodeServiceLogs

## SYNOPSIS
Upload compute node service log files to an Azure Storage container.

## SYNTAX

### AzureBatchComputeNodeServiceLogs (Default)
```
Add-AzureBatchComputeNodeServiceLogs [-ContainerUrl] <String> [-StartTime] <DateTime> [[-EndTime] <DateTime>]
 -BatchContext <BatchAccountContext> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Id
```
Add-AzureBatchComputeNodeServiceLogs [-PoolId] <String> [-ComputeNodeId] <String> [-ContainerUrl] <String>
 [-StartTime] <DateTime> [[-EndTime] <DateTime>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ParentObject
```
Add-AzureBatchComputeNodeServiceLogs [[-ComputeNode] <PSComputeNode>] [-ContainerUrl] <String>
 [-StartTime] <DateTime> [[-EndTime] <DateTime>] -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet gathers Azure Batch service log files in an automated fashion from nodes if you are experiencing an error and wish to escalate to Azure support. The Azure Batch service log files should be shared with Azure support to aid in debugging issues with the Batch service. 

## EXAMPLES

### Example 1

```powershell
$storageContext = New-AzureStorageContext -StorageAccountName "contosogeneral" -StorageAccountKey "<Storage Key for ContosoGeneral ends with ==>"
$sasToken = New-AzureStorageContainerSASToken -Name "contosocontainer" -Context $storageContext
$containerUrl = "https://contosogeneral.blob.core.windows.net/contosocontainer" + $sasToken
$batchContext = Get-AzureRmBatchAccountKeys -AccountName "contosobatch"
Add-AzureBatchComputeNodeServiceLogs -BatchContext $batchContext -PoolId "contosopool" -ComputeNodeId "tvm-1612030122_1-20180405t234700z" -ContainerUrl $containerUrl -StartTime "2018-01-01 00:00:00Z"
```

Upload compute node service logs written on or after January 1, 2018 midnight, which were obtained from the compute node, given pool id of the pool in which the compute node resides, and compute node id.

### Example 2

```powershell
$storageContext = New-AzureStorageContext -StorageAccountName "contosogeneral" -StorageAccountKey "<Storage Key for ContosoGeneral ends with ==>"
$sasToken = New-AzureStorageContainerSASToken -Name "contosocontainer" -Context $storageContext
$containerUrl = "https://contosogeneral.blob.core.windows.net/contosocontainer" + $sasToken
$batchContext = Get-AzureRmBatchAccountKeys -AccountName "contosobatch"
Add-AzureBatchComputeNodeServiceLogs -BatchContext $batchContext -PoolId "contosopool" -ComputeNodeId "tvm-1612030122_1-20180405t234700z" -ContainerUrl $containerUrl -StartTime "2018-01-01 00:00:00Z" -EndTime "2018-01-10 00:00:00Z"
```

Upload compute node service logs written on or after January 1, 2018 midnight and before January 10, 2018 midnight, which were obtained from the compute node, given pool id of the pool in which the compute node resides, and compute node id.

### Example 3

```powershell
$storageContext = New-AzureStorageContext -StorageAccountName "contosogeneral" -StorageAccountKey "<Storage Key for ContosoGeneral ends with ==>"
$sasToken = New-AzureStorageContainerSASToken -Name "contosocontainer" -Context $storageContext
$containerUrl = "https://contosogeneral.blob.core.windows.net/contosocontainer" + $sasToken
$batchContext = Get-AzureRmBatchAccountKeys -AccountName "contosobatch"
Get-AzureBatchComputeNode -BatchContext $batchContext -Id "tvm-1612030122_1-20180405t234700z" -PoolId "contosopool" | Add-AzureBatchComputeNodeServiceLogs -BatchContext $batchContext -ContainerUrl $containerUrl -StartTime "2018-01-01 00:00:00Z" -EndTime "2018-01-10 00:00:00Z"
```

Upload compute node service logs written on or after January 1, 2018 midnight and before January 10, 2018 midnight, which were obtained from the compute node object.

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

### -ComputeNode
{{Fill ComputeNode Description}}

```yaml
Type: PSComputeNode
Parameter Sets: ParentObject
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ComputeNodeId
The id of the compute node.

```yaml
Type: String
Parameter Sets: Id
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerUrl
The container url to Azure Storage.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -EndTime
The end time of service log to be added (optional).

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolId
The id of the pool that contains the compute node.

```yaml
Type: String
Parameter Sets: Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
The start time of service log to be added.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Batch.Models.PSComputeNode
Microsoft.Azure.Commands.Batch.BatchAccountContext

## OUTPUTS

### Microsoft.Azure.Commands.Batch.Models.PSAddComputeNodeServiceLogsResult

## NOTES

## RELATED LINKS
