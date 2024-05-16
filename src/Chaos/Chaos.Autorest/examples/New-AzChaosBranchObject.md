### Example 1: Create an in-memory object for Branch.
```powershell
$actionObj = New-AzChaosActionObject -Name "urn:csci:microsoft:virtualMachine:shutdown/1.0" -Type "continuous"
New-AzChaosBranchObject -Action $actionObj -Name "branch1"
```

```output
Action Name
------ ----
{{…    branch1
```

Create an in-memory object for Branch.