### Example 1
```powershell
Remove-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName
```

Remove the WAF policy called $policyName in $resourceGroupName.

### Example 2
```powershell
Get-AzFrontDoorWafPolicy -ResourceGroupName $resourceGroupName | Remove-AzFrontDoorWafPolicy
```

Remove all WAF policy in $resourceGroupName.