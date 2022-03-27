### Example 1: List the vm resources currently being monitored by the Elastic monitor resource
```powershell
Get-AzElasticVMHost -ResourceGroupName azure-elastic-test -Name elastic-pwsh02
```

```output
VMResourceId
------------
/subscriptions/xxxxxx-xxxxx-xxxx-xxxxxx/resourceGroups/vidhi-rg/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS
```

This command lists the vm resources currently being monitored by the Elastic monitor resource.

