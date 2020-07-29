### Example 1: Create a new MySql server Firewall Rule
```powershell
PS C:\> New-AzMySqlFirewallRule -Name rule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0

Name Type
---- ----
rule Microsoft.DBforMySQL/servers/firewallRules
```

This cmdlets create a MySql server Firewall Rule.

### Example 2: Create a new MySql Firewall Rule use only one parameter StartIPAddress when only one IP needs to be authorized
```powershell
PS C:\> New-AzMySqlFirewallRule -Name rule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -StartIPAddress 0.0.0.1

Name Type
---- ----
rule Microsoft.DBforMySQL/servers/firewallRules
```

This cmdlets create a MySql Firewall Rule use only one parameter StartIPAddress when only one IP needs to be authorized.