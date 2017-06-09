---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmSqlDatabaseToFailoverGroup

## SYNOPSIS
Adds one or more databases to an Azure SQL Database Failover Group.

## SYNTAX

```
Add-AzureRmSqlDatabaseToFailoverGroup -ServerName <String> -FailoverGroupName <String>
 -Database <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel]>
 -ResourceGroupName <String> [<CommonParameters>]
```

## DESCRIPTION
Adds one or more databases on a Azure SQL Database Failover Group's primary server to to that Failover Group. The databases must not be secondary databases in existing replication relationships. The command will start geo-replication of any added databases to the Failover Group's secondary server.

To obtain database objects with which to populate the '-Database' parameter, use (for example) the Get-AzureRmSqlDatabase cmdlet.

The Failover Group's primary server must be used to execute the command.

## EXAMPLES

### Example 1
```
PS C:\> $failoverGroup = Get-AzureRmSqlDatabase -ResourceGroupName rg -ServerName primaryserver -DatabaseName db1 | Add-AzureRmSqlDatabaseToFailoverGroup -ResourceGroupName rg -ServerName primaryserver -FailoverGroupName fg
```

This command adds one database to a Failover Group by piping it in.

### Example 2
```
PS C:\> $primaryServer = Get-AzureRmSqlServer -ResourceGroupName rg -ServerName primaryserver
PS C:\> $failoverGroup = $primaryServer | Add-AzureRmSqlDatabaseToFailoverGroup -FailoverGroupName fg -Database ($primaryServer | Get-AzureRmSqlDatabase)
```

This command adds all databases in a server to a Failover Group.

### Example 3
```
PS C:\> $failoverGroup = Get-AzureRmSqlDatabaseFailoverGroup -ResourceGroupName rg -ServerName primaryserver -FailoverGroupName fg
PS C:\> $databases = Get-AzureRmSqlElasticPoolDatabase -ResourceGroupName rg -ServerName primaryserver -ElasticPoolName pool1
PS C:\> $failoverGroup = $failoverGroup | Add-AzureRmSqlDatabaseToFailoverGroup -Database $databases
```

This command adds all databases in an Elastic Pool to a Failover Group.

## PARAMETERS

### -Database
One or more Azure SQL Databases on the Failover Group's primary server to be added to the Failover Group.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel]
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FailoverGroupName
The name of the Azure SQL Database Failover Group.

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
The name of the resource group.

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

### -ServerName
The name of the primary Azure SQL Database Server of the Failover Group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Collections.Generic.List\`1\[\[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel, Microsoft.Azure.Commands.Sql, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null\]\]

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[New-AzureRmSqlDatabaseFailoverGroup](./New-AzureRmSqlDatabaseFailoverGroup.md)

[Set-AzureRmSqlDatabaseFailoverGroup](./Set-AzureRmSqlDatabaseFailoverGroup.md)

[Get-AzureRmSqlDatabaseFailoverGroup](./Get-AzureRmSqlDatabaseFailoverGroup.md)

[Remove-AzureRmSqlDatabaseFromFailoverGroup](./Remove-AzureRmSqlDatabaseFromFailoverGroup.md)

[Switch-AzureRmSqlDatabaseFailoverGroup](./Switch-AzureRmSqlDatabaseFailoverGroup.md)

[Remove-AzureRmSqlDatabaseFailoverGroup](./Remove-AzureRmSqlDatabaseFailoverGroup.md)

[SQL Database Documentation](https://docs.microsoft.com/azure/sql-database/)
