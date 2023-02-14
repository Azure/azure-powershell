### Example 1: List the compute resources currently being monitored by the monitor resource
```powershell
<<<<<<< HEAD
Get-AzLogzMonitorVMHost -ResourceGroupName logz-rg-test -Name pwsh-logz04
```

```output
=======
PS C:\> Get-AzLogzMonitorVMHost -ResourceGroupName logz-rg-test -Name pwsh-logz04

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
AgentVersion Id
------------ --
1.0          /SUBSCRIPTIONS/xxxx-xxxxxx-xx-xxxxxx/RESOURCEGROUPS/KOYTEST/PROVIDERS/MICROSOFT.COMPUTE/VIRTUALMACHINES/TEST-VM-1
```

This command lists the compute resources currently being monitored by the monitor resource.

