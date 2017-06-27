---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmStorageAccountNetworkACL

## SYNOPSIS
Get the NetworkAcls property of a Storage Account

## SYNTAX

```
Get-AzureRmStorageAccountNetworkACL [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzureRmStorageAccountNetworkACL** cmdlet gets the NetworkAcls property of a Storage Account

## EXAMPLES

### Example 1: Get NetworkAcls property of a specified storage account
```
PS C:\> Get-AzureRmStorageAccountNetworkACL  -ResourceGroupName "rg1" -AccountName "mystorageaccount"
```

This command gets NetworkAcls property of a specified storage account

## PARAMETERS

### -Name
Specifies the name of the Storage account.

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

### -ResourceGroupName
Specifies the name of the resource group contains the Storage account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSNetworkACL

## NOTES

## RELATED LINKS

