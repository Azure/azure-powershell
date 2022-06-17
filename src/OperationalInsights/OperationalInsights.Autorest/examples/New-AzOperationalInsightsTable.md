### Example 1: Create a new custom table 
```powershell
PS C:\>  $col1 = New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'
PS C:\>  $col2 = New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'
PS C:\>  $schemaColumns = ($col1, $col2)

PS C:\>  New-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name {TableName_CL} -RetentionInDay 33 -TotalRetentionInDay 55 -SchemaName {TableName_CL} -SchemaColumn $schemaColumns

Name             ResourceGroupName
----             -----------------
dabenhamKuku1_CL

```

Create a new custom table with all needed dependencies.