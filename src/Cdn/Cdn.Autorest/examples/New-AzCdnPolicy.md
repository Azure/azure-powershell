### Example 1: Create a CDN WAF policy
```powershell
New-AzCdnPolicy -ResourceGroupName testps-rg-da16jm -Name policy001 -Location Global -SkuName Standard_Microsoft -PolicySettingEnabledState Enabled -PolicySettingMode Prevention
```

Creates a CDN WAF policy in the specified resource group.

