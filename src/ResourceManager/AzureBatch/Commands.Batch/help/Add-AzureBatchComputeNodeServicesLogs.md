---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.batch/xxx-xxxxxxxxx
schema: 2.0.0
---

# Add-AzureBatchComputeNodeServiceLogs

## SYNOPSIS
Upload Azure Batch service log files from the specified compute node to an Azure Storage container.

## SYNTAX

Get-AzureBatchPoolNodeCounts
   [-PoolId <string>]
   [-ComputeNodeId <string>]
   [-ContainerUrl <string>]
   [-StartTime <StartTime>]
   [-EndTime <EndTime>]
   -BatchContext <BatchAccountContext>
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]

Get-AzureBatchPoolNodeCounts
   [-ComputeNode <PSComputeNode>]
   [-ContainerUrl <string>]
   [-StartTime <StartTime>]
   [-EndTime <EndTime>]
   -BatchContext <BatchAccountContext>
   [-DefaultProfile <IAzureContextContainer>]
   [<CommonParameters>]

## DESCRIPTION

This is for gathering Azure Batch service log files in an automated fashion from nodes if you are experiencing an error and wish to escalate to Azure support. The Azure Batch service log files should be shared with Azure support to aid in debugging issues with the Batch service. 

## EXAMPLES

To upload compute node service logs written on or after January 1, 2018 midnight, which were obtained from the compute node, given pool id of the pool in which the compute node resides:

$storageContext = New-AzureStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "<Storage Key for ContosoGeneral ends with ==>
$sasToken = New-AzureStorageContainerSASToken -Name "contosocontainer" -Context $storageContext
$containerUrl = "https://contosogeneral.blob.core.windows.net/contosocontainer" + $sasToken
$batchContext = Get-AzureRmBatchAccountKeys -AccountName "contosobatch"
Add-AzureBatchComputeNodeServiceLogs -BatchContext $batchContext -PoolId "contosopool" -ComputeNode "tvm-1612030122_1-20180405t234700z" -ContainerUrl $containerUrl -StartTime "2018-01-01 00:00:00Z"

To upload compute node service logs written on or after January 1, 2018 midnight and before January 10, 2018 midnight, which were obtained from the compute node, given pool id of the pool in which the compute node resides:

$storageContext = New-AzureStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "<Storage Key for ContosoGeneral ends with ==>
$sasToken = New-AzureStorageContainerSASToken -Name "contosocontainer" -Context $storageContext
$containerUrl = "https://contosogeneral.blob.core.windows.net/contosocontainer" + $sasToken
$batchContext = Get-AzureRmBatchAccountKeys -AccountName "contosobatch"
Add-AzureBatchComputeNodeServiceLogs -BatchContext $batchContext -PoolId "contosopool" -ComputeNode "tvm-1612030122_1-20180405t234700z" -ContainerUrl $containerUrl -StartTime "2018-01-01 00:00:00Z" -EndTime "2018-01-10 00:00:00Z"

To upload compute node service logs written on or after January 1, 2018 midnight and before January 10, 2018 midnight, which were obtained from the compute node:

$storageContext = New-AzureStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "<Storage Key for ContosoGeneral ends with ==>
$sasToken = New-AzureStorageContainerSASToken -Name "contosocontainer" -Context $storageContext
$containerUrl = "https://contosogeneral.blob.core.windows.net/contosocontainer" + $sasToken
$batchContext = Get-AzureRmBatchAccountKeys -AccountName "contosobatch"
Get-AzureBatchComputeNode -BatchContext $batchContext -Id "tvm-1612030122_1-20180405t234700z" -PoolId "contosopool" | Add-AzureBatchComputeNodeServiceLogs -BatchContext $batchContext -ContainerUrl $containerUrl -StartTime "2018-01-01 00:00:00Z" -EndTime "2018-01-10 00:00:00Z"

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

### -PoolId
The id of the Pool that contains the compute node.

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

### -ComputeNodeId
The ID of the compute node from which you want to get the Azure Batch service log files uploaded.

```yaml
Type: String
Parameter Sets: Id
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ComputeNode
The powershell compute node object from which Azure Batch service log files are gathered.

```yaml
Type: String
Parameter Sets: ParentObject
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True
Accept wildcard characters: False
```

### ContainerUrl
The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s). The URL must include a Shared Access Signature (SAS) granting write permissions to the container. The SAS duration must allow enough time for the upload to finish. The start time for SAS is optional and recommended to not be specified.

```yaml
Type: String
Parameter Sets: AzureBatchComputeNodeServiceLogs
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### StartTime
The start time of the time range from which to upload Batch Service log file(s).Any log file containing a log message in the time range will be uploaded. This means that the operation might retrieve more logs, since we always upload entire log file, but the operation should not retrieve less logs. Please select the value cautiously, a large time range may result in a large volume of upload. When specifying a time, ensure that the time includes timezone info if it is a local time, or is a UTC time.

```yaml
Type: Datetime
Parameter Sets: AzureBatchComputeNodeServiceLogs
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False

### EndTime
Any log file containing a log message in the time range will be uploaded. This means that the operation might retrieve more logs, since we always upload entire log file, but the operation should not retrieve less logs. Please select the value cautiously, a large time range may result in a large volume of upload. When specifying a time, ensure that the time includes timezone info if it is a local time, or is a UTC time. If this is omitted, the default is to upload all logs available after the startTime.

```yaml
Type: Datetime
Parameter Sets: AzureBatchComputeNodeServiceLogs
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False

## INPUTS

### System.String
### System.DateTime
Microsoft.Azure.Commands.Batch.Models.PSCloudPool
Microsoft.Azure.Commands.Batch.BatchAccountContext


## OUTPUTS
Microsoft.Azure.Commands.Batch.Models.PSAddComputeNodeServiceLogsResult


## NOTES

## RELATED LINKS
[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[Get-AzureBatchPool](./Get-AzureBatchPool.md)

[Get-AzureBatchComputeNode](./Get-AzureBatchComputeNode.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)

