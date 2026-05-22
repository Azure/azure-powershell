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
Get-AzPostgreSqlFlexibleServerReplica -ResourceGroup <String> -ServerName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all read replicas of a server.

## EXAMPLES

### Example 1: List all tuning options in a server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                           State
----                           -----
index                          
configuration                  Disabled
table
```

Lists all tuning options in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get all tuning options in a server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                           State
----                           -----
index                          
configuration                  Disabled
table
```

Lists all tuning options in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments.
If subscription is not passed explicitly, it's taken from default context.

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

### -ResourceGroup
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
