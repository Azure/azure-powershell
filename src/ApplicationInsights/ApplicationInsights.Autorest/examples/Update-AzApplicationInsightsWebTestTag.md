### Example 1: Updates Application Insights link of the Web test
[Update-AzApplicationInsightsWebTestTag API Swgger](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json#L189)
```powershell
Update-AzApplicationInsightsWebTestTag -ResourceGroupName azpwsh-rg-test -Name webtest01-lucasappinsights -Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/lucasappinsights" = "Resource"}
```
```output
Location Name                       WebTestKind   ResourceGroupName   Enabled
-------- ----                       -----------   -----------------   -------
westus2  webtest01-lucasappinsights standard      azpwsh-rg-test      True
```

This command updates Application Insights link of the Web test.

### Example 2: Updates Application Insights link of the Web test by pipeline
```powershell
Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -WebTestName webtest01-lucasappinsights | Update-AzApplicationInsightsWebTestTag -Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"}
```
```output
Location Name                       WebTestKind   ResourceGroupName     Enabled
-------- ----                       -----------   -----------------     -------
westus2  webtest01-lucasappinsights standard      azpwsh-rg-test        True
```

This command updates Application Insights link of the Web test by pipeline.

