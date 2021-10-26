### Example 1: Remove Run Command
```powershell
PS C:\> Remove-AzVMRunCommand -ResourceGroupName $rgname -VMName $vmname -RunCommandName "firstruncommand"

```

Remove a Run Command by its Name