---
external help file: Az.Carbon-help.xml
Module Name: Az.Carbon
online version: https://learn.microsoft.com/powershell/module/az.carbon/get-azcarbonemissionreport
schema: 2.0.0
---

# Get-AzCarbonEmissionReport

## SYNOPSIS
API for Carbon Emissions Reports

## SYNTAX

```
Get-AzCarbonEmissionReport -QueryParameter <IQueryFilter> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
API for Carbon Emissions Reports.
QueryParameter argument value can be one of the following:

| Name                                    | Description                                                       |
|-----------------------------------------|-------------------------------------------------------------------|
| ItemDetailsQueryFilterObject                  | Query Parameters for ItemDetailsReport                            |
| MonthlySummaryReportQueryFilterObject         | Query filter parameter to configure MonthlySummaryReport queries. |
| OverallSummaryReportQueryFilterObject         | Query filter parameter to configure OverallSummaryReport queries. |
| TopItemsMonthlySummaryReportQueryFilterObject | Query filter parameter to configure TopItemsMonthlySummaryReport queries. |
| TopItemsSummaryReportQueryFilterObject        | Query filter parameter to configure TopItemsSummaryReport queries. |

Create query filters using `New-AzCarbonItemDetailsQueryFilterObject`, `New-AzCarbonMonthlySummaryReportQueryFilterObject`, `New-AzCarbonOverallSummaryReportQueryFilterObject`, `New-AzCarbonTopItemsMonthlySummaryReportQueryFilterObject`, or `New-AzCarbonTopItemsSummaryReportQueryFilterObject` commands.

## EXAMPLES

### Example 1: Get Carbon Emission Overall Summary Report

```powershell
$queryFilter = New-AzCarbonOverallSummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000001')
Get-AzCarbonEmissionReport -queryParameter $queryFilter | ft -Wrap
```

```output
SkipToken SubscriptionAccessDecisionList Value
--------- ------------------------------ -----
                                         {{
                                           "dataType": "OverallSummaryData",
                                           "latestMonthEmissions": 39383.3366448505,
                                           "previousMonthEmissions": 40661.9872283036,
                                           "monthOverMonthEmissionsChangeRatio": -0.0314458458774745,
                                           "monthlyEmissionsChangeValue": -1278.65058345307
                                         }}
```

### Example 2: Get Carbon Emission Monthly Summary Report
```powershell
$queryFilter = New-AzCarbonMonthlySummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3')  -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
Get-AzCarbonEmissionReport -QueryParameter $queryFilter | ft -Wrap
```

```output
SkipToken SubscriptionAccessDecisionList Value
--------- ------------------------------ -----
                                         {{
                                           "dataType": "MonthlySummaryData",
                                           "latestMonthEmissions": 3525.67179020239,
                                           "previousMonthEmissions": 3593.48686516752,
                                           "monthOverMonthEmissionsChangeRatio": -0.0188716635150321,
                                           "monthlyEmissionsChangeValue": -67.815074965129,
                                           "date": "2024-03-01",
                                           "carbonIntensity": 0.0168623676945453
                                         }, {
                                           "dataType": "MonthlySummaryData",
                                           "latestMonthEmissions": 3589.80751350466,
                                           "previousMonthEmissions": 3525.67179020239,
                                           "monthOverMonthEmissionsChangeRatio": 0.0181910646023542,
                                           "monthlyEmissionsChangeValue": 64.1357233022695,
                                           "date": "2024-04-01",
                                           "carbonIntensity": 0.0178511992810588
                                         }, {
                                           "dataType": "MonthlySummaryData",
                                           "latestMonthEmissions": 3767.01931731306,
                                           "previousMonthEmissions": 3589.80751350466,
                                           "monthOverMonthEmissionsChangeRatio": 0.0493652662828696,
                                           "monthlyEmissionsChangeValue": 177.211803808404,
                                           "date": "2024-05-01",
                                           "carbonIntensity": 0.0169343176994967
                                         }, {
                                           "dataType": "MonthlySummaryData",
                                           "latestMonthEmissions": 3683.0046913582,
                                           "previousMonthEmissions": 3767.01931731306,
                                           "monthOverMonthEmissionsChangeRatio": -0.0223026798850581,
                                           "monthlyEmissionsChangeValue": -84.0146259548633,
                                           "date": "2024-06-01",
                                           "carbonIntensity": 0.0169734192025334
                                         }�}
```

### Example 3: Get Carbon Emission Monthly Summary Report and output results to a file
By default, PowerShell displays only 4 results in the response array. If you need to see more results, you can increase this limit by setting the `$FormatEnumerationLimit` variable to your desired value. To capture all the items, you can output the response to a file.


```powershell
$queryFilter = New-AzCarbonMonthlySummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3')  -DateRangeEnd 2025-03-01 -DateRangeStart 2024-03-01 -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
$FormatEnumerationLimit = 12
Get-AzCarbonEmissionReport -QueryParameter $queryFilter | ft -Wrap | Out-File -FilePath "output.txt"
```

### Example 4: Get Carbon Emission Item Details Report
```powershell
$queryFilter = New-AzCarbonItemDetailsQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -OrderBy 'ItemName' -PageSize 10 -SortDirection 'Desc' -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
Get-AzCarbonEmissionReport -QueryParameter $queryFilter | Format-List
```

```output
SkipToken                      : sPP822BrWq/7KLioRo//82ElzO3kjjNSWyI2QLd8tdhGJzTGiC5jStEEugcsjMhgF+HHqUYmbnlMIiXFfyF9tntszpYWBiKRrA3ZNBNcaSshz/8kljCf0shQiljs682ZYmhVpg1Z/3jND+AJyCncNi8UIrVg3IF2xT94kzqJ0wCJgoDSJhuHd
                                 xBp6iCjDjs/xFaJFG+2fQln/UaznXUG6RRRR+bM7s0MiewRD5TNdr7MC1zATr4K3K51bRB4eTOiMpvRU/HuoTVq01q4rlfjf6r1zyzbWpEOgWfrpAg6F4RG+jj30dAMm7j/OOSqLxNmBJ7GZCE3Kzqf2onkY1oM5g==|ZtP1kwM7nnaGteMqE
                                 ntW4QeBIDSKEKtiPEr0PQFc8XMi8pSVHFjmJU5dRsk0VkuTxATMKr63+2A5jxcGpAwqxNAE9wMH5ZXHI8ZNGw372rx+D8Bomoyn4C1cLOGfXVACE5gmmlDy61nvt8rUPi/YgFV5b35W1gcPBhtFwzVUaE7hLz0r/vMvnfPWaWLNrndobGx4A2
                                 TGzYyIC0djRfE+89FJL8jzBvra01PVv4yMkFP+jVq1bWR+D+0FGV8fmznm+7iMComFEG390NzKaAH8I6V9KrDsauvVMrgCT2TOuwEos2pC6UmZfuzfu+vpQoHWt2xKbUOugqoCoNuxgRjC2g==
SubscriptionAccessDecisionList :
Value                          : {
                                  "dataType": "ResourceItemDetailsData",
                                  "latestMonthEmissions": 0.1,
                                  "previousMonthEmissions": 0.05,
                                  "monthOverMonthEmissionsChangeRatio": 1,
                                  "monthlyEmissionsChangeValue": 0.05,
                                  "itemName": "rgName1",
                                  "resourceGroup": "rgGroup",
                                  "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName1",
                                  "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                  "categoryType": "Resource",
                                  "resourceType": "microsoft.storage/storageaccounts",
                                  "location": "east us"
                                },
                                {
                                  "dataType": "ResourceItemDetailsData",
                                  "latestMonthEmissions": 0.1,
                                  "previousMonthEmissions": 0.05,
                                  "monthOverMonthEmissionsChangeRatio": 1,
                                  "monthlyEmissionsChangeValue": 0.05,
                                  "itemName": "rgName2",
                                  "resourceGroup": "rgGroup",
                                  "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName2",
                                  "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                  "categoryType": "Resource",
                                  "resourceType": "microsoft.storage/storageaccounts",
                                  "location": "east us"
                                },
                                {
                                  "dataType": "ResourceItemDetailsData",
                                  "latestMonthEmissions": 0.1,
                                  "previousMonthEmissions": 0.05,
                                  "monthOverMonthEmissionsChangeRatio": 1,
                                  "monthlyEmissionsChangeValue": 0.05,
                                  "itemName": "rgName3",
                                  "resourceGroup": "rgGroup",
                                  "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName3",
                                  "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                  "categoryType": "Resource",
                                  "resourceType": "microsoft.storage/storageaccounts",
                                  "location": "east us"
                                },
                                {
                                  "dataType": "ResourceItemDetailsData",
                                  "latestMonthEmissions": 0.1,
                                  "previousMonthEmissions": 0.05,
                                  "monthOverMonthEmissionsChangeRatio": 1,
                                  "monthlyEmissionsChangeValue": 0.05,
                                  "itemName": "rgName4",
                                  "resourceGroup": "rgGroup",
                                  "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName4",
                                  "subscriptionId": "00000000-0000-0000-0000-000000000001",
                                  "categoryType": "Resource",
                                  "resourceType": "microsoft.storage/storageaccounts",
                                  "location": "east us"
                                }..}
```

### Example 5: Get Carbon Emission Item Details Report and output results to a file.
By default, PowerShell displays only 4 results in the response array. If you need to see more results, you can increase this limit by setting the `$FormatEnumerationLimit` variable to your desired value. To capture all the items, you can output the response to a file.


```powershell
$queryFilter = New-AzCarbonItemDetailsQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -OrderBy 'ItemName' -PageSize 100 -SortDirection 'Desc' -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
$FormatEnumerationLimit = 100
Get-AzCarbonEmissionReport -QueryParameter $queryFilter | Format-List | Out-File -FilePath "output.txt"
```

### Example 6: Get Carbon Emission Top Items Summary Report
```powershell
$queryFilter =  New-AzCarbonTopItemsSummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -TopItem 5 -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
$FormatEnumerationLimit = 10
Get-AzCarbonEmissionReport -queryParameter $queryFilter | ft -Wrap
```

```output
SkipToken SubscriptionAccessDecisionList Value
--------- ------------------------------ -----
                                         {
                                          "dataType": "ResourceTopItemsSummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName1",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName1",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsSummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName2",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName2",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsSummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName3",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName3",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsSummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName4",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName4",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000001",
                                          "categoryType": "Resource"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsSummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName5",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName5",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000001",
                                          "categoryType": "Resource"
                                        }...}
```

### Example 7: Get Carbon Emission Top Items Monthly Summary Report
```powershell
$queryFilter =  New-AzCarbonTopItemsMonthlySummaryReportQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -TopItem 5 -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
$FormatEnumerationLimit = 10
Get-AzCarbonEmissionReport -queryParameter $queryFilter | ft -Wrap
```

```output
SkipToken SubscriptionAccessDecisionList Value
--------- ------------------------------ -----
                                        {
                                          "dataType": "ResourceTopItemsMonthlySummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName1",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName1",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource",
                                          "date": "2024-05-01"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsMonthlySummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName1",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName1",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource",
                                          "date": "2024-04-01"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsMonthlySummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName1",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName1",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource",
                                          "date": "2024-03-01"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsMonthlySummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName2",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName2",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource",
                                          "date": "2024-05-01"
                                        },
                                        {
                                          "dataType": "ResourceTopItemsMonthlySummaryData",
                                          "latestMonthEmissions": 0.1,
                                          "previousMonthEmissions": 0.05,
                                          "monthOverMonthEmissionsChangeRatio": 1,
                                          "monthlyEmissionsChangeValue": 0.05,
                                          "itemName": "rgName2",
                                          "resourceGroup": "rgGroup",
                                          "resourceId": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgGroup/providers/microsoft.storage/storageaccounts/rgName2",
                                          "subscriptionId": "00000000-0000-0000-0000-000000000000",
                                          "categoryType": "Resource",
                                          "date": "2024-04-01"
                                        }...}
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -QueryParameter
Shared query filter parameter to configure carbon emissions data queries for all different report type defined in ReportTypeEnum.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Carbon.Models.IQueryFilter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Carbon.Models.IQueryFilter

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Carbon.Models.ICarbonEmissionDataListResult

## NOTES

## RELATED LINKS
