---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.dll-Help.xml
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationmongodbdatabasesetting
schema: 2.0.0
---

# New-AzDataMigrationMongoDbDatabaseSetting

## SYNOPSIS
Creates database setting for migration for the mongoDb migration

## SYNTAX

```
New-AzDataMigrationMongoDbDatabaseSetting -Name <String> [-TargetRequestUnit <Int32>]
 [-CollectionSetting <MongoDbCollectionSetting[]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzDataMigrationMongoDbDatabaseSetting  cmdlet creates the migration setting object that specifies the throughput and delete behavior.
The output is a key value pair with name of collection and value of the setting, which can be used in invoking the migration task.

## EXAMPLES

### Example 1
```powershell
New-AzDataMigrationMongoDbDatabaseSetting  -Name mycollection -RU 1000 -CollectionSetting @($coll1, $coll2)
```

```output
Name Setting
---- -------
test Microsoft.Azure.Management.DataMigration.Models.MongoDbDatabaseSettings
```

## PARAMETERS

### -CollectionSetting
The collection settings for the databases, refer to: New-AzureRmDmsMongoCollectionSetting

```yaml
Type: Microsoft.Azure.Commands.DataMigration.Models.MongoDb.MongoDbCollectionSetting[]
Parameter Sets: (All)
Aliases: Coll

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the database

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DatabaseName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetRequestUnit
The dedicated database level request unit value. If not set, that collection uses shared database RU.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases: RU

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.DataMigration.Models.MongoDbDatabaseSetting

## NOTES

## RELATED LINKS
