---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
ms.assetid: F6EA099A-D588-49AE-9D2C-865BC32685BA
online version: 
schema: 2.0.0
---

# Get-AzureRmStorageAccountNameAvailability

## SYNOPSIS
Checks the availability of a storage account name.

## SYNTAX

```
Get-AzureRmStorageAccountNameAvailability [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmStorageAccountNameAvailability** cmdlet checks whether the name of an Azure Storage account is valid and available to use.

## EXAMPLES

### Example 1: Check availability of a storage account name
```
PS C:\>Get-AzureRmStorageAccountNameAvailability -Name 'ContosoStorage03'
```

This command checks the availability of the name ContosoStorage03.

## PARAMETERS

### -Name
Specifies the name of the Storage account that this cmdlet checks.

```yaml
Type: String
Parameter Sets: (All)
Aliases: StorageAccountName, AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

## NOTES

## RELATED LINKS

[Azure Storage Manager Cmdlets](./AzureRM.Storage.md)


