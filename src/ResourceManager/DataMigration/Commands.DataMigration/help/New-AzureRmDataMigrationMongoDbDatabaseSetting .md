---
external help file: Microsoft.Azure.Commands.DataMigration.dll-Help.xml
Module Name: AzureRM.DataMigration
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datamigration/New-AzureRmDmsMongoDbDatabaseSettings
schema: 2.0.0
---

# New-AzureRmDataMigrationMongoDbDatabaseSetting 

## SYNOPSIS
Creates database setting for migration for the mongoDb migration

## SYNTAX

```
New-AzureRmDataMigrationMongoDbDatabaseSetting  -Name <Name> [-RU <RU>] -Collections <Collections>
```

## DESCRIPTION
The New-AzureRmDataMigrationMongoDbDatabaseSetting  cmdlet creates the migration setting object that specifies the throughput and delete behavior. 
The output is a key value pair with name of collection and value of the setting, which can be used in invoking the migration task.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmDataMigrationMongoDbDatabaseSetting  -Name mycollection -RU 1000 -Collections @(coll1, coll2)

```

## PARAMETERS

### -Name
Name of the database

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```
### -TargetRU
The dedicated database level request unit value. If not set, that collection uses shared database RU.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: RU

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Collections
The array of MongoDb collection setting objects returned by New-AzureRmDmsMongoDbDatabaseSetting call.

```yaml
Type: System.Collections.Generic.KeyValuePair<string, MongoDbCollectionSettings>[]
Parameter Sets: (All)
Aliases: colls

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

## OUTPUTS

### System.Collections.Generic.KeyValuePair<string, MongoDbDatabaseSettings>

## NOTES

## RELATED LINKS
