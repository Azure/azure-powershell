### Example 1: Read the latest workspace evaluation after refreshing recommendations
```powershell
Update-AzChaosWorkspaceRecommendation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
Get-AzChaosWorkspaceEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
Status    WorkspaceName
------    -------------
Succeeded contoso-workspace
```

Reads the latest terminal workspace evaluation record produced by `Update-AzChaosWorkspaceRecommendation`. Use this when a recommendation refresh has finished and you need to inspect the stored result again without starting a new evaluation.

### Example 2: Read the latest workspace evaluation after setup
```powershell
Initialize-AzChaosWorkspace -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace -Location eastus -Scope '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg'
Get-AzChaosWorkspaceEvaluation -ResourceGroupName contoso-rg -WorkspaceName contoso-workspace
```

```output
Status    WorkspaceName
------    -------------
Succeeded contoso-workspace
```

Reads the workspace evaluation record after `Initialize-AzChaosWorkspace` creates the workspace and runs its initial evaluation. Use this cmdlet to re-read the terminal result later instead of repeating setup or evaluation work.
