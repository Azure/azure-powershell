### Example 1: Delete environment container version
```powershell
Remove-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandjobenv
```

```output
```

Delete environment container

### Example 2: Delete environment container by pipeline
```powershell
Get-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandjobenv | Remove-AzMLWorkspaceEnvironmentVersion
```

```output
```

Delete environment container by pipeline

