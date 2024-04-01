### Example 1: List all workbook revisions
```powershell
Get-AzApplicationInsightsWorkbookRevision -ResourceGroupName appinsights-hkrs2v-test -Name f7d7151e-7907-4f46-8a5e-6bf4a4cfedec | fl
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

This command lists all workbook revisions.

### Example 2: Get a single workbook revision defined by its revisionId
```powershell
Get-AzApplicationInsightsWorkbookRevision -ResourceGroupName appinsights-hkrs2v-test -Name f7d7151e-7907-4f46-8a5e-6bf4a4cfedec -RevisionId "91788fbfb8384ea5998ac73b9fa3e6eb"
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

This command gets a single workbook revision defined by its revisionId.

### Example 3: Get a single workbook revision defined by resource id
```powershell
Get-AzApplicationInsightsWorkbookRevision -InputObject "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/workbooks/f7d7151e-7907-4f46-8a5e-6bf4a4cfedec/revisions/91788fbfb8384ea5998ac73b9fa3e6eb"
```

```output
ResourceGroupName       Name                                 DisplayName                                  Location Kind   Category
-----------------       ----                                 -----------                                  -------- ----   --------
appinsights-hkrs2v-test f7d7151e-7907-4f46-8a5e-6bf4a4cfedec f7d7151e-7907-4f46-8a5e-6bf4a4cfedec-display westus2  shared workbook
```

This command gets a single workbook revision defined by resource id.
