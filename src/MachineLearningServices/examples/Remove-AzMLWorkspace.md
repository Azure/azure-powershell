### Example 1: Deletes a machine learning workspace
```powershell
Remove-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-test01 -Tag @{'key1' = 'value2'}
```

```output
```

Deletes a machine learning workspace

### Example 2: Deletes a machine learning workspace by pipeline
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-test01 | Remove-AzMLWorkspace -Tag @{'key1' = 'value2'}
```

```output
```

Deletes a machine learning workspace by pipeline
