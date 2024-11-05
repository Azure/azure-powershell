### Example 1: List Private Link Resources by Workspace
```powershell
Get-AzWvdPrivateLinkResource -ResourceGroupName ResourceGroupName -WorkspaceName workspaceName
```

```output
Name
----
feed
global
```

List the private link resources available for this workspace.

### Example 2: List Private Link Resources by Hostpool
```powershell
Get-AzWvdPrivateLinkResource -ResourceGroupName ResourceGroupName -HostPoolName hostpoolName
```

```output
Name
----
connection
```

List the private link resources available for this hostpool.