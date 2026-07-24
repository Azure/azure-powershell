### Example 1: Refresh recommendations for a workspace
```powershell
Update-AzChaosWorkspaceRecommendation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
```

Re-runs discovery and evaluation for the `contoso-workspace` workspace so that each catalog scenario gets a fresh recommendation status.

### Example 2: Refresh recommendations and return the result object
```powershell
Update-AzChaosWorkspaceRecommendation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -PassThru
```

```output
True
```

Refreshes recommendations and returns `$true` when the refresh completes. Use `-PassThru` when you script the call and need to branch on the outcome.
