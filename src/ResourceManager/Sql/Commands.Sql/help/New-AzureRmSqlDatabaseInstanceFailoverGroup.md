---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# New-AzureRmSqlDatabaseInstanceFailoverGroup

## SYNOPSIS
This command creates a new Azure SQL Database Instance Failover Group.

## SYNTAX

```
New-AzureRmSqlDatabaseInstanceFailoverGroup [[-ResourceGroupName] <String>] [-Location] <String> -Name <String>
 [-PartnerResourceGroupName <String>] -PartnerRegion <String> -PrimaryManagedInstanceName <String>
 -PartnerManagedInstanceName <String> [-FailoverPolicy <FailoverPolicy>]
 [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure SQL Database Instance Failover Group between the specified regions with the noted Managed Instance pair.

Two Azure SQL Database TDS endpoints are created at Name.SqlDatabaseDnsSuffix (for example, Name.database.windows.net) and Name.secondary.SqlDatabaseDnsSuffix. These endpoints may be used to connect to the primary and secondary regions of the Failover Group, respectively. If the primary region is affected by an outage, automatic failover of the endpoints and databases will be triggered as dictated by the Instance Failover Group's failover policy and grace period.

During preview of the Instance Failover Groups feature, only values greater than or equal to 1 hour are supported for the '-GracePeriodWithDataLossHours' parameter.

## EXAMPLES

### Example 1
```
C:\> $failoverGroup = New-AzureRmSqlDatabaseInstanceFailoverGroup -Name fgName -Location location -ResourceGroupName rg -PrimaryManagedInstanceName $managedInstance.Name -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstance.Name -FailoverPolicy Automatic -GracePeriodWithDataLossHours 1
```

This command creates a new Instance Failover Group with failover policy 'Automatic' for the Managed Instance pair.

### Example 2
```
C:\> $failoverGroup = New-AzureRmSqlDatabaseInstanceFailoverGroup -Name fgName -Location location -ResourceGroupName rg -PrimaryManagedInstanceName $managedInstance.Name -PartnerRegion $partnerRegion -PartnerManagedInstanceName $partnerManagedInstance.Name -FailoverPolicy Manual
```

This command creates a new Instance Failover Group with failover policy 'Manual' for the Managed Instance pair.

## PARAMETERS

### -AllowReadOnlyFailoverToPrimary
Whether an outage on the secondary server should trigger automatic failover of the read-only endpoint.
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

### -Location
The name of the Local Region on which to create the Instance Failover Group.

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
The name of the Azure SQL Database Failover Group to create.

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

### -PartnerManagedInstanceName
The name of the Managed Instance on the partner region to be added to the Azure SQL Database Instance Failover Group.

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

### -PartnerRegion
The name of the secondary server of the Azure SQL Database Instance Failover Group.

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

### -PartnerResourceGroupName
The name of the secondary resource group of the Azure SQL Database Instance Failover Group.

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

### -PrimaryManagedInstanceName
The name of the Managed Instance on the local region to be added to the Azure SQL Database Instance Failover Group.

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

Required: False
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


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
