### Example 1: Get datastore secrets
```powershell
Get-AzMLWorkspaceDatastoreSecret  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name workspaceartifactstore
```

```output
SecretsType Key
----------- ---
AccountKey  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

Get datastore secrets.
