### Example 1: Simple Example
```powershell
PS C:\> Set-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -RunCommandName 'firstruncommand' 

Location Name             Type
-------- ----             ----
eastus   firstruncommand2 Microsoft.Compute/virtualMachines/runCommands
```

The Set-AzVMRunCommand cmdlet updates properties for existing run command or adds a new run command to a virtual machine.