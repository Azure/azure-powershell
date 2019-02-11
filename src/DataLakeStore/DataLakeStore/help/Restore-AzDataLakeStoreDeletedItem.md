---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStore.dll-Help.xml
Module Name: Az.DataLakeStore
ms.assetid: ECA70C6C-E0B0-445D-BCAD-041625FAC632
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakestore/get-azdatalakestoreitem
schema: 2.0.0
---

# Restore-AzDataLakeStoreDeletedItem

## SYNOPSIS
Restore a deleted file or folder in Azure Data Lake

## SYNTAX
### ByName (Default)
```
Restore-AzDataLakeStoreDeletedItem [-Account] <String> [-Path] <String> [-Destination] <String> [-Type] <String> [-RestoreAction] <String> [-Force] [-PassThru]
```

### ByInputObject
```
Restore-AzDataLakeStoreDeletedItem [-Account] <String> [-DeletedItem] <DataLakeStoreDeletedItem> [-RestoreAction] <String> [-Force] [-PassThru]
```

## DESCRIPTION
The **Restore-AzDataLakeStoreDeletedItem** cmdlet restores a deleted file or folder in Data Lake Store. Requires the path of deleted item in trash retunred by Get-AzDataLakeStoreDeletedItem.

## EXAMPLES

### Example 1: Get details of a file from the Data Lake Store
```
PS > Restore-AzDataLakeStoreDeletedItem -Account ml1ptrashtest -Path adl://ml1ptrashtest.azuredatalake.com/`$temp/trash/131940576000000000/me1sch201110222/deleted_0a7b9a4a-7dc0-4ddb-aa6c-6d55dca8e770
-Destination adl://ml1ptrashtest.azuredatalake.com/test0/file_1230 -Type "file" -Force
PS >

```

## PARAMETERS
### ByName (Default)
#### -Account
Specifies the name of the Data Lake Store account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

#### -Path
The path of the deleted deleted file or folder in trash.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

#### -Destination
The destination path to where the deleted file or folder should be restored. 

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

#### -Type
The type of entry being restored - "file" or "folder"

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```


#### DeletedItem
The deleted item object
```yaml
Type: DataLakeStoreDeletedItem
Parameter Sets: InputObjectParameterSet
Aliases: Default

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

#### -RestoreAction
Action to take on destination name conflicts - "copy" or "overwrite"

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
#### -PassThru
Return boolean true on success

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```
### -Force
Forces the command to run without asking for user confirmation

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Get-AzDataLakeStoreDeletedItem](./Get-AzDataLakeStoreDeletedItem.md)