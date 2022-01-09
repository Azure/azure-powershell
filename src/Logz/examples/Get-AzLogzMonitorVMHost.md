### Example 1: List the compute resources currently being monitored by the monitor resource
```powershell
PS C:\> Get-AzLogzMonitorVMHost -ResourceGroupName logz-rg-test -Name pwsh-logz04

AgentVersion Id
------------ --
1.0          /SUBSCRIPTIONS/xxxx-xxxxxx-xx-xxxxxx/RESOURCEGROUPS/KOYTEST/PROVIDERS/MICROSOFT.COMPUTE/VIRTUALMACHINES/TEST-VM-1
```

This command lists the compute resources currently being monitored by the monitor resource.

