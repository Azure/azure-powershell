### Example 1: Get the payload that needs to be passed in the request body for installing Dynatrace agent on a VM
```powershell
Get-AzDynatraceMonitorVMHostPayload -ResourceGroupName dyobrg -MonitorName dyob-pwsh01
```

```output
EnvironmentId IngestionKey
------------- ------------
ihx78752      dt0c01.C3A5JBXDZ4C3SCZDRBJ3D23I.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

This coammnd gets the payload that needs to be passed in the request body for installing Dynatrace agent on a VM.