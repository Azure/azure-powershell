### Example 1: Removes a WAF policy
```powershell
Remove-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName
```

Remove the WAF policy called $policyName in $resourceGroupName.

### Example 2: Removes all WAF policy
```powershell
Get-AzFrontDoorWafPolicy -ResourceGroupName $resourceGroupName | Remove-AzFrontDoorWafPolicy
```

Remove all WAF policy in $resourceGroupName.