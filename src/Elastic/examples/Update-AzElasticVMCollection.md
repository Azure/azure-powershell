### Example 1: Update the VM details that will be monitored by the Elastic monitor resource
```powershell
Update-AzElasticVMCollection -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -OperationName Add -VMResourceId '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGroup01/providers/Microsoft.Compute/virtualMachines/LinuxVM01'
```

Update the VM details that will be monitored by the Elastic monitor resource.

### Example 2: Update the VM details that will be monitored by the Elastic monitor resource via JSON string
```powershell
$vmCollProps = @{
    vmResourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGroup01/providers/Microsoft.Compute/virtualMachines/LinuxVM01"
    operationName = "Add"
}
$vmCollPropsJson = ConvertTo-Json -InputObject $vmCollProps
Update-AzElasticVMCollection -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 -JsonString $vmCollPropsJson
```

Update the VM details that will be monitored by the Elastic monitor resource via JSON string.

### Example 3: Update the VM details that will be monitored by the Elastic monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | Update-AzElasticVMCollection -OperationName Delete -VMResourceId '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGroup01/providers/Microsoft.Compute/virtualMachines/LinuxVM01'
```

Update the VM details that will be monitored by the Elastic monitor resource via pipeline.
