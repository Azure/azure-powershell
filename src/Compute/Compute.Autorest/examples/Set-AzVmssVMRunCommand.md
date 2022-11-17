### Example 1: Set RunCommand by name
```powershell
Set-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname -RunCommandName "first" -VMScaleSetName $vmssname
```

```output
Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Add RunCommand to an Instance of VMSS. 
