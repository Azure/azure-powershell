### Example 1: Update an extension in a machine to a specific version
```powershell
$target = @{"Microsoft.Compute.CustomScriptExtension" = @{"targetVersion"="1.10.12"}}
Update-AzConnectedExtension -ResourceGroupName "myResourceGroup" -MachineName "myMachine" -ExtensionTarget $target
```

```output
<None>
```

Update an extension in a machine to a specific version
