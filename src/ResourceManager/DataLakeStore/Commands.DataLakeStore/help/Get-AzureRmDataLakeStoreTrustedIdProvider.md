---
external help file: Microsoft.Azure.Commands.DataLakeStore.dll-Help.xml
ms.assetid: D79080D5-2785-4C46-86FD-FDAA11117D17
online version: 
schema: 2.0.0
---

# Get-AzureRmDataLakeStoreTrustedIdProvider

## SYNOPSIS
Gets the specified trusted identity provider in the specified Data Lake Store.
If no provider is specified, then lists all providers for the account.

## SYNTAX

```
Get-AzureRmDataLakeStoreTrustedIdProvider [-Account] <String> [[-Name] <String>]
 [[-ResourceGroupName] <String>]
```

## DESCRIPTION
The Get-AzureRmDataLakeStoreTrustedIdProvider cmdlet gets the specified trusted identity provider in the specified Data Lake Store.
If no provider is specified, then lists all providers for the account.

## EXAMPLES

### --------------------------  Example 1: Get a specific trusted identity provider  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmDataLakeStoreTrustedIdProvider -AccountName "ContosoADL" -Name MyProvider
```

Returns the provider named "MyProvider" from account "ContosoADL"

### --------------------------  Example 2: List all providers in an account  --------------------------
@{paragraph=PS C:\\\>}

```
PS C:\> Get-AzureRmDataLakeStoreTrustedIdProvider -AccountName "ContosoADL"
```

Lists all providers under the account "ContosoADL"

## PARAMETERS

### -Account
The Data Lake Store account to retrieve the trusted identity provider from

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the trusted identity provider to retrieve

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group under which want to retrieve the specified account's specified trusted identity provider.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### Microsoft.Azure.Management.DataLake.Store.Models.TrustedIdProvider

### System.Collections.Generic.IList`1[[Microsoft.Azure.Management.DataLake.Store.Models.TrustedIdProvider, Microsoft.Azure.Management.DataLake.Store, Version=0.12.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]

## NOTES

## RELATED LINKS

