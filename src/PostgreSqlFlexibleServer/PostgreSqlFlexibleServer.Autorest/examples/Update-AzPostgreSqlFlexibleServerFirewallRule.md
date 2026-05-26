### Example 1: Update a firewall rule in a flexible server
```powershell
<<<<<<< HEAD
Update-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroupName example-resource-group -ServerName example-server -Name example-firewall-rule -StartIPAddres #.#.#.# -EndIPAddress #.#.#.#
=======
Update-Update-AzPostgreSqlFlexibleServerFirewallRule -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -Name example-firewall-rule -StartIPAddres #.#.#.# -EndIPAddress #.#.#.#
>>>>>>> 15f018d78f3a5ebd1cabcfc830b54ee117a67146
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

Updates one firewall rule in an Azure Database for PostgreSQL flexible server with firewall rule name, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
