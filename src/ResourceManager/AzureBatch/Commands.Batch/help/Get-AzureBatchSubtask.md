---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: 7D0D8B46-4BF0-47D5-9261-3306AEB9E7DD
online version: 
schema: 2.0.0
---

# Get-AzureBatchSubtask

## SYNOPSIS
Gets the subtask information of the specified task.

## SYNTAX

### ODataFilter (Default)
```
Get-AzureBatchSubtask [-JobId] <String> [-TaskId] <String> [-MaxCount <Int32>]
 -BatchContext <BatchAccountContext> [<CommonParameters>]
```

### ParentObject
```
Get-AzureBatchSubtask [[-Task] <PSCloudTask>] [-MaxCount <Int32>] -BatchContext <BatchAccountContext>
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureBatchSubtask** cmdlet retrieves the subtask information about the specified task.
Subtasks provide parallel processing for individual tasks, and enable precise monitoring of task execution and progress.

## EXAMPLES

### Example 1: Return all subtasks for a specified task
```
PS C:\>$Context = Get-AzureRmBatchAccountKeys -AccountName "contosobatchaccount"
PS C:\> Get-AzureBatchSubtask -JobId "Job-01" -TaskID "myTask" -BatchContext $Context
```

These commands return all the subtasks for the task with the ID myTask.
To do this, the first command in the example creates an object reference to the account keys for the batch account contosobatchaccount.
This object reference is stored in a variable named $context.

The second command then uses that object reference and the **Get-AzureBatchSubtask** cmdlet to return all the subtasks for myTask, a task that runs as part of job Job-01.

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

### -JobId
Specifies the ID of the job that contains the task whose subtasks this cmdlet gets.

```yaml
Type: String
Parameter Sets: ODataFilter
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxCount
Specifies the maximum number of subtasks to return.
If you specify a value of zero (0) or less, the cmdlet does not use an upper limit.
The default value is 1000.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Task
Specifies an object reference to the task that contain the subtasks that this cmdlet returns.
This object reference is created by using the Get-AzureBatchTask cmdlet and storing the returned object in a variable.

```yaml
Type: PSCloudTask
Parameter Sets: ParentObject
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TaskId
Specifies the ID of the task whose subtasks this cmdlet returns.

```yaml
Type: String
Parameter Sets: ODataFilter
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

###  
This cmdlet returns instances of the **PSSubtaskInformation** object.

## NOTES

## RELATED LINKS

[Get-AzureBatchTask](./Get-AzureBatchTask.md)


