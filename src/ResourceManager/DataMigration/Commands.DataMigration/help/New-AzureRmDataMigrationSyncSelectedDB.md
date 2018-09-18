---
external help file: Microsoft.Azure.Commands.DataMigration.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datamigration/New-AzureRmDataMigrationService
schema: 2.0.0
---

# New-AzureRmDataMigrationSyncSelectedDB

## SYNOPSIS
Creates a database input object for the sync scenarios with information about source nad target databases.

## SYNTAX

```
New-AzureRmDataMigrationSyncSelectedDB -TargetDatabaseName <String> -SchemaName <String> -TableMap <Hashtable>
 [-MigrationSetting <Hashtable>] [-SourceSetting <Hashtable>] [-TargetSetting <Hashtable>]
 -SourceDatabaseName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzureRmDataMigrationSyncSelectedDB cmdlet creates a database info object specific to the sync scenario which contains information about source and target databases.  

## EXAMPLES

### Example 1
```
PS C:\> $tableMap = New-Object 'system.collections.generic.dictionary[string,string]'
	$tableMap.Add("dbo.TestTable1", "dbo.TestTable1")
	$tableMap.Add("dbo.TestTable2","dbo.TestTable2")

	$selectedDbs = New-AzureRmDmsSqlServerSqlDbSyncSelectedDB 
		-TargetDatabaseName DatabaseName `
		-SchemaName dbo `
		-TableMap $tableMap `
		-Name DatabaseName
```

This example creates a database metadata object describing the migrating settings for $DatabaseName to database $DatabaseName.  

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

### -MigrationSetting
Migration settings which tune the migration behavior

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SchemaName
Schema name to be migrated

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDatabaseName
The name of the source database.```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceSetting
Source settings to tune source endpoint migration behavior

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableMap
Mapping of source to target tables

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDatabaseName
The name of the target database

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSetting
Target settings to tune target endpoint migration behavior

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

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

### Microsoft.Azure.Management.DataMigration.Models.MigrateSqlServerSqlDbSyncTaskInput

## NOTES

## RELATED LINKS

