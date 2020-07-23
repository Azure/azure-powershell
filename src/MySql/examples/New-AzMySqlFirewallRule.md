### Example 1: Create a new MySql server Firewall Rule
```powershell
PS C:\> New-AzMySqlFirewallRule -Name rule -ResourceGroupName PowershellMySqlTest -ServerName mysql-test -EndIPAddress 0.0.0.1 -StartIPAddress 0.0.0.0

Name Type
---- ----
rule Microsoft.DBforMySQL/servers/firewallRules
```

This cmdlets create a MySql server Firewall Rule.