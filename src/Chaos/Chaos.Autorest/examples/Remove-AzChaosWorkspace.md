### Example 1: Delete a workspace
```powershell
Remove-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace
```

```output
```

Deletes the `contoso-workspace` workspace and every scenario, scenario configuration, and scenario run under it.

### Example 2: Delete a workspace and confirm the outcome
```powershell
Remove-AzChaosWorkspace -ResourceGroupName contoso-rg -Name contoso-workspace -PassThru
```

```output
True
```

Deletes the workspace and returns `$true` when the delete completes. Use `-PassThru` when you script the call and need to branch on the outcome.
