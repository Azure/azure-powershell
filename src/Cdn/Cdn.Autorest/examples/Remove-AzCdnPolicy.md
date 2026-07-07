### Example 1: Remove a CDN WAF policy
```powershell
Remove-AzCdnPolicy -ResourceGroupName testps-rg-da16jm -Name policy001
```

Removes the specified CDN WAF policy.

### Example 2: Remove a CDN WAF policy by identity
```powershell
Get-AzCdnPolicy -ResourceGroupName testps-rg-da16jm -Name policy001 | Remove-AzCdnPolicy
```

Removes the specified CDN WAF policy by identity.

