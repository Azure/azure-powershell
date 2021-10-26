### Example 1: Get RunCommand by name
```powershell
PS C:\> Get-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname -RunCommandName "first" -VMScaleSetName $vmssname

Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Get by runcommand name

### Example 2: Get RunCommand by Instance
```powershell
PS C:\> Get-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname  -VMScaleSetName $vmssname

Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Get RunCommand by Instance
