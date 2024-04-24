### Example 1: Get all lab plans in subscription.
```powershell
Get-AzLabServicesLabPlan
```

```output
Location      Name                          Type
--------      ----                          ----
westus2       plan1                         Microsoft.LabServices/labPlans
westus2       plan2                         Microsoft.LabServices/labPlans
westus2       plan3                         Microsoft.LabServices/labPlans
```
Returns all lab plans in a subscription.