### Example 1: Updates parameter tag of  the Application Insights web test
[Update-AzApplicationInsightsWebTestTag API Swgger](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json#L189)
```powershell
PS C:\> Update-AzApplicationInsightsWebTestTag -ResourceGroupName lucas-rg-test -Name webtest01-lucasappinsights -Tag @{"hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/lucasappinsights" = "Resource"}

Location Name                       WebTestKind   ResourceGroupName
-------- ----                       -----------   -----------------
westus2  webtest01-lucasappinsights standard      lucas-rg-test
```

This command updates parameter tag of  the Application Insights web test.

### Example 2: Updates parameter tag of  the Application Insights web test by pipeline
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName lucas-rg-test -WebTestName webtest01-lucasappinsights | Update-AzApplicationInsightsWebTestTag -Tag @{"hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"}

Location Name                       WebTestKind   ResourceGroupName
-------- ----                       -----------   -----------------
westus2  webtest01-lucasappinsights standard      lucas-rg-test
```

This command updates parameter tag of the Application Insights web test by pipeline.

