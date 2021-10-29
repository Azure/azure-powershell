### Example 1: Creates or updates an Application Insights standard web test
[New-AzApplicationInsightsWebTest API Swagger](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json#L140)
```powershell
PS C:\> $location01 = New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
PS C:\> $location02 = New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
PS C:\> New-AzApplicationInsightsWebTest -ResourceGroup lucas-rg-test -Name standardwebtestpwsh03 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"} `
-RequestUrl "https://www.bing.com" -RequestHttpVerb "GET" `
-PropertiesWebTestName 'standardwebtestpwsh03' `
-ValidationRuleSslCheck -ValidationRuleSslCertRemainingLifetimeCheck 7 -ValidationRuleExpectedHttpStatusCode 200 `
-Enabled -Frequency 300 -Timeout 120 -WebTestKind "standard" -RetryEnabled -PropertiesLocations $location01, $location02

Location Name                  Type                        Kind ResourceGroupName
-------- ----                  ----                        ---- -----------------
westus2  standardwebtestpwsh03 microsoft.insights/webtests      lucas-rg-test
```

**issue01: Parameter `Name`， `PropertiesWebTestName` and `SyntheticMonitorId`(should be hide)**

The parameter `Name` define how display the name in the azure portal and The parameter `PropertiesWebTestName` define how to display the name in the app insights.

The default value of the parameter `SyntheticMonitorId` is equal to the passed value of `Name`.

How to rename the `Name` parameter and `PropertiesWebTestName`?

![img01](https://raw.githubusercontent.com/FL-LearningGroup/LucasNote/main/works/azure/imgs/test-azure-appinsights-webtest-how%20to%20dislay%20the%20name%20in%20the%20azure%20portal-01.png)
![img02](https://raw.githubusercontent.com/FL-LearningGroup/LucasNote/main/works/azure/imgs/test-azure-appinsights-webtest-how%20to%20dislay%20the%20name%20in%20the%20azure%20portal-02.png)

**issue02: Parameter [Kind](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json#L405) and [WebTestKind](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/applicationinsights/resource-manager/Microsoft.Insights/preview/2018-05-01-preview/webTests_API.json#L463)**

After testing, the parameter `WebTestKind` is required. If you pass their values at the same time, `WebTestKind` will overwrite `Kind`.

So should we hide `Kind` and rename `WebTestKind` to `Kind` ?

```powershell
PS C:\> New-AzApplicationInsightsWebTest -ResourceGroup lucas-rg-test -Name standardwebtestpwsh06 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"} `
-RequestUrl "https://www.bing.com" -RequestHttpVerb "GET" `
-PropertiesWebTestName 'standardwebtestpwshinproperty' -SyntheticMonitorId 'monitorid-test02' `
-ValidationRuleSslCheck -ValidationRuleSslCertRemainingLifetimeCheck 7 -ValidationRuleExpectedHttpStatusCode 200 `
-Enabled -Frequency 300 -Timeout 120 -WebTestKind "standard" -RetryEnabled -PropertiesLocations $location01, $location02 `
-Debug `
-Kind 'ping'

Location Name                  Type                        Kind ResourceGroupName
-------- ----                  ----                        ---- -----------------
westus2  standardwebtestpwsh08 microsoft.insights/webtests ping lucas-rg-test
```
```json
{
  "req": {
      "location": "westus2",
      "tags": {
        "hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01": "Resource"
      },
      "properties": {
        "Request": {
          "RequestUrl": "https://www.bing.com",
          "HttpVerb": "GET"
        },
        "ValidationRules": {
          "SSLCheck": true,
          "SSLCertRemainingLifetimeCheck": 7,
          "ExpectedHttpStatusCode": 200
        },
        "SyntheticMonitorId": "standardwebtestpwsh06",
        "Name": "standardwebtestpwshinproperty",
        "Enabled": true,
        "Frequency": 300,
        "Timeout": 120,
        "Kind": "standard",
        "RetryEnabled": true,
        "Locations": [
          {
            "Id": "emea-nl-ams-azr"
          },
          {
            "Id": "us-ca-sjc-azr"
          }
        ]
      },
      "kind": "ping"
    }
  },
  "res": {
    "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/webtests/standardwebtestpwsh08",
    "name": "standardwebtestpwsh08",
    "type": "microsoft.insights/webtests",
    "location": "westus2",
    "tags": {
      "hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01": "Resource"
    },
    "kind": "ping",
    "etag": "\"0a007f22-0000-0600-0000-617bacfa0000\"",
    "properties": {
      "SyntheticMonitorId": "standardwebtestpwsh08",
      "Name": "standardwebtestpwsh03",
      "Description": null,
      "Enabled": true,
      "Frequency": 300,
      "Timeout": 120,
      "Kind": "standard",
      "RetryEnabled": true,
      "Locations": [
        {
          "Id": "emea-nl-ams-azr"
        },
        {
          "Id": "us-ca-sjc-azr"
        }
      ],
      "Configuration": null,
      "Request": {
        "RequestUrl": "https://www.bing.com",
        "Headers": null,
        "HttpVerb": "GET",
        "RequestBody": null,
        "ParseDependentRequests": null,
        "FollowRedirects": null
      },
      "ValidationRules": {
        "ExpectedHttpStatusCode": 200,
        "IgnoreHttpStatusCode": null,
        "ContentValidation": null,
        "SSLCheck": true,
        "SSLCertRemainingLifetimeCheck": 7
      },
      "provisioningState": "Succeeded"
    }
  }
```

This command creates or updates an Application Insights standard web test.

### Example 2: Creates or updates an Application Insights basic web test
```powershell
PS C:\> New-AzApplicationInsightsWebTest -ResourceGroup lucas-rg-test -Name basicwebtestpwsh01 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"} `
-ConfigurationWebTest "<WebTest Name=`"webtest01`"         Id=`"6026d348-bd2e-4275-9390-1dd597c8f7b8`"         Enabled=`"True`"         CssProjectStructure=`"`"         CssIteration=`"`"         Timeout=`"120`"         WorkItemIds=`"`"         xmlns=`"http://microsoft.com/schemas/VisualStudio/TeamTest/2010`"         Description=`"`"         CredentialUserName=`"`"         CredentialPassword=`"`"         PreAuthenticate=`"True`"         Proxy=`"default`"         StopOnError=`"False`"         RecordedResultFile=`"`"         ResultsLocale=`"`">        <Items>        <Request         Method=`"GET`"         Guid=`"ab304356-4ce0-2fa3-439d-e3bd940b729c`"         Version=`"1.1`"         Url=`"https://www.bing.com`"         ThinkTime=`"0`"         Timeout=`"120`"         ParseDependentRequests=`"False`"         FollowRedirects=`"True`"         RecordResult=`"True`"         Cache=`"False`"         ResponseTimeGoal=`"0`"         Encoding=`"utf-8`"         ExpectedHttpStatusCode=`"200`"         ExpectedResponseUrl=`"`"         ReportingName=`"`"         IgnoreHttpStatusCode=`"False`" />        </Items>        </WebTest>" `
-PropertiesWebTestName 'basicwebtestpwsh01' `
-Enabled -Frequency 300 -Timeout 120 -WebTestKind "ping" -RetryEnabled -PropertiesLocations $location01, $location02

Location Name               Type                        Kind ResourceGroupName
-------- ----               ----                        ---- -----------------
westus2  basicwebtestpwsh01 microsoft.insights/webtests      lucas-rg-test
```

This command creates or updates an Application Insights basic web test.
