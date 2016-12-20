---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: 38ED2854-23D0-400E-A5C8-239346B2AF99
online version: 
schema: 2.0.0
---

# Get-AzureBatchNodeFile

## SYNOPSIS
Gets the properties of Batch node files.

## SYNTAX

### ComputeNode_Id (Default)
```
Get-AzureBatchNodeFile [-PoolId] <String> [-ComputeNodeId] <String> [[-Name] <String>]
 -BatchContext <BatchAccountContext> [<CommonParameters>]
```

### Task_Id
```
Get-AzureBatchNodeFile -JobId <String> -TaskId <String> [[-Name] <String>] -BatchContext <BatchAccountContext>
 [<CommonParameters>]
```

### Task_ODataFilter
```
Get-AzureBatchNodeFile -JobId <String> -TaskId <String> [-Filter <String>] [-MaxCount <Int32>] [-Recursive]
 -BatchContext <BatchAccountContext> [<CommonParameters>]
```

### ParentTask
```
Get-AzureBatchNodeFile [[-Task] <PSCloudTask>] [-Filter <String>] [-MaxCount <Int32>] [-Recursive]
 -BatchContext <BatchAccountContext> [<CommonParameters>]
```

### ComputeNode_ODataFilter
```
Get-AzureBatchNodeFile [-PoolId] <String> [-ComputeNodeId] <String> [-Filter <String>] [-MaxCount <Int32>]
 [-Recursive] -BatchContext <BatchAccountContext> [<CommonParameters>]
```

### ParentComputeNode
```
Get-AzureBatchNodeFile [[-ComputeNode] <PSComputeNode>] [-Filter <String>] [-MaxCount <Int32>] [-Recursive]
 -BatchContext <BatchAccountContext> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureBatchNodeFile** cmdlet gets the properties of the Azure Batch node files of a task or compute node.
To narrow your results, you can specify an Open Data Protocol (OData) filter.
If you specify a task, but not a filter, this cmdlet returns properties for all node files for that task.
If you specify a compute node, but not a filter, this cmdlet returns properties for all node files for that compute node.

## EXAMPLES

### Example 1: Get the properties of a node file associated with a task
```
PS C:\>Get-AzureBatchNodeFile -JobId "Job-000001" -TaskId "Task26" -Name "Stdout.txt" -BatchContext $Context
IsDirectory Name          Properties                                      Url

----------- ----          ----------                                      ---

False       StdOut.txt    Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso...
```

This command gets the properties of the StdOut.txt node file associated with the task that has the ID Task26 in the job that has the ID Job-000001.
Use the Get-AzureRmBatchAccountKeys cmdlet to assign a context to the $Context variable.

### Example 2: Get the properties of node files associated with a task by using a filter
```
PS C:\>Get-AzureBatchNodeFile -JobId "Job-00002" -TaskId "Task26" -Filter "startswith(name,'St')" -BatchContext $Context
IsDirectory Name        Properties                                      Url

----------- ----        ----------                                      ---

False       StdErr.txt  Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
False       StdOut.txt  Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso...
```

This command gets the properties of the node files whose names start with st and are associated with task that has the ID Task26 under job that has the ID Job-00002.

### Example 3: Recursively get the properties of node files associated with a task
```
PS C:\>Get-AzureBatchTask "Job-00003" "Task31" -BatchContext $Context | Get-AzureBatchNodeFile -Recursive -BatchContext $Context
IsDirectory Name             Properties                                      Url

----------- ----             ----------                                      ---

False       ProcessEnv.cmd   Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
False       StdErr.txt       Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
False       StdOut.txt       Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
True        wd                                                               https://cmdletexample.westus.Batch.contoso... 
False       wd\newFile.txt   Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso...
```

This command gets the properties of all files associated with the task that has the ID Task31 in job Job-00003.
This command specifies the *Recursive* parameter.
Therefore, the cmdlet performs a recursive file search is performed, and returns the wd\newFile.txt node file.

### Example 4: Get a single file from a compute node
```
PS C:\>Get-AzureBatchNodeFile -PoolId "Pool22" -ComputeNodeId "ComputeNode01" -Name "Startup\StdOut.txt" -BatchContext $Context
IsDirectory Name                    Properties                                      Url
----------- ----                    ----------                                      ---
False       startup\stdout.txt      Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso...
```

This command gets the file that is named Startup\StdOut.txt from the compute node that has the ID ComputeNode01 in the pool that has the ID Pool22.

### Example 5: Get all files under a folder from a compute node
```
PS C:\>Get-AzureBatchNodeFile -PoolId "Pool22" -ComputeNodeId "ComputeNode01" -Filter "startswith(name,'startup')" -Recursive -BatchContext $Context
IsDirectory Name                      Properties                                      Url
----------- ----                      ----------                                      ---
True        startup                                                                   https://cmdletexample.westus.Batch.contoso... 
False       startup\ProcessEnv.cmd    Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
False       startup\stderr.txt        Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
False       startup\stdout.txt        Microsoft.Azure.Commands.Batch.Models.PSFile... https://cmdletexample.westus.Batch.contoso... 
True        startup\wd                                                                https://cmdletexample.westus.Batch.contoso...
```

This command gets all the files under the startup folder from the compute node that has the ID ComputeNode01 in the pool that has the ID Pool22.
This cmdlet specifies the *Recursive* parameter.

### Example 6: Get files from the root folder of a compute node
```
PS C:\>Get-AzureBatchComputeNode "Pool22" -Id "ComputeNode01" -BatchContext $Context | Get-AzureBatchNodeFile -BatchContext $Context
IsDirectory Name           Properties       Url
----------- ----           ----------       ---
True        shared                          https://cmdletexample.westus.Batch.contoso... 
True        startup                         https://cmdletexample.westus.Batch.contoso... 
True        workitems                       https://cmdletexample.westus.Batch.contoso...
```

This command gets all the files at the root folder of the compute node that has the ID ComputeNode01 in the pool that has the ID Pool22.

## PARAMETERS

### -BatchContext
Specifies the **BatchAccountContext** instance that this cmdlet uses to interact with the Batch service.
To obtain a **BatchAccountContext** object that contains access keys for your subscription, use the Get-AzureRmBatchAccountKeys cmdlet.

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
Specifies the compute node, as a **PSComputeNode** object, that contains the Batch node files.
To obtain a compute node object, use the Get-AzureBatchComputeNode cmdlet.

```yaml
Type: PSComputeNode
Parameter Sets: ParentComputeNode
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ComputeNodeId
Specifies the ID of the compute node that contains the Batch node files.

```yaml
Type: String
Parameter Sets: ComputeNode_Id, ComputeNode_ODataFilter
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Filter
Specifies an OData filter clause.
This cmdlet returns properties for node files that match the filter that this parameter specifies.

```yaml
Type: String
Parameter Sets: Task_ODataFilter, ParentTask, ComputeNode_ODataFilter, ParentComputeNode
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobId
Specifies the ID of the job that contains the target task.

```yaml
Type: String
Parameter Sets: Task_Id, Task_ODataFilter
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxCount
Specifies the maximum number of node files for which this cmdlet returns properties.
If you specify a value of zero (0) or less, the cmdlet does not use an upper limit.
The default value is 1000.

```yaml
Type: Int32
Parameter Sets: Task_ODataFilter, ParentTask, ComputeNode_ODataFilter, ParentComputeNode
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the node file for which this cmdlet retrieves properties.
You cannot specify wildcard characters.

```yaml
Type: String
Parameter Sets: ComputeNode_Id, Task_Id
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolId
Specifies the ID of the pool that contains the compute node from which to get properties of node files.

```yaml
Type: String
Parameter Sets: ComputeNode_Id, ComputeNode_ODataFilter
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Recursive
Indicates that this cmdlet returns a recursive list of files.
Otherwise, it returns only the files in the root folder.

```yaml
Type: SwitchParameter
Parameter Sets: Task_ODataFilter, ParentTask, ComputeNode_ODataFilter, ParentComputeNode
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Task
Specifies the task, as a **PSCloudTask** object, with which the node files are associated.
To obtain a task object, use the Get-AzureBatchTask cmdlet.

```yaml
Type: PSCloudTask
Parameter Sets: ParentTask
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TaskId
Specifies the ID of the task for which this cmdlet gets properties of node files.

```yaml
Type: String
Parameter Sets: Task_Id, Task_ODataFilter
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### PSNodeFile

## NOTES

## RELATED LINKS

[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[Get-AzureBatchComputeNode](./Get-AzureBatchComputeNode.md)

[Get-AzureBatchNodeFileContent](./Get-AzureBatchNodeFileContent.md)

[Get-AzureBatchTask](./Get-AzureBatchTask.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)


