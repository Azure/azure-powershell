---
external help file: Az.PostgreSqlFlexibleServer-help.xml
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
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all read replicas of a server.

## EXAMPLES

### Example 1: List all read replicas for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name                 ResourceGroupName Location    SkuName         State ReplicationRole
----                 ----------------- --------    -------         ----- ---------------
myPostgreSqlServer-r1 replica-rg        West US 2   Standard_D2s_v3 Ready Replica
myPostgreSqlServer-r2 replica-rg        East US     Standard_D2s_v3 Ready Replica
```

Lists all read replicas for the specified PostgreSQL Flexible Server primary instance.

### Example 2: Get details of read replicas across regions
```powershell
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroupName "production-rg" -ServerName "prod-postgresql-primary"
```

```output
Name                    ResourceGroupName Location      SkuName         State ReplicationRole ReplicationState
----                    ----------------- --------      -------         ----- --------------- ----------------
prod-postgresql-replica1 production-rg     West Europe   Standard_D4s_v3 Ready Replica        Active
prod-postgresql-replica2 production-rg     North Europe  Standard_D4s_v3 Ready Replica        Active
```

Retrieves information about all read replicas, showing their geographic distribution and replication status.

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
