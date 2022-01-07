### Example 1: Update an extension in a machine to a specific version
```powershell
PS C:\> $target = @{"Microsoft.Compute.CustomScriptExtension" = @{"targetVersion"="1.10.12"}}
PS C:\> Update-AzConnectedExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -ExtensionTarget $target

<None>
```
Update an extension in a machine to a specific version