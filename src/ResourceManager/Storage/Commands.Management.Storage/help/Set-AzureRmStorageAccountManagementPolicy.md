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

```
Set-AzureRmStorageAccountManagementPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 [-Policy] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmStorageAccountManagementPolicy** cmdlet creates or modifies the management policy of an Azure Storage account.
The management policy rules must be in JSON format

## EXAMPLES

### Example 1: Create or update the management policy of a Storage account.
```
PS C:\> $policy = '{
  "version": 0.5,
  "rules": [ 
    {
      "name": "ruleFoo", 
      "type": "lifecycle", 
      "definition": {
        "filters": {
          "blobTypes": [ "blockBlob" ],
          "nameMatch": [ "foo" ]
        },
        "actions": {
          "baseBlob": {
            "tierToCool": { "daysAfterLastModifiedGreaterThan": 30 },
            "tierToArchive": { "daysAfterLastModifiedGreaterThan": 90 },
            "delete": { "daysAfterLastModifiedGreaterThan": 2555 }
          },
          "snapshot": {
            "delete": { "daysAfterCreationGreaterThan": 90 }
          }
        }
      }
    },
	{
      "name": "expirationRule", 
      "type": "Lifecycle", 
      "definition": 
        {
          "filters": {
            "blobTypes": [ "blockBlob" ]
          },
          "actions": {
            "baseBlob": {
              "delete": { "daysAfterLastModifiedGreaterThan": 365 }
            }
          }
        }      
    }
  ]
}'
PS C:\>Set-AzureRmStorageAccountManagementPolicy -ResourceGroupName "MyResourceGroup" -AccountName "mystorageaccount" -Policy $policy
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

### -Policy
The lifecycle management policy, it's a collection of rules in a JSON document.

```yaml
Type: String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountName
Storage Account Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

