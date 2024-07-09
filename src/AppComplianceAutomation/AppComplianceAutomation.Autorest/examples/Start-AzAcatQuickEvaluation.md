### Example 1: Get resources' quick compliance results.
```powershell
Start-AzAcatQuickEvaluation -Resources @("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers/Microsoft.Compute/virtualMachines/testvm")
```

```output
EvaluationEndTime QuickAssessment ResourceId
----------------- --------------- ----------
                  {}              {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/testrg/providers…
```

Get resources' quick compliance results.
