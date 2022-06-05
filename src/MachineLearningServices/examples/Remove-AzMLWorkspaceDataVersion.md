### Example 1: Delete data version
```powershell
Remove-AzMLWorkspaceDataVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data -Version 2
```

```output
```

Delete data version

### Example 2: Delete data version by pipeline
```powershell
Get-AzMLWorkspaceDataVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name iris-data -Version 2 | Remove-AzMLWorkspaceDataVersion
```

```output
```

Delete data version by pipeline

