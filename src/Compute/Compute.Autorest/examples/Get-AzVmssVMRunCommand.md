### Example 1: Get RunCommand by name
```powershell
Get-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname -RunCommandName "first" -VMScaleSetName $vmssname
```

```output
Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Get by runcommand name

### Example 2: Get RunCommand by Instance
```powershell
Get-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname  -VMScaleSetName $vmssname
```

```output
Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Get RunCommand by Instance
