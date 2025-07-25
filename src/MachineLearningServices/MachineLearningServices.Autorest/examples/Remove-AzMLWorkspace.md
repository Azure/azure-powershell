### Example 1: Deletes a machine learning workspace
```powershell
Remove-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-test01
```

Deletes a machine learning workspace

### Example 2: Deletes a machine learning workspace by pipeline
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-test01 | Remove-AzMLWorkspace
```

Deletes a machine learning workspace by pipeline

