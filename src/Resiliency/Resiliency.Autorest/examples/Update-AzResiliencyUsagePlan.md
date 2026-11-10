### Example 1: Update the tags of a usage plan
```powershell
Update-AzResiliencyUsagePlan -ResourceGroupName contoso-rg -Name contoso-usage-plan -Tag @{ env = "test"; owner = "sre" }
```

Updates the tags of an existing usage plan.
