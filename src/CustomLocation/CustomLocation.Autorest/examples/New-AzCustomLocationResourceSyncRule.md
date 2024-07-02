### Example 1: Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group.
```powershell
$MatchExpressions = New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
New-AzCustomLocationResourceSyncRule -Name azps-resourcesyncrule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Location eastus -Priority 999 -SelectorMatchExpression $MatchExpressions -SelectorMatchLabel @{"Key1"="Value1"} -TargetResourceGroup "/subscriptions/{subId}/resourceGroups/azps_test_cluster"
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

Create a Resource Sync Rule in the parent Custom Location, Subscription Id and Resource Group.