---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: 3107D061-7F25-45D0-8029-C99120A156DA
online version: 
schema: 2.0.0
---

# Enable-AzureBatchAutoScale

## SYNOPSIS
Enables automatic scaling of a pool.

## SYNTAX

```
Enable-AzureBatchAutoScale [-Id] <String> [[-AutoScaleFormula] <String>]
 [[-AutoScaleEvaluationInterval] <TimeSpan>] -BatchContext <BatchAccountContext> [<CommonParameters>]
```

## DESCRIPTION
The **Enable-AzureBatchAutoScale** cmdlet enables automatic scaling of the specified pool.

## EXAMPLES

### Example 1: Enable automatic scaling for a pool
```
PS C:\>$Formula = 'totalNodes=($CPUPercent.GetSamplePercent(TimeInterval_Minute*0,TimeInterval_Minute*10)<0.7?5:(min($CPUPercent.GetSample(TimeInterval_Minute*0, TimeInterval_Minute*10))>0.8?($CurrentDedicated*1.1):$CurrentDedicated));$TargetDedicated=min(100,totalNodes);';
PS C:\> Enable-AzureBatchAutoScale -Id "MyPool" -AutoScaleFormula $Formula -BatchContext $Context
```

The first command defines a formula, and then saves it to the $Formula variable.

The second command enables automatic scaling on the pool named MyPool using the formula in $Formula.

## PARAMETERS

### -AutoScaleEvaluationInterval
Specifies the amount of time (in minutes) that elapses before the pool size is automatically adjusted according to the AutoScale formula.
The default value is 15 minutes, and the minimum value is 5 minutes.

```yaml
Type: TimeSpan
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScaleFormula
Specifies the formula for the desired number of compute nodes in the pool.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Id
Specifies the object ID of the pool for which to enable automatic scaling.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Disable-AzureBatchAutoScale](./Disable-AzureBatchAutoScale.md)

[Test-AzureBatchAutoScale](./Test-AzureBatchAutoScale.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)


