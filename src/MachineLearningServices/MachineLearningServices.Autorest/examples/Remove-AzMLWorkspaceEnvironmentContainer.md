### Example 1: Delete environment container
```powershell
Remove-AzMLWorkspaceEnvironmentContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name pwshenv01
```

```output
```

Delete environment container

### Example 2: Delete environment container by pipeline
```powershell
Get-AzMLWorkspaceEnvironmentContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name pwshenv01 | Remove-AzMLWorkspaceEnvironmentContainer 
```

```output
```

Delete environment container by pipeline
