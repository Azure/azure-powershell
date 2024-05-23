### Example 1: List the compute resources currently being monitored by the monitor resource
```powershell
Get-AzLogzMonitorVMHost -ResourceGroupName logz-rg-test -Name pwsh-logz04
```

```output
AgentVersion Id
------------ --
1.0          /SUBSCRIPTIONS/xxxx-xxxxxx-xx-xxxxxx/RESOURCEGROUPS/KOYTEST/PROVIDERS/MICROSOFT.COMPUTE/VIRTUALMACHINES/TEST-VM-1
```

This command lists the compute resources currently being monitored by the monitor resource.

