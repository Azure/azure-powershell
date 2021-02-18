---
<<<<<<< HEAD
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/Az.sql/set-Azsqldatabaseinstancefailovergroup
=======
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/Az.sql/set-Azsqldatabaseinstancefailovergroup
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Set-AzSqlDatabaseInstanceFailoverGroup

## SYNOPSIS
Modifies the configuration of an Instance Failover Group.

## SYNTAX

<<<<<<< HEAD
### SetIFGDefault (Default)
```
Set-AzSqlDatabaseInstanceFailoverGroup [-ResourceGroupName] <String> [-Location] <String> [-Name] <String>
 [-FailoverPolicy <FailoverPolicy>] [-GracePeriodWithDataLossHours <Int32>]
 [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set a Instance Failover Group from Resource Id
```
Set-AzSqlDatabaseInstanceFailoverGroup [-Location] <String> [-ResourceId] <String>
 [-FailoverPolicy <FailoverPolicy>] [-GracePeriodWithDataLossHours <Int32>]
 [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set a Instance Failover Group from AzureSqlInstanceFailoverGroupModel instance definition
```
Set-AzSqlDatabaseInstanceFailoverGroup -InputObject <AzureSqlInstanceFailoverGroupModel>
 [-FailoverPolicy <FailoverPolicy>] [-GracePeriodWithDataLossHours <Int32>]
 [-AllowReadOnlyFailoverToPrimary <AllowReadOnlyFailoverToPrimary>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
=======
### SetInstanceFailoverGroupDefaultSet (Default)
```
Set-AzSqlDatabaseInstanceFailoverGroup [-ResourceGroupName] <String> [-Location] <String> [-Name] <String>
 [-FailoverPolicy <String>] [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetInstanceFailoverGroupByResourceIdSet
```
Set-AzSqlDatabaseInstanceFailoverGroup [-Location] <String> [-ResourceId] <String> [-FailoverPolicy <String>]
 [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetInstanceFailoverGroupByAzureSqlInstanceFailoverGroupModelSet
```
Set-AzSqlDatabaseInstanceFailoverGroup [-InputObject] <AzureSqlInstanceFailoverGroupModel>
 [-FailoverPolicy <String>] [-GracePeriodWithDataLossHours <Int32>] [-AllowReadOnlyFailoverToPrimary <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

## DESCRIPTION
This command modifies the configuration of an Instance Failover Group.

The Instance Failover Group's primary region should be used to execute the command.

During preview of the Instance Failover Groups feature, only values greater than or equal to 1 hour are supported for the '-GracePeriodWithDataLossHours' parameter.

## EXAMPLES

### Example 1
```
<<<<<<< HEAD
PS C:\> $failoverGroup = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location -Name fg | Set-AzSqlDatabaseFailoverGroup -FailoverPolicy Manual
=======
PS C:\> $failoverGroup = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location -Name fg | Set-AzSqlDatabaseInstanceFailoverGroup -FailoverPolicy Manual
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Output:
ResourceGroupName                     : rg
Location                              : East US
Name                                  : fg
PartnerResourceGroupName              : rg
PartnerRegion                         : West US
PrimaryManagedInstanceName            : managedInstance1
PartnerManagedInstanceName            : managedInstance2
ReplicationRole                       : Primary
ReplicationState                      : CATCH_UP
ReadWriteFailoverPolicy               : Manual
FailoverWithDataLossGracePeriodHours  : 
ReadOnlyFailoverPolicy                : Disabled
Id                                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg/providers/Microsoft.Sql/locations/eastus/instanceFailoverGroups/fg
```

Sets a Instance Failover Group's failover policy to 'Manual' by piping in the Failover Group.

## PARAMETERS

### -AllowReadOnlyFailoverToPrimary
Whether outages on the secondary server should trigger automatic failover of the read-only endpoint.
<<<<<<< HEAD
This feature is not yet supported.

```yaml
Type: AllowReadOnlyFailoverToPrimary
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled
=======

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
<<<<<<< HEAD
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential
=======
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailoverPolicy
The failover policy of the Instance Failover Group.

```yaml
<<<<<<< HEAD
Type: FailoverPolicy
Parameter Sets: (All)
Aliases:
Accepted values: Automatic, Manual
=======
Type: System.String
Parameter Sets: (All)
Aliases:
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GracePeriodWithDataLossHours
Interval before automatic failover is initiated if an outage occurs on the primary server and failover cannot be completed without data loss.

```yaml
<<<<<<< HEAD
Type: Int32
=======
Type: System.Int32
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
Type: AzureSqlInstanceFailoverGroupModel
Parameter Sets: Set a Instance Failover Group from AzureSqlInstanceFailoverGroupModel instance definition
=======
Type: Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model.AzureSqlInstanceFailoverGroupModel
Parameter Sets: SetInstanceFailoverGroupByAzureSqlInstanceFailoverGroupModelSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Local Region from which to retrieve the Instance Failover Group.

```yaml
<<<<<<< HEAD
Type: String
Parameter Sets: SetIFGDefault, Set a Instance Failover Group from Resource Id
=======
Type: System.String
Parameter Sets: SetInstanceFailoverGroupDefaultSet, SetInstanceFailoverGroupByResourceIdSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Instance Failover Group.

```yaml
<<<<<<< HEAD
Type: String
Parameter Sets: SetIFGDefault
=======
Type: System.String
Parameter Sets: SetInstanceFailoverGroupDefaultSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
<<<<<<< HEAD
Type: String
Parameter Sets: SetIFGDefault
=======
Type: System.String
Parameter Sets: SetInstanceFailoverGroupDefaultSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Resource ID of the Instance Failover Group to set.

```yaml
<<<<<<< HEAD
Type: String
Parameter Sets: Set a Instance Failover Group from Resource Id
=======
Type: System.String
Parameter Sets: SetInstanceFailoverGroupByResourceIdSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: 0
Default value: None
<<<<<<< HEAD
Accept pipeline input: True (ByValue)
=======
Accept pipeline input: True (ByPropertyName)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
<<<<<<< HEAD
Type: SwitchParameter
=======
Type: System.Management.Automation.SwitchParameter
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
Type: SwitchParameter
=======
Type: System.Management.Automation.SwitchParameter
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model.AzureSqlInstanceFailoverGroupModel
System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model.AzureSqlInstanceFailoverGroupModel

## NOTES

## RELATED LINKS
