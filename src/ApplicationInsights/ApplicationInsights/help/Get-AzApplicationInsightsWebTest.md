---
external help file:
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/get-azapplicationinsightswebtest
schema: 2.0.0
---

# Get-AzApplicationInsightsWebTest

## SYNOPSIS
Get a specific Application Insights web test definition.

## SYNTAX

### List1 (Default)
```
Get-AzApplicationInsightsWebTest [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzApplicationInsightsWebTest -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzApplicationInsightsWebTest -InputObject <IApplicationInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzApplicationInsightsWebTest -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzApplicationInsightsWebTest -AppInsightsName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a specific Application Insights web test definition.

## EXAMPLES

### Example 1: List all Application Insights web tests under a subscription
```powershell
Get-AzApplicationInsightsWebTest
```

```output
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
Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test
```

```output
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
Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -AppInsightsName appinsights-portal01
```

```output
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
Get-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name standard-pwsh01
```

```output
Name            Location WebTestKind ResourceGroupName  Enabled
----            -------- ----------- -----------------  -------
standard-pwsh01 westus2  standard    azpwsh-rg-test     True
```

This command gets a specific Application Insights web test definition.

### Example 5: Get a specific Application Insights web test definition by pipeline
```powershell
$location01 = New-AzApplicationInsightsWebTestGeolocationObject -Location "emea-nl-ams-azr"
$location02 = New-AzApplicationInsightsWebTestGeolocationObject -Location "us-ca-sjc-azr"
New-AzApplicationInsightsWebTest -ResourceGroupName azpwsh-rg-test -Name standardwebtestpwsh03 -Location 'westus2' `
-Tag @{"hidden-link:/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/azpwsh-rg-test/providers/microsoft.insights/components/appinsightsportal01" = "Resource"} `
-RequestUrl "https://learn.microsoft.com/" -RequestHttpVerb "GET" `
-TestName 'standardwebtestpwsh03' `
-RuleSslCheck -RuleSslCertRemainingLifetimeCheck 7 -RuleExpectedHttpStatusCode 200 `
-Enabled -Frequency 300 -Timeout 120 -Kind "standard" -RetryEnabled -GeoLocation $location01, $location02 ` |Get-AzApplicationInsightsWebTest
```

```output
Name                    Location WebTestKind ResourceGroupName  Enabled
----                    -------- ----------- -----------------  -------
standardwebtestpwsh03   westus2  standard    azpwsh-rg-test     True
```

This command gets a specific Application Insights web test definition by pipeline.

## PARAMETERS

### -AppInsightsName
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: True
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Application Insights WebTest resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WebTestName

Required: True
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
Parameter Sets: Get, List, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1, List2
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220615.IWebTest

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IApplicationInsightsIdentity>`: Identity Parameter
  - `[AnnotationId <String>]`: The unique annotation ID. This is unique within a Application Insights component.
  - `[ComponentName <String>]`: The name of the Application Insights component resource.
  - `[ExportId <String>]`: The Continuous Export configuration ID. This is unique within a Application Insights component.
  - `[Id <String>]`: Resource identity path
  - `[KeyId <String>]`: The API Key ID. This is unique within a Application Insights component.
  - `[PurgeId <String>]`: In a purge status request, this is the Id of the operation the status of which is returned.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the Application Insights component resource.
  - `[RevisionId <String>]`: The id of the workbook's revision.
  - `[StorageType <StorageType?>]`: The type of the Application Insights component data source for the linked storage account.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WebTestName <String>]`: The name of the Application Insights WebTest resource.

## RELATED LINKS

