### Example 1: Get the payload of NewRelic agent on a VM.
```powershell
Invoke-AzNewRelicHostMonitor -MonitorName test-03 -ResourceGroupName ps-test
```

```output
d2c8985ebb446c47775399c9cNRALba50cec4bdd
```

Returns the payload that needs to be passed in the request body for installing NewRelic agent on a VM.