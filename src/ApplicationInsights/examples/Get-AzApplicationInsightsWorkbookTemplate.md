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