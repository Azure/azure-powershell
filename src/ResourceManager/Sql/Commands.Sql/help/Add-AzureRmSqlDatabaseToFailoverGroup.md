---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmSqlDatabaseToFailoverGroup

## SYNOPSIS
Cmdlet that adds databases into the Azure SQL Failover Group

## SYNTAX

```
Add-AzureRmSqlDatabaseToFailoverGroup [-FailoverGroupName] <String>
 -Database <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel]>
 [-Tag <Hashtable>] [-ServerName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
Cmdlet to add Azure Sql Databases into a Failover Group. Database input parameters should be a Azure Sql Database Model object, which could be obtained either through pipelining or storing in Powershell environment variables with the Get_AzureRmSqlDatabase Cmdelet. 

## EXAMPLES

### Example 1
```
PS C:\> Add-AzureRmSqlDatabaseToFailoverGroup -FailoverGroupName myFg-ResourceGroupName myRg -ServerName mysvr
```

### Example 2
Using Pipe Line to pipe in the database objects 
```
PS C:\> Get-AzureRmSqlDatabase -ServerName testsvr -ResourceGroupName rg2 | Add-AzureRmSqlDatabaseToFailoverGroup -FailoverGroupName myFg-ResourceGroupName myRg -ServerName mysvr
```

## PARAMETERS

### -Database
The Azure SQL Database to be added to the secondary server.

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
The name of the Azure SQL Failover Group.

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
The name of the Azure SQL Server the Failover Group is in.

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

### -Tag
The tags to associate with the Azure SQL Database Failover Group

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

### System.String
System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel, Microsoft.Azure.Commands.Sql, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

