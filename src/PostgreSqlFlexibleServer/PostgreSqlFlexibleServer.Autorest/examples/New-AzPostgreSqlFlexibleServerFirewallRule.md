### Example 1: Add a firewall rule to a flexible server
```powershell
New-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-firewall-rule -StartIPAddress #.#.#.# -EndIPAddress #.#.#.#
```

```output
EndIPAddress                 : #.#.#.#
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/firewallRules/example-firewall-rule
Name                         : example-firewall-rule
ResourceGroupName            : example-resource-group
StartIPAddress               : #.#.#.#
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/firewallRules
```

Adds a firewall rule to an Azure Database for PostgreSQL flexible server. If subscription is not passed explicitly, it's taken from default context.
