### Example 1: Simple Example
```powershell
Set-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -Location $location -RunCommandName 'firstruncommand' 

Location Name             Type
-------- ----             ----
eastus   firstruncommand Microsoft.Compute/virtualMachines/runCommands
```

The Set-AzVMRunCommand cmdlet updates properties for existing run command or adds a new run command to a virtual machine.
