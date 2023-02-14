### Example 1: List the vm resources currently being monitored by the Elastic monitor resource
```powershell
<<<<<<< HEAD
Get-AzElasticVMHost -ResourceGroupName azure-elastic-test -Name elastic-pwsh02
```

```output
=======
PS C:\> Get-AzElasticVMHost -ResourceGroupName azure-elastic-test -Name elastic-pwsh02

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
VMResourceId
------------
/subscriptions/xxxxxx-xxxxx-xxxx-xxxxxx/resourceGroups/vidhi-rg/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS
```

This command lists the vm resources currently being monitored by the Elastic monitor resource.

