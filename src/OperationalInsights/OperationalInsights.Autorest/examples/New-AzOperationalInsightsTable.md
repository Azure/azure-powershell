### Example 1: Create a new custom table 
```powershell
$col1 = New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'
$col2 = New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'
$schemaColumns = ($col1, $col2)

New-AzOperationalInsightsTable -ResourceGroupName RG-name -WorkspaceName WS-name -Name TableName_CL -RetentionInDay 33 -TotalRetentionInDay 55 -SchemaName TableName_CL -SchemaColumn $schemaColumns
```
```output
Name             ResourceGroupName
----             -----------------
dabenhamKuku1_CL

```

Create a new custom table with all needed dependencies.