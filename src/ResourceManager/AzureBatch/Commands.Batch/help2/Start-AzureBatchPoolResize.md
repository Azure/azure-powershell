---
external help file: Microsoft.Azure.Commands.Batch.dll-Help.xml
ms.assetid: 82DC8DC4-D8EC-4847-A54C-B779256FD590
online version: 
schema: 2.0.0
---

# Start-AzureBatchPoolResize

## SYNOPSIS
Starts to resize a pool.

## SYNTAX

```
Start-AzureBatchPoolResize [-Id] <String> -TargetDedicated <Int32> [-ResizeTimeout <TimeSpan>]
 [-ComputeNodeDeallocationOption <ComputeNodeDeallocationOption>] -BatchContext <BatchAccountContext>
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzureBatchPoolResize** cmdlet starts an Azure Batch resize operation on a pool.

## EXAMPLES

### Example 1: Resize a pool to 12 nodes
```
PS C:\>Start-AzureBatchPoolResize -Id "ContosoPool06" -TargetDedicated 12 -BatchContext $Context
```

This command starts a resize operation on the pool that has the ID ContosoPool06.
The target for the operation is 12 dedicated compute nodes.
Use the Get-AzureRmBatchAccountKeys cmdlet to assign a context to the $Context variable.

### Example 2: Resize a pool using a deallocation option
```
PS C:\>Get-AzureBatchPool -Id "ContosoPool06" -BatchContext $Context | Start-AzureBatchPoolResize -TargetDedicated 5 -ResizeTimeout ([TimeSpan]::FromHours(1)) -ComputeNodeDeallocationOption ([Microsoft.Azure.Batch.Common.ComputeNodeDeallocationOption]::Terminate) -BatchContext $Context
```

This cmdlet resizes a pool to five dedicated compute nodes.
The command gets the pool that has the ID ContosoPool06 by using the Get-AzureBatchPool cmdlet.
The command passes that pool object to the current cmdlet by using the pipeline operator.
The command starts a resize operation on the pool.
The target is five dedicated compute nodes.
The command specifies time-out period of one hour.
The command specifies a deallocation option of Terminate.

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

### -ComputeNodeDeallocationOption
Specifies a deallocation option for the resizing operation that this cmdlet starts.

```yaml
Type: ComputeNodeDeallocationOption
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the ID of the pool that this cmdlet resizes.

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

### -ResizeTimeout
Specifies a time-out period for the resizing operation.
If the pool does not reach the target size by this time, the resize operation stops.

```yaml
Type: TimeSpan
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDedicated
Specifies the target number of dedicated compute nodes.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmBatchAccountKeys](./Get-AzureRmBatchAccountKeys.md)

[Get-AzureBatchPool](./Get-AzureBatchPool.md)

[Stop-AzureBatchPoolResize](./Stop-AzureBatchPoolResize.md)

[Azure Batch Cmdlets](./AzureRM.Batch.md)


