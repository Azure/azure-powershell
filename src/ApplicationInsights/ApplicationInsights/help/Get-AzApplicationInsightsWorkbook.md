---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/get-azapplicationinsightsworkbook
schema: 2.0.0
---

# Get-AzApplicationInsightsWorkbook

## SYNOPSIS
Get a single workbook by its resourceName.

## SYNTAX

### List (Default)
```
Get-AzApplicationInsightsWorkbook [-SubscriptionId <String[]>] [-CanFetchContent] -Category <CategoryType>
 [-Tag <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzApplicationInsightsWorkbook -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-CanFetchContent] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzApplicationInsightsWorkbook -ResourceGroupName <String> [-SubscriptionId <String[]>] [-CanFetchContent]
 -Category <CategoryType> [-Tag <String[]>] [-LinkedSourceId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzApplicationInsightsWorkbook -InputObject <IApplicationInsightsIdentity> [-CanFetchContent]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a single workbook by its resourceName.

## EXAMPLES

### Example 1: List workbooks by category
```powershell
Get-AzApplicationInsightsWorkbook -Category 'workbook'
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test 7d195dcc-7d02-459f-a181-5b46662e4060 Workbook01                                   westus2  shared workbook
appinsights-hkrs2v-test c65b3461-9270-45b7-b6ad-ddd644458b0e                                              westus2  user   workbook
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 Workbook02-display                           westus2  user   workbook
appinsights-hkrs2v-test 842437e8-8ef1-4ce7-b1a7-4cebf6c10188 Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test aac4bf14-0f25-4ac3-a4d4-76c63bf7312e Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test 74446cb1-d125-4c1f-ab84-e57fd93101d2 Workbook03-display                           westus2  shared workbook
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user   workbook
appinsights-hkrs2v-test b41466f0-a464-4531-ab31-df6ba613d8fe b41466f0-a464-4531-ab31-df6ba613d8fe-display westus2  user   workbook
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

This command lists workbooks by category.

### Example 2: Get a single workbook by its resourceName
```powershell
Get-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name f7d7151e-7907-4f46-8a5e-6bf4a4cfedec
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workboo
```

This command get a single workbook by its resourceName.

### Example 3: Get a single workbook by pipeline
```powershell
$name = (New-Guid).ToString()
New-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name $name -Location westus2  -DisplayName "$name-display" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/components/appinsights-48mah3-pwsh" -Category 'workbook' -SerializedData $null | Get-AzApplicationInsightsWorkbook
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workboo
```

This command gets a single workbook by pipeline.

### Example 4: List all workbooks by resource group
```powershell
Get-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Category 'workbook'
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test 7d195dcc-7d02-459f-a181-5b46662e4060 Workbook01                                   westus2  shared workbook
appinsights-hkrs2v-test c65b3461-9270-45b7-b6ad-ddd644458b0e                                              westus2  user   workbook
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 Workbook02-display                           westus2  user   workbook
appinsights-hkrs2v-test 842437e8-8ef1-4ce7-b1a7-4cebf6c10188 Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test aac4bf14-0f25-4ac3-a4d4-76c63bf7312e Workbook03-display                           westus2  user   workbook
appinsights-hkrs2v-test 74446cb1-d125-4c1f-ab84-e57fd93101d2 Workbook03-display                           westus2  shared workbook
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user   workbook
appinsights-hkrs2v-test b41466f0-a464-4531-ab31-df6ba613d8fe b41466f0-a464-4531-ab31-df6ba613d8fe-display westus2  user   workbook
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

This command lists all workbooks by resource group.

## PARAMETERS

### -CanFetchContent
Flag indicating whether or not to return the full content for each applicable workbook.
If false, only return summary content for workbooks.

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

### -Category
Category of workbook to return.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Support.CategoryType
Parameter Sets: List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -LinkedSourceId
Azure Resource Id that will fetch all linked workbooks.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags presents on each workbook returned.

```yaml
Type: System.String[]
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220401.IWorkbook

## NOTES

## RELATED LINKS
