### Example 1: Refresh recommendations for a workspace
```powershell
Update-AzChaosWorkspaceRecommendation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
```

Re-runs discovery and evaluation for the `contoso-workspace` workspace so that each catalog scenario gets a fresh recommendation status. The service stores a terminal workspace evaluation record that you can read later with `Get-AzChaosWorkspaceEvaluation`.

### Example 2: Refresh recommendations and inspect the evaluation result
```powershell
$evaluation = Update-AzChaosWorkspaceRecommendation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
$evaluation | Format-List Status, NumScenariosToEvaluate, NumScenariosEvaluatedSucceeded, NumScenariosEvaluatedFailed
```

```output
Status                        : Succeeded
NumScenariosToEvaluate        : 12
NumScenariosEvaluatedSucceeded : 12
NumScenariosEvaluatedFailed   : 0
```

Captures the workspace evaluation record the refresh produces and reports how many catalog scenarios were evaluated. The command returns an evaluation object, not a boolean, so branch on `Status` rather than on the object itself. Use `Get-AzChaosWorkspaceEvaluation` to re-read the same record later without triggering another refresh.
