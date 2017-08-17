---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: 75483BC7-440A-437B-9EDE-D270D87CF3C5
online version: 
schema: 2.0.0
---

# Set-AzureBatchJob

## SYNOPSIS
Updates a Batch job.

## SYNTAX

```
Set-AzureBatchJob [-Job] <PSCloudJob> -BatchContext <BatchAccountContext> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureBatchJob** cmdlet updates an Azure Batch job.
Use the Get-AzureBatchJob cmdlet to get a **PSCloudJob** object.
Modify the properties of that object, and then use the current cmdlet to commit your changes to the Batch service.

## EXAMPLES

### Example 1: Update a job
```
PS C:\>$Job = Get-AzureBatchJob -Id "Job17" -BatchContext $Context
PS C:\> $Job.Priority = 1
PS C:\> Set-AzureBatchJob -Job $Job -BatchContext $Context
```

The first command gets a pool by using **Get-AzureBatchJob**, and then stores it in the $Job variable.

The second command modifies the priority specification on the $Job object.

The final command updates the Batch service to match the local object in $Job.

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

### -Job
Specifies a **PSCloudJob** to which this cmdlet updates the Batch service.

```yaml
Type: PSCloudJob
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### BatchAccountContext

Parameter 'BatchContext' accepts value of type 'BatchAccountContext' from the pipeline

### PSCloudJob

Parameter 'Job' accepts value of type 'PSCloudJob' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Disable-AzureBatchJob](./Disable-AzureBatchJob.md)

[Enable-AzureBatchJob](./Enable-AzureBatchJob.md)

[Get-AzureBatchJob](./Get-AzureBatchJob.md)

[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[New-AzureBatchJob](./New-AzureBatchJob.md)

[Remove-AzureBatchJob](./Remove-AzureBatchJob.md)

[Stop-AzureBatchJob](./Stop-AzureBatchJob.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)


