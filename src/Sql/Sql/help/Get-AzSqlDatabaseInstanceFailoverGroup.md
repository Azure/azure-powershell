---
<<<<<<< HEAD
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/get-azsqldatabaseinstancefailovergroup
=======
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/get-azsqldatabaseinstancefailovergroup
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzSqlDatabaseInstanceFailoverGroup

## SYNOPSIS
Gets or lists Instance Failover Groups.

## SYNTAX

```
<<<<<<< HEAD
Get-AzSqlDatabaseInstanceFailoverGroup [[-Name] <String>] [-ResourceGroupName] <String>
 [-Location] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
=======
Get-AzSqlDatabaseInstanceFailoverGroup [[-Name] <String>] [-ResourceGroupName] <String> [-Location] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```

## DESCRIPTION
Gets a specific Instance Failover Group or lists the Instance Failover Groups in a region under the user's subscription.

Either region in the Instance Failover Group may be used to execute the command. The returned values will reflect the state of the Managed Instances in that region with respect to the Instance Failover Group.

## EXAMPLES

### Example 1
```
PS C:\> $failoverGroups = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location
Output:
{
	ResourceGroupName                     : rg
	Location                              : East US
	Name                                  : fg
	PartnerResourceGroupName              : rg
	PartnerRegion                         : West US
	PrimaryManagedInstanceName            : managedInstance1
	PartnerManagedInstanceName            : managedInstance2
	ReplicationRole                       : Primary
	ReplicationState                      : CATCH_UP
	ReadWriteFailoverPolicy               : Automatic
	FailoverWithDataLossGracePeriodHours  : 1
	ReadOnlyFailoverPolicy                : Disabled
	Id                                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg/providers/Microsoft.Sql/locations/eastus/instanceFailoverGroups/fg
}
```

Lists all Failover Groups in the region

### Example 2
```
PS C:\> $failoverGroup = Get-AzSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location -Name fg
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
ReadWriteFailoverPolicy               : Automatic
FailoverWithDataLossGracePeriodHours  : 1
ReadOnlyFailoverPolicy                : Disabled
Id                                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rg/providers/Microsoft.Sql/locations/eastus/instanceFailoverGroups/fg
```

Get a specific Instance Failover Group.

## PARAMETERS

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

### -Location
The name of the Local Region from which to retrieve the Instance Failover Group.

```yaml
<<<<<<< HEAD
Type: String
=======
Type: System.String
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Instance Failover Group to retrieve.

```yaml
<<<<<<< HEAD
Type: String
=======
Type: System.String
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: False
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
=======
Type: System.String
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model.AzureSqlInstanceFailoverGroupModel

## NOTES

## RELATED LINKS
