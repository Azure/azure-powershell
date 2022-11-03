---
external help file:
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/get-azapplicationinsightsmyworkbook
schema: 2.0.0
---

# Get-AzApplicationInsightsMyWorkbook

## SYNOPSIS
Get a single private workbook by its resourceName.

## SYNTAX

### List1 (Default)
```
Get-AzApplicationInsightsMyWorkbook -Category <CategoryType> [-SubscriptionId <String[]>] [-CanFetchContent]
 [-Tag <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzApplicationInsightsMyWorkbook -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzApplicationInsightsMyWorkbook -InputObject <IApplicationInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzApplicationInsightsMyWorkbook -ResourceGroupName <String> -Category <CategoryType>
 [-SubscriptionId <String[]>] [-CanFetchContent] [-LinkedSourceId <String>] [-Tag <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a single private workbook by its resourceName.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
Get-AzApplicationInsightsMyWorkbook -Category 'workbook'
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
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzApplicationInsightsMyWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name 5df8625f-fae4-4a38-9f43-62a40a2e99d1
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind Category
-----------------       ----                                 -----------                                  -------- ---- --------
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user workbook
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
$name = (New-Guid).ToString()
New-AzApplicationInsightsMyWorkbook -ResourceGroupName $env.resourceGroup -Name $name -Location westus2  -DisplayName "$name-display" -SourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/components/appinsights-48mah3-pwsh" -Category 'workbook' -SerializedData $null | Get-AzApplicationInsightsMyWorkbook
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind Category
-----------------       ----                                 -----------                                  -------- ---- --------
appinsights-hkrs2v-test 5df8625f-fae4-4a38-9f43-62a40a2e99d1 5df8625f-fae4-4a38-9f43-62a40a2e99d1-display westus2  user workbook
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
Get-AzApplicationInsightsMyWorkbook -ResourceGroupName appinsights-hkrs2v-test -Category 'workbook'
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
```

{{ Add description here }}

## PARAMETERS

### -CanFetchContent
Flag indicating whether or not to return the full content for each applicable workbook.
If false, only return summary content for workbooks.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List, List1
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

### -LinkedSourceId
Azure Resource Id that will fetch all linked workbooks.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Application Insights component resource.

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook

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

