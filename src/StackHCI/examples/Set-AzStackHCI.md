### Example 1: 
```powershell
Set-AzStackHCI -EnableWSSubscription $true
```

```output
Result: Success
```

Invoking on one of the cluster node to enable Windows Server Subscription feature

### Example 2: 
```powershell
Set-AzStackHCI -ComputerName ClusterNode1 -DiagnosticLevel Basic
```

```output
Result: Success
```

Invoking from the management node to set the diagnostic level to Basic

