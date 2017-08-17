---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: 23893EAE-47F3-45AA-AEB2-354FB8316C25
online version: 
schema: 2.0.0
---

# Set-AzureBatchPool

## SYNOPSIS
Updates the properties of a pool.

## SYNTAX

```
Set-AzureBatchPool [-Pool] <PSCloudPool> -BatchContext <BatchAccountContext> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureBatchPool** cmdlet updates the properties of a pool in the Azure Batch service.
Use the Get-AzureBatchPool cmdlet to get a **PSCloudPool** object.
Modify the properties of that object, and then use the current cmdlet to commit your changes to the Batch service.

## EXAMPLES

### Example 1: Update a pool
```
PS C:\>$Pool = Get-AzureBatchPool "ContosoPool" -BatchContext $Context
PS C:\> $StartTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
PS C:\> $StartTask.CommandLine = "cmd /c echo example"
PS C:\> $Pool.StartTask = $StartTask
PS C:\> Set-AzureBatchPool -Pool $Pool -BatchContext $Context
```

The first command gets a pool by using **Get-AzureBatchPool**, and then stores it in the $Pool variable.

The next three commands modify the start task specification on the $Pool object.

The final command updates the Batch service to match the local object in $Pool.

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

### -Pool
Specifies the **PSCloudPool** to which this cmdlet updates the Batch service.

```yaml
Type: PSCloudPool
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

### PSCloudPool

Parameter 'Pool' accepts value of type 'PSCloudPool' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureBatchPool](./Get-AzureBatchPool.md)

[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[New-AzureBatchPool](./New-AzureBatchPool.md)

[Remove-AzureBatchPool](./Remove-AzureBatchPool.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)


