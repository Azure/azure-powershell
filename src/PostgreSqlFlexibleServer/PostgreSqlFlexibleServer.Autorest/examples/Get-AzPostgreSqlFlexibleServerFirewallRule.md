### Example 1: List all firewall rules in a server
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                                     StartIPAddress       EndIPAddress
----                                     --------------       ------------
example-firewall-rule-01                 ###.###.###.###      ###.###.###.###
example-firewall-rule-02                 ###.###.###.###      ###.###.###.###
```

Lists all firewall rules in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get one firewall rule in a server
```powershell
Get-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-firewall-rule
```

```output
Name                                     StartIPAddress       EndIPAddress
----                                     --------------       ------------
example-firewall-rule                    ###.###.###.###      ###.###.###.###
```

Gets one firewall rule in an Azure Database for PostgreSQL flexible server with firewall rule name, server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.

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
