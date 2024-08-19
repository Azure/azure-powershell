---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/get-azapplicationinsightsworkbooktemplate
schema: 2.0.0
---

# Get-AzApplicationInsightsWorkbookTemplate

## SYNOPSIS
Get a single workbook template by its resourceName.

## SYNTAX

### Get (Default)
```
Get-AzApplicationInsightsWorkbookTemplate -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzApplicationInsightsWorkbookTemplate -InputObject <IApplicationInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a single workbook template by its resourceName.

## EXAMPLES

### Example 1: Get a single workbook template by its resourceName
```powershell
Get-AzApplicationInsightsWorkbookTemplate -ResourceGroupName resourceGroup -Name workbooktemplate-pwsh01
```

```output
ResourceGroupName       Name                    Location
-----------------       ----                    --------
appinsights-hkrs2v-test workbooktemplate-pwsh01 westu
```

This command gets a single workbook template by its resourceName.

### Example 2: Get a single workbook template by pipeline
```powershell
$gallery = New-AzApplicationInsightsWorkbookTemplateGalleryObject -Category "Failures" -Name "Simple Template" -Type 'tsg' -ResourceType "microsoft.insights/components" -Order 100

$data = @{
  "version"= "Notebook/1.0";
  "items"= @(
    @{
      "type"= 1;
      "content"= @{
        "json"= "## New workbook\n---\n\nWelcome to your new workbook.  This area will display text formatted as markdown.\n\n\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections."
      };
      "name"= "text - 2"
    },
    @{
      "type"= 3;
      "content"= @{
        "version"= "KqlItem/1.0";
        "query"= "union withsource=TableName *\n| summarize Count=count() by TableName\n| render barchart";
        "size"= 1;
        "exportToExcelOptions"= "visible";
        "queryType"= 0;
        "resourceType"= "microsoft.operationalinsights/workspaces"
      };
      "name"= "query - 2"
    }
  );
  "styleSettings"= @{};
  "$schema"= "https://github.com/Microsoft/Application-Insights-Workbooks/blob/master/schema/workbook.json"
}

New-AzApplicationInsightsWorkbookTemplate -ResourceGroupName resourceGroup -Name 'workbooktemplate-pwsh01' -Location 'westus2' -Gallery $gallery -TemplateData $data -Priority 1 | Get-AzApplicationInsightsWorkbookTemplate
```

```output
ResourceGroupName       Name                    Location
-----------------       ----                    --------
appinsights-hkrs2v-test workbooktemplate-pwsh01 westus2
```

This command gets a single workbook template by pipeline.

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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20201120.IWorkbookTemplate

## NOTES

## RELATED LINKS
