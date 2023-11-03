### Example 1: Delete datastore by pipeline
```powershell
Remove-AzMLWorkspaceDatastore -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-demo -Name blobdatastore
```

```output
```

Delete datastore

### Example 2: Delete datastore by pipeline
```powershell
Get-AzMLWorkspaceDatastore -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-demo -Name blobdatastore | Remove-AzMLWorkspaceDatastore
```

```output
```

Delete datastore

