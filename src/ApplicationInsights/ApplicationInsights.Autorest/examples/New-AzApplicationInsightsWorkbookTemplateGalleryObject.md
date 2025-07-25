### Example 1: Create an in-memory object for WorkbookTemplateGallery
```powershell
New-AzApplicationInsightsWorkbookTemplateGalleryObject -Category "Failures" -Name "Simple Template" -Type 'tsg' -ResourceType "microsoft.insights/components" -Order 100
```

```output
Name            Category
----            --------
Simple Template Failures
```

Create an in-memory object for WorkbookTemplateGallery.