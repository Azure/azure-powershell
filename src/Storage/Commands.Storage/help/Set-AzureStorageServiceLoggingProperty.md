---
external help file: Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml
ms.assetid: 5422429E-C609-4C1F-A021-E2A085B5F74E
online version: https://docs.microsoft.com/en-us/powershell/module/azure.storage/set-azurestorageserviceloggingproperty
schema: 2.0.0
---

# Set-AzureStorageServiceLoggingProperty

## SYNOPSIS
Modifies logging for Azure Storage services.

## SYNTAX

```
Set-AzureStorageServiceLoggingProperty [-ServiceType] <StorageServiceType> [-Version <Double>]
 [-RetentionDays <Int32>] [-LoggingOperations <LoggingOperations[]>] [-PassThru] [-Context <IStorageContext>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureStorageServiceLoggingProperty** cmdlet modifies logging for Azure Storage services.

## EXAMPLES

### Example 1: Modify logging properties for the Blob service
```
C:\PS>Set-AzureStorageServiceLoggingProperty -ServiceType Blob -LoggingOperations Read,Write -PassThru -RetentionDays 10 -Version 1.0
```

This command modifies version 1.0 logging for blob storage to include read and write operations.
Azure Storage service logging retains entries for 10 days.
Because this command specifies the *PassThru* parameter, the command displays the modified logging properties.

## PARAMETERS

### -Context
Specifies an Azure storage context.
To obtain a storage context, use the New-AzureStorageContext cmdlet.

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

### -LoggingOperations
Specifies an array of Azure Storage service operations.
Azure Storage services logs the operations that this parameter specifies.
The acceptable values for this parameter are:

- None
- Read
- Write
- Delete
- All

```yaml
Type: LoggingOperations[]
Parameter Sets: (All)
Aliases: 
Accepted values: None, Read, Write, Delete, All

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Indicates that this cmdlet returns the updated logging properties.
If you do not specify this parameter, this cmdlet does not return a value.

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

### -RetentionDays
Specifies the number of days that the Azure Storage service retains logged information.

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

### -ServiceType
Specifies the storage service type.
This cmdlet modifies the logging properties for the service type that this parameter specifies.
The acceptable values for this parameter are:

- Blob 
- Table
- Queue
- File

The value of File is not currently supported.

```yaml
Type: StorageServiceType
Parameter Sets: (All)
Aliases: 
Accepted values: Blob, Table, Queue, File

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Specifies the version of the Azure Storage service logging.
The default value is 1.0.

```yaml
Type: Double
Parameter Sets: (All)
Aliases: 

Required: False
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

## OUTPUTS

### Microsoft.WindowsAzure.Storage.Shared.Protocol.LoggingProperties

## NOTES

## RELATED LINKS

[Get-AzureStorageServiceLoggingProperty](./Get-AzureStorageServiceLoggingProperty.md)

[New-AzureStorageContext](./New-AzureStorageContext.md)


