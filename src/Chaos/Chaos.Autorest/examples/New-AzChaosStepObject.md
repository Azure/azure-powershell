### Example 1: Create an in-memory object for Step.
```powershell
$branchObj = New-AzChaosBranchObject -Action $actionObj -Name "branch1"
New-AzChaosStepObject -Branch $branchObj -Name "step1"
```

```output
Branch Name
------ ----
{{…    step1
```

Create an in-memory object for Step.