### Example 1: Get the primary and secondary connection strings for the given Relay namespace
```powershell
Get-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-01
```

```output
KeyName                   : authRule-01
PrimaryConnectionString   : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
PrimaryKey                : xxxxxxxxxxxxxxxxx
SecondaryConnectionString : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
SecondaryKey              : xxxxxxxxxxxxxxxxx
```

This cmdlet gets the primary and secondary connection strings for the given Relay namespace.

### Example 2: Get the primary and secondary connection strings for the given Hybrid Connection
```powershell
Get-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01  -Name authRule-01
```

```output
KeyName                   : authRule-01
PrimaryConnectionString   : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
PrimaryKey                : xxxxxxxxxxxxxxxxx
SecondaryConnectionString : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
SecondaryKey              : xxxxxxxxxxxxxxxxx
```

This cmdlet gets the primary and secondary connection strings for the given Hybrid Connection.

### Example 3: Get the primary and secondary connection strings for the given Wcf Relay
```powershell
Get-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01  -Name authRule-01 | Format-List
```

```output
KeyName                   : authRule-01
PrimaryConnectionString   : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
PrimaryKey                : xxxxxxxxxxxxxxxxx
SecondaryConnectionString : Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
SecondaryKey              : xxxxxxxxxxxxxxxxx
```

This cmdlet gets the primary and secondary connection strings for the given Wcf Relay.