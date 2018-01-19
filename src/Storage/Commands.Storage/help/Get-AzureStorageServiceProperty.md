---
external help file: Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml
Module Name: Azure.Storage
online version: 
schema: 2.0.0
---

# Get-AzureStorageServiceProperty

## SYNOPSIS
Gets properties for Azure Storage services.

## SYNTAX

```
Get-AzureStorageServiceProperty [-ServiceType] <StorageServiceType> [-Context <IStorageContext>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureStorageServiceProperty** cmdlet gets the properties for Azure Storage services.

## EXAMPLES

### Example 1: Get  Azure Storage services property of the Blob service
```
C:\PS>Get-AzureStorageServiceProperty -ServiceType Blob

Logging.Version             : 1.0
Logging.LoggingOperations   : Read, Write
Logging.RetentionDays       : 
HourMetrics.Version         : 1.0
HourMetrics.MetricsLevel    : ServiceAndApi
HourMetrics.RetentionDays   : 7
MinuteMetrics.Version       : 1.0
MinuteMetrics.MetricsLevel  : None
MinuteMetrics.RetentionDays : 
Cors                        : 
DefaultServiceVersion       : 2017-04-17

```

This command gets DefaultServiceVersion property of the Blob service.

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

### -ServiceType
Specifies the storage service type.
This cmdlet gets the logging properties for the service type that this parameter specifies.
The acceptable values for this parameter are:

- Blob 
- Table
- Queue
- File

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel.PSSeriviceProperties

## NOTES

## RELATED LINKS

