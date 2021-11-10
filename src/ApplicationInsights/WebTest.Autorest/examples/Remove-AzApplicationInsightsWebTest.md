### Example 1: Deletes an Application Insights web test
```powershell
PS C:\> Remove-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name standardwebtest01-lucasappinsights

```

This command deletes an Application Insights web test.

### Example 2: Deletes an Application Insights web test by pipeline
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name webtest01-lucasappinsights | Remove-AzApplicationInsightsWebTest

```

This command deletes an Application Insights web test by pipeline.

