---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmSqlDatabaseFailoverGroup

## SYNOPSIS
The Cmdlet that removes the Azure SQL Failover Group

## SYNTAX

```
Remove-AzureRmSqlDatabaseFailoverGroup [-FailoverGroupName] <String> [-PartnerResourceGroupName <String>]
 -PartnerServerName <String> [-Force] [-ServerName] <String> [-ResourceGroupName] <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This command deletes all secondary databases included the FG and removes the FG object with the specified name from each participating server. The primary databases will become regular read-write databases. The listener endpoint will be unregistered from DNS.  


## EXAMPLES

### Example 1
```
PS C:\> PS C:\> Remove-AzureRmSqlDatabaseFailoverGroup -PrimaryResourceGroupName "myFG" -ServerName "myserver" –FailoverGroupName "myFG"  

```


## PARAMETERS

### -FailoverGroupName
The name of the Azure SQL Failover Group to remove.

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

### -Force
Skip confirmation message for performing the action

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

