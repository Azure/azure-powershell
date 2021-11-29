### Example 1: List all Application Insights web tests under a subscription
```powershell
PS C:\> Get-AzApplicationInsightsWebTest

Name                                 Location WebTestKind ResourceGroupName
----                                 -------- ----------- -----------------
bsaic-portal-appinsights-portal01    westus2  ping        azpwsh-rg-test
basic-portal02-appinsights-portal01  westus2  ping        azpwsh-rg-test
basic-portal03-appinsights-portal01  westus2  ping        azpwsh-rg-test
standard-portal-appinsights-portal01 westus2  standard    azpwsh-rg-test
standard-pwsh01                      westus2  standard    azpwsh-rg-test
```

This command lists all Application Insights web tests under a subscription.

### Example 2: List all Application Insights web tests under a resource group
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test

Name                                 Location WebTestKind ResourceGroupName
----                                 -------- ----------- -----------------
bsaic-portal-appinsights-portal01    westus2  ping        azpwsh-rg-test
basic-portal02-appinsights-portal01  westus2  ping        azpwsh-rg-test
basic-portal03-appinsights-portal01  westus2  ping        azpwsh-rg-test
standard-portal-appinsights-portal01 westus2  standard    azpwsh-rg-test
standard-pwsh01                      westus2  standard    azpwsh-rg-test
```

This command lists all Application Insights web tests under a resource group.

### Example 3: List all Application Insights web tests under a specific Application Insights
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -AppInsightsName appinsights-portal01

Name                                 Location WebTestKind ResourceGroupName   Enabled
----                                 -------- ----------- -----------------   -------
bsaic-portal-appinsights-portal01    westus2  ping        azpwsh-rg-test      True
basic-portal02-appinsights-portal01  westus2  ping        azpwsh-rg-test      True  
basic-portal03-appinsights-portal01  westus2  ping        azpwsh-rg-test      True
standard-portal-appinsights-portal01 westus2  standard    azpwsh-rg-test      True
standard-pwsh01                      westus2  standard    azpwsh-rg-test      True
```

This command lists all Application Insights web tests under a specific Application Insights.

### Example 4: Get a specific Application Insights web test definition
```powershell
PS C:\> Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name standard-pwsh01

Name            Location WebTestKind ResourceGroupName  Enabled
----            -------- ----------- -----------------  -------
standard-pwsh01 westus2  standard    azpwsh-rg-test     True
```

This command gets a specific Application Insights web test definition.

### Example 5: Get a specific Application Insights web test definition by pipeline
```powershell
PS C:\> $location01 = New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
PS C:\> $location02 = New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
PS C:\> New-AzApplicationInsightsWebTest -ResourceGroup azpwsh-rg-test -Name standardwebtestpwsh03 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"} `
-RequestUrl "https://docs.microsoft.com/"  -RequestHttpVerb "GET" `
-NameInAppInsights 'standardwebtestpwsh03' `
-RuleSslCheck -RuleSslCertRemainingLifetimeCheck 7 -RuleExpectedHttpStatusCode 200 `
-Enabled -Frequency 300 -Timeout 120 -WebTestKind "standard" -RetryEnabled -GeoLocations $location01, $location02 ` |Get-AzApplicationInsightsWebTest

Name                    Location WebTestKind ResourceGroupName  Enabled
----                    -------- ----------- -----------------  -------
standardwebtestpwsh03   westus2  standard    azpwsh-rg-test     True
```

This command gets a specific Application Insights web test definition by pipeline.