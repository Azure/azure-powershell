### Example 1: Remove a table
```powershell
PS C:\> Remove-AzOperationalInsightsTable -ResourceGroupName {RG-name} -Name {Table-name} -WorkspaceName {WS-name}

--no output--
```
Remove a table by name.


### Example 2: Remove a default 'Heartbeat' table - fail
```powershell
PS C:\> Remove-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -Name Heartbeat -WorkspaceName dabenham-PSH2
Remove-AzOperationalInsightsTable_Delete: No actual change was detected, for table - Heartbeat, both schema and metadata information modifications seems to be missing.

Deletion of default tables is not possible
After performing an update to a default table using 'New-AzOperationalInsightsTable' or 'Update-AzOperationalInsightsTable' cmdlets, performing delete will revert the default table to it's original values'

PS C:\> $tempTable = Update-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-PSH2 -Name Heartbeat -RetentionInDay 55
PS C:\> $tempTable.RetentionInDay
55

PS C:\> Remove-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-PSH2 -Name Heartbeat
PS C:\> $tempTable = Get-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-PSH2 -Name Heartbeat
PS C:\> $tempTable.RetentionInDay
30
```

Using Remove-AzOperationalInsightsTable cmdlet to delete a default table is used to restore table to default state. if default state was not changed - the cmdlet will fail.