### Example 1: Resync all the keys associated with this workspace. This includes keys for the storage account, app insights and password for container registry
```powershell
Sync-AzMLWorkspaceKey -ResourceGroupName ml-rg-test -Name mlworkspace-test01
```

```output
```

Resync all the keys associated with this workspace. This includes keys for the storage account, app insights and password for

### Example 2: Resync all the keys associated with this workspace  by pipeline
```powershell
Get-AzMLWorkspaceKey -ResourceGroupName ml-rg-test -Name mlworkspace-test01 | Sync-AzMLWorkspaceKey
```

```output
```

Resync all the keys associated with this workspace by pipeline

