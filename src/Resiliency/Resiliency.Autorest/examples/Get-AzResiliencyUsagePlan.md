### Example 1: List usage plans in the current subscription
```powershell
Get-AzResiliencyUsagePlan
```

Lists all resiliency usage plans in the current subscription.

### Example 2: List usage plans in a resource group
```powershell
Get-AzResiliencyUsagePlan -ResourceGroupName contoso-rg
```

Lists all resiliency usage plans in resource group `contoso-rg`.

### Example 3: Get a usage plan
```powershell
Get-AzResiliencyUsagePlan -ResourceGroupName contoso-rg -Name contoso-usage-plan
```

Gets usage plan `contoso-usage-plan`.
