### Example 1: Regenerates the primary or secondary connection strings for the given Relay namespace
```powershell
New-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-01 -RegenerateKey 'PrimaryKey'
```

```output
KeyName     PrimaryConnectionString
-------     -----------------------                                                                                                                          
authRule-01 Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
```

This cmdlet regenerates the primary or secondary connection strings for the given Relay namespace.

### Example 2: Regenerates the primary or secondary connection strings for the given Hybrid Connection
```powershell
New-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01  -Name authRule-01 -RegenerateKey 'PrimaryKey'
```

```output
KeyName     PrimaryConnectionString
-------     -----------------------                                                                                                                          
authRule-01 Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
```

This cmdlet regenerates the primary or secondary connection strings for the given Hybrid Connection.

### Example 3: Regenerates the primary or secondary connection strings for the given Wcf Relay
```powershell
New-AzRelayKey -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01  -Name authRule-01 -RegenerateKey 'PrimaryKey'
```

```output
KeyName     PrimaryConnectionString
-------     -----------------------                                                                                                                          
authRule-01 Endpoint=sb://namespace-pwsh01.servicebus.windows.net/;SharedAccessKeyName=authRule-01;SharedAccessKey=xxxxxxxxxxxxxxxxx
```

This cmdlet regenerates the primary or secondary connection strings for the given Wcf Relay.