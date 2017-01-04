---
external help file: Microsoft.Azure.Commands.DataLakeStore.dll-Help.xml
ms.assetid: 234D579E-B62D-4D70-8D2E-22AC0D9AC513
online version: 
schema: 2.0.0
---

# Get-AzureRmDataLakeStoreAccount

## SYNOPSIS
Gets details of a Data Lake Store account.

## SYNTAX

### All In Subscription (Default)
```
Get-AzureRmDataLakeStoreAccount [<CommonParameters>]
```

### Specific Account
```
Get-AzureRmDataLakeStoreAccount [[-ResourceGroupName] <String>] [-Name] <String> [<CommonParameters>]
```

### All In Resource Group
```
Get-AzureRmDataLakeStoreAccount [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDataLakeStoreAccount** cmdlet gets details of a Data Lake Store account.

## EXAMPLES

### Example 1: Get a Data Lake Store account
```
PS C:\>Get-AzureRmDataLakeStoreAccount -Name "ContosoADL"
```

This command gets the account named ContosoADL.

## PARAMETERS

### -Name
Specifies the name of the account to get.

```yaml
Type: String
Parameter Sets: Specific Account
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the Data Lake Store account to get.

```yaml
Type: String
Parameter Sets: Specific Account
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: All In Resource Group
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

## OUTPUTS

### PSDataLakeStoreAccount
The specific Data Lake Store account asked for.

### List<PSDataLakeStoreAccount>
A list of Data Lake Store accounts in the resource group or subscription specified.

## NOTES

## RELATED LINKS

[New-AzureRmDataLakeStoreAccount](./New-AzureRmDataLakeStoreAccount.md)

[Remove-AzureRmDataLakeStoreAccount](./Remove-AzureRmDataLakeStoreAccount.md)

[Set-AzureRmDataLakeStoreAccount](./Set-AzureRmDataLakeStoreAccount.md)

[Test-AzureRmDataLakeStoreAccount](./Test-AzureRmDataLakeStoreAccount.md)


