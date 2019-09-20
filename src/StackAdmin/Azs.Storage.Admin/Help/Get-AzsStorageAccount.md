---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version:
schema: 2.0.0
---

# Get-AzsStorageAccount

## SYNOPSIS
Returns the requested storage account.

## SYNTAX

### List (Default)
```
Get-AzsStorageAccount [-Summary] [-Filter <String>] [-Location <String>] [<CommonParameters>]
```

### InputObject
```
Get-AzsStorageAccount -InputObject <StorageAccount> [<CommonParameters>]
```

### Get
```
Get-AzsStorageAccount [-Location <String>] -Name <String> [<CommonParameters>]
```

### ResourceId
```
Get-AzsStorageAccount -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of storage accounts.

## EXAMPLES

### EXAMPLE 1
```
Get-AzsStorageAccount -Summary
```

Get a list of storage accounts.

### EXAMPLE 2
```
Get-AzsStorageAccount -Name f8f7ff7335cb4ba284fb855547e48f34
```

Get details of the specified storage account.

## PARAMETERS

### -Summary
Switch for whether summary or detailed information is returned.

```yaml
Type: SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter string

```yaml
Type: String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount.

```yaml
Type: StorageAccount
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocationName
Location name.

```yaml
Type: String
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Internal storage account ID, which is not visible to tenant.

```yaml
Type: String
Parameter Sets: Get
Aliases: AccountId

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

### Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount
## NOTES

## RELATED LINKS
