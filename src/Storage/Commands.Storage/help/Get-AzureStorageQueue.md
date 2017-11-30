---
external help file: Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml
ms.assetid: C2EBCCF0-56CE-4D49-A138-74E52FC3A9AC
online version: https://docs.microsoft.com/en-us/powershell/module/azure.storage/get-azurestoragequeue
schema: 2.0.0
---

# Get-AzureStorageQueue

## SYNOPSIS
Lists storage queues.

## SYNTAX

### QueueName (Default)
```
Get-AzureStorageQueue [[-Name] <String>] [-Context <IStorageContext>] [<CommonParameters>]
```

### QueuePrefix
```
Get-AzureStorageQueue -Prefix <String> [-Context <IStorageContext>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureStorageQueue** cmdlet lists storage queues associated with an Azure Storage account.

## EXAMPLES

### Example 1: List all Azure Storage queues
```
PS C:\>Get-AzureStorageQueue
```

This command gets a list of all storage queues for the current Storage account.

### Example 2: List Azure Storage queues using a wildcard character
```
PS C:\>Get-AzureStorageQueue -Name queue*
```

This command uses a wildcard character to get a list of storage queues whose name starts with queue.

### Example 3: List Azure Storage queues using queue name prefix
```
PS C:\>Get-AzureStorageQueue -Prefix "queue"
```

This example uses the *Prefix* parameter to get a list of storage queues whose name starts with queue.

## PARAMETERS

### -Context
Specifies the Azure storage context.
You can create it by using the **New-AzureStorageContext** cmdlet.

```yaml
Type: IStorageContext
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Specifies a name.
If no name is specified, the cmdlet gets a list of all the queues.
If a full or partial name is specified, the cmdlet gets all queues that match the name pattern.

```yaml
Type: String
Parameter Sets: QueueName
Aliases: N, Queue

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: True
```

### -Prefix
Specifies a prefix used in the name of the queues you want to get.

```yaml
Type: String
Parameter Sets: QueuePrefix
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

### IStorageContext

Parameter 'Context' accepts value of type 'IStorageContext' from the pipeline

### String

Parameter 'Name' accepts value of type 'String' from the pipeline

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageQueue

## NOTES

## RELATED LINKS

[New-AzureStorageQueue](./New-AzureStorageQueue.md)

[Remove-AzureStorageQueue](./Remove-AzureStorageQueue.md)


