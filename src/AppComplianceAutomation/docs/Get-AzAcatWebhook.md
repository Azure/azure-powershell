---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/get-azacatwebhook
schema: 2.0.0
---

# Get-AzAcatWebhook

## SYNOPSIS
Get the AppComplianceAutomation webhook and its properties.

## SYNTAX

### List (Default)
```
Get-AzAcatWebhook -ReportName <String> [-Select <String>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAcatWebhook -Name <String> -ReportName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the AppComplianceAutomation webhook and its properties.

## EXAMPLES

### Example 1: List webhooks under a report.
```powershell
Get-AzAcatWebhook -ReportName "test-report"
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook2 7/19/2023 6:32:51 AM                     User                    7/19/2023 6:32:51 AM
test-webhook  3/1/2023 5:17:12 AM                      User                    7/18/2023 6:23:55 PM     FunctionApp
```

List webhooks under a report.

### Example 2: List top 2 webhooks under a report.
```powershell
Get-AzAcatReport -SkipToken 0 -Top 2
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook2 7/19/2023 6:32:51 AM                     User                    7/19/2023 6:32:51 AM
test-webhook  3/1/2023 5:17:12 AM                      User                    7/18/2023 6:23:55 PM     FunctionApp
```

List top 2 webhooks under a report.

### Example 3: Get webhook under a report by webhook name.
```powershell
Get-AzAcatWebhook -ReportName "test-report" -Name "test-webhook"
```

```output
Name         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastMod
                                                                                                      ifiedBy
----         ------------------- ------------------- ----------------------- ------------------------ -----------------
test-webhook 3/1/2023 5:17:12 AM                     User                    7/18/2023 6:23:55 PM     FunctionApp
```

Get webhook under a report by webhook name.

### Example 4: Select specific property of webhooks.
```powershell
Get-AzAcatWebhook -ReportName "test-report" -Select "name"
```

```output
Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastMo
                                                                                                       difiedBy
----          ------------------- ------------------- ----------------------- ------------------------ ----------------
test-webhook2
test-webhook
```

Select specific property of webhooks.

## PARAMETERS

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

### -Name
Webhook Name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WebhookName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReportName
Report Name.

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

### -Select
OData Select statement.
Limits the properties on each entry to just those requested, e.g.
?$select=reportName,id.

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

### -SkipToken
Skip over when retrieving results.

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

### -Top
Number of elements to return when retrieving results.

```yaml
Type: System.Int32
Parameter Sets: List
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource

## NOTES

ALIASES

## RELATED LINKS

