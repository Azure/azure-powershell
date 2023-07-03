### Example 1: Get the payload of NewRelic agent on a VM.
```powershell
Invoke-AzNewRelicHostMonitor -MonitorName test-03 -ResourceGroupName ps-test
```

```output
ba50cec4bdd85ebb446c47775d2c89399c9cNRAL
```

Returns the payload that needs to be passed in the request body for installing NewRelic agent on a VM.