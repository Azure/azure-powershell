---
external help file:
Module Name: Az.ApplicationInsights
online version: https://docs.microsoft.com/powershell/module/az.applicationinsights/new-azapplicationinsightswebtest
schema: 2.0.0
---

# New-AzApplicationInsightsWebTest

## SYNOPSIS
Creates or updates an Application Insights web test definition.

## SYNTAX

```
New-AzApplicationInsightsWebTest -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ConfigurationWebTest <String>] [-ContentValidationContentMatch <String>]
 [-ContentValidationIgnoreCase] [-ContentValidationPassIfTextFound] [-Description <String>] [-Enabled]
 [-Frequency <Int32>] [-Kind <WebTestKind>] [-PropertiesLocations <IWebTestGeolocation[]>]
 [-PropertiesWebTestName <String>] [-RequestBody <String>] [-RequestFollowRedirect]
 [-RequestHeader <IHeaderField[]>] [-RequestHttpVerb <String>] [-RequestParseDependentRequest]
 [-RequestUrl <String>] [-RetryEnabled] [-SyntheticMonitorId <String>] [-Tag <Hashtable>] [-Timeout <Int32>]
 [-ValidationRuleExpectedHttpStatusCode <Int32>] [-ValidationRuleIgnoreHttpsStatusCode]
 [-ValidationRuleSslCertRemainingLifetimeCheck <Int32>] [-ValidationRuleSslCheck]
 [-WebTestKind <WebTestKindEnum>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an Application Insights web test definition.

## EXAMPLES

### Example 1: Creates or updates an Application Insights standard web test
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

After testing, the parameter `WebTestKind` is required.
If you pass their values at the same time, `WebTestKind` will overwrite `Kind`.

So should we hide `Kind` and rename `WebTestKind` to `Kind` ?

```powershell
PS C:\\> New-AzApplicationInsightsWebTest -ResourceGroup lucas-rg-test -Name standardwebtestpwsh06 -Location 'westus2' `
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

## PARAMETERS

### -ConfigurationWebTest
The XML specification of a WebTest to run against an application.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentValidationContentMatch
Content to look for in the return of the WebTest.
Must not be null or empty.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentValidationIgnoreCase
When set, this value makes the ContentMatch validation case insensitive.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentValidationPassIfTextFound
When true, validation will pass if there is a match for the ContentMatch string.
If false, validation will fail if there is a match

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
User defined description for this WebTest.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Is the test actively being monitored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Frequency
Interval in seconds between test runs for this WebTest.
Default value is 300.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of WebTest that this web test watches.
Choices are ping and multistep.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.WebTestKind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Application Insights WebTest resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: WebTestName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesLocations
A list of where to physically run the tests from to give global coverage for accessibility of your application.
To construct, see NOTES section for PROPERTIESLOCATIONS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20180501Preview.IWebTestGeolocation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesWebTestName
User defined name if this WebTest.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestBody
Base64 encoded string body to send with this web test.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestFollowRedirect
Follow redirects for this web test.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestHeader
List of headers and their values to add to the WebTest call.
To construct, see NOTES section for REQUESTHEADER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20180501Preview.IHeaderField[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestHttpVerb
Http verb to use for this web test.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestParseDependentRequest
Parse Dependent request for this WebTest.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestUrl
Url location to test.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryEnabled
Allow for retries should this WebTest fail.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyntheticMonitorId
Unique ID of this WebTest.
This is typically the same value as the Name field.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeout
Seconds until this WebTest will timeout and fail.
Default value is 30.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationRuleExpectedHttpStatusCode
Validate that the WebTest returns the http status code provided.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationRuleIgnoreHttpsStatusCode
When set, validation will ignore the status code.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationRuleSslCertRemainingLifetimeCheck
A number of days to check still remain before the the existing SSL cert expires.
Value must be positive and the SSLCheck must be set to true.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationRuleSslCheck
Checks to see if the SSL cert is still valid.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebTestKind
The kind of web test this is, valid choices are ping, multistep, basic, and standard.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.WebTestKindEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20180501Preview.IWebTest

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PROPERTIESLOCATIONS <IWebTestGeolocation[]>: A list of where to physically run the tests from to give global coverage for accessibility of your application.
  - `[Location <String>]`: Location ID for the WebTest to run from.

REQUESTHEADER <IHeaderField[]>: List of headers and their values to add to the WebTest call.
  - `[Name <String>]`: The name of the header.
  - `[Value <String>]`: The value of the header.

## RELATED LINKS

