---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
Module Name: AzureRM.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.storage/set-azurermstorageaccountmanagementpolicy
schema: 2.0.0
---

# Set-AzureRmStorageAccountManagementPolicy

## SYNOPSIS
Creates or modifies the management policy of an Azure Storage account.

## SYNTAX

### AccountNamePolicyString
```
Set-AzureRmStorageAccountManagementPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 [-Policy] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountNamePolicyObject
```
Set-AzureRmStorageAccountManagementPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 -InputObject <PSManagementPolicy> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AccountObject
```
Set-AzureRmStorageAccountManagementPolicy -StorageAccount <PSStorageAccount> [-Policy] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmStorageAccountManagementPolicy** cmdlet creates or modifies the management policy of an Azure Storage account.
The management policy rules must be in JSON format

## EXAMPLES

### Example 1: Create or update the management policy of a Storage account.
```
PS C:\> $policy = '{
    "version":"0.5",
    "rules":
    [{
        "type": "Lifecycle",
        "name": "olcmtest",
        "definition": {
            "filters":
            {
                "blobTypes":["blockBlob"],
                "prefixMatch":["olcmtestcontainer"]
            },
            "actions":
            {
                "baseBlob":
                {
                    "delete":
                    {
                        "daysAfterModificationGreaterThan":1000
                    },
					"tierToArchive" : {
						"daysAfterModificationGreaterThan" : 90
					},
                    "tierToCool":
                    {
                        "daysAfterModificationGreaterThan":1000
                    }
                },
				"snapshot":
                {
                    "delete":
                    {
                        "daysAfterCreationGreaterThan":5000
                    }
                }
            }
        }
    }]
}'
PS C:\>Set-AzureRmStorageAccountManagementPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Policy $policy

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
LastModifiedTime   : 5/28/2018 10:09:18 AM
```

This command creates or updates the management policy of a Storage account..

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

### -InputObject
Management Object to Set

```yaml
Type: PSManagementPolicy
Parameter Sets: AccountNamePolicyObject
Aliases: ManagementPolicy

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Policy
The lifecycle management policy, it's a collection of rules in a JSON document.
See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.

```yaml
Type: String
Parameter Sets: AccountNamePolicyString, AccountObject
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: AccountNamePolicyString, AccountNamePolicyObject
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
Parameter Sets: AccountNamePolicyString, AccountNamePolicyObject
Aliases: AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicy

## NOTES

## RELATED LINKS

