---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/set-azurermsqldatabaseinstancefailovergroup
schema: 2.0.0
---

# Set-AzureRmSqlDatabaseInstanceFailoverGroup

## SYNOPSIS
Modifies the configuration of an Azure SQL Database Instance Failover Group.

## SYNTAX

### Set a Instance Failover Group from AzureSqlInstanceFailoverGroupModel instance definition
```
Set-AzureRmSqlDatabaseInstanceFailoverGroup [[-ResourceGroupName] <String>] [-Location] <String>
 [-Name] <String> -InputObject <AzureSqlInstanceFailoverGroupModel> [-FailoverPolicy <FailoverPolicy>]
 [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### Set a Instance Failover Group from Resource Id
```
Set-AzureRmSqlDatabaseInstanceFailoverGroup [[-ResourceGroupName] <String>] [-Location] <String>
 [-Name] <String> [-ResourceId] <String> [-FailoverPolicy <FailoverPolicy>]
 [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
This command modifies the configuration of an Azure SQL Database Instance Failover Group.

The Instance Failover Group's primary region should be used to execute the command.

During preview of the Instance Failover Groups feature, only values greater than or equal to 1 hour are supported for the '-GracePeriodWithDataLossHours' parameter.

## EXAMPLES

### Example 1
```
PS C:\> $failoverGroup = Get-AzureRmSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location -Name fg | Set-AzureRmSqlDatabaseFailoverGroup -FailoverPolicy Manual
```

Sets a Instance Failover Group's failover policy to 'Manual' by piping in the Failover Group.

## PARAMETERS

### -AllowReadOnlyFailoverToPrimary
Whether outages on the secondary server should trigger automatic failover of the read-only endpoint.
This feature is not yet supported.

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

### -FailoverPolicy
The failover policy of the Azure SQL Database Instance Failover Group.

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

### -GracePeriodWithDataLossHours
Interval before automatic failover is initiated if an outage occurs on the primary server and failover cannot be completed without data loss.

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

### -InputObject
The Instance Failover Group object to set

```yaml
Type: AzureSqlInstanceFailoverGroupModel
Parameter Sets: Set a Instance Failover Group from AzureSqlInstanceFailoverGroupModel instance definition
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Local Region from which to retrieve the Instance Failover Group.

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

### -Name
The name of the Azure SQL Database Instance Failover Group.

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

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The Resource ID of the Instance Failover Group to set.

```yaml
Type: String
Parameter Sets: Set a Instance Failover Group from Resource Id
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model.AzureSqlInstanceFailoverGroupModel


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
