---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmSqlDatabaseFailoverGroup

## SYNOPSIS
Cmdlet to get the Azure SQL Failover Group Object

## SYNTAX

```
Get-AzureRmSqlDatabaseFailoverGroup [[-FailoverGroupName] <String>] [-ServerName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
Cmdlet to get the Azure SQL Failover Group Object

## EXAMPLES

### Example 1
```
PS C:\> $myFG = Get-AzureRMSqlDatabaseFailoverGroup -ResourceGroupName "myrg" -ServerName "myserver"
```

{{ Add example description here }}

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

