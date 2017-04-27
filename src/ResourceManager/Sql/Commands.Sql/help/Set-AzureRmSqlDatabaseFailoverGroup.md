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
Set-AzureRmSqlDatabaseFailoverGroup [-FailoverGroupName] <String> [-FailoverPolicy <FailoverPolicy>]
 [-GracePeriodWithDataLossHour <Int32>] [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>]
 [-Tag <Hashtable>] [-ServerName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
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
The failover policy for read only endpoint of the failover group.

```yaml
Type: AllowReadOnlyFailoverToPrimary
Parameter Sets: (All)
Aliases: 
Accepted values: Enabled, Disabled

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -FailoverPolicy
The failover policy without data loss for the failover group.

```yaml
Type: FailoverPolicy
Parameter Sets: (All)
Aliases: 
Accepted values: Automatic, Manual

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GracePeriodWithDataLossHour
The grace period for failover with data loss of the failover group. This property defines how big of the window we tolerate for data loss during failover operation

```yaml
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
The tag to associate with the Azure SQL Database Failover Group

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

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

