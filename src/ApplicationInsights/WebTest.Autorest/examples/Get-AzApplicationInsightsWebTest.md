### Example 1: List all Application Insights web tests under a subscription
```powershell
PS C:\> Get-AzApplicationInsightsWebTest

Location Name                     Type                        Kind ResourceGroupName
-------- ----                     ----                        ---- -----------------
westus2  basictest-appinsighttest microsoft.insights/webtests      lucas-rg-test
```

This command lists all Application Insights web tests under a subscription.

### Example 2: List all Application Insights web tests under a resource group
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName lucas-rg-test

Location Name                     Type                        Kind ResourceGroupName
-------- ----                     ----                        ---- -----------------
westus2  basictest-appinsighttest microsoft.insights/webtests      lucas-rg-test
```

This command lists all Application Insights web tests under a resource group.

### Example 3: List all Application Insights web tests under a specific Application Insights
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName lucas-rg-test -ComponentName appinsighttest

Location Name                     Type                        Kind ResourceGroupName
-------- ----                     ----                        ---- -----------------
westus2  basictest-appinsighttest microsoft.insights/webtests      lucas-rg-test
```

This command lists all Application Insights web tests under a specific Application Insights.

### Example 4: Get a specific Application Insights web test definition
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName lucas-rg-test -Name basictest-appinsighttest

Location Name                     Type                        Kind ResourceGroupName
-------- ----                     ----                        ---- -----------------
westus2  basictest-appinsighttest microsoft.insights/webtests      lucas-rg-test
```

This command gets a specific Application Insights web test definition.

### Example 5: Get a specific Application Insights web test definition by pipeline
```powershell
PS C:\> New-AzApplicationInsightsWebTest -ResourceGroup lucas-rg-test -Name standardwebtestpwsh03 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"} `
-RequestUrl "https://www.bing.com" -RequestHttpVerb "GET" `
-PropertiesWebTestName 'standardwebtestpwsh03' `
-ValidationRuleSslCheck -ValidationRuleSslCertRemainingLifetimeCheck 7 -ValidationRuleExpectedHttpStatusCode 200 `
-Enabled -Frequency 300 -Timeout 120 -WebTestKind "standard" -RetryEnabled -PropertiesLocations $location01, $location02 ` |Get-AzApplicationInsightsWebTest

Location Name                     Type                        Kind ResourceGroupName
-------- ----                     ----                        ---- -----------------
westus2  standardwebtestpwsh03 microsoft.insights/webtests      lucas-rg-test
```

This command gets a specific Application Insights web test definition by pipeline.