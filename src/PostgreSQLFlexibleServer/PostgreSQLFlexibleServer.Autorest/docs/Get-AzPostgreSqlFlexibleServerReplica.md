---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverreplica
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerReplica

## SYNOPSIS
Lists all read replicas of a server.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all read replicas of a server.

## EXAMPLES

### Example 1: Get all read replicas for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name               : myPostgreSqlServer-replica-1
ResourceGroupName  : myResourceGroup
Location           : East US 2
SourceServerName   : myPostgreSqlServer
SourceServerRegion : East US
ReplicaRole        : AsyncReplica
State              : Ready
SkuName            : Standard_D2s_v3
StorageSizeGb      : 128

Name               : myPostgreSqlServer-replica-2
ResourceGroupName  : myResourceGroup
Location           : Central US
SourceServerName   : myPostgreSqlServer
SourceServerRegion : East US
ReplicaRole        : AsyncReplica
State              : Ready
SkuName            : Standard_D2s_v3
StorageSizeGb      : 128
```

Retrieves all read replicas for the specified PostgreSQL Flexible Server.

### Example 2: Get replicas for a production server
```powershell
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01"
```

```output
Name               : prod-postgresql-01-read-replica
ResourceGroupName  : production-rg
Location           : West Europe
SourceServerName   : prod-postgresql-01
SourceServerRegion : East US
ReplicaRole        : AsyncReplica
State              : Ready
SkuName            : Standard_D4s_v3
StorageSizeGb      : 256
ReplicationLag     : 00:00:02.150
```

Retrieves information about read replicas for a production PostgreSQL Flexible Server.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServer

## NOTES

## RELATED LINKS

