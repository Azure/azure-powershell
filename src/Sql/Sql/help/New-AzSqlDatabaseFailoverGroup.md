---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/new-azsqldatabasefailovergroup
schema: 2.0.0
---

# New-AzSqlDatabaseFailoverGroup

## SYNOPSIS
This command creates a new Azure SQL Database Failover Group.

## SYNTAX

```
New-AzSqlDatabaseFailoverGroup [-ServerName] <String> -FailoverGroupName <String>
 [-PartnerSubscriptionId <String>] [-PartnerResourceGroupName <String>] -PartnerServerName <String>
 [-FailoverPolicy <FailoverPolicy>] [-GracePeriodWithDataLossHours <Int32>]
 [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>]
 [-PartnerServerList <System.Collections.Generic.List`1[System.String]>]
 [-ReadOnlyEndpointTargetServer <String>] [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure SQL Database Failover Group for the specified servers.
Two Azure SQL Database TDS endpoints are created at FailoverGroupName.SqlDatabaseDnsSuffix (for example, FailoverGroupName.database.windows.net) and FailoverGroupName.secondary.SqlDatabaseDnsSuffix. These endpoints may be used to connect to the primary and secondary servers in the Failover Group, respectively. If the primary server is affected by an outage, automatic failover of the endpoints and databases will be triggered as dictated by the Failover Group's failover policy and grace period.
Newly created Failover Groups do not contain any databases. To control the set of databases in a Failover Group, use the 'Add-AzSqlDatabaseToFailoverGroup' and 'Remove-AzSqlDatabaseFromFailoverGroup' cmdlets.
Only values greater than or equal to 1 hour are supported for the '-GracePeriodWithDataLossHours' parameter.

[!NOTE] It's possible to deploy your auto-failover group across subscriptions by using the -PartnerSubscriptionId parameter in Azure Powershell starting with [Az.SQL 3.11.0](https://www.powershellgallery.com/packages/Az.Sql/3.11.0).

## EXAMPLES

### Example 1
```powershell
$failoverGroup = New-AzSqlDatabaseFailoverGroup -ResourceGroupName rg -ServerName primaryserver -PartnerServerName secondaryserver -FailoverGroupName fg -FailoverPolicy Automatic -GracePeriodWithDataLossHours 1
```

This command creates a new Failover Group with failover policy 'Automatic' for two servers in the same resource group.

### Example 2
```powershell
$failoverGroup = New-AzSqlDatabaseFailoverGroup -ResourceGroupName rg1 -ServerName primaryserver -PartnerResourceGroupName rg2 -PartnerServerName secondaryserver1 -FailoverGroupName fg -FailoverPolicy Manual
```

This command creates a new Failover Group with failover policy 'Manual' for two servers in different resource groups.

### Example 3
```powershell
$sub2 = 'b3c40cd6-024f-428c-921b-cda6c6834c34'
$failoverGroup = New-AzSqlDatabaseFailoverGroup -ServerName primaryserver -FailoverGroupName fg -PartnerSubscriptionId $sub2 -PartnerResourceGroupName rg2 -PartnerServerName secondaryserver1 -FailoverPolicy Manual -ResourceGroupName rg1
```

```output
FailoverGroupName                    : fg
Location                             : East US
ResourceGroupName                    : rg1
ServerName                           : primaryserver
PartnerLocation                      : West US 2
PartnerResourceGroupName             : rg2
PartnerServerName                    : secondaryserver1
ReplicationRole                      : Primary
ReplicationState                     : CATCH_UP
ReadWriteFailoverPolicy              : Manual
FailoverWithDataLossGracePeriodHours :
DatabaseNames                        : {}
```

This command creates a new Failover Group with failover policy 'Manual' for two servers in different subscriptions.

## PARAMETERS

### -AllowReadOnlyFailoverToPrimary
Whether an outage on the secondary server should trigger automatic failover of the read-only endpoint.

```yaml
Type: Microsoft.Azure.Commands.Sql.FailoverGroup.Model.AllowReadOnlyFailoverToPrimary
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
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverGroupName
The name of the Azure SQL Database Failover Group to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverPolicy
The failover policy of the Azure SQL Database Failover Group.

```yaml
Type: Microsoft.Azure.Commands.Sql.FailoverGroup.Model.FailoverPolicy
Parameter Sets: (All)
Aliases:
Accepted values: Automatic, Manual

Required: False
Position: Named
Default value: Manual
Accept pipeline input: False
Accept wildcard characters: False
```

### -GracePeriodWithDataLossHours
Interval before automatic failover is initiated if an outage occurs on the primary server and failover cannot be completed without data loss.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 1
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerResourceGroupName
The name of the secondary resource group of the Azure SQL Database Failover Group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerServerList
The list of partner servers in the failover group (empty list for 0 servers).

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerServerName
The name of the secondary server of the Azure SQL Database Failover Group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerSubscriptionId
The name of the secondary subscription id of the Azure SQL Database Failover Group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadOnlyEndpointTargetServer
The name of the target server for the read only endpoint. If empty, defaults to value of PartnerServerName.

```yaml
Type: System.String
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
Type: System.String
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.FailoverGroup.Model.AzureSqlFailoverGroupModel

## NOTES

## RELATED LINKS

[Set-AzSqlDatabaseFailoverGroup](./Set-AzSqlDatabaseFailoverGroup.md)

[Get-AzSqlDatabaseFailoverGroup](./Get-AzSqlDatabaseFailoverGroup.md)

[Add-AzSqlDatabaseToFailoverGroup](./Add-AzSqlDatabaseToFailoverGroup.md)

[Remove-AzSqlDatabaseFromFailoverGroup](./Remove-AzSqlDatabaseFromFailoverGroup.md)

[Switch-AzSqlDatabaseFailoverGroup](./Switch-AzSqlDatabaseFailoverGroup.md)

[Remove-AzSqlDatabaseFailoverGroup](./Remove-AzSqlDatabaseFailoverGroup.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)
