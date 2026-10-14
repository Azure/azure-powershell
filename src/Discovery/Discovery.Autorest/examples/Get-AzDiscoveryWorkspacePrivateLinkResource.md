### Example 1: List private link resources for a workspace
```powershell
Get-AzDiscoveryWorkspacePrivateLinkResource -ResourceGroupName "my-rg" -WorkspaceName "my-workspace"
```

```output
Name            GroupId
----            -------
workspace       workspace
```

Lists available private link resources for the specified workspace.
