---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmSqlDatabaseFromFailoverGroup

## SYNOPSIS
The Cmdlet that drops databases from the Azure SQL Failover Group.

## SYNTAX

```
Remove-AzureRmSqlDatabaseFromFailoverGroup -FailoverGroupName <String>
 -Databases <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel]>
 [-Tags <Hashtable>] -ServerName <String> -ResourceGroupName <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command must be executed on the primary server. The command drops the corresponding secondary databases on all secondary servers and unregisters the read-write databases from the FG.  The database input parameter is a Azure Sql Database Model and it should be either piped in or passed in as a environmental variable.


## EXAMPLES

### Example 1
Remove one database from the Failover Group

```
PS C:\> Get-AzureRmSqlDatabase -ServerName testsvr -ResourceGroupName myrg2 -DatabaseName testdb | Remove-AzureRmSqlDatabaseFromFailoverGroup -FailoverGroupName testfg -ResourceGroupName rg2 -ServerName testsvr
```

### Example 2:
Remove all databases in a server from the Failover Group

```
PS C:\> Get-AzureRmSqlDatabase -ServerName testsvr -ResourceGroupName myrg2 | Remove-AzureRmSqlDatabaseFromFailoverGroup -FailoverGroupName testfg -ResourceGroupName rg2 -ServerName testsvr
```

## PARAMETERS

### -Databases
The Azure SQL Databases to be added to the secondary server.```yaml
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
The name of the Azure SQL Failover Group.```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
The name of the Azure SQL Server the Failover Group is in.```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tags
The tag to associate with the Azure Sql Elastic Pool```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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
System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel, Microsoft.Azure.Commands.Sql, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS


