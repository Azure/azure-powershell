---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: CB2F472B-C792-4A11-A055-F4161DCFBB28
online version: 
schema: 2.0.0
---

# Remove-AzureBatchJob

## SYNOPSIS
Deletes a Batch job.

## SYNTAX

```
Remove-AzureBatchJob [-Id] <String> [-Force] -BatchContext <BatchAccountContext> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureBatchJob** cmdlet deletes an Azure Batch job.
This cmdlet prompts you for confirmation before it removes a job, unless you specify the *Force* parameter.

## EXAMPLES

### Example 1: Delete a Batch job
```
PS C:\>Remove-AzureBatchJob -Id "Job-000001" -BatchContext $Context
```

This command deletes the job that has the ID Job-000001.
The command prompts you for confirmation before it deletes the job.
Use the Get-AzureRmBatchAccountKeys cmdlet to assign a context to the $Context variable.

### Example 2: Delete a Batch job without confirmation by using the pipeline
```
PS C:\>Get-AzureBatchJob -Id "Job-000002" -BatchContext $Context | Remove-AzureBatchJob -Force -BatchContext $Context
```

This command gets the job that has the ID Job-000002 by using the Get-AzureBatchJob cmdlet.
The command passes that job to the current cmdlet by using the pipeline operator.
The command deletes that job.
Because the command includes the *Force* parameter, it does not prompt you for confirmation.

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

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the ID of the job that this cmdlet deletes.
You cannot specify wildcard characters.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### BatchAccountContext

Parameter 'BatchContext' accepts value of type 'BatchAccountContext' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Disable-AzureBatchJob](./Disable-AzureBatchJob.md)

[Enable-AzureBatchJob](./Enable-AzureBatchJob.md)

[Get-AzureBatchJob](./Get-AzureBatchJob.md)

[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[New-AzureBatchJob](./New-AzureBatchJob.md)

[Stop-AzureBatchJob](./Stop-AzureBatchJob.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)


