---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
Module Name: AzureRM.DataLakeAnalytics
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datalakeanalytics/remove-azurermdatalakeanalyticscatalogitemaclentry
schema: 2.0.0
---

# Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry

## SYNOPSIS
Deletes an entry from the ACL of a catalog or catalog item in Data Lake Analytics.

## SYNTAX

### RemoveCatalogAclEntryForUserOrGroup (Default)
```
Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> -ObjectId <Guid> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveCatalogItemAclEntryForUserOrGroup
```
Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> -ObjectId <Guid> [-ItemType] <String>
 [-Path] <CatalogPathInstance> [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry** cmdlet removes an entry (ACE) from the access control list (ACL) of a catalog or catalog item in Data Lake Analytics.

## EXAMPLES

### Example 1: Remove the user ACL for a catalog
```powershell
PS C:\> Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -ObjectId (Get-AzureRmADUser -Mail "PattiFuller@contoso.com").Id
```

This command removes the catalog ACL for Patti Fuller of the contosoadla account.

### Example 2: Remove the user ACL for a database
```powershell
PS C:\> Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -ObjectId (Get-AzureRmADUser -Mail "PattiFuller@contoso.com").Id -ItemType Database -Path "databaseName"
```

This command removes the database ACL for Patti Fuller of the contosoadla account.

## PARAMETERS

### -Account
Specifies the Data Lake Analytics account name.

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

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ItemType
Specifies the type of the catalog or catalog item(s). The acceptable values for this parameter are:
- Catalog
- Database

```yaml
Type: String
Parameter Sets: RemoveCatalogItemAclEntryForUserOrGroup
Aliases:
Accepted values: Catalog, Database

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ObjectId
The identity of the user to remove.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Indicates a boolean response should be returned indicating the result of the delete operation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specifies the Data Lake Analytics path of an catalog or catalog item.
The parts of the path should be separated by a period (.).

```yaml
Type: CatalogPathInstance
Parameter Sets: RemoveCatalogItemAclEntryForUserOrGroup
Aliases:

Required: True
Position: 3
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

### None
This cmdlet does not accept any input.

## OUTPUTS

### bool
If PassThru is specified, returns true upon successful completion.

## NOTES

## RELATED LINKS

[U-SQL now offers database level access control](https://github.com/Azure/AzureDataLake/blob/master/docs/Release_Notes/2016/2016_08_01/USQL_Release_Notes_2016_08_01.md#u-sql-now-offers-database-level-access-control)

[Get-AzureRmDataLakeAnalyticsCatalogItemAclEntry](Get-AzureRmDataLakeAnalyticsCatalogItemAclEntry.md)

[Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry](Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry.md)
