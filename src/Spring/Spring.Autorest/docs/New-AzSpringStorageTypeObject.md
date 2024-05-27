---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringstoragetypeobject
schema: 2.0.0
---

# New-AzSpringStorageTypeObject

## SYNOPSIS
Create an in-memory object for StorageAccount.

## SYNTAX

```
New-AzSpringStorageTypeObject -AccountKey <String> -AccountName <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageAccount.

## EXAMPLES

### Example 1: Create an in-memory object for StorageProperties.
```powershell
New-AzSpringStorageTypeObject -AccountKey String -AccountName String
```

```output
AccountKey AccountName StorageType
---------- ----------- -----------
String     String      StorageAccount
```

Create an in-memory object for StorageProperties.

## PARAMETERS

### -AccountKey
The account key of the Azure Storage Account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountName
The account name of the Azure Storage Account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.StorageAccount

## NOTES

## RELATED LINKS

