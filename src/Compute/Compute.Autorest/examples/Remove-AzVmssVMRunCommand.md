### Example 1: Remove VMSS VM RunCommand
```powershell
Remove-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname -RunCommandName "first" -VMScaleSetName $vmssname
```

Remove VMSS VM RunCommand