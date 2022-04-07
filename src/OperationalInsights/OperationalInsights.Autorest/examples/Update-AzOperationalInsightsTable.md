### Example 1: Update table's retention 
```powershell
Update-AzOperationalInsightsTable -ResourceGroupName RG-name -WorkspaceName WS-name -Name TableName_CL -RetentionInDay 40
```
```output
Name             ResourceGroupName
----             -----------------
dabenhamKuku1_CL
```

Update of custom table retention

### Example 2: Update a default table will not work at first try 
```powershell
Update-AzOperationalInsightsTable -ResourceGroupName RG-name -WorkspaceName WS-name -Name Heartbeat -RetentionInDay 40

Update-AzOperationalInsightsTable_UpdateExpanded: 'Patch' cannot be used for table creation - Heartbeat. Use 'Put' instead.

$tempTable = New-AzOperationalInsightsTable -ResourceGroupName RG-name -WorkspaceName WS-name -Name Heartbeat -RetentionInDay 50 
$tempTable
```
```output
Name      ResourceGroupName
----      -----------------
Heartbeat
```
```powershell
$tempTable.RetentionInDay
```
```output
50
```
```powershell
$tempTable = Update-AzOperationalInsightsTable -ResourceGroupName RG-name -WorkspaceName WS-name -Name Heartbeat -RetentionInDay 30
$tempTable
```
```output
Name      ResourceGroupName
----      -----------------
Heartbeat
```
```powershell
$tempTable.RetentionInDay
```
```output
30
```

To update a default table for the first time, please use New-AzOperationalInsightsTable as you would use Update-AzOperationalInsightsTable. 
After the using New-AzOperationalInsightsTable for the first time, you can use Update-AzOperationalInsightsTable normally
