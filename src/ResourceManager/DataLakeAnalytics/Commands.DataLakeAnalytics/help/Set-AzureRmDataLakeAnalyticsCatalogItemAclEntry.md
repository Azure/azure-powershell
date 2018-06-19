---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
Module Name: AzureRM.DataLakeAnalytics
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datalakeanalytics/set-azurermdatalakeanalyticscatalogitemaclentry
schema: 2.0.0
---

# Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry

## SYNOPSIS
Modifies an entry in the ACL of a catalog or catalog item in Data Lake Analytics.

## SYNTAX

### SetCatalogAclEntryForUser (Default)
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-User] -ObjectId <Guid>
 [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetCatalogItemAclEntryForUser
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-User] -ObjectId <Guid>
 [-ItemType] <String> [-Path] <CatalogPathInstance> [-Permissions] <PermissionType>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetCatalogAclEntryForGroup
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-Group] -ObjectId <Guid>
 [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetCatalogItemAclEntryForGroup
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-Group] -ObjectId <Guid>
 [-ItemType] <String> [-Path] <CatalogPathInstance> [-Permissions] <PermissionType>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetCatalogAclEntryForOther
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-Other] [-Permissions] <PermissionType>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetCatalogItemAclEntryForOther
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-Other] [-ItemType] <String>
 [-Path] <CatalogPathInstance> [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetCatalogAclEntryForUserOwner
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-UserOwner]
 [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetCatalogItemAclEntryForUserOwner
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-UserOwner] [-ItemType] <String>
 [-Path] <CatalogPathInstance> [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetCatalogAclEntryForGroupOwner
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-GroupOwner]
 [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetCatalogItemAclEntryForGroupOwner
```
Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry [-Account] <String> [-GroupOwner] [-ItemType] <String>
 [-Path] <CatalogPathInstance> [-Permissions] <PermissionType> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry** cmdlet adds or modifies an entry (ACE) in the access control list (ACL) of a catalog or catalog item in Data Lake Analytics.

## EXAMPLES

### Example 1: Modify user permissions for a catalog
```powershell
PS C:\> Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -User -ObjectId (Get-AzureRmADUser -Mail "PattiFuller@contoso.com").Id -Permissions Read
```

This command modifies the catalog ACE for Patti Fuller to have read permissions.

### Example 2: Modify user Permissions for a database
```powershell
PS C:\> Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -User -ObjectId (Get-AzureRmADUser -Mail "PattiFuller@contoso.com").Id -ItemType Database -Path "databaseName" -Permissions Read
```

This command modifies the database ACE for Patti Fuller to have read permissions.

### Example 3: Modify other permissions for a catalog
```powershell
PS C:\> Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -Other -Permissions Read
```

This command modifies the catalog ACE for other to have read permissions.

### Example 4: Modify other Permissions for a database
```powershell
PS C:\> Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -Other -ItemType Database -Path "databaseName" -Permissions Read
```

### Example 5: Modify user owner permissions for a catalog
```powershell
PS C:\> Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -UserOwner -Permissions Read
```

This command sets the owner permission for the account to Read.

### Example 6: Modify user owner Permissions for a database
```powershell
PS C:\> Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry -Account "contosoadla" -UserOwner -ItemType Database -Path "databaseName" -Permissions Read
```

This command sets the owner permission for the database to Read.

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

### -Group
Set ACL entry of catalog for group.

```yaml
Type: SwitchParameter
Parameter Sets: SetCatalogAclEntryForGroup, SetCatalogItemAclEntryForGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GroupOwner
Set ACL entry of catalog for group owner.

```yaml
Type: SwitchParameter
Parameter Sets: SetCatalogAclEntryForGroupOwner, SetCatalogItemAclEntryForGroupOwner
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ItemType
Specifies the type of the catalog or catalog item(s). The acceptable values for this parameter are:
- Catalog
- Database

```yaml
Type: String
Parameter Sets: SetCatalogItemAclEntryForUser, SetCatalogItemAclEntryForGroup, SetCatalogItemAclEntryForOther, SetCatalogItemAclEntryForUserOwner, SetCatalogItemAclEntryForGroupOwner
Aliases:
Accepted values: Catalog, Database

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ObjectId
The identity of the user to set.

```yaml
Type: Guid
Parameter Sets: SetCatalogAclEntryForUser, SetCatalogItemAclEntryForUser, SetCatalogAclEntryForGroup, SetCatalogItemAclEntryForGroup
Aliases: Id, UserId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Other
Set ACL entry of catalog for other.

```yaml
Type: SwitchParameter
Parameter Sets: SetCatalogAclEntryForOther, SetCatalogItemAclEntryForOther
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Path
Specifies the Data Lake Analytics path of an catalog or catalog item.
The parts of the path should be separated by a period (.).

```yaml
Type: CatalogPathInstance
Parameter Sets: SetCatalogItemAclEntryForUser, SetCatalogItemAclEntryForGroup, SetCatalogItemAclEntryForOther, SetCatalogItemAclEntryForUserOwner, SetCatalogItemAclEntryForGroupOwner
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Permissions
Specifies the permissions for the ACE.
The acceptable values for this parameter are:

- None
- Read
- ReadWrite

```yaml
Type: PermissionType
Parameter Sets: (All)
Aliases:
Accepted values: None, Read, ReadWrite

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -User
Set ACL entry of catalog for user.

```yaml
Type: SwitchParameter
Parameter Sets: SetCatalogAclEntryForUser, SetCatalogItemAclEntryForUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserOwner
Set ACL entry of catalog for user owner.

```yaml
Type: SwitchParameter
Parameter Sets: SetCatalogAclEntryForUserOwner, SetCatalogItemAclEntryForUserOwner
Aliases:

Required: True
Position: Named
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

### List\<PSDataLakeAnalyticsAcl>
The resulting list of ACL entries.

## NOTES

## RELATED LINKS

[Get-AzureRmDataLakeAnalyticsCatalogItemAclEntry](Get-AzureRmDataLakeAnalyticsCatalogItemAclEntry.md)

[Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry](Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry.md)

[U-SQL now offers database level access control](https://github.com/Azure/AzureDataLake/blob/master/docs/Release_Notes/2016/2016_08_01/USQL_Release_Notes_2016_08_01.md#u-sql-now-offers-database-level-access-control)
