---
external help file:
Module Name: Az.PostgreSql
online version: https://learn.microsoft.com/powershell/module/az.postgresql/restore-azpostgresqlflexibleserver
schema: 2.0.0
---

# Restore-AzPostgreSqlFlexibleServer

## SYNOPSIS
Restore a PostgreSQL flexible server using Geo-restore

## SYNTAX

### PointInTimeRestore (Default)
```
Restore-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> -SourceServerName <String>
 -RestorePointInTime <DateTime> [-SubscriptionId <String>] [-PrivateDnsZone <String>] [-Subnet <String>]
 [-Zone <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GeoRestore
```
Restore-AzPostgreSqlFlexibleServer -Name <String> -ResourceGroupName <String> -SourceServerName <String>
 -RestorePointInTime <DateTime> -UseGeoRestore [-SubscriptionId <String>] [-Sku <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Restore a PostgreSQL flexible server using Geo-restore

## EXAMPLES

### Example 1: Restore PostgreSql server using PointInTime Restore
```powershell
$restorePointInTime = (Get-Date).AddMinutes(-10)
Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -RestorePointInTime $restorePointInTime 
```

```output
Name           Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----           --------  -------         -------        ------------------ -------------
pg-restore     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

These cmdlets restore PostgreSql server using PointInTime Restore.

### Example 1: Restore PostgreSql server using PointInTime Restore with different network resource
```powershell

$Subnet = '/subscriptions/00000000-0000-0000-0000-0000000000/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.Network/virtualNetworks/vnetname/subnets/subnetname'
$DnsZone = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/postgresqltest/providers/Microsoft.Network/privateDnsZones/testserver.private.postgres.database.azure.com'
$restorePointInTime = (Get-Date).AddMinutes(-10)
Restore-AzPostgreSqlFlexibleServer -Name pg-restore -ResourceGroupName PowershellPostgreSqlTest -SourceServerName postgresql-test -RestorePointInTime $restorePointInTime -Subnet $subnet -PrivateDnsZone $DnsZone
```

```output
Name           Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----           --------  -------         -------        ------------------ -------------
pg-restore     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

These cmdlets restore PostgreSql server using PointInTime Restore.

## PARAMETERS

### -AsJob
Run the command as a job.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the server to restore.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateDnsZone
The id of an existing private dns zone.
You can use the
        private dns zone from same resource group, different resource group, or
        different subscription.
The suffix of dns zone has to be same as that of fully qualified domain of the server.

```yaml
Type: System.String
Parameter Sets: PointInTimeRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.

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

### -RestorePointInTime
The point in time to restore from (ISO8601 format), e.g., 2017-04-26T02:10:00+08:00.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The name of the sku, typically, tier + family + cores, e.g., B_Gen4_1, GP_Gen5_8.

```yaml
Type: System.String
Parameter Sets: GeoRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceServerName
The name of the source server to restore from.

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

### -Subnet
The id of an existing Subnet the private access server will created to.
Please note that the subnet will be delegated to Microsoft.DBforPostgreSQL/flexibleServers.
After delegation, this subnet cannot be used for any other type of Azure resources.

```yaml
Type: System.String
Parameter Sets: PointInTimeRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Application-specific metadata in the form of key-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GeoRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseGeoRestore
Use Geo mode to restore

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GeoRestore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
Availability zone into which to provision the resource.

```yaml
Type: System.String
Parameter Sets: PointInTimeRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20210601.IServerAutoGenerated

## NOTES

## RELATED LINKS

