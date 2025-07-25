### Example 1: Update scheduled query rule
```powershell
$subscriptionId=(Get-AzContext).Subscription.Id
Update-AzScheduledQueryRule -Name test-rule -ResourceGroupName test-group -Scope "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachines/test-vm" -ActionGroupResourceId "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/microsoft.insights/actionGroups/test-action-group" -AutoMitigate:$false
```

Update scheduled query rule