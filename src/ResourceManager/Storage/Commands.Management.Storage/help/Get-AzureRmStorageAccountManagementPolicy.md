---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
Module Name: AzureRM.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.storage/get-azurermstorageaccountmanagementpolicy
schema: 2.0.0
---

# Get-AzureRmStorageAccountManagementPolicy

## SYNOPSIS
Gets the management policy of an Azure Storage account.

## SYNTAX

### AccountName
```
Get-AzureRmStorageAccountManagementPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AccountObject
```
Get-AzureRmStorageAccountManagementPolicy -StorageAccount <PSStorageAccount>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmStorageAccountManagementPolicy** cmdlet gets the management policy of an Azure Storage account.

## EXAMPLES

### Example 1: Get the management policy of a Storage account.
```
PS C:\>Get-AzureRmStorageAccountManagementPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount"

ResourceGroupName  : myresourcegroup
StorageAccountName : mystorageaccount
Id                 : /subscriptions/********-****-****-****-************/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/managementPolicies/default
Name               : DefaultManagementPolicy
Type               : Microsoft.Storage/storageAccounts/managementPolicies
Policy             : {
                       "version": "0.5",
                       "rules": [
                         {
                           "name": "olcmtest",
                           "type": "Lifecycle",
                           "definition": {
                             "filters": {
                               "blobTypes": [
                                 "blockBlob"
                               ],
                               "prefixMatch": [
                                 "olcmtestcontainer"
                               ]
                             },
                             "actions": {
                               "baseBlob": {
                                 "tierToCool": {
                                   "daysAfterModificationGreaterThan": 1000
                                 },
                                 "tierToArchive": {
                                   "daysAfterModificationGreaterThan": 90
                                 },
                                 "delete": {
                                   "daysAfterModificationGreaterThan": 1000
                                 }
                               },
                               "snapshot": {
                                 "delete": {
                                   "daysAfterCreationGreaterThan": 5000
                                 }
                               }
                             }
                           }
                         }
                       ]
                     }
LastModifiedTime   : 5/28/2018 10:05:51 AM
```

This command gets the management policy of a Storage account.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: AccountName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccount
Storage account object

```yaml
Type: PSStorageAccount
Parameter Sets: AccountObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccountName
Storage Account Name.

```yaml
Type: String
Parameter Sets: AccountName
Aliases: AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Storage.Models.StorageAccountKey

## NOTES

## RELATED LINKS

