### Example 1: Update the vm details that will be monitored by the Elastic monitor resource
```powershell
<<<<<<< HEAD
Update-AzElasticVMCollection -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 -OperationName Add -VMResourceId '/subscriptions/xxxxxxxx-xxxxx-xxxx-xxxx-xxxxxxxx/resourceGroups/VIDHI-RG/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS'
=======
PS C:\> Update-AzElasticVMCollection -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 -OperationName Add -VMResourceId '/subscriptions/xxxxxxxx-xxxxx-xxxx-xxxx-xxxxxxxx/resourceGroups/VIDHI-RG/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command updates the vm details that will be monitored by the Elastic monitor resource

### Example 2: Update the vm details that will be monitored by the Elastic monitor resource by pipeline
```powershell
<<<<<<< HEAD
Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 | Update-AzElasticVMCollection -OperationName Delete -VMResourceId '/subscriptions/xxxxxxxx-xxxxx-xxxx-xxxx-xxxxxxxx/resourceGroups/VIDHI-RG/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS'
=======
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02 | Update-AzElasticVMCollection -OperationName Delete -VMResourceId '/subscriptions/xxxxxxxx-xxxxx-xxxx-xxxx-xxxxxxxx/resourceGroups/VIDHI-RG/providers/Microsoft.Compute/virtualMachines/vidhi-linuxOS'

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This command updates the vm details that will be monitored by the Elastic monitor resource by pipeline.

