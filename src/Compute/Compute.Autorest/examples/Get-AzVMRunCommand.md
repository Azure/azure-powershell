### Example 1: Get Run Command by Name
```powershell
PS C:\>  Get-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -RunCommandName "firstruncommand2"

Location Name             Type
-------- ----             ----
eastus   firstruncommand2 Microsoft.Compute/virtualMachines/runCommands
```

Get Run Command by it's name.

### Example 2: Get Run Commands by VM
```powershell
PS C:\> Get-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname  

Location Name             Type
-------- ----             ----
eastus   firstruncommand  Microsoft.Compute/virtualMachines/runCommands
eastus   firstruncommand2 Microsoft.Compute/virtualMachines/runCommands
eastus   firstruncommand3 Microsoft.Compute/virtualMachines/runCommands
```

Get Run Commands by VM name
