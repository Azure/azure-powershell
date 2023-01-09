### Example 1: Get resource usages of an AzureCDN profile
```powershell
Get-AzCdnProfileResourceUsage -ResourceGroupName testps-rg-da16jm -ProfileName cdn001
```

```output
CurrentValue Limit ResourceType Unit
------------ ----- ------------ ----
0            25    endpoint     count
```
Get resource usages of an AzureCDN profile


