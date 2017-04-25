---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmSqlDatabaseFailoverGroup

## SYNOPSIS
This command is executed in the context of the primary server. It creates the new Azure SQL Failover Group on the server. 

## SYNTAX

```
New-AzureRmSqlDatabaseFailoverGroup -FailoverGroupName <String> [-PartnerResourceGroupName <String>]
 -PartnerServerName <String> [-FailoverPolicy <FailoverPolicy>] [-GracePeriodWithDataLossHour <Int32>]
 [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>] [-Tag <Hashtable>] [-ServerName] <String>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
Cmdlet that creates the new Azure SQL Failover Group on the server. 

## EXAMPLES

### Example 1
```
PS C:\> C:\> $ag = New-AzureRMSqlDatabaseFailoverGroup -ResourceGroupName "myrg" -ServerName "myserver" -PartnerServerName "mydrserver" -FailoverGroupName "MyFG" -FailoverPolicy "Automatic" -AllowReadOnlyFailoverToPrimary "Enabled" -GracePeriodWithDataLossHours 1
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
The name of the Azure SQL FailoverGroup to create.

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
The window of grace period that we tolerate with data loss during a failover operation for the failover group.

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

### -PartnerResourceGroupName
The partner resource group name for Azure SQL Database Failover Group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerServerName
The partner server name for Azure SQL Database Failover Group.

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

