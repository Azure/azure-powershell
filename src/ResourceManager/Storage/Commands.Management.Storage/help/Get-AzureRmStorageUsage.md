---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
Module Name: AzureRM.Storage
ms.assetid: 11AAA319-DDBB-4156-9BE7-4DE8B80A904C
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.storage/get-azurermstorageusage
schema: 2.0.0
---

# Get-AzureRmStorageUsage

## SYNOPSIS
Gets the Storage resource usage of the current subscription.

## SYNTAX

```
Get-AzureRmStorageUsage [-Location <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmStorageUsage** cmdlet gets the resource usage for Azure Storage for the current subscription.

## EXAMPLES

### Example 1: Get the storage resources usage
```
PS C:\>Get-AzureRmStorageUsage
```

This command gets the Storage resources usage of the current subscription.
 

### Example 2: Get the storage resources usage of specified location
```
PS C:\>Get-AzureRmStorageUsage -Location 'West US'

LocalizedName : Storage Accounts
Name          : StorageAccounts
Unit          : Count
CurrentValue  : 18
Limit         : 250
```

This command gets the Storage resources usage of of specified location under the current subscription.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Indicate to get Storage resources usage on the specified location.
If not specified, will get Storage resources usage on all locations under the subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSUsage

## NOTES

## RELATED LINKS

[Azure Storage Manager Cmdlets](./AzureRM.Storage.md)


