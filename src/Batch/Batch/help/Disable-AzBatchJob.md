<<<<<<< HEAD
﻿---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
ms.assetid: C831F934-7513-4882-A155-816E56CD9807
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/disable-azbatchjob
=======
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
ms.assetid: C831F934-7513-4882-A155-816E56CD9807
online version: https://docs.microsoft.com/powershell/module/az.batch/disable-azbatchjob
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Disable-AzBatchJob

## SYNOPSIS
Disables a Batch job.

## SYNTAX

```
Disable-AzBatchJob [-Id] <String> [-DisableJobOption] <DisableJobOption> -BatchContext <BatchAccountContext>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Disable-AzBatchJob** cmdlet disables an Azure Batch job.
After you enable a job, new tasks can run.
Disabled jobs do not run new tasks.
You can enable a disabled job later.

## EXAMPLES

### Example 1: Disable a Batch job
```
PS C:\>Disable-AzBatchJob -Id "Job-000001" -DisableJobOption "Terminate" -BatchContext $Context
```

This command disables the job that has the ID Job-000001.
The command terminates active tasks for the job.
<<<<<<< HEAD
Use the **Get-AzBatchAccountKeys** cmdlet to assign a context to the $Context variable.
=======
Use the **Get-AzBatchAccountKey** cmdlet to assign a context to the $Context variable.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## PARAMETERS

### -BatchContext
Specifies the **BatchAccountContext** instance that this cmdlet uses to interact with the Batch service.
<<<<<<< HEAD
If you use the Get-AzBatchAccount cmdlet to get your BatchAccountContext, then Azure Active Directory authentication will be used when interacting with the Batch service. To use shared key authentication instead, use the Get-AzBatchAccountKeys cmdlet to get a BatchAccountContext object with its access keys populated. When using shared key authentication, the primary access key is used by default. To change the key to use, set the BatchAccountContext.KeyInUse property.
=======
If you use the Get-AzBatchAccount cmdlet to get your BatchAccountContext, then Azure Active Directory authentication will be used when interacting with the Batch service. To use shared key authentication instead, use the Get-AzBatchAccountKey cmdlet to get a BatchAccountContext object with its access keys populated. When using shared key authentication, the primary access key is used by default. To change the key to use, set the BatchAccountContext.KeyInUse property.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

```yaml
Type: Microsoft.Azure.Commands.Batch.BatchAccountContext
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableJobOption
Specifies what to do with active tasks associated with the job that this cmdlet disables.
<<<<<<< HEAD
Valid values are: 
- Requeue 
- Terminate 
=======
Valid values are:
- Requeue
- Terminate
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
- Wait

```yaml
Type: Microsoft.Azure.Batch.Common.DisableJobOption
Parameter Sets: (All)
Aliases:
Accepted values: Requeue, Terminate, Wait

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the ID of the job that this cmdlet disables.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### System.String

### Microsoft.Azure.Commands.Batch.BatchAccountContext

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS

[Enable-AzBatchJob](./Enable-AzBatchJob.md)

<<<<<<< HEAD
[Get-AzBatchAccountKeys](./Get-AzBatchAccountKeys.md)
=======
[Get-AzBatchAccountKey](./Get-AzBatchAccountKey.md)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

[Get-AzBatchJob](./Get-AzBatchJob.md)

[New-AzBatchJob](./New-AzBatchJob.md)

[Remove-AzBatchJob](./Remove-AzBatchJob.md)

[Stop-AzBatchJob](./Stop-AzBatchJob.md)

<<<<<<< HEAD
[Azure Batch Cmdlets](./Az.Batch.md)


=======
[Azure Batch Cmdlets](/powershell/module/Az.Batch/)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
