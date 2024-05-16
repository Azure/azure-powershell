### Example 1: Creates or updates a standard kind of the Application Insights web test
```powershell
$geoLocation = @()
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
New-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name standard-pwsh01 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsights-portal01" = "Resource"} `
-RequestUrl "https://www.bing.com" -RequestHttpVerb "GET" -TestName 'standard-pwsh01' `
-RuleExpectedHttpStatusCode 200 -Frequency 300 -Enabled -Timeout 120 -Kind 'standard' -RetryEnabled -GeoLocation $geoLocation
```

```output
Name            Location WebTestKind ResourceGroupName  Enabled
----            -------- ----------- -----------------  -------
standard-pwsh01 westus2  standard    azpwsh-rg-test     True
```

This command creates or updates an standard kind of the Application Insights web test.

We enter hidden-link in the `Tag` parameter to associate WebTest and Application Insights.

### Example 2: Creates or updates a standard kind of the Application Insights web test in disabled state
```powershell
$geoLocation = @()
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
New-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name standard-pwsh01 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsights-portal01" = "Resource"} `
-RequestUrl "https://www.bing.com" -RequestHttpVerb "GET" -TestName 'standard-pwsh01' `
-RuleExpectedHttpStatusCode 200 -Frequency 300 -Enabled:$false -Timeout 120 -Kind 'standard' -RetryEnabled -GeoLocation $geoLocation
```

```output
Name            Location WebTestKind ResourceGroupName  Enabled
----            -------- ----------- -----------------  -------
standard-pwsh01 westus2  standard    azpwsh-rg-test     False
```

This command creates or updates a standard kind of the Application Insights web test in disabled state.

The switch parameter "-Enabled" must be set explicitly to $false to disable the test.

### Example 3: Creates or updates a ping kind of the Application Insights web test
```powershell
$geoLocation = @()
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
New-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name 'pingwebtest-pwsh01' -TestName 'pingwentest-pwsh01testname' -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsights-portal01" = "Resource"} `
-GeoLocation $geoLocation -RetryEnabled -Enabled -Frequency 300 -Timeout 90 `
-Kind 'ping' -RequestUrl 'https://cn.bing.com' -RequestParseDependent -RuleExpectedHttpStatusCode 200 `
-ContentMatch "status"
```

```output
Name               Location WebTestKind ResourceGroupName   Enabled
----               -------- ----------- -----------------   -------
pingwebtest-pwsh01 westus2  ping        azpwsh-rg-test      True
```

This command creates or updates an ping kind of the Application Insights web test.

### Example 4: Creates or updates a ping kind of the Application Insights web test with custom configuration
```powershell
$geoLocation = @()
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
$geoLocation += New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
New-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name 'pingwebtest-pwsh01' -TestName 'pingwentest-pwsh01testname' -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsights-portal01" = "Resource"} `
-GeoLocation $geoLocation -RetryEnabled -Enabled -Frequency 300 -Timeout 90 `
-Kind 'ping' `
-Configuration "<WebTest  Name=`"basic-portal03`"  Id=`"9407db10-5d84-487f-98a3-a1ee67bb98f0`"  Enabled=`"True`"  CssProjectStructure=`"`"  CssIteration=`"`"  Timeout=`"90`"  WorkItemIds=`"`"  xmlns=`"http://microsoft.com/schemas/VisualStudio/TeamTest/2010`"  Description=`"`"  CredentialUserName=`"`"  CredentialPassword=`"`"  PreAuthenticate=`"True`"  Proxy=`"default`"  StopOnError=`"False`"  RecordedResultFile=`"`"  ResultsLocale=`"`">
    <Items>
        <Request Method=`"GET`"  Guid=`"a2025e53-0702-d03e-f311-5774ec16893d`"  Version=`"1.1`"  Url=`"https://www.bing.com`"  ThinkTime=`"0`"  Timeout=`"90`"  ParseDependentRequests=`"True`"  FollowRedirects=`"True`"  RecordResult=`"True`"  Cache=`"False`"  ResponseTimeGoal=`"0`"  Encoding=`"utf-8`"  ExpectedHttpStatusCode=`"200`"  ExpectedResponseUrl=`"`"  ReportingName=`"`"  IgnoreHttpStatusCode=`"False`" />
    </Items>
    <ValidationRules>
        <ValidationRule  Classname=`"Microsoft.VisualStudio.TestTools.WebTesting.Rules.ValidationRuleFindText, Microsoft.VisualStudio.QualityTools.WebTestFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`"  DisplayName=`"Find Text`"  Description=`"Verifies the existence of the specified text in the response.`"  Level=`"High`"  ExectuionOrder=`"BeforeDependents`">
            <RuleParameters>
            <RuleParameter Name=`"FindText`" Value=`"test&#x20;content&#x20;match`" />
            <RuleParameter Name=`"IgnoreCase`" Value=`"False`" />
            <RuleParameter Name=`"UseRegularExpression`" Value=`"False`" />
            <RuleParameter Name=`"PassIfTextFound`" Value=`"True`" />
            </RuleParameters>
        </ValidationRule>
    </ValidationRules>
</WebTest>"
```
```output
Name               Location WebTestKind ResourceGroupName   Enabled
----               -------- ----------- -----------------   -------
pingwebtest-pwsh01 westus2  ping        azpwsh-rg-test      True
```

This command creates or updates an ping kind of the Application Insights web test with custom configuration.
