### Example 1: Set pricing plan and daily data volume information for an application insights resource
```powershell
PS C:\> Set-AzApplicationInsightsPricingPlan -ResourceGroupName "testgroup" -Name "test" -PricingPlan "Basic" -DailyCapGB 400
```

Set the pricing plan to "Basic", set the daily data volume cap to 400GB per day and stop send notification when hit cap for resource "test" in resource group "testgroup"