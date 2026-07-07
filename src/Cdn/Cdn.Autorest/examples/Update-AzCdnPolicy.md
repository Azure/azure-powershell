### Example 1: Update CDN WAF policy tags
```powershell
Update-AzCdnPolicy -ResourceGroupName testps-rg-da16jm -Name policy001 -Tag @{ environment = "test" }
```

Updates tags on the specified CDN WAF policy.

### Example 2: Update CDN WAF policy tags by identity
```powershell
Get-AzCdnPolicy -ResourceGroupName testps-rg-da16jm -Name policy001 | Update-AzCdnPolicy -Tag @{ environment = "test" }
```

Updates tags on the specified CDN WAF policy by identity.

