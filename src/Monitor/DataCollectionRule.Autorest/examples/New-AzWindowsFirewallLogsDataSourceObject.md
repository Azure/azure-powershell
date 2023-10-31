### Example 1: Create windows firewall logs data source object
```powershell
New-AzWindowsFirewallLogsDataSourceObject -Stream "Microsoft-WindowsFirewall","Microsoft-ASimNetworkSessionLogs-WindowsFirewall" -Name "myFirewallLogsDataSource1"
```

```output
Name                      Stream
----                      ------
myFirewallLogsDataSource1 {Microsoft-WindowsFirewall, Microsoft-ASimNetworkSessionLogs-WindowsFirewall}
```

This command creates a windows firewall log data source object.
