---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleserverfirewallrule
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerFirewallRule

## SYNOPSIS
Gets information about a firewall rule in a server.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerFirewallRule -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFlexibleServer
```
Get-AzPostgreSqlFlexibleServerFirewallRule -Name <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerFirewallRule -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerFirewallRule -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a firewall rule in a server.

## EXAMPLES

### Example 1: List all firewall rules in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server
```

```output
Name                                     StartIPAddress       EndIPAddress
----                                     --------------       ------------
example-firewall-rule-01                 ###.###.###.###      ###.###.###.###
example-firewall-rule-02                 ###.###.###.###      ###.###.###.###
```

Lists all firewall rules in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one firewall rule in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-firewall-rule
```

```output
Name                                     StartIPAddress       EndIPAddress
----                                     --------------       ------------
example-firewall-rule                    ###.###.###.###      ###.###.###.###
```

Gets one firewall rule in an Azure Database for PostgreSQL flexible server with firewall rule name, server name, resource group, and subscription explicitly passed as arguments.
If subscription is not passed explicitly, it's taken from default context.

### Example 3: Get one fireall rule corresponding to specific resource identifier
```powershell
$ID = "/subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/firewallRules/example-firewall-rule"
Get-AzPostgreSqlFlexibleServerFirewallRule -InputObject $ID
```

```output
Name                                     StartIPAddress       EndIPAddress
----                                     --------------       ------------
example-firewall-rule                    ###.###.###.###      ###.###.###.###
```

Gets one firewall rule in an Azure Database for PostgreSQL flexible server with the specific resource identifier of the firewall rule, explicitly passed as an argument.

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

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentityFlexibleServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the firewall rule.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityFlexibleServer, Get
Aliases: FirewallRuleName

Required: True
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFirewallRule

## NOTES

## RELATED LINKS
