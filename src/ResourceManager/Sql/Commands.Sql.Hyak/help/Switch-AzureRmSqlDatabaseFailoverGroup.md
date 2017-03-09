---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Switch-AzureRmSqlDatabaseFailoverGroup

## SYNOPSIS
The Cmdlet that issues failover operation on Azure SQL Failover Group

## SYNTAX

```
Switch-AzureRmSqlDatabaseFailoverGroup [[-FailoverGroupName] <String>] [-AllowDataLoss] [-ServerName] <String>
 [-ResourceGroupName] <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command must be executed on a secondary server of a specific FG. The FG is identified by the listener name. The command switches all secondary databases to the primary role. All active TDS sessions will be disconnected. All new TDS sessions will be automatically re-routed to the secondary server, which now becomes primary server. When the original primary server is back online it will automatically become the secondary server and all formerly primary databases in it will switch to the secondary role. 


## EXAMPLES

### Example 1
```
Issue failover operation with data loss
PS C:\> C:\> $ag | Switch-AzureRMSqlDatabaseFailoverGroup -AllowDataLoss 

```

### Example 1
```
Issue failover operation without data loss
PS C:\> C:\> $ag | Switch-AzureRMSqlDatabaseFailoverGroup 

```


## PARAMETERS

### -AllowDataLoss
Whether this failover operation will allow data loss.

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

### -FailoverGroupName
The name of the Azure SQL Failover Group to retrieve.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
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

### System.Object

## NOTES

## RELATED LINKS

