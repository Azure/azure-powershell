### Example 1: Remove a stream analytics by name
```powershell
Remove-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test02

```
This command removes a stream analytics by name.
**Please stop all jobs of the stream analytics cluster before invoke Remove-AzStreamAnalyticsCluster.**

### Example 2: Remove a stream analytics by pipeline
```powershell
Get-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-m-test01 | Remove-AzStreamAnalyticsCluster

```

This command removes a stream analytics by pipeline.
**Please stop all jobs of the stream analytics cluster before invoke Remove-AzStreamAnalyticsCluster.**