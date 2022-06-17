### Example 1: Update table's retention 
```powershell
PS C:\> Update-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name {TableName_CL} -RetentionInDay 40

Name             ResourceGroupName
----             -----------------
dabenhamKuku1_CL
```

Update of custom table retention

### Example 2: Update a default table will not work at first try 
```powershell
PS C:\> Update-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name Heartbeat -RetentionInDay 40

Update-AzOperationalInsightsTable_UpdateExpanded: 'Patch' cannot be used for table creation - Heartbeat. Use 'Put' instead.

PS C:\>$tempTable = New-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name Heartbeat -RetentionInDay 50 
PS C:\>$tempTable
Name      ResourceGroupName
----      -----------------
Heartbeat

$tempTable.RetentionInDay
50

PS C:\>$tempTable = Update-AzOperationalInsightsTable -ResourceGroupName {RG-name} -WorkspaceName {WS-name} -Name Heartbeat -RetentionInDay 30
PS C:\>$tempTable
Name      ResourceGroupName
----      -----------------
Heartbeat

$tempTable.RetentionInDay
30
```

To update a default table for the first time, please use New-AzOperationalInsightsTable as you would use Update-AzOperationalInsightsTable. 
After the using New-AzOperationalInsightsTable for the first time, you can use Update-AzOperationalInsightsTable normally
