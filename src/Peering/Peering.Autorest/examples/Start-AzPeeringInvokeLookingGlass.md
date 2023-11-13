### Example 1: Invoke looking glass command
```powershell
Start-AzPeeringInvokeLookingGlass -Command Ping -DestinationIp 1.1.1.1 -SourceLocation Seattle -SourceType EdgeSite
```

```output
Command Output
------- ------
Ping    PING 1.1.1.1 (1.1.1.1): 56 data bytes…
```

Invoke the given looking glass command

