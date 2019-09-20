---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version:
schema: 2.0.0
---

# Update-AzsStorageSettings

## SYNOPSIS

## SYNTAX

```
Update-AzsStorageSettings [-Location <String>] -RetentionPeriodForDeletedStorageAccountsInDays <Int32>
 [<CommonParameters>]
```

## DESCRIPTION
Update storge resource provider settings.

## EXAMPLES

### EXAMPLE 1
```
Update-AzsStorageSetting -RetentionPeriodForDeletedStorageAccountsInDays 2
```

Update the storage settings

## PARAMETERS

### -Location
Location name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionPeriodForDeletedStorageAccountsInDays
Set the retention days for deleted storage accounts.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Storage.Admin.Models.Settings
## NOTES

## RELATED LINKS
