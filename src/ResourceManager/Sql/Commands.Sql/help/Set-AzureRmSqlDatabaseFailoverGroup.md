---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmSqlDatabaseFailoverGroup

## SYNOPSIS
The Cmdlet that sets properties of the Azure SQL Failover Group

## SYNTAX

```
Set-AzureRmSqlDatabaseFailoverGroup -FailoverGroupName <String> [-FailoverPolicy <FailoverPolicy>]
 [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>]
 [-Tags <Hashtable>] -ServerName <String> -ResourceGroupName <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command modifies the configuration of the failover group. Adding or removing servers and databases requires using the specialized cmdlets. 


## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmSqlDatabaseFailoverGroup -FailoverGroupName testfg -PartnerServerName testsvr -FailoverPolicy Automatic -GracePeriodWithDataLossHours 1 -AllowReadOnlyFailoverToPrimary Disabled -ServerName test1 -ResourceGroupName rg2
```


## PARAMETERS

### -AllowReadOnlyFailoverToPrimary
The failover policy for read only endpoint of the failover group.```yaml
Type: AllowReadOnlyFailoverToPrimary
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FailoverPolicy
The failover policy without data loss for the failover group.```yaml
Type: FailoverPolicy
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GracePeriodWithDataLossHours
The grace period for failover with data loss of the failover group.```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
The tag to associate with the Azure Sql Failover Group```yaml
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

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

